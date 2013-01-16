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
        private IEnumerable<ClippingItem> sourceList;
        private readonly int count;
        private readonly int fetchDelay;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClippingItemProvider"/> class.
        /// </summary>
        /// <param name="_fetchDelay"></param>
        /// <param name="_sourceList"></param>
        public ClippingItemProvider(IEnumerable<ClippingItem> _sourceList, int _fetchDelay)
        {
            count = _sourceList.Count();
            fetchDelay = _fetchDelay;
            sourceList = _sourceList;
        }

        public void Order()
        {
            sourceList = sourceList.OrderBy(c => c.Author).ToList();
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
            if (end > sourceList.Count())
            {
                end = count;
            }
            else
            {
                end = sourceList.Count();
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
