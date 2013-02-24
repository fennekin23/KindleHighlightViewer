using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using KindleHighlightViewer.Code;
using System.Windows.Input;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using KindleHighlightViewer.Code.DataVirtualization;
using System.Collections;

namespace KindleHighlightViewer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(IDataLoader loader)
        {
            loader.Load().ToList().ForEach(item => clippingsList.Add(item));
        }

        List<ClippingItem> clippingsList = new List<ClippingItem>();
        /// <summary>
        /// View list of clippings.
        /// </summary>
        public List<ClippingItem> ClippingsList
        {
            get { return clippingsList; }
            set { clippingsList = value; OnPropertyChanged("ClippingsList"); }
        }

        ClippingItem selectedItem = new ClippingItem();
        /// <summary>
        /// Selected clipping.
        /// </summary>
        public ClippingItem SelectedItem
        {
            get { return selectedItem; }
            set { this.selectedItem = value; OnPropertyChanged("SelectedItem"); }
        }

        bool loadingVisible = false;
        /// <summary>
        /// Loading window visibility.
        /// </summary>
        public bool LoadingVisible
        {
            get { return loadingVisible; }
            set { loadingVisible = value; OnPropertyChanged("LoadingVisible"); }
        }

        /* INotifyPropertyChanged members*/
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* Copy command */
        public void CopyCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(SelectedItem.Title) && !String.IsNullOrEmpty(SelectedItem.Author) && !String.IsNullOrEmpty(SelectedItem.HighlightedText))
            {
                string copyMessage = String.Format("{0} ({1}) \"{2}\"", SelectedItem.Title, SelectedItem.Author, SelectedItem.HighlightedText);
                Clipboard.SetText(copyMessage);
            }
        }

        /* Order command */
        public void OrderCommand(Func<ClippingItem, string> func)
        {
            ClippingsList = ClippingsList.OrderBy(func).ToList();
        }
    }
}