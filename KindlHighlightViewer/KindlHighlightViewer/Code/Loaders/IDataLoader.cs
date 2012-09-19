using System.Collections.Generic;

namespace KindlHighlightViewer.Code
{
    public interface IDataLoader
    {
        IEnumerable<ClippingItem> Load(string path = "");
    }
}
