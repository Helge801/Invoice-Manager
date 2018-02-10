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
using Windows.UI;
using Custom_Air_Files.Models;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Custom_Air_Files.UserControls
{
    public sealed partial class AddAddressUserControl : UserControl
    {
        public delegate void UserControlClose(string ControlName, bool Succeeded, object NewItem);
        public static event UserControlClose CallUserControlClose;


        public static Customer ActiveCustomer { get; set; }
        Brush OldBorderbrush;
        Brush RedBrush = new SolidColorBrush(Colors.Red);

        public AddAddressUserControl()
        {
            this.InitializeComponent();
            Pages.SubPages.SingleCustomerPage.CallClearUserControls += ClearAllFields;
            OldBorderbrush = NameTextBox.BorderBrush;
        }

        private void AddCircleButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputsAreGood())
            {
                int zipCode;
                int.TryParse(ZipTextBox.Text, out zipCode);
                FinishAddAsynce(Line1TextBox.Text, Line2TextBox.Text, CityTextBox.Text, StateTextBox.Text, zipCode, NameTextBox.Text, NotesTextBox.Text);
                ClearAllFields();
            }
        }

        private void CancelCircleButton_Click(object sender, RoutedEventArgs e)
        {
            ClearAllFields();
            CallUserControlClose("AddAddressUserControl", false, new Address());
        }

        private bool InputsAreGood()
        {
            bool pass = true;

            if (NameTextBox.Text.Length < 2)
            {
                pass = false;
                NameTextBox.BorderBrush = RedBrush;
            }

            if (Line1TextBox.Text.Length < 5)
            {
                pass = false;
                Line1TextBox.BorderBrush = RedBrush;
            }

            if (CityTextBox.Text.Length < 3)
            {
                pass = false;
                CityTextBox.BorderBrush = RedBrush;
            }

            if (StateTextBox.Text.Length < 2)
            {
                pass = false;
                StateTextBox.BorderBrush = RedBrush;
            }

            if (ZipTextBox.Text.Length < 5)
            {
                pass = false;
                ZipTextBox.BorderBrush = RedBrush;
            }

            return pass;
        }

        private void ClearAllFields()
        {
            NameTextBox.Text = "";
            Line1TextBox.Text = "";
            Line2TextBox.Text = "";
            CityTextBox.Text = "";
            StateTextBox.Text = "";
            ZipTextBox.Text = "";
            NotesTextBox.Text = "";

            NameTextBox.BorderBrush = OldBorderbrush;
            Line1TextBox.BorderBrush = OldBorderbrush;
            Line2TextBox.BorderBrush = OldBorderbrush;
            CityTextBox.BorderBrush = OldBorderbrush;
            StateTextBox.BorderBrush = OldBorderbrush;
            ZipTextBox.BorderBrush = OldBorderbrush;
            NotesTextBox.BorderBrush = OldBorderbrush;
        }
        private async void FinishAddAsynce(string line1, string line2, string city, string state, int zip, string name, string notes)
        {
            bool billing;
            var dialoge = new Windows.UI.Popups.MessageDialog($"Will this be {ActiveCustomer.FirstName} {ActiveCustomer.LastName}'s primary billing address?");
            dialoge.Title = "Billing Address";
            dialoge.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 0 });
            dialoge.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 1 });
            dialoge.Commands.Add(new Windows.UI.Popups.UICommand("Not Sure") { Id = 2 });
            dialoge.DefaultCommandIndex = 1;
            dialoge.CancelCommandIndex = 1;
            var response = await dialoge.ShowAsync();
            if ((int)response.Id == 0)
                billing = true;
            else
                billing = false;
            Address CreatedAddress = new Address() { Line1 = line1, Line2 = line2, City = city, State = state, Zip = zip, Name = name, Notes = notes, Image = "", IsBilling = billing, CustomerId = ActiveCustomer.Id };

            MainPage.db.Insert(CreatedAddress);
            Address NewAddress = MainPage.db.Table<Address>().Where(a => a.CustomerId == ActiveCustomer.Id).Where(b => b.Line1 == line1).First();
            CallUserControlClose("AddAddressUserControl", true, NewAddress);

        }

        private void ZipTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (!Regex.IsMatch(sender.Text, "^\\d*\\d*$") && sender.Text != "")
            {
                int pos = sender.SelectionStart - 1;
                sender.Text = sender.Text.Remove(pos, 1);
                sender.SelectionStart = pos;
            }

        }
        private void NameTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (NameTextBox.Text.Length > 1)
                NameTextBox.BorderBrush = OldBorderbrush;
        }
        private void CityTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (CityTextBox.Text.Length > 1)
                CityTextBox.BorderBrush = OldBorderbrush;
        }
        private void ZipTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (ZipTextBox.Text.Length > 1)
                ZipTextBox.BorderBrush = OldBorderbrush;
        }
        private void Line1TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (Line1TextBox.Text.Length > 1)
                Line1TextBox.BorderBrush = OldBorderbrush;
        }
        private void StateTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (Line1TextBox.Text.Length > 1)
                Line1TextBox.BorderBrush = OldBorderbrush;
        }

        private void ZipTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                AddCircleButton_Click(this, null);
            }
        }

        private void NotesTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                AddCircleButton_Click(this, null);
            }
        }
    }
}
