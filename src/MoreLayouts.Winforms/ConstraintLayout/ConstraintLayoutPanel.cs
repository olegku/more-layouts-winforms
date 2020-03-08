using System.ComponentModel;
using System.Windows.Forms;
using MoreLayouts.WinForms.Core;

namespace MoreLayouts.WinForms.ConstraintLayout
{
    [ProvideProperty("Left", typeof(Control))]
    [ProvideProperty("Top", typeof(Control))]
    [ProvideProperty("Center", typeof(Control))]
    [ProvideProperty("Middle", typeof(Control))]
    [ProvideProperty("Right", typeof(Control))]
    [ProvideProperty("Bottom", typeof(Control))]
    public class ConstraintLayoutPanel : AbstractLayoutPanel<IConstraintLayoutParams, IConstraintLayoutElement>,
        IConstraintLayoutParams, 
        IExtenderProvider
    {
        protected override AbstractLayoutEngine<IConstraintLayoutParams, IConstraintLayoutElement>
            CreateLayoutEngine() => new ConstraintLayoutEngine();

        protected override IConstraintLayoutElement CreateLayoutElement(Control child) =>
            new ConstraintLayoutElement(child);

        #region Provided Properties

        [DisplayName("Left")]
        [DefaultValue(null)]
        public SimpleConstraint GetLeft(Control child) => base.GetElement(child).Left;
        public void SetLeft(Control child, SimpleConstraint constraint) => GetElement(child).Left = constraint;

        [DisplayName("Top")]
        [DefaultValue(null)]
        public SimpleConstraint GetTop(Control child) => base.GetElement(child).Top;
        public void SetTop(Control child, SimpleConstraint constraint) => GetElement(child).Top = constraint;

        [DisplayName("Center")]
        [DefaultValue(null)]
        public SimpleConstraint GetCenter(Control child) => base.GetElement(child).Center;
        public void SetCenter(Control child, SimpleConstraint constraint) => GetElement(child).Center = constraint;

        [DisplayName("Middle")]
        [DefaultValue(null)]
        public SimpleConstraint GetMiddle(Control child) => base.GetElement(child).Middle;
        public void SetMiddle(Control child, SimpleConstraint constraint) => GetElement(child).Middle = constraint;

        [DisplayName("Right")]
        [DefaultValue(null)]
        public SimpleConstraint GetRight(Control child) => base.GetElement(child).Right;
        public void SetRight(Control child, SimpleConstraint constraint) => GetElement(child).Right = constraint;

        [DisplayName("Bottom")]
        [DefaultValue(null)]
        public SimpleConstraint GetBottom(Control child) => base.GetElement(child).Bottom;
        public void SetBottom(Control child, SimpleConstraint constraint) => GetElement(child).Bottom = constraint;

        #endregion

        bool IExtenderProvider.CanExtend(object extendee) => extendee is Control control && control.Parent == this;

        // TODO: rethink
        private new ConstraintLayoutElement GetElement(Control child) => (ConstraintLayoutElement)base.GetElement(child);
    }
}