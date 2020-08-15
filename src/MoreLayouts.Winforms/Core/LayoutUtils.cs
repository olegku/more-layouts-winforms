using System;
using System.Drawing;
using System.Windows.Forms;

namespace MoreLayouts.WinForms.Core
{
    public static class LayoutUtils
    {
        public static int GetCenter(this Rectangle rect) => rect.Left + rect.Width / 2;
        public static int GetMiddle(this Rectangle rect) => rect.Top + rect.Height / 2;

        public static Point GetTopLeft(this Rectangle rect) => new Point(rect.Left, rect.Top);
        public static Point GetMiddleLeft(this Rectangle rect) => new Point(rect.Left, rect.GetMiddle());
        public static Point GetBottomLeft(this Rectangle rect) => new Point(rect.Left, rect.Bottom);

        public static Point GetTopCenter(this Rectangle rect) => new Point(rect.GetCenter(), rect.Top);
        public static Point GetMiddleCenter(this Rectangle rect) => new Point(rect.GetCenter(), rect.GetMiddle());
        public static Point GetBottomCenter(this Rectangle rect) => new Point(rect.GetCenter(), rect.Bottom);

        public static Point GetTopRight(this Rectangle rect) => new Point(rect.Right, rect.Top);
        public static Point GetMiddleRight(this Rectangle rect) => new Point(rect.Right, rect.GetMiddle());
        public static Point GetBottomRight(this Rectangle rect) => new Point(rect.Right, rect.Bottom);

        public static Rectangle Inflate(this Rectangle rect, Padding padding) => Rectangle.FromLTRB(
            rect.Left - padding.Left,
            rect.Top - padding.Top,
            rect.Right + padding.Right,
            rect.Bottom + padding.Bottom);

        public static Rectangle Deflate(this Rectangle rect, Padding padding) => Rectangle.FromLTRB(
                rect.Left + padding.Left,
                rect.Top + padding.Top,
                rect.Right - padding.Right,
                rect.Bottom - padding.Bottom);


        public static Rectangle AnchorRect(Rectangle outerBounds, Size innerSize, AnchorStyles anchorStyles)
        {
            var anchorLeft = AnchorStylesExtensions.HasFlag(anchorStyles, AnchorStyles.Left);
            var anchorTop = AnchorStylesExtensions.HasFlag(anchorStyles, AnchorStyles.Top);
            var anchorRight = AnchorStylesExtensions.HasFlag(anchorStyles, AnchorStyles.Right);
            var anchorBottom = AnchorStylesExtensions.HasFlag(anchorStyles, AnchorStyles.Bottom);
            int left, top, right, bottom;

            if (anchorLeft && anchorRight)
            {
                left = outerBounds.Left;
                right = outerBounds.Right;
            }
            else if (anchorLeft)
            {
                left = outerBounds.Left;
                right = left + innerSize.Width;
            }
            else if (anchorRight)
            {
                right = outerBounds.Right;
                left = right - innerSize.Width;
            }
            else
            {
                left = outerBounds.Left + (outerBounds.Width - innerSize.Width) / 2;
                right = left + innerSize.Width;
            }

            if (anchorTop && anchorBottom)
            {
                top = outerBounds.Top;
                bottom = outerBounds.Bottom;
            }
            else if (anchorTop)
            {
                top = outerBounds.Top;
                bottom = top + innerSize.Height;
            }
            else if (anchorBottom)
            {
                bottom = outerBounds.Bottom;
                top = bottom - innerSize.Height;
            }
            else
            {
                top = outerBounds.Top + (outerBounds.Height - innerSize.Height) / 2;
                bottom = top + innerSize.Height;
            }

            return Rectangle.FromLTRB(left, top, right, bottom);
        }

        public static int Round(float value)
        {
            return (int)Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public static Rectangle Round(RectangleF rect)
        {
            return new Rectangle(
                Round(rect.Left), 
                Round(rect.Top), 
                Round(rect.Width), 
                Round(rect.Height));
        }
    }

    public static class AnchorStylesExtensions
    {
        public static bool HasFlag(this AnchorStyles @this, AnchorStyles flag)
        {
            return (@this & flag) != AnchorStyles.None;
        }
    }
}