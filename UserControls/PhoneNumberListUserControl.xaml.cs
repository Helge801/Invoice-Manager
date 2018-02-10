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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Custom_Air_Files.UserControls
{
    public sealed partial class PhoneNumberListUserControl : UserControl
    {
        PhoneNumber PhoneNumber { get { return this.DataContext as PhoneNumber; } }

        public PhoneNumberListUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AreaCodeTextBlock.Text = $"({AreaCodeTextBlock.Text})";
            NumberTextBlock.Text = $"{PhoneNumber.Number.ToString().Substring(0, 3)}-{PhoneNumber.Number.ToString().Substring(3, 4)}";
            if (PhoneNumber.Extention.ToString() == "0")
                ExtentionTextBlock.Text = "";
            else
                ExtentionTextBlock.Text = $"EXT. {PhoneNumber.Extention.ToString()}";

            if (string.IsNullOrEmpty(PhoneNumber.Notes))
                NotesTextBlock.Visibility = Visibility.Collapsed;
        }
    }
}
