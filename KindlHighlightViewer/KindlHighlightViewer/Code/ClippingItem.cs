using System;

namespace KindlHighlightViewer.Code
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
        public string Title { get; set; }

        /// <summary>
        /// Book author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Highlighted text.
        /// </summary>
        public string HighlightedText { get; set; }
    }
}
