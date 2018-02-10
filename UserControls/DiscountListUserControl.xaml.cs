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
    public sealed partial class DiscountListUserControl : UserControl
    {
        Discount Discount { get { return this.DataContext as Discount; } }
        public DiscountListUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Discount.Type == Discount.DiscountType.Percentage)
                AmountTextBlock.Text = String.Format("{0}%", 5.00);
            else
                AmountTextBlock.Text = Discount.Amount.ToString("C", new CultureInfo("en-US"));
        }
    }
}
