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
            var availableBounds = layoutParams.DisplayRectangle;

            foreach (var element in layoutParams.Elements)
            {
                var elementSize = element.SpecifiedSize;
                Rectangle elementBounds;

                switch (element.Dock)
                {
                    case DockStyle.None:
                        goto default;
                    
                    case DockStyle.Top:
                        SliceHorizontally(
                            availableBounds, 
                            slice: availableBounds.Top + elementSize.Height, 
                            topRect: out elementBounds, 
                            bottomRect: out availableBounds);
                        break;
                    
                    case DockStyle.Bottom:
                        SliceHorizontally(
                            availableBounds,
                            slice: availableBounds.Bottom - elementSize.Height,
                            topRect: out availableBounds,
                            bottomRect: out elementBounds);
                        break;
                    
                    case DockStyle.Left:
                        SliceVertically(
                            availableBounds,
                            slice: availableBounds.Left + elementSize.Width,
                            leftRect: out elementBounds,
                            rightRect: out availableBounds);
                        break;
                    
                    case DockStyle.Right:
                        SliceVertically(
                            availableBounds,
                            slice: availableBounds.Right - elementSize.Width,
                            leftRect: out availableBounds,
                            rightRect: out elementBounds);
                        break;
                    
                    case DockStyle.Fill:
                        elementBounds = availableBounds;
                        break;
                    
                    default:
                        elementBounds = Rectangle.Empty;
                        break;
                }

                element.Arrange(elementBounds);
            }
        }

        private static void SliceVertically(Rectangle rect, int slice, out Rectangle leftRect, out Rectangle rightRect)
        {
            leftRect = Rectangle.FromLTRB(rect.Left, rect.Top, slice, rect.Bottom);
            rightRect = Rectangle.FromLTRB(slice, rect.Top, rect.Right, rect.Bottom);
        }

        private static void SliceHorizontally(Rectangle rect, int slice, out Rectangle topRect, out Rectangle bottomRect)
        {
            topRect = Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, slice);
            bottomRect = Rectangle.FromLTRB(rect.Left, slice, rect.Right, rect.Bottom);
        }
    }
}
