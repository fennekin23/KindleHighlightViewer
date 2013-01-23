using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KindleHighlightViewer.Code
{
    public class OrderByAuthor
    {
        private static RoutedUICommand orderByAuthor;
        static OrderByAuthor()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.A, ModifierKeys.Alt, "Alt+A"));
            orderByAuthor = new RoutedUICommand(
              "OrderByAuthorCmd", "OrderByAuthorCmd", typeof(OrderByAuthor), inputs);
        }

        public static RoutedUICommand OrderByAuthorCmd
        {
            get { return orderByAuthor; }
        }
    }

    public class OrderByTitle
    {
        private static RoutedUICommand orderByTitle;
        static OrderByTitle()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.T, ModifierKeys.Alt, "Alt+T"));
            orderByTitle = new RoutedUICommand(
              "OrderByTitleCmd", "OrderByTitleCmd", typeof(OrderByTitle), inputs);
        }

        public static RoutedUICommand OrderByTitleCmd
        {
            get { return orderByTitle; }
        }
    }
}
