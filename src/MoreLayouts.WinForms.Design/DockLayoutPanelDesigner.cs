using System.Collections;
using System.ComponentModel;

namespace MoreLayouts.WinForms.Design
{
    internal class DockLayoutPanelChildDesigner : LayoutPanelDesigner, IChildDesignerFilter
    {
        void IChildDesignerFilter.FilterProperties(IComponent component, IDictionary properties)
        {
            properties.Remove("Anchor");
        }
    }
}