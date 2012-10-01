using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using KindlHighlightViewer.Code;
using System.Windows.Input;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using KindleHighlightViewer.Code.DataVirtualization;

namespace KindlHighlightViewer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {

        }

        //IDataLoader dataLoader;

        ClippingItemProvider clippingItemProvider;
        public MainViewModel(IDataLoader loader)
        {
            var tempCollection = loader.Load();
            clippingItemProvider = new ClippingItemProvider(30, tempCollection);
            clippingsList  = new AsyncVirtualizingCollection<ClippingItem>(clippingItemProvider, 30, 1000000);
        }

        AsyncVirtualizingCollection<ClippingItem> clippingsList;
        /// <summary>
        /// View list of clippings.
        /// </summary>
        public AsyncVirtualizingCollection<ClippingItem> ClippingsList
        {
            get { return clippingsList; }
            set { clippingsList = value; }
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

        bool loadingVisible = true;
        /// <summary>
        /// Loading window visibility.
        /// </summary>
        public bool LoadingVisible
        {
            get { return loadingVisible; }
            set { loadingVisible = value; OnPropertyChanged("LoadingVisible"); }
        }

        ///// <summary>
        ///// Loading clippings to ClippingsList.
        ///// </summary>
        //public void LoadClippings()
        //{
        //    LoadingVisible = false;
        //}

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
    }
}
