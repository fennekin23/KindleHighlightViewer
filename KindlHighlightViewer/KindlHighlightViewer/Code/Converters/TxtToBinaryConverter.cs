using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
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

            List<ClippingItem> clippingsList = new List<ClippingItem>();
            string pattern = @"(?<title>.+ )\((?<author>.+)\)";
            using (StreamReader reader = new StreamReader(path))
            {
                MD5Utility HashUtility = new MD5Utility();
                bool isNewFile = HashUtility.IsNewFile(reader.BaseStream); // check md5 hash of last converted and current

                if (isNewFile)
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    while (!reader.EndOfStream)
                    {
                        ClippingItem item = new ClippingItem();
                        string tempTandA = reader.ReadLine(); // title (author) string
                        item.Title = Regex.Match(tempTandA, pattern).Groups["title"].ToString();
                        item.Author = Regex.Match(tempTandA, pattern).Groups["author"].ToString();
                        string tempHorB = reader.ReadLine(); // highlight or bookmark
                        reader.ReadLine();
                        item.HighlightedText = reader.ReadLine();
                        reader.ReadLine();
                        if (tempHorB.Contains("Highlight"))
                            clippingsList.Add(item);
                    }
                    reader.Close();
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
            path += ".bin";
            FileStream writeStream = new FileStream(path, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(writeStream, clippingsList);
            writeStream.Close();
        }
    }
}
