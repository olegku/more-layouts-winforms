using System.Windows.Forms;
using MoreLayouts.WinForms.Core;

namespace MoreLayouts.WinForms.ConstraintLayout
{
    public interface IConstraintLayoutElement : ILayoutElement
    {
        ElementVars Vars { get; }
        SimplePropertyConstraint Left { get; }
        SimplePropertyConstraint Top { get; }
        SimplePropertyConstraint Center { get; }
        SimplePropertyConstraint Middle { get; }
        SimplePropertyConstraint Right { get; }
        SimplePropertyConstraint Bottom { get; }
        SimplePropertyConstraint Width { get; }
        SimplePropertyConstraint Height { get; }
    }

    public interface IConstraintLayoutParams : ILayoutParams<IConstraintLayoutElement>
    {
        SimplePropertyConstraint GetLeft(Control child);
        SimplePropertyConstraint GetTop(Control child);
        SimplePropertyConstraint GetCenter(Control child);
        SimplePropertyConstraint GetMiddle(Control child);
        SimplePropertyConstraint GetRight(Control child);
        SimplePropertyConstraint GetBottom(Control child);
    }

    public class ConstraintLayoutElement : LayoutElement, IConstraintLayoutElement
    {
        public ConstraintLayoutElement(Control control) : base(control)
        {
            Vars = new ElementVars();
        }

        public ElementVars Vars { get; }

        public SimplePropertyConstraint Left { get; set; }
        public SimplePropertyConstraint Top { get; set; }
        public SimplePropertyConstraint Center { get; set; }
        public SimplePropertyConstraint Middle { get; set; }
        public SimplePropertyConstraint Right { get; set; }
        public SimplePropertyConstraint Bottom { get; set; }
        public SimplePropertyConstraint Width { get; set; }
        public SimplePropertyConstraint Height { get; set; }
    }
}