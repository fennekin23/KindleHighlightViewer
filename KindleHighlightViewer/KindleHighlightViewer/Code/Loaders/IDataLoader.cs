using System.Collections.Generic;

namespace KindleHighlightViewer.Code
{
    public interface IDataLoader
    {
        IEnumerable<ClippingItem> Load(string path = "");
    }
}
