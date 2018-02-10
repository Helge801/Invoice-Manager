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
    public sealed partial class InvoiceDiscountListUserControl : UserControl
    {
        InvoiceDiscount InvoiceDiscount { get { return this.DataContext as InvoiceDiscount;  } }
        public InvoiceDiscountListUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (InvoiceDiscount.Type == Discount.DiscountType.Percentage)
            {
                AmountTextBlock.Text = String.Format("{0}%", InvoiceDiscount.Amount);
            }
            else
            {
                AmountTextBlock.Text = InvoiceDiscount.Amount.ToString("C", new CultureInfo("en-US"));
            }
        }
    }
}
