using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MoreLayoutsWinforms
{
    public static class ControlExtensions
    {
        private static readonly Func<Control, Rectangle> _delegateGetSpecifiedBounds;
        private static readonly Action<Control, Rectangle, BoundsSpecified> _delegateSetBounds;

        static ControlExtensions()
        {
            var assemblyWinforms = typeof(Control).Assembly;

            // System.Windows.Forms.Layout.CommonProperties::Rectangle GetSpecifiedBounds(IArrangedElement element)
            var methodGetSpecifiedBounds = GetMethodInfo(
                assemblyWinforms,
                "System.Windows.Forms.Layout.CommonProperties",
                "GetSpecifiedBounds",
                BindingFlags.Static | BindingFlags.NonPublic);
            _delegateGetSpecifiedBounds = (Func<Control, Rectangle>)Delegate.CreateDelegate(
                typeof(Func<Control, Rectangle>),
                methodGetSpecifiedBounds);

            // System.Windows.Forms.Layout.IArrangedElement::void SetBounds(Rectangle bounds, BoundsSpecified specified)
            var methodSetBounds = GetMethodInfo(
                assemblyWinforms,
                "System.Windows.Forms.Layout.IArrangedElement",
                "SetBounds",
                BindingFlags.Instance | BindingFlags.Public);
            _delegateSetBounds = (Action<Control, Rectangle, BoundsSpecified>)Delegate.CreateDelegate(
                typeof(Action<Control, Rectangle, BoundsSpecified>),
                methodSetBounds);

            MethodInfo GetMethodInfo(Assembly assembly, string typeName, string methodName, BindingFlags bindingFlags)
            {
                var type = assembly.GetType(typeName) ??
                           throw new InvalidOperationException($"Type '{typeName}' not found");
                return type.GetMethod(methodName, bindingFlags) ??
                       throw new InvalidOperationException($"Method '{methodName}' not found in type '{typeName}'");
            }
        }

        public static Size GetSpecifiedSize(this Control control)
        {
            var specifiedBounds = _delegateGetSpecifiedBounds.Invoke(control);
            return specifiedBounds.Size;
        }

        public static void Arrange(this Control control, Rectangle bounds)
        {
            _delegateSetBounds.Invoke(control, bounds, BoundsSpecified.None);
        }

        public static Control VerifyParent(this Control control, Control parentControl)
        {
            if (control == null) throw new ArgumentNullException(nameof(control));
            if (control.Parent != parentControl)
            {
                throw new InvalidOperationException("Not a child");
            }

            return control;
        }
    }
}