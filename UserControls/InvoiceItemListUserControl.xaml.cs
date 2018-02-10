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
using System.Text.RegularExpressions;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Custom_Air_Files.UserControls
{
    public sealed partial class InvoiceItemListUserControl : UserControl
    {
        public InvoiceItem InvoiceItem { get { return this.DataContext as InvoiceItem; } }
        //private string OriginalAmount;

        public delegate void ItemDataChanged();
        public static event ItemDataChanged CallItemDataChanged;
        //TODO: (High) This is not done. must add function for updating everything upon change of any information and updating of dependant lists and totals

        private double OriginalAmount;

        public InvoiceItemListUserControl()
        {

            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            double amount = InvoiceItem.Amount;
            AmountTextBox.Text = amount.ToString("N2");
            AmountTextBox.TextChanging += AmountTextBox_TextChanging;
        }

        private void AmountTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            //"^\\d*\\.?\\d*$"
            if (!Regex.IsMatch(sender.Text, "^\\d*\\.?\\d*$") && sender.Text != "")
            {
                int pos = sender.SelectionStart - 1;
                sender.Text = sender.Text.Remove(pos, 1);
                sender.SelectionStart = pos;
            }
        }

        private void AmountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            double NewAmount;
            if (double.TryParse(AmountTextBox.Text, out NewAmount) && NewAmount != OriginalAmount)
            {
                AmountTextBox.TextChanging -= AmountTextBox_TextChanging;
                AmountTextBox.Text = NewAmount.ToString("N2");
                AmountTextBox.TextChanging += AmountTextBox_TextChanging;
                InvoiceItem NewItem = this.DataContext as InvoiceItem;
                NewItem.Amount = NewAmount;
                MainPage.db.Update(NewItem);
                CallItemDataChanged();
                //TODO: Handle update
            }
            else
            {
                AmountTextBox.TextChanging -= AmountTextBox_TextChanging;
                AmountTextBox.Text = OriginalAmount.ToString("N2");
                AmountTextBox.TextChanging += AmountTextBox_TextChanging;
            }


        }

        private void AmountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(AmountTextBox.Text, out this.OriginalAmount))
                Custom_Air_Files.FunctionClasses.PopupHelper.QuickPopup("Error Parsing Amounts. reloading invoice is recomended", "Parse Error");
                
        }
    }
}
