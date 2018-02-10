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
using Custom_Air_Files.Models;
using System.Globalization;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Custom_Air_Files.UserControls
{
    public sealed partial class InvoiceTileUserControl : UserControl
    {
        Invoice Invoice { get { return this.DataContext as Invoice; } }
        //TODO: (low) Possible create Master CustomerList in order to prevent each User Control from accessing Database. Maybe do this with all user Controls that access db

        public InvoiceTileUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s,e) => Bindings.Update();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Customer customer = MainPage.db.Table<Customer>().Where(c => c.Id == Invoice.CustomerId).First();
            CustomerNameTextBlock.Text = $"{customer.FirstName} {customer.LastName}";
            InvoiceDateTextBlock.Text = Invoice.StartDate.ToString("MM/dd/yyy", CultureInfo.InvariantCulture);
        }
    }
}
