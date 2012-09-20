using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace KindlHighlightViewer.Code
{
    public class ShowBox
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
