using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KindlHighlightViewer.Code
{
    /// <summary>
    /// Convert "My Clippings.txt" to "My Clippings.txt.bin".
    /// </summary>
    public class TxtToBinaryConverter : IDataConverter
    {
        /// <summary>
        /// Loading clippings from My Clippings.txt file on kindle.
        /// </summary>
        /// <param name="path">Path to "My Clippings.txt".</param>
        /// <returns></returns>
        public IEnumerable<ClippingItem> Convert(string path = "")
        {
            if (String.IsNullOrEmpty(path)) // if load executing with out parameter
            {
                path = "My Clippings.txt";
            }

            IDataLoader txtLoader = new TxtDataLoader();
            IEnumerable<ClippingItem> clippingsList = txtLoader.Load(path);

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
        /// Save clippings to binary file.
        /// </summary>
        /// <param name="clippingsList">Clippings list.</param>
        /// <param name="path">Path to save.</param>
        private void Save(string path, IEnumerable<ClippingItem> clippingsList)
        {
            try
            {
                path += ".bin";
                FileStream writeStream = new FileStream(path, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writeStream, clippingsList);
                writeStream.Close();
            }
            catch (Exception ex)
            {
                ShowBox.ShowError("Error while saving bin file. \n" + ex.Message);
            }
        }
    }
}
