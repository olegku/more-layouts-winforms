using System.ComponentModel;
using System.Windows.Forms;
using MoreLayoutsWinforms.Core;

namespace MoreLayoutsWinforms.ConstraintLayout
{
    public class ConstraintLayoutPanel : AbstractLayoutPanel<IConstraintLayoutParams, IConstraintLayoutElement>,
        IConstraintLayoutParams, 
        IExtenderProvider
    {
        protected override AbstractLayoutEngine<IConstraintLayoutParams, IConstraintLayoutElement>
            CreateLayoutEngine() => new ConstraintLayoutEngine();

        protected override IConstraintLayoutElement CreateLayoutElement(Control child) =>
            new ConstraintLayoutElement(child);

        #region Implementation of IConstraintLayoutParams

        public SimpleConstraint GetLeft(Control child)
        {
            throw new System.NotImplementedException();
        }

        public SimpleConstraint GetTop(Control child)
        {
            throw new System.NotImplementedException();
        }

        public SimpleConstraint GetCenter(Control child)
        {
            throw new System.NotImplementedException();
        }

        public SimpleConstraint GetMiddle(Control child)
        {
            throw new System.NotImplementedException();
        }

        public SimpleConstraint GetRight(Control child)
        {
            throw new System.NotImplementedException();
        }

        public SimpleConstraint GetBottom(Control child)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        public bool CanExtend(object extendee) => extendee is Control control && 
                                                  control.Parent == this;
    }
}