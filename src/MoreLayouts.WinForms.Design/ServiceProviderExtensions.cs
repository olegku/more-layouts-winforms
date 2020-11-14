using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MoreLayouts.WinForms.Design
{
    internal static class ServiceProviderExtensions
    {
        public static T GetService<T>(this IServiceProvider serviceProvider) => (T)serviceProvider.GetService(typeof(T));

        public static bool TryGetService<T>(this IServiceProvider serviceProvider, out T service)
        {
            service = (T)serviceProvider?.GetService(typeof(T));
            return service != null;
        }

        public static bool TryGetService<T>(this IComponent component, out T service)
        {
            service = (T)component?.Site?.GetService(typeof(T));
            return service != null;
        }

        public static bool TryGetService<T>(this IDesigner designer, out T service)
        {
            service = (T)designer?.Component?.Site?.GetService(typeof(T));
            return service != null;
        }

        public static void SubstituteService<T>(this IServiceContainer serviceContainer, Func<IServiceContainer, T, T> factory)
        {
            var serviceType = typeof(T);
            var originalService = (T)serviceContainer.GetService(serviceType);
            serviceContainer.RemoveService(serviceType);

            var newService = factory(serviceContainer, originalService);
            serviceContainer.AddService(serviceType, newService);
        }

        public static IDisposable ChangingComponentProperty(this IComponent component, string propertyName)
        {
            if (!component.TryGetService(out IComponentChangeService componentChangeService))
            {
                return null;
            }

            var property = TypeDescriptor.GetProperties(component)[propertyName];
            var oldValue = property.GetValue(component);
            componentChangeService.OnComponentChanging(component, property);

            return new DisposableAction(() =>
            {
                var newValue = property.GetValue(component);
                componentChangeService.OnComponentChanged(component, property, oldValue, newValue);
            });
        }

        private class DisposableAction : IDisposable
        {
            private readonly Action _action;
            public DisposableAction(Action action) => _action = action;
            public void Dispose() => _action?.Invoke();
        }
    }
}