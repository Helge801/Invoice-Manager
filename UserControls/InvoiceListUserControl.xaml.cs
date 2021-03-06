﻿using System;
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
    public sealed partial class InvoiceListUserControl : UserControl
    {
        Invoice Invoice { get { return this.DataContext as Invoice; } }

        public InvoiceListUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            InvoiceDateTextBlock.Text = Invoice.StartDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            InvoiceTotalTextBlock.Text = Invoice.Total.ToString("C", new System.Globalization.CultureInfo("en-US"));
        }
    }
}
