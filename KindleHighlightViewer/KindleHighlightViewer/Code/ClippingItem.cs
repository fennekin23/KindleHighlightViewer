using System;

namespace KindleHighlightViewer.Code
{
    /// <summary>
    /// Data structure for presentation clipping item.
    /// </summary>
    [Serializable]
    public class ClippingItem
    {
        /// <summary>
        /// Book title.
        /// </summary>
        string title = "Untitled";
        public string Title { get { return String.IsNullOrEmpty(title) ? "Untitled" : title; } set { title = value; } }

        /// <summary>
        /// Book author.
        /// </summary>
        string author = "Undefined";
        public string Author { get { return String.IsNullOrEmpty(author) ? "Undefined" : author; } set { author = value; } }

        /// <summary>
        /// Highlighted text.
        /// </summary>
        public string HighlightedText { get; set; }
    }
}
