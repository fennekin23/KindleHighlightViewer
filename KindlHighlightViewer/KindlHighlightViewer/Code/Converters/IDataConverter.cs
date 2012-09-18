using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KindlHighlightViewer.Code
{
    public interface IDataConverter
    {
        IEnumerable<ClippingItem> Convert(string path = "");
    }
}
