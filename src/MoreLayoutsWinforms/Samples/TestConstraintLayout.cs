using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoreLayoutsWinforms.ConstraintLayout;

namespace MoreLayoutsWinforms
{
    public partial class TestConstraintLayout : UserControl
    {
        public TestConstraintLayout()
        {
            InitializeComponent();
        }

        public ConstraintLayoutPanel ConstraintLayout => constraintLayoutPanel1;

        private void button2_Click(object sender, EventArgs e)
        {
            constraintLayoutPanel1.SetTop(button2, new SimpleConstraint(button1, ConstraintProperty.Bottom, 0));
        }
    }
}
