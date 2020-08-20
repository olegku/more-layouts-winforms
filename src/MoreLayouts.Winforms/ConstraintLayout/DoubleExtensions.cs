using static System.Math;

namespace MoreLayouts.WinForms.ConstraintLayout
{
    public static class DoubleExtensions
    {
        internal const double Epsilon = 2.22044604925031E-16;

        public static bool IsCloseTo(this double value, double other)
        {
            if (value == other) return true;
            var num1 = (Abs(value) + Abs(other) + 10.0) * Epsilon;
            var num2 = value - other;
            return num2 > -num1 && num2 < num1;
        }
    }
}