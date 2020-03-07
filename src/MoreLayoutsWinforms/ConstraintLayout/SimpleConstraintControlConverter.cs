using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MoreLayoutsWinforms.ConstraintLayout
{
    internal class SimpleConstraintControlConverter : ReferenceConverter
    {
        public SimpleConstraintControlConverter(Type type) : base(type)
        {
        }

        protected override bool IsValueAllowed(ITypeDescriptorContext context, object value)
        {
            return value is Control control && control.Parent is ConstraintLayoutPanel;
        }
    }
}