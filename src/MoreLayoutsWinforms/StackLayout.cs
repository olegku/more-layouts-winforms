using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MoreLayoutsWinforms
{
    public interface IStackLayoutParams : ILayoutParams
    {
        Orientation Orientation { get; }
        int Spacing { get; }
    }


    public class StackLayoutPanel : AbstractLayoutPanel<IStackLayoutParams>, IStackLayoutParams
    {
        private Orientation _orientation = Orientation.Vertical;
        private int _spacing;

        protected override AbstractLayoutEngine<IStackLayoutParams> CreateLayoutEngine() => new StackLayoutEngine();

        #region Properties

        [Category("Layout")]
        [Description("TODO")]
        [DefaultValue(Orientation.Vertical)]
        public Orientation Orientation
        {
            get => _orientation;
            set => SetLayoutProperty(ref _orientation, value);
        }

        [Category("Layout")]
        [Description("TODO")]
        [DefaultValue(0)]
        public int Spacing
        {
            get => _spacing;
            set => SetLayoutProperty(ref _spacing, value);
        }

        #endregion
    }


    public class StackLayoutEngine : AbstractLayoutEngine<IStackLayoutParams>
    {
        protected override void LayoutOverride(IStackLayoutParams layoutParams, Control container, LayoutEventArgs layoutEventArgs)
        {
            var elementBounds = layoutParams.DisplayRectangle;
            var isHorizontal = layoutParams.Orientation == Orientation.Horizontal;

            foreach (Control child in container.Controls)
            {
                var childSize = layoutParams.GetSpecifiedSize(child);

                if (isHorizontal)
                    elementBounds.Width = childSize.Width;
                else
                    elementBounds.Height = childSize.Height;

                ArrangeElement(child, childSize, elementBounds);

                if (isHorizontal)
                    elementBounds.X += elementBounds.Width + layoutParams.Spacing;
                else
                    elementBounds.Y += elementBounds.Height + layoutParams.Spacing;
            }
        }

        private static void ArrangeElement(Control child, Size childSize, Rectangle elementBounds)
        {
            child.Arrange(LayoutUtils.AnchorRect(elementBounds, childSize, child.Anchor));
        }
    }
}