using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Threading;
using Windows.UI;
using System.Text.RegularExpressions;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Custom_Air_Files.UserControls
{
    public sealed partial class AddPhoneNumberUserControl : UserControl
    {
        ObservableCollection<string> TypeList = new ObservableCollection<string>();
        public delegate void AddPhoneUserControlCancel(object source, EventArgs e);
        public static event AddPhoneUserControlCancel CallCancel;
        public delegate void AddPhoneUserControlAdd(PhoneNumber p);
        public static event AddPhoneUserControlAdd CallAdd;

        public AddPhoneNumberUserControl()
        {
            this.InitializeComponent();
            Pages.SubPages.SingleCustomerPage.CallAddPhoneClose += SingleCustomerPage_CallAddPhoneClose;
            AddTypesToList();
        }

        private void SingleCustomerPage_CallAddPhoneClose(object source, EventArgs e)
        {
            CancelCircleButton_Click(this, null);
        }

        private void AddTypesToList()
        {
            TypeList.Add("Mobile");
            TypeList.Add("Home");
            TypeList.Add("Office");
            TypeList.Add("Work");
            TypeList.Add("Fax");
            TypeList.Add("Other...");
        }

        private void AreaCodeTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (AreaCodeTextBox.Text.Length == 3)
            {
                FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                AreaCodeTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
        }

        private void FirstNumberTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (FirstNumberTextBox.Text.Length == 3)
            {
                FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                FirstNumberTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
        }

        private void NumberTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NumberTypeComboBox.SelectedIndex == 5)
            {
                OtherTypeTextBox.Text = "";
                OtherTypeTextBox.Visibility = Visibility.Visible;
                OtherTypeTextBox.Focus(FocusState.Programmatic);

            }
            else
            {
                OtherTypeTextBox.Text = (string)NumberTypeComboBox.SelectedItem;
                OtherTypeTextBox.Visibility = Visibility.Collapsed;
            }
        }

        private void AddCircleButton_Click(object sender, RoutedEventArgs e)
        {
            //DataChecks
            bool flagged = false;

            if(AreaCodeTextBox.Text.Length < 3)
            {
                AreaCodeTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                flagged = true;
            }

            if(FirstNumberTextBox.Text.Length < 3)
            {
                FirstNumberTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                flagged = true;
            }

            if(SecondNumberTextBox.Text.Length < 4)
            {
                SecondNumberTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                flagged = true;
            }

            if(NumberTypeComboBox.SelectedItem == null)
            {
                NumberTypeComboBox.BorderBrush = new SolidColorBrush(Colors.Red);
                flagged = true;
            }
            else
            {
                if (NumberTypeComboBox.SelectedIndex == 5)
                {
                    if (OtherTypeTextBox.Text.Length < 1)
                    {
                        OtherTypeTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                        flagged = true;
                    }
                }
            }


            //create new number

            if (!flagged)
            { 
                int areacode = Convert.ToInt32(AreaCodeTextBox.Text);
                int number = Convert.ToInt32(FirstNumberTextBox.Text + SecondNumberTextBox.Text);
                int ext;
                string type;
                string notes = NotesTextBox.Text;
                int custId = Pages.SubPages.SingleCustomerPage.CustomerNumber;
                bool hasExt = false;
                PhoneNumber p;

                if (!string.IsNullOrEmpty(ExtintionTextBox.Text))
                {
                    ext = Convert.ToInt32(ExtintionTextBox.Text);
                    hasExt = true;
                }
                else ext = 0;

                if (NumberTypeComboBox.SelectedIndex == 5)
                {
                    type = OtherTypeTextBox.Text;
                }
                else
                {
                    type = NumberTypeComboBox.SelectedItem.ToString();
                }

                if (hasExt)
                {
                    p = new PhoneNumber {Extention = ext, AreaCode = areacode, CustomerId = custId, Name = type, Number = number, Notes = notes };
                }
                else
                {
                    p = new PhoneNumber { AreaCode = areacode, CustomerId = custId, Name = type, Number = number, Notes = notes };
                }

                MainPage.db.Insert(p);
                CallAdd(p);
                CancelCircleButton_Click(this, null);

            }

        }

        private void CancelCircleButton_Click(object sender, RoutedEventArgs e)
        {
            AreaCodeTextBox.Text = "";
            AreaCodeTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            FirstNumberTextBox.Text = "";
            FirstNumberTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            SecondNumberTextBox.Text = "";
            SecondNumberTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            ExtintionTextBox.Text = "";
            NumberTypeComboBox.SelectedIndex = 0; //TODO: Throwing error on first number add
            NumberTypeComboBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            OtherTypeTextBox.Text = "";
            OtherTypeTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            OtherTypeTextBox.Visibility = Visibility.Collapsed;
            NotesTextBox.Text = "";
            CallCancel(this, null);
        }

        private void SecondNumberTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (SecondNumberTextBox.Text.Length == 4)
            {
                SecondNumberTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
        }

        private void OtherTypeTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(OtherTypeTextBox.Text))
                OtherTypeTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            NumberTypeComboBox.SelectedIndex = 0;
        }

        private void AreaCodeTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (!Regex.IsMatch(sender.Text, "^\\d*\\d*$" ) && sender.Text != "")
            {
                int pos = sender.SelectionStart - 1;
                sender.Text = sender.Text.Remove(pos, 1);
                sender.SelectionStart = pos;
            }
        }

        private void FirstNumberTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (!Regex.IsMatch(sender.Text, "^\\d*\\d*$") && sender.Text != "")
            {
                int pos = sender.SelectionStart - 1;
                sender.Text = sender.Text.Remove(pos, 1);
                sender.SelectionStart = pos;
            }
        }

        private void SecondNumberTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (!Regex.IsMatch(sender.Text, "^\\d*\\d*$") && sender.Text != "")
            {
                int pos = sender.SelectionStart - 1;
                sender.Text = sender.Text.Remove(pos, 1);
                sender.SelectionStart = pos;
            }
        }

        private void ExtintionTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (!Regex.IsMatch(sender.Text, "^\\d*\\d*$") && sender.Text != "")
            {
                int pos = sender.SelectionStart - 1;
                sender.Text = sender.Text.Remove(pos, 1);
                sender.SelectionStart = pos;
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
