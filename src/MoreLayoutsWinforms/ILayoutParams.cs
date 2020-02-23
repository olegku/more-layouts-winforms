using System.Drawing;
using System.Windows.Forms;

namespace MoreLayoutsWinforms
{
    public interface ILayoutParams
    {
        // TODO: rename to LayoutBounds?
        Rectangle DisplayRectangle { get; }
        Size GetSpecifiedSize(Control child);
    }
}