using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MoreLayouts.WinForms.Design.ConstraintLayout
{
    internal class ConstraintLayoutPanelDesigner : LayoutPanelDesigner, IChildDesignerFilter
    {
        public override bool ParticipatesWithSnapLines { get; } = false;

        void IChildDesignerFilter.FilterProperties(IComponent component, IDictionary properties)
        {
            properties.Remove("Anchor");
            properties["Location"] = TypeDescriptor.CreateProperty(typeof(Control), "Location", typeof(Point), BrowsableAttribute.No);
        }
    }
}
