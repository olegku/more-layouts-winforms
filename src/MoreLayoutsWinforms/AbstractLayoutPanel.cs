using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace MoreLayoutsWinforms
{
    [DesignerCategory("code")]
    public abstract class AbstractLayoutPanel<TLayoutParams> : Panel, ILayoutParams where TLayoutParams : ILayoutParams
    {
        private LayoutEngine _layoutEngine;

        public sealed override LayoutEngine LayoutEngine => _layoutEngine ?? (_layoutEngine = CreateLayoutEngine());

        public Size GetSpecifiedSize(Control child)
        {
            child.VerifyParent(this);
            return child.GetSpecifiedSize();
        }

        protected abstract AbstractLayoutEngine<TLayoutParams> CreateLayoutEngine();

        protected void SetLayoutProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            field = value;
            PerformLayout(this, propertyName);
        }
    }
}
