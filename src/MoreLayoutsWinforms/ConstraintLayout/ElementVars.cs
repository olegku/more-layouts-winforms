using Kiwi;

namespace MoreLayoutsWinforms.ConstraintLayout
{
    // TODO: make internal
    public class ElementVars
    {
        private static int _counter = 0;

        public ElementVars()
        {
            Id = ++_counter;

            Width = new Variable($"{Id}.{nameof(Width)}");
            Height = new Variable($"{Id}.{nameof(Height)}");

            Left = new Variable($"{Id}.{nameof(Left)}");
            Center = new Variable($"{Id}.{nameof(Center)}");
            Right = new Variable($"{Id}.{nameof(Right)}");

            Top = new Variable($"{Id}.{nameof(Top)}");
            Middle = new Variable($"{Id}.{nameof(Middle)}");
            Bottom = new Variable($"{Id}.{nameof(Bottom)}");
        }

        public int Id { get; }

        public Variable Width { get; }
        public Variable Height { get; }

        public Variable Left { get; }
        public Variable Center { get; }
        public Variable Right { get; }

        public Variable Top { get; }
        public Variable Middle { get; }
        public Variable Bottom { get; }

        public Variable this[ConstraintProperty property]
        {
            get
            {
                switch (property)
                {
                    case ConstraintProperty.None: goto default;
                    case ConstraintProperty.Width: return Width;
                    case ConstraintProperty.Height: return Height;
                    case ConstraintProperty.Left: return Left;
                    case ConstraintProperty.Center: return Center;
                    case ConstraintProperty.Right: return Right;
                    case ConstraintProperty.Top: return Top;
                    case ConstraintProperty.Middle: return Middle;
                    case ConstraintProperty.Bottom: return Bottom;
                    default: return null;
                }
            }
        }
    }
}