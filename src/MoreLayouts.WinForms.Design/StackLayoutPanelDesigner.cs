using System;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace MoreLayouts.WinForms.Design
{
    internal class StackLayoutPanelDesigner : LayoutPanelDesigner
    {
        public override bool ParticipatesWithSnapLines { get; } = false;

        protected override bool AllowSetChildIndexOnDrop { get; } = false;

        protected override bool AllowGenericDragBox { get; } = false;

        #region Drag Handlers

        protected override void OnDragDrop(DragEventArgs de)
        {
            base.OnDragDrop(de);

            WriteToDebug($"OnDragDrop", de);

            if (GetService(typeof(ISelectionService)) is ISelectionService selectionService)
            {
                var selectionCount = selectionService.SelectionCount;
                GetService<IDebugOutputPane>().WriteLine("SelectionCount = " + selectionCount);
            }
        }

        protected override void OnDragComplete(DragEventArgs de)
        {
            base.OnDragComplete(de);

            WriteToDebug($"OnDragComplete", de);
        }

        protected override void OnDragEnter(DragEventArgs de)
        {
            base.OnDragEnter(de);

            WriteToDebug($"OnDragEnter", de);
        }

        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);

            GetService<IDebugOutputPane>()?.WriteLine($"OnDragLeave");
        }

        protected override void OnDragOver(DragEventArgs de)
        {
            base.OnDragOver(de);

            WriteToDebug("OnDragOver", de);
        }

        private void WriteToDebug(string name, DragEventArgs de)
        {
            GetService<IDebugOutputPane>()?.WriteLine($"\t{name}(X={de.X}, Y={de.Y}, Effect={de.Effect})");
        }

        #endregion
    }
}