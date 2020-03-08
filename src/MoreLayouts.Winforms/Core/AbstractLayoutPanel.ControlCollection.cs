using System.Windows.Forms;

namespace MoreLayouts.WinForms.Core
{
    public abstract partial class AbstractLayoutPanel<TLayoutParams, TLayoutElement>
    {
        private new class ControlCollection : Control.ControlCollection
        {
            private readonly AbstractLayoutPanel<TLayoutParams, TLayoutElement> _owner;

            public ControlCollection(AbstractLayoutPanel<TLayoutParams, TLayoutElement> owner) : base(owner)
            {
                _owner = owner;
            }

            public override void Add(Control value)
            {
                // value can be already added
                if (!_owner._elements.ContainsKey(value))
                {
                    _owner._elements.Add(value, _owner.CreateLayoutElement(value));
                }

                base.Add(value);
            }

            public override void Remove(Control value)
            {
                base.Remove(value);
                _owner._elements.Remove(value);
            }
        }
    }
}