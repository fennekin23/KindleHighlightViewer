﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace KindlHighlightViewer.Code
{
    /// <summary>
    /// Logic for loading data from txt file, saving it to xml.
    /// </summary>
    public class DataLoader
    {
        /// <summary>
        /// Loading clippings from My Clippings.txt file on kindle.
        /// </summary>
        /// <param name="path">Path to "My Clippings.txt".</param>
        /// <returns></returns>
        public List<ClippingItem> LoadFromTxt(string path = "My Clippings.txt")
        {
            List<ClippingItem> clippingsList = new List<ClippingItem>();
            string pattern = @"(?<title>.+ )\((?<author>.+)\)";
            StreamReader reader = new StreamReader(path);
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
            return clippingsList;
        }
    }
}