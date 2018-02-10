using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Custom_Air_Files.FunctionClasses
{
    class PopupHelper
    {
        public async static void QuickPopup(string message)
        {
            await new MessageDialog(message).ShowAsync();
        }
        public async static void QuickPopup(string message, string title)
        {
            var dialoge = new MessageDialog(message, title);
            await dialoge.ShowAsync();
        }
    }
}
