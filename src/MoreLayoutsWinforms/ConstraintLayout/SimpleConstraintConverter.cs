using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MoreLayoutsWinforms.ConstraintLayout
{
    internal class SimpleConstraintConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) ||
                   base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                var constant = int.Parse(stringValue);
                return new SimpleConstraint(null, ConstraintProperty.None, constant);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || 
                   base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is SimpleConstraint simpleConstraint)
            {
                if (destinationType == typeof(InstanceDescriptor))
                {
                    return ConvertToInstanceDescriptor(simpleConstraint);
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        private static object ConvertToInstanceDescriptor(SimpleConstraint simpleConstraint)
        {
            if (simpleConstraint.Control == null && 
                simpleConstraint.Property == ConstraintProperty.None)
            {
                var constructorInfo = GetConstructorInfo(typeof(int));
                return new InstanceDescriptor(constructorInfo, new object[]
                {
                    simpleConstraint.Constant
                });
            }
            else
            {
                var constructorInfo = GetConstructorInfo(typeof(Control), typeof(ConstraintProperty), typeof(int));
                return new InstanceDescriptor(constructorInfo, new object[]
                {
                    simpleConstraint.Control,
                    simpleConstraint.Property,
                    simpleConstraint.Constant
                });
            }
        }

        private static ConstructorInfo GetConstructorInfo(params Type[] ctorArgumentTypes)
        {
            var type = typeof(SimpleConstraint);
            return type.GetConstructor(ctorArgumentTypes) 
                   ?? throw new NotSupportedException(); // TODO: add message
        }
    }
}