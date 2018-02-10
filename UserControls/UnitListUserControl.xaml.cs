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
//TODO (Low) make it so that if we are making an invoice fopr an address that has already been invoiced before, the existing units are added
//TODO (Low) Make it so that units can be flagged a replaced so that they don't keep showing up on invoices in the future. for this we will need some sort of Flagged field in the Unit or the Ass class in order to mark this.
namespace Custom_Air_Files.UserControls
{
    public sealed partial class UnitListUserControl : UserControl
    {
        Unit Unit { get { return this.DataContext as Unit; } }

        public UnitListUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }
    }
}
