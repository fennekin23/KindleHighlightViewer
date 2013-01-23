using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace KindleHighlightViewer.Code
{
    /// <summary>
    /// Convert "My Clippings.txt" to "My Clippings.txt.xml".
    /// </summary>
    public class TxtToXmlConverter : IDataConverter
    {
        /// <summary>
        /// Loading clippings from My Clippings.txt file on kindle.
        /// </summary>
        /// <param name="path">Path to "My Clippings.txt".</param>
        /// <returns></returns>
        public IEnumerable<ClippingItem> Convert(string path)
        {
            if (String.IsNullOrEmpty(path)) // if load executing with out parameter
            {
                path = "My Clippings.txt";
            }

            IDataLoader xmlLoader = new XmlDataLoader();
            IEnumerable<ClippingItem> clippingsList = xmlLoader.Load(path);

            using (StreamReader reader = new StreamReader(path))
            {
                MD5Utility HashUtility = new MD5Utility();
                bool isNewFile = HashUtility.IsNewFile(reader.BaseStream); // check md5 hash of last converted and current

                if (isNewFile)
                {
                    Save(path, clippingsList);
                }
            }
            return clippingsList;
        }

        /// <summary>
        /// Save clippings to xml file.
        /// </summary>
        /// <param name="clippingsList">Clippings list.</param>
        /// <param name="path">Path to save.</param>
        private void Save(string path, IEnumerable<ClippingItem> clippingsList)
        {
            try
            {
                path += ".xml";
                XmlSerializer serializer = new XmlSerializer(clippingsList.GetType());
                TextWriter writer = new StreamWriter(path);
                serializer.Serialize(writer, clippingsList);
                writer.Close();
            }
            catch (Exception ex)
            {
                ShowBox.ShowError("Error while saving xml file. \n" + ex.Message);
            }
        }
    }
}
