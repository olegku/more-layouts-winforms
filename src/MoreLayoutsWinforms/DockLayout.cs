using System.Drawing;
using System.Windows.Forms;

namespace MoreLayoutsWinforms
{
    public interface IDockLayoutParams : ILayoutParams<IDockLayoutElement>
    {
    }


    public interface IDockLayoutElement : ILayoutElement
    {
        DockStyle Dock { get; }
    }


    public class DockLayoutElement : LayoutElement, IDockLayoutElement
    {
        public DockLayoutElement(Control control) : base(control)
        {
        }

        public DockStyle Dock => Control.Dock;
    }


    public class DockLayoutPanel : AbstractLayoutPanel<IDockLayoutParams, IDockLayoutElement>, IDockLayoutParams
    {
        protected override AbstractLayoutEngine<IDockLayoutParams, IDockLayoutElement> CreateLayoutEngine() => new DockLayout();
        protected override IDockLayoutElement CreateLayoutElement(Control child) => new DockLayoutElement(child);
    }


    public class DockLayout : AbstractLayoutEngine<IDockLayoutParams, IDockLayoutElement>
    {
        protected override void LayoutOverride(IDockLayoutParams layoutParams)
        {
            var left = layoutParams.DisplayRectangle.Left;
            var top= layoutParams.DisplayRectangle.Top;
            var right = layoutParams.DisplayRectangle.Right;
            var bottom = layoutParams.DisplayRectangle.Bottom;

            foreach (var element in layoutParams.Elements)
            {
                var elementSize = element.SpecifiedSize;
                Rectangle elementBounds;

                switch (element.Dock)
                {
                    case DockStyle.None:
                        goto default;
                    
                    case DockStyle.Top:
                        elementBounds = Rectangle.FromLTRB(left, top, right, top + elementSize.Height);
                        top += elementSize.Height;
                        break;
                    
                    case DockStyle.Bottom:
                        elementBounds = Rectangle.FromLTRB(left, bottom - elementSize.Height, right, bottom);
                        bottom -= elementSize.Height;
                        break;
                    
                    case DockStyle.Left:
                        elementBounds = Rectangle.FromLTRB(left, top, left + elementSize.Width, bottom);
                        left += elementSize.Width;
                        break;
                    
                    case DockStyle.Right:
                        elementBounds = Rectangle.FromLTRB(right - elementSize.Width, top, right, bottom);
                        right -= elementSize.Width;
                        break;
                    
                    case DockStyle.Fill:
                        elementBounds = Rectangle.FromLTRB(left, top, right, bottom);
                        break;
                    
                    default:
                        elementBounds = Rectangle.Empty;
                        break;
                }

                element.Arrange(elementBounds);
            }
        }
    }
}
