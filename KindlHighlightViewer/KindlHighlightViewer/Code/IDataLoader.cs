using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KindlHighlightViewer.Code
{
    public interface IDataLoader
    {
        IEnumerable<ClippingItem> Load(string path = "");
    }
}
