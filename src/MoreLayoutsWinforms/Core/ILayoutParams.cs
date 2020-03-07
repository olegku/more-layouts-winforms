using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MoreLayoutsWinforms.Core
{
    public interface ILayoutParams<out TElement> where TElement : ILayoutElement
    {
        // TODO: rename to LayoutBounds?
        Rectangle DisplayRectangle { get; }
        IReadOnlyList<TElement> Elements { get; }

        // TODO: try redo to not expose Control instances to layout logic by default
        TElement GetElement(Control control);
    }

    public interface ILayoutElement
    {
        Size SpecifiedSize { get; }
        AnchorStyles Anchor { get; }
        void Arrange(Rectangle bounds);
    }

    public class LayoutElement : ILayoutElement
    {

        public LayoutElement(Control control)
        {
            Control = control ?? throw new ArgumentNullException(nameof(control));
        }

        protected Control Control { get; }
        public Size SpecifiedSize => Control.GetSpecifiedSize();
        public AnchorStyles Anchor => Control.Anchor;

        public void Arrange(Rectangle bounds) => Control.Arrange(bounds);
    }
}