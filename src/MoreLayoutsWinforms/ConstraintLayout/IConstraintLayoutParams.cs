using System.Windows.Forms;
using MoreLayoutsWinforms.Core;

namespace MoreLayoutsWinforms.ConstraintLayout
{
    public interface IConstraintLayoutElement : ILayoutElement
    {
        ElementVars Vars { get; }
        SimpleConstraint Left { get; }
        SimpleConstraint Top { get; }
        SimpleConstraint Center { get; }
        SimpleConstraint Middle { get; }
        SimpleConstraint Right { get; }
        SimpleConstraint Bottom { get; }
    }

    public interface IConstraintLayoutParams : ILayoutParams<IConstraintLayoutElement>
    {
        SimpleConstraint GetLeft(Control child);
        SimpleConstraint GetTop(Control child);
        SimpleConstraint GetCenter(Control child);
        SimpleConstraint GetMiddle(Control child);
        SimpleConstraint GetRight(Control child);
        SimpleConstraint GetBottom(Control child);
    }

    public class ConstraintLayoutElement : LayoutElement, IConstraintLayoutElement
    {
        public ConstraintLayoutElement(Control control) : base(control)
        {
            Vars = new ElementVars();
        }

        public ElementVars Vars { get; }

        public SimpleConstraint Left { get; set; }
        public SimpleConstraint Top { get; set; }
        public SimpleConstraint Center { get; set; }
        public SimpleConstraint Middle { get; set; }
        public SimpleConstraint Right { get; set; }
        public SimpleConstraint Bottom { get; set; }
    }
}