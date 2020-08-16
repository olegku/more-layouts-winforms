using System;
using System.Windows.Forms;
using MoreLayouts.WinForms.ConstraintLayout;

namespace MoreLayouts.WinForms.Samples
{
    public partial class TestConstraintLayout : UserControl
    {
        public TestConstraintLayout()
        {
            InitializeComponent();
        }

        //public ConstraintLayoutPanel ConstraintLayout => constraintLayoutPanel1;

        private void Button2Click(object sender, EventArgs e)
        {
            constraintLayoutPanel1.SetTop(button2, new SimpleConstraint(button1, ConstraintProperty.Bottom, 0));
        }
    }
}
