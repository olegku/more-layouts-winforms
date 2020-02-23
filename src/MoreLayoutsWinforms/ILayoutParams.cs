using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MoreLayoutsWinforms
{
    public interface ILayoutParams<out TElement> where TElement : ILayoutElement
    {
        // TODO: rename to LayoutBounds?
        Rectangle DisplayRectangle { get; }
        IReadOnlyList<TElement> Elements { get; }
    }

    public interface ILayoutElement
    {
        Size SpecifiedSize { get; }
        AnchorStyles Anchor { get; }
        void Arrange(Rectangle bounds);
    }

    public class LayoutElement : ILayoutElement
    {
        private readonly Control _control;

        public LayoutElement(Control control)
        {
            _control = control ?? throw new ArgumentNullException(nameof(control));
        }

        public Size SpecifiedSize => _control.GetSpecifiedSize();
        public AnchorStyles Anchor => _control.Anchor;

        public void Arrange(Rectangle bounds) => _control.Arrange(bounds);
    }
}