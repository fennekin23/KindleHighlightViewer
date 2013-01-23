using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KindleHighlightViewer.Code
{
    /// <summary>
    /// Logic for loading data from binary file.
    /// </summary>
    public class BinaryDataLoader : IDataLoader
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
                path = "My Clippings.txt.bin";
            }

            try
            {
                FileStream readStream = new FileStream(path, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                IEnumerable<ClippingItem> clippingsList = (IEnumerable<ClippingItem>)formatter.Deserialize(readStream);
                readStream.Close();
                return clippingsList;
            }
            catch (Exception ex)
            {
                ShowBox.ShowError("Error while loading bin file. \n" + ex.Message);
            }

            return new List<ClippingItem>();
        }
    }
}
