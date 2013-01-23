using System.Collections.Generic;

namespace KindleHighlightViewer.Code
{
    public interface IDataConverter
    {
        IEnumerable<ClippingItem> Convert(string path = "");
    }
}
