using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KindlHighlightViewer.Code;
using System.Diagnostics;
using System.Threading;

namespace KindleHighlightViewer.Code.DataVirtualization
{
    class ClippingItemProvider : IItemsProvider<ClippingItem>
    {
        private readonly int _count;
        private readonly int _fetchDelay;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClippingItemProvider"/> class.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="fetchDelay"></param>
        public ClippingItemProvider(int count, int fetchDelay)
        {
            _count = count;
            _fetchDelay = fetchDelay;
        }

        /// <summary>
        /// Fetches the total number of items available.
        /// </summary>
        /// <returns></returns>
        public int FetchCount()
        {
            Trace.WriteLine("FetchCount");
            Thread.Sleep(_fetchDelay);
            return _count; 
        }

        /// <summary>
        /// Fetches a range of items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of items to fetch.</param>
        /// <returns></returns>
        public IList<ClippingItem> FetchRange(int startIndex, int count)
        {
            Trace.WriteLine("FetchRange: " + startIndex + "," + count);
            Thread.Sleep(_fetchDelay);

            List<ClippingItem> list = new List<ClippingItem>();
            return list;
        }
    }
}
