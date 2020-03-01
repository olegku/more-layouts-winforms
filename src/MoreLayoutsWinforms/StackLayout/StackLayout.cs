using System.ComponentModel;
using System.Windows.Forms;

namespace MoreLayoutsWinforms
{
    public interface IStackLayoutParams : ILayoutParams<ILayoutElement>
    {
        Orientation Orientation { get; }
        int Spacing { get; }
    }


    public class StackLayoutPanel : AbstractLayoutPanel<IStackLayoutParams, ILayoutElement>, IStackLayoutParams
    {
        private Orientation _orientation = Orientation.Vertical;
        private int _spacing;

        protected override AbstractLayoutEngine<IStackLayoutParams, ILayoutElement> CreateLayoutEngine() => new StackLayoutEngine();
        protected override ILayoutElement CreateLayoutElement(Control child) => new LayoutElement(child);

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


    public class StackLayoutEngine : AbstractLayoutEngine<IStackLayoutParams, ILayoutElement>
    {
        protected override void LayoutOverride(IStackLayoutParams layoutParams)
        {
            var elementBounds = layoutParams.DisplayRectangle;
            var isHorizontal = layoutParams.Orientation == Orientation.Horizontal;

            foreach (var element in layoutParams.Elements)
            {
                var elementSize = element.SpecifiedSize;

                if (isHorizontal)
                    elementBounds.Width = elementSize.Width;
                else
                    elementBounds.Height = elementSize.Height;

                element.Arrange(LayoutUtils.AnchorRect(elementBounds, elementSize, element.Anchor));

                if (isHorizontal)
                    elementBounds.X += elementBounds.Width + layoutParams.Spacing;
                else
                    elementBounds.Y += elementBounds.Height + layoutParams.Spacing;
            }
        }
    }
}