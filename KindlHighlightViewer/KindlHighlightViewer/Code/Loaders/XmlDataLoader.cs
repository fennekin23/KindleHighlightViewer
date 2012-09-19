using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace KindlHighlightViewer.Code
{
    /// <summary>
    /// Logic for loading data from xml file.
    /// </summary>
    public class XmlDataLoader : IDataLoader
    {
        /// <summary>
        /// Loading clippings from My Clippings.txt.xml file on file system.
        /// </summary>
        /// <param name="path">Path to "My Clippings.txt.xml".</param>
        /// <returns></returns>
        public IEnumerable<ClippingItem> Load(string path)
        {
            if (String.IsNullOrEmpty(path)) // if load executing with out parameter
            {
                path = "My Clippings.txt.xml";
            }

            try
            {
                XDocument openDocument = XDocument.Load(path);
                IEnumerable<ClippingItem> clippingsList = (from item in openDocument.Descendants("ClippingItem")
                                                           select
                                                               new ClippingItem
                                                               {
                                                                   Title = item.Element("Title").Value,
                                                                   Author = item.Element("Author").Value,
                                                                   HighlightedText = item.Element("HighlightedText").Value
                                                               }).ToArray();
                return clippingsList;
            }
            catch (Exception ex)
            {
                ShowBox.ShowError("Error while loading xml file. \n" + ex.Message);
            }

            return new List<ClippingItem>();
        }
    }
}
