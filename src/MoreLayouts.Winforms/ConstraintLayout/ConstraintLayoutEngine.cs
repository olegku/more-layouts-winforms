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
                AddSpecifiedBoundsConstraints(solver, element);

                element.Left?.AddToSolver(solver, element.Vars.Left, layoutParams);
                element.Top?.AddToSolver(solver, element.Vars.Top, layoutParams);
                element.Center?.AddToSolver(solver, element.Vars.Center, layoutParams);
                element.Middle?.AddToSolver(solver, element.Vars.Middle, layoutParams);
                element.Right?.AddToSolver(solver, element.Vars.Right, layoutParams);
                element.Bottom?.AddToSolver(solver, element.Vars.Bottom, layoutParams);
                element.Width?.AddToSolver(solver, element.Vars.Width, layoutParams);
                element.Height?.AddToSolver(solver, element.Vars.Height, layoutParams);
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


        private static void AddSpecifiedBoundsConstraints(Solver solver, IConstraintLayoutElement element)
        {
            var medium1 = Strength.Create(0, 1, 0, 1);
            var medium2 = Strength.Create(0, 1, 0, 2);

            solver.AddConstraint(element.Vars.Left == element.SpecifiedBounds.Left | medium1);
            solver.AddConstraint(element.Vars.Top == element.SpecifiedBounds.Top | medium1);
            solver.AddConstraint(element.Vars.Width == element.SpecifiedSize.Width | medium2);
            solver.AddConstraint(element.Vars.Height == element.SpecifiedSize.Height | medium2);
        }
    }
}