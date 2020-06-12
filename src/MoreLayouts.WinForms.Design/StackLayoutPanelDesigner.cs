using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;
using MoreLayouts.WinForms.Core;
using MoreLayouts.WinForms.StackLayout;

namespace MoreLayouts.WinForms.Design
{
    internal class StackLayoutPanelDesigner : LayoutPanelDesigner, IChildDesignerFilter
    {
        private Control _insertBeforeControl;

        #region Properties

        public new StackLayoutPanel Panel => (StackLayoutPanel)Component;

        public override bool ParticipatesWithSnapLines { get; } = false;

        protected override bool AllowSetChildIndexOnDrop { get; } = false;

        #endregion

        void IChildDesignerFilter.FilterProperties(IComponent component, IDictionary properties)
        {
            // Dock property is not used by StackLayout, but messes with Anchor property which is used, so remove it in design-mode
            properties.Remove("Dock");
        }

        #region Drag Handlers

        protected override void OnDragOver(DragEventArgs de)
        {
            base.OnDragOver(de);

            var selectionService = GetService<ISelectionService>();
            if (selectionService == null) return;

            _insertBeforeControl = Panel.Controls
                .OfType<Control>()
                .Except(selectionService.GetSelectedComponents().OfType<Control>())
                .FirstOrDefault(child =>
                {
                    var childRect = child.RectangleToScreen(child.ClientRectangle);
                    return (Panel.Orientation == Orientation.Horizontal)
                        ? de.X <= childRect.GetCenter()
                        : de.Y <= childRect.GetMiddle();
                });

            WriteToDebug($" insert before {_insertBeforeControl}");
        }

        protected override void OnDragDrop(DragEventArgs de)
        {
            base.OnDragDrop(de);

            var selectionService = GetService<ISelectionService>();
            if (selectionService == null) return;

            var insertIndex = (_insertBeforeControl == null)
                ? Panel.Controls.Count
                : Panel.Controls.IndexOf(_insertBeforeControl);

            selectionService.GetSelectedComponents()
                .OfType<Control>()
                .ToList()
                .ForEach(control =>
                {
                    var currentIndex = Panel.Controls.GetChildIndex(control);
                    if (currentIndex >= 0 && currentIndex < insertIndex)
                    {
                        insertIndex--;
                    }

                    Panel.Controls.SetChildIndex(control, insertIndex++);
                });
        }

        #endregion

        private void WriteToDebug(string message)
        {
            GetService<IDebugOutputPane>()?.WriteLine(message);
        }
    }
}