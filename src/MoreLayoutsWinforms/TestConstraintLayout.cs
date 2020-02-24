
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoreLayoutsWinforms
{
    public partial class TestConstraintLayout : UserControl
    {
        public TestConstraintLayout()
        {
            InitializeComponent();
            constraintLayoutPanel1.Controls.Add(new Button());
        }
    }
}
