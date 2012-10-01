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
        private readonly int count;
        private readonly int fetchDelay;
        private IEnumerable<ClippingItem> sourceList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClippingItemProvider"/> class.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="fetchDelay"></param>
        /// <param name="_sourceList"></param>
        public ClippingItemProvider(int _fetchDelay, IEnumerable<ClippingItem> _sourceList)
        {
            count = _sourceList.Count();
            fetchDelay = _fetchDelay;
            sourceList = _sourceList;
        }

        /// <summary>
        /// Fetches the total number of items available.
        /// </summary>
        /// <returns></returns>
        public int FetchCount()
        {
            Trace.WriteLine("FetchCount");
            Thread.Sleep(fetchDelay);
            return count; 
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
            Thread.Sleep(fetchDelay);

            int end = 0;
            if ((startIndex + count) > sourceList.Count())
            {
                end = sourceList.Count();
            }
            else
            {
                end = startIndex + count;
            }

            List<ClippingItem> list = new List<ClippingItem>();
            for (int i = startIndex; i < end; i++)
            {
                list.Add(sourceList.ElementAt(i));
            }

            return list;
        }
    }
}
