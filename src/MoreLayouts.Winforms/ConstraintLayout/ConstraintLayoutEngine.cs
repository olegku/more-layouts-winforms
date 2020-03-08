using System.Drawing;
using Kiwi;
using MoreLayouts.WinForms.Core;

namespace MoreLayouts.WinForms.ConstraintLayout
{
    public class ConstraintLayoutEngine : AbstractLayoutEngine<IConstraintLayoutParams, IConstraintLayoutElement>
    {
        protected override void LayoutOverride(IConstraintLayoutParams layoutParams)
        {
            var solver = new Solver();
            
            foreach (var element in layoutParams.Elements)
            {
                AddCommonConstraints(solver, element, layoutParams.DisplayRectangle);

                AddSimpleConstraint(solver, layoutParams, element.Vars.Left, element.Left);
                AddSimpleConstraint(solver, layoutParams, element.Vars.Top, element.Top);
                AddSimpleConstraint(solver, layoutParams, element.Vars.Center, element.Center);
                AddSimpleConstraint(solver, layoutParams, element.Vars.Middle, element.Middle);
                AddSimpleConstraint(solver, layoutParams, element.Vars.Right, element.Right);
                AddSimpleConstraint(solver, layoutParams, element.Vars.Bottom, element.Bottom);

                solver.AddConstraint(element.Vars.Width == element.SpecifiedSize.Width | Strength.Medium);
                solver.AddConstraint(element.Vars.Height == element.SpecifiedSize.Height | Strength.Medium);
            }

            solver.UpdateVariables();

            foreach (var element in layoutParams.Elements)
            {
                var vars = element.Vars;
                var elementBounds = new RectangleF(
                    (float)vars.Left.Value,
                    (float)vars.Top.Value,
                    (float)vars.Width.Value, 
                    (float)vars.Height.Value);

                element.Arrange(LayoutUtils.Round(elementBounds));
            }
        }

        private static void AddSimpleConstraint(
            Solver solver,
            IConstraintLayoutParams layoutParams,
            Variable lhs,
            SimpleConstraint constraint)
        {
            if (constraint == null) return;

            if (constraint.Control == null || 
                constraint.Property == ConstraintProperty.None)
            {
                solver.AddConstraint(lhs == constraint.Constant);
            }
            else
            {
                var element = layoutParams.GetElement(constraint.Control);
                var elementVar = element.Vars[constraint.Property];
                solver.AddConstraint(lhs == elementVar + constraint.Constant);
            }
        }

        private static void AddCommonConstraints(Solver solver, IConstraintLayoutElement element, Rectangle layoutBounds)
        {
            var vars = element.Vars;

            solver.AddConstraint(vars.Left == layoutBounds.Left | Strength.Weak);
            solver.AddConstraint(vars.Top == layoutBounds.Top | Strength.Weak);

            // weak constraints to keep element within panel bounds
            solver.AddConstraint(vars.Left >= layoutBounds.Left | Strength.Medium);
            solver.AddConstraint(vars.Top >= layoutBounds.Top | Strength.Medium);
            solver.AddConstraint(vars.Right <= layoutBounds.Right | Strength.Medium);
            solver.AddConstraint(vars.Bottom <= layoutBounds.Bottom | Strength.Medium);

            // strong constraints to make width and height non-negative
            solver.AddConstraint(vars.Width >= 0);
            solver.AddConstraint(vars.Height >= 0);

            // strong constraints to set relations for width/left/center/right and height/top/middle/bottom
            solver.AddConstraint(vars.Left + vars.Width == vars.Right);
            solver.AddConstraint(vars.Left + vars.Width / 2 == vars.Center);
            solver.AddConstraint(vars.Top + vars.Height == vars.Bottom);
            solver.AddConstraint(vars.Top + vars.Height / 2 == vars.Middle);
        }
    }
}