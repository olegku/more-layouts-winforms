using System.ComponentModel;
using System.Windows.Forms;
using Kiwi;

namespace MoreLayouts.WinForms.ConstraintLayout
{
    [TypeConverter(typeof(SimpleConstraintConverter))]
    public class SimplePropertyConstraint
    {
        public SimplePropertyConstraint(double constant) : this(null, ConstraintProperty.None, constant)
        {
        }

        public SimplePropertyConstraint(Control control, ConstraintProperty property, double constant)
        {
            Control = control;
            Property = property;
            Constant = constant;
        }

        #region Properties

        [TypeConverter(typeof(SimpleConstraintControlConverter))]
        public Control Control { get; set; }
        
        public ConstraintProperty Property { get; set; }

        public double Constant { get; set; }

        #endregion

        // TODO: extract interface
        internal void AddToSolver(Solver solver, Variable lhs, IConstraintLayoutParams layoutParams)
        {
            if (Control == null || Property == ConstraintProperty.None)
            {
                solver.AddConstraint(lhs == Constant);
            }
            else
            {
                var element = layoutParams.GetElement(Control);
                var elementVar = element.Vars[Property];
                solver.AddConstraint(lhs == elementVar + Constant);
            }
        }

        public override string ToString()
        {
            if (Control != null && Property != ConstraintProperty.None)
            {
                var result = $"{Control.Name}.{Property}";
                if (!Constant.IsCloseTo(0))
                {
                    result += $" + {Constant}";
                }

                return result;
            }

            return $"{Constant}";
        }
    }
}