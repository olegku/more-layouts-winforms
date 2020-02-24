using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace MoreLayoutsWinforms
{
    [DesignerCategory("code")]
    public abstract class AbstractLayoutPanel<TLayoutParams, TLayoutElement> : Panel, ILayoutParams<TLayoutElement> 
        where TLayoutParams : ILayoutParams<TLayoutElement>
        where TLayoutElement : ILayoutElement
    {
        private LayoutEngine _layoutEngine;
        private readonly Dictionary<Control, TLayoutElement> _elements = new Dictionary<Control, TLayoutElement>();

        public sealed override LayoutEngine LayoutEngine => _layoutEngine ?? (_layoutEngine = CreateLayoutEngine());

        // TODO: remove Linq
        public IReadOnlyList<TLayoutElement> Elements => Controls
            .OfType<Control>()
            .Select(control => _elements[control])
            .ToList()
            .AsReadOnly();

        public Size GetSpecifiedSize(Control child)
        {
            child.VerifyParent(this);
            return child.GetSpecifiedSize();
        }

        protected abstract AbstractLayoutEngine<TLayoutParams, TLayoutElement> CreateLayoutEngine();
        protected abstract TLayoutElement CreateLayoutElement(Control child);

        protected void SetLayoutProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            field = value;
            PerformLayout(this, propertyName);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            // TODO: this event happens after layout update is called, so doesn't' help
            base.OnControlAdded(e);
            _elements[e.Control] = CreateLayoutElement(e.Control);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            _elements.Remove(e.Control);
        }
    }
}
