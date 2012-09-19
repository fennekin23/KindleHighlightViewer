using System.Collections.Generic;

namespace KindlHighlightViewer.Code
{
    public interface IDataConverter
    {
        IEnumerable<ClippingItem> Convert(string path = "");
    }
}
