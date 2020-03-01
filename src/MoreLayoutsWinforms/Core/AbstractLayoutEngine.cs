using System;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace MoreLayoutsWinforms
{
    public abstract class AbstractLayoutEngine<TLayoutParams, TLayoutElement> : LayoutEngine
        where TLayoutParams : ILayoutParams<TLayoutElement>
        where TLayoutElement : ILayoutElement
    {
        public sealed override bool Layout(object container, LayoutEventArgs layoutEventArgs)
        {
            if (container is TLayoutParams layoutSettings)
            {
                // TODO: add reentrancy check

                var containerControl = (Control)container;
                
                if (ShouldPerformLayout(layoutEventArgs))
                {
                    LayoutOverride(layoutSettings);
                }
                
                return containerControl.AutoSize;
            }

            throw new NotSupportedException(
                $"'{container.GetType().FullName}' does not implement '{typeof(TLayoutParams).FullName}'");
        }

        // TODO: redesign this method to return child rectangles (layout slots)
        protected abstract void LayoutOverride(TLayoutParams layoutParams);

        private bool ShouldPerformLayout(LayoutEventArgs layoutEventArgs)
        {
            return true;
        }
    }
}