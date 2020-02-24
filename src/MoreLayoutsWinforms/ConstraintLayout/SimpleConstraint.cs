using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace MoreLayoutsWinforms.ConstraintLayout
{
    [TypeConverter(typeof(SimpleConstraintConverter))]
    public struct SimpleConstraint
    {
        public SimpleConstraint(Control control, ConstraintProperty property, int constant)
        {
            Control = control;
            Property = property;
            Constant = constant;
        }

        #region Properties

        public Control Control { get; set; }
        public ConstraintProperty Property { get; set; }
        public int Constant { get; set; }

        #endregion


        internal void AddToSolver(Kiwi.Solver solver)
        {
            // TODO
        }

        public override string ToString()
        {
            if (Control != null && Property != ConstraintProperty.None)
            {
                var result = $"{Control.Name}.{Property}";
                if (Constant != 0)
                {
                    result += $"+ {Constant}";
                }

                return result;
            }

            return $"{Constant}";
        }
    }

    internal class SimpleConstraintConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || 
                   base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var simpleConstraint = (SimpleConstraint)value;
            if (destinationType == typeof(InstanceDescriptor))
            {
                var constructorInfo = GetConstructorInfo(typeof(SimpleConstraint), new[]
                {
                    typeof(Control), 
                    typeof(ConstraintProperty), 
                    typeof(int)
                });
                return new InstanceDescriptor(constructorInfo, new object[]
                {
                    simpleConstraint.Control,
                    simpleConstraint.Property,
                    simpleConstraint.Constant
                });
            }
            
            return base.ConvertTo(context, culture, value, destinationType);
        }

        private static ConstructorInfo GetConstructorInfo(Type type, Type[] ctorArgumentTypes)
        {
            return type.GetConstructor(ctorArgumentTypes) ?? 
                   throw new NotSupportedException(); // TODO: add messages
        }
    }
}