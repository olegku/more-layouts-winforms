using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace MoreLayouts.WinForms.Design
{
    internal class StackInsertionCursorGlyph : Glyph
    {
        private const int CursorBarThickness = 3;

        private readonly Color _color;
        private readonly Point _p1;
        private readonly Point _p2;
        private readonly Rectangle _clipBounds;

        public StackInsertionCursorGlyph(Color backColor, Rectangle panelBounds, Orientation stackOrientation, Point position) : base(null)
        {
            _color = (backColor.GetBrightness() < 0.5)
                ? ControlPaint.Light(backColor)
                : ControlPaint.Dark(backColor);

            var bounds = panelBounds;
            bounds.Inflate(-2, -2);

            if (stackOrientation == Orientation.Vertical)
            {
                _p1 = new Point(bounds.Left, position.Y);
                _p2 = new Point(bounds.Right - 1, position.Y);
            }
            else
            {
                _p1 = new Point(position.X, bounds.Top);
                _p2 = new Point(position.X, bounds.Bottom - 1);
            }

            var rect = Rectangle.Union(
                new Rectangle(_p1, new Size(1, 1)),
                new Rectangle(_p2, new Size(1, 1)));
            rect.Inflate(CursorBarThickness, CursorBarThickness);
            rect.Intersect(bounds);

            _clipBounds = rect;
        }

        public override Rectangle Bounds => _clipBounds;

        public override Cursor GetHitTest(Point p) => null;

        public override void Paint(PaintEventArgs pe)
        {
            var oldState = pe.Graphics.Save();

            pe.Graphics.SetClip(_clipBounds);
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (var pen = new Pen(_color, CursorBarThickness)
            {
                StartCap = LineCap.DiamondAnchor, 
                EndCap = LineCap.DiamondAnchor
            })
            {
                pe.Graphics.DrawLine(pen, _p1, _p2);
            }

            pe.Graphics.Restore(oldState);
        }
    }
}