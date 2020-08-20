using System.ComponentModel;
using System.Windows.Forms;
using MoreLayouts.WinForms.Core;

namespace MoreLayouts.WinForms.ConstraintLayout
{
    [Designer("MoreLayouts.WinForms.Design.ConstraintLayout.ConstraintLayoutPanelDesigner, MoreLayouts.WinForms.Design")]
    [ProvideProperty("Left", typeof(Control))]
    [ProvideProperty("Top", typeof(Control))]
    [ProvideProperty("Center", typeof(Control))]
    [ProvideProperty("Middle", typeof(Control))]
    [ProvideProperty("Right", typeof(Control))]
    [ProvideProperty("Bottom", typeof(Control))]
    [ProvideProperty("Width", typeof(Control))]
    [ProvideProperty("Height", typeof(Control))]
    public class ConstraintLayoutPanel : AbstractLayoutPanel<IConstraintLayoutParams, IConstraintLayoutElement>,
        IConstraintLayoutParams, 
        IExtenderProvider
    {
        private const string Category = "Layout Constraints";

        protected override AbstractLayoutEngine<IConstraintLayoutParams, IConstraintLayoutElement>
            CreateLayoutEngine() => new ConstraintLayoutEngine();

        protected override IConstraintLayoutElement CreateLayoutElement(Control child) =>
            new ConstraintLayoutElement(child);

        #region Provided Properties

        [DisplayName("Left")]
        [Category(Category)]
        [DefaultValue(null)]
        public SimplePropertyConstraint GetLeft(Control child) => base.GetElement(child).Left;
        public void SetLeft(Control child, SimplePropertyConstraint propertyConstraint)
        {
            GetElement(child).Left = propertyConstraint;
            PerformLayout(this, "LeftConstraint");
        }

        [DisplayName("Top")]
        [Category(Category)]
        [DefaultValue(null)]
        public SimplePropertyConstraint GetTop(Control child) => base.GetElement(child).Top;
        public void SetTop(Control child, SimplePropertyConstraint propertyConstraint)
        {
            GetElement(child).Top = propertyConstraint;
            PerformLayout(this, "TopConstraint");
        }

        [DisplayName("Center")]
        [Category(Category)]
        [DefaultValue(null)]
        public SimplePropertyConstraint GetCenter(Control child) => base.GetElement(child).Center;
        public void SetCenter(Control child, SimplePropertyConstraint propertyConstraint)
        {
            GetElement(child).Center = propertyConstraint;
            PerformLayout(this, "CenterConstraint");
        }

        [DisplayName("Middle")]
        [Category(Category)]
        [DefaultValue(null)]
        public SimplePropertyConstraint GetMiddle(Control child) => base.GetElement(child).Middle;
        public void SetMiddle(Control child, SimplePropertyConstraint propertyConstraint)
        {
            GetElement(child).Middle = propertyConstraint;
            PerformLayout(this, "MiddleConstraint");
        }

        [DisplayName("Right")]
        [Category(Category)]
        [DefaultValue(null)]
        public SimplePropertyConstraint GetRight(Control child) => base.GetElement(child).Right;
        public void SetRight(Control child, SimplePropertyConstraint propertyConstraint)
        {
            GetElement(child).Right = propertyConstraint;
            PerformLayout(this, "RightConstraint");
        }

        [DisplayName("Bottom")]
        [Category(Category)]
        [DefaultValue(null)]
        public SimplePropertyConstraint GetBottom(Control child) => base.GetElement(child).Bottom;
        public void SetBottom(Control child, SimplePropertyConstraint propertyConstraint)
        {
            GetElement(child).Bottom = propertyConstraint;
            PerformLayout(this, "BottomConstraint");
        }

        [DisplayName("Width")]
        [Category(Category)]
        [DefaultValue(null)]
        public SimplePropertyConstraint GetWidth(Control child) => base.GetElement(child).Width;
        public void SetWidth(Control child, SimplePropertyConstraint propertyConstraint)
        {
            GetElement(child).Width = propertyConstraint;
            PerformLayout(this, "WidthConstraint");
        }

        [DisplayName("Height")]
        [Category(Category)]
        [DefaultValue(null)]
        public SimplePropertyConstraint GetHeight(Control child) => base.GetElement(child).Height;
        public void SetHeight(Control child, SimplePropertyConstraint propertyConstraint)
        {
            GetElement(child).Height = propertyConstraint;
            PerformLayout(this, "HeightConstraint");
        }

        #endregion

        bool IExtenderProvider.CanExtend(object extendee) => extendee is Control control && control.Parent == this;

        // TODO: rethink
        private new ConstraintLayoutElement GetElement(Control child) => (ConstraintLayoutElement)base.GetElement(child);
    }
}