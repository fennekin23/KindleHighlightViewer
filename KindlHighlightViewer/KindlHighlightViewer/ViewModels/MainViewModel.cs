using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using KindlHighlightViewer.Code;

namespace KindlHighlightViewer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {

        }

        public MainViewModel(List<ClippingItem> clippings)
        {
            foreach (ClippingItem item in clippings)
            {
                ClippingsList.Add(item);
            }
        }

        ObservableCollection<ClippingItem> clippingsList = new ObservableCollection<ClippingItem>();
        /// <summary>
        /// View list of clippings.
        /// </summary>
        public ObservableCollection<ClippingItem> ClippingsList
        {
            get { return clippingsList; }
            set { clippingsList = value; OnPropertyChanged("ClippingsList"); }
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
    }
}
