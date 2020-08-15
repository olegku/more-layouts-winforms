using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;
using MoreLayouts.WinForms.Core;
using MoreLayouts.WinForms.StackLayout;

namespace MoreLayouts.WinForms.Design
{
    internal class StackLayoutPanelDesigner : LayoutPanelDesigner, IChildDesignerFilter
    {
        private Control _insertionBeforeControl;
        private Adorner _insertionAdorner;

        #region Imported Services

        [Import] public ISelectionService SelectionService { get; set; }
        [Import] public IDebugOutputPane DebugOutput { get; set; }
        [Import] public new BehaviorService BehaviorService { get; set; }
        [Import] public IDesignerHost DesignerHost { get; set; }

        #endregion

        public new StackLayoutPanel Panel => (StackLayoutPanel)Component;

        public override bool ParticipatesWithSnapLines { get; } = false;

        protected override bool AllowSetChildIndexOnDrop { get; } = false;

        void IChildDesignerFilter.FilterProperties(IComponent component, IDictionary properties)
        {
            // Dock property is not used by StackLayout, but messes with Anchor property which is used, so remove it in design-mode
            properties.Remove("Dock");
        }

        #region Drag Handlers

        protected override void OnDragOver(DragEventArgs de)
        {
            base.OnDragOver(de);

            var insertionBeforeControl = Panel.Controls
                .Cast<Control>()
                .Except(SelectionService.GetSelectedComponents().OfType<Control>())
                .FirstOrDefault(child =>
                {
                    var childRect = child.RectangleToScreen(child.ClientRectangle);
                    return (Panel.Orientation == Orientation.Horizontal)
                        ? de.X <= childRect.GetCenter()
                        : de.Y <= childRect.GetMiddle();
                });

            UpdateInsertionDisplay(insertionBeforeControl);
        }

        protected override void OnDragDrop(DragEventArgs de)
        {
            base.OnDragDrop(de);

            var insertionIndex = (_insertionBeforeControl == null)
                ? Panel.Controls.Count
                : Panel.Controls.IndexOf(_insertionBeforeControl);

            SelectionService.GetSelectedComponents()
                .OfType<Control>()
                .ToList()
                .ForEach(control =>
                {
                    var currentIndex = Panel.Controls.GetChildIndex(control);
                    if (currentIndex >= 0 && currentIndex < insertionIndex)
                    {
                        insertionIndex--;
                    }

                    Panel.Controls.SetChildIndex(control, insertionIndex++);
                });

            ClearInsertionDisplay();
        }

        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);

            ClearInsertionDisplay();
        }

        #endregion

        private void ClearInsertionDisplay()
        {
            _insertionBeforeControl = null;

            if (_insertionAdorner != null)
            {
                ClearInsertionCursorGlyphAndInvalidate();
                BehaviorService.Adorners.Remove(_insertionAdorner);
                _insertionAdorner = null;
            }
        }

        private void UpdateInsertionDisplay(Control insertionBeforeControl)
        {
            if (_insertionAdorner == null)
            {
                _insertionAdorner = new Adorner();
                BehaviorService.Adorners.Add(_insertionAdorner);
            }
            else
            {
                _insertionAdorner.Enabled = true;
            }

            if (_insertionBeforeControl != insertionBeforeControl)
            {
                _insertionBeforeControl = insertionBeforeControl;
                ClearInsertionCursorGlyphAndInvalidate();
                AddInsertionCursorGlyphAndInvalidate();
            }
        }

        private void ClearInsertionCursorGlyphAndInvalidate()
        {
            if (_insertionAdorner.Glyphs.Count > 0 &&
                _insertionAdorner.Glyphs[0] is StackInsertionCursorGlyph glyph)
            {
                _insertionAdorner.Glyphs.Clear();
                BehaviorService.Invalidate(glyph.Bounds);
            }
        }

        private void AddInsertionCursorGlyphAndInvalidate()
        {
            if (_insertionBeforeControl != null)
            {
                var panelBounds = BehaviorService.ControlRectInAdornerWindow(Panel);

                var cursorPosition = BehaviorService
                    .ControlRectInAdornerWindow(_insertionBeforeControl)
                    .Inflate(_insertionBeforeControl.Margin)
                    .GetTopLeft();

                var glyph = new StackInsertionCursorGlyph(Panel.BackColor, panelBounds, Panel.Orientation, cursorPosition);
                _insertionAdorner.Glyphs.Add(glyph);

                BehaviorService.Invalidate(glyph.Bounds);
            }
        }
    }
}