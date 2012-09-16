using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using KindlHighlightViewer.Code;
using KindlHighlightViewer.ViewModels;

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
            TxtToXml.Convert();

            IDataLoader XmlLoader = new XmlDataLoader();
            MainViewModel mainViewModel = new MainViewModel(XmlLoader);
            
            MainWindow window = new MainWindow();
            window.DataContext = mainViewModel;
            window.Show();
        }
    }
}
