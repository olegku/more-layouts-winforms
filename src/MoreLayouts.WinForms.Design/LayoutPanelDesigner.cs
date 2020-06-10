using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using MoreLayouts.WinForms.Core;

namespace MoreLayouts.WinForms.Design
{
    internal class LayoutPanelDesigner : ScrollableControlDesigner
    {
        public LayoutPanelDesigner()
        {
            AutoResizeHandles = true;
        }

        public override void Initialize(IComponent component)
        {
            MoreDesignerServices.Initialize(component.Site?.GetService<IDesignerHost>());
            base.Initialize(component);
        }

        public virtual Panel Panel => (Panel)Component;

        protected virtual T GetService<T>() => (T) GetService(typeof(T));

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            if (Panel.BorderStyle == BorderStyle.None && Panel.Visible)
            {
                DrawBorder(pe.Graphics);
            }

            base.OnPaintAdornments(pe);
        }

        protected virtual void DrawBorder(Graphics graphics)
        {
            using (var borderPen = CreateBorderPen())
            {
                var rect = Control.ClientRectangle;
                rect.Width--;
                rect.Height--;

                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.DrawRectangle(borderPen, rect);
                graphics.DrawLine(borderPen, rect.GetTopLeft(), rect.GetBottomRight());
                graphics.DrawLine(borderPen, rect.GetTopRight(), rect.GetBottomLeft());
            }
        }

        protected Pen CreateBorderPen()
        {
            var borderColor = (Control.BackColor.GetBrightness() < 0.5)
                ? ControlPaint.Light(Control.BackColor)
                : ControlPaint.Dark(Control.BackColor);

            return new Pen(borderColor)
            {
                DashOffset = 0.5f,
                DashPattern = new[] { 2f, 2f }
            };
        }
    }
}