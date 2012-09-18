using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using KindlHighlightViewer.Code;
using KindlHighlightViewer.ViewModels;
using System.ComponentModel;
using System.Threading.Tasks;

namespace KindlHighlightViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IDataConverter TxtToXml = new TxtToXmlConverter();
            IDataConverter TxtToBin = new TxtToBinaryConverter();

            //TxtToXml.Convert();
            TxtToBin.Convert();

            IDataLoader XmlLoader = new XmlDataLoader();
            IDataLoader BinLoader = new BinaryDataLoader();

            MainViewModel mainViewModel = new MainViewModel(BinLoader);
            MainWindow window = new MainWindow();
            window.DataContext = mainViewModel;
            window.Show();
            mainViewModel.LoadClippings();
        }
    }
}
