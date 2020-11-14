using System.ComponentModel;
using System.Windows.Forms;
using MoreLayouts.WinForms.Core;

namespace MoreLayouts.WinForms.StackLayout
{
    public interface IStackLayoutParams : ILayoutParams<ILayoutElement>
    {
        Orientation Orientation { get; }
        int Spacing { get; }
    }


    [Designer("MoreLayouts.WinForms.Design.StackLayoutPanelDesigner, MoreLayouts.WinForms.Design")]
    public class StackLayoutPanel : AbstractLayoutPanel<IStackLayoutParams, ILayoutElement>, IStackLayoutParams
    {
        private static class Defaults
        {
            public const Orientation Orientation = System.Windows.Forms.Orientation.Vertical;
            public const int Spacing = 0;
        }

        private Orientation _orientation = Defaults.Orientation;
        private int _spacing = Defaults.Spacing;

        protected override AbstractLayoutEngine<IStackLayoutParams, ILayoutElement> CreateLayoutEngine() => new StackLayoutEngine();
        protected override ILayoutElement CreateLayoutElement(Control child) => new LayoutElement(child);

        #region Properties

        [Category("Layout")]
        [Description("Orientation of stack elements arrangement")]
        [DefaultValue(Defaults.Orientation)]
        public Orientation Orientation
        {
            get => _orientation;
            set => SetLayoutProperty(ref _orientation, value);
        }

        [Category("Layout")]
        [Description("Spacing between stack elements")]
        [DefaultValue(Defaults.Spacing)]
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