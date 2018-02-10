using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Globalization;
using Custom_Air_Files.Models;
using Custom_Air_Files.Models.SubModels;
using SQLite;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Custom_Air_Files.UserControls
{
    public sealed partial class MaintenanceListUserControl : UserControl
    {
        Maintenance Maintenance { get { return this.DataContext as Maintenance; } }
        Address FirstAddress;
        SQLiteConnection db = MainPage.db;

        public MaintenanceListUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
            
            
        }

        private Address GetFirstAddress()
        {
            AssAddressMaintenance asstab = db.Table<AssAddressMaintenance>().Where(a => a.MaintenanceId == Maintenance.Id).ToList().First();
            Address add = db.Table<Address>().Where(a => a.Id == asstab.AddressId).ToList().First();
            return add;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FirstAddress = GetFirstAddress();
            FirstAddressNameTextBlock.Text = FirstAddress.Name;
            FistAddressLine1TextBlock.Text = FirstAddress.Line1;
            
        }
    }
}
