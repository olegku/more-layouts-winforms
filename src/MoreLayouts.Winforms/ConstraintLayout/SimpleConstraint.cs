using System.ComponentModel;
using System.Windows.Forms;

namespace MoreLayouts.WinForms.ConstraintLayout
{
    [TypeConverter(typeof(SimpleConstraintConverter))]
    public class SimpleConstraint
    {
        public SimpleConstraint(int constant) : this(null, ConstraintProperty.None, constant)
        {
        }

        public SimpleConstraint(Control control, ConstraintProperty property, int constant)
        {
            Control = control;
            Property = property;
            Constant = constant;
        }

        #region Properties

        [TypeConverter(typeof(SimpleConstraintControlConverter))]
        public Control Control { get; set; }
        
        public ConstraintProperty Property { get; set; }

        // TODO: rename to Offset?
        public int Constant { get; set; }

        #endregion

        internal void AddToSolver(Kiwi.Solver solver)
        {
            // TODO
        }

        public override string ToString()
        {
            if (Control != null && Property != ConstraintProperty.None)
            {
                var result = $"{Control.Name}.{Property}";
                if (Constant != 0)
                {
                    result += $" + {Constant}";
                }

                return result;
            }

            return $"{Constant}";
        }
    }
}