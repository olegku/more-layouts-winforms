using System;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace MoreLayoutsWinforms
{
    public abstract class AbstractLayoutEngine<TLayoutParams> : LayoutEngine where TLayoutParams : ILayoutParams
    {
        public sealed override bool Layout(object container, LayoutEventArgs layoutEventArgs)
        {
            if (container is TLayoutParams layoutSettings)
            {
                var containerControl = (Control)container;
                LayoutOverride(layoutSettings, containerControl, layoutEventArgs);
                return containerControl.AutoSize;
            }

            throw new NotSupportedException($"'{container.GetType().FullName}' does not implement '{typeof(TLayoutParams).FullName}'");
        }

        // TODO: redesign this method to return child rectangles (layout slots)
        // TODO: get rid of container and layoutEventArgs
        protected abstract void LayoutOverride(
            TLayoutParams layoutParams,
            Control container,
            LayoutEventArgs layoutEventArgs);
    }
}