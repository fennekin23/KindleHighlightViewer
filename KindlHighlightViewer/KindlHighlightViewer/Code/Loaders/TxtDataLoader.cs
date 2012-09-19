using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace KindlHighlightViewer.Code
{
    /// <summary>
    /// Logic for loading data from txt file.
    /// </summary>
    public class TxtDataLoader : IDataLoader
    {
        /// <summary>
        /// Loading clippings from My Clippings.txt file on kindle.
        /// </summary>
        /// <param name="path">Path to "My Clippings.txt".</param>
        /// <returns></returns>
        public IEnumerable<ClippingItem> Load(string path)
        {
            if (String.IsNullOrEmpty(path)) // if load executing with out parameter
            {
                path = "My Clippings.txt";
            }

            try
            {
                List<ClippingItem> clippingsList = new List<ClippingItem>();
                string pattern = @"(?<title>.+ )\((?<author>.+)\)";
                using (StreamReader reader = new StreamReader(path))
                {
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
                }
                return clippingsList;
            }
            catch (Exception ex)
            {
                ShowBox.ShowError("Error while loading txt file. \n" + ex.Message);
            }

            return new List<ClippingItem>();
        }
    }
}
