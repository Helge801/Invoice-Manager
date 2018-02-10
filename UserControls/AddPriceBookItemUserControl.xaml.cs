using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class AddPriceBookItemUserControl : UserControl
    {

        public delegate void AddItemCancelDelegate();
        public static event AddItemCancelDelegate CallAddItemCancel;

        public AddPriceBookItemUserControl()
        {
            this.InitializeComponent();
            Pages.PriceBookPage.CalladdItemFlyoutClose += CancelCircleButton_Click;
        }

        private void DescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CTB.Text = (200 - DescriptionTextBox.Text.Length).ToString();
        }

        private void AmountTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (!Regex.IsMatch(sender.Text, "^\\d*\\.?\\d*$") && sender.Text != "")
            {
                int pos = sender.SelectionStart - 1;
                sender.Text = sender.Text.Remove(pos, 1);
                sender.SelectionStart = pos;
            }
        }

        private void AddCircleButton_Click(object sender, RoutedEventArgs e)
        {
            //Perform Checks
            bool Flagged = false;

            if (!(NameTextBox.Text.Length > 1))
            {
                NameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                Flagged = true;
            }

            if (!(DescriptionTextBox.Text.Length > 3))
            {
                DescriptionTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                Flagged = true;
            }

            if (!(AmountTextBox.Text.Length > 0))
            {
                AmountTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                Flagged = true;
            }

            if (!Flagged)
            {
                PriceBookItem Item = new PriceBookItem() { Amount = Convert.ToDouble(AmountTextBox.Text), Name = NameTextBox.Text, Description = DescriptionTextBox.Text, Image = "None" };
                AddAsyncPortion(Item);
                //TODO: (waiting) add delegate for adding new pricebook Item to list once Pricebook page is complete
            }


        }

        private async void AddAsyncPortion(PriceBookItem Item)
        {
            var dialog = new Windows.UI.Popups.MessageDialog("Will this be a regularly used item?", "Item Type");
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 1 });
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;
            var result = await dialog.ShowAsync();

            if ((int)result.Id == 0)
                Item.Regular = true;
            else
                Item.Regular = false;

            await MainPage.dbAsync.InsertAsync(Item);
        }

        private void CancelCircleButton_Click(object sender, RoutedEventArgs e)
        {
            NameTextBox.Text = "";
            NameTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            DescriptionTextBox.Text = "";
            DescriptionTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            AmountTextBox.Text = "";
            AmountTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            CallAddItemCancel();
        }

        private void NameTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (NameTextBox.Text.Length > 1)
                NameTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
        }

        private void DescriptionTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (DescriptionTextBox.Text.Length > 2)
                DescriptionTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
        }

        private void AmountTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (AmountTextBox.Text.Length > 0)
                AmountTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
        }

        private void AmountTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                AmountTextBox.IsEnabled = false;
                AmountTextBox.IsEnabled = true;
                AddCircleButton_Click(this, null);
            }
        }
    }
}
