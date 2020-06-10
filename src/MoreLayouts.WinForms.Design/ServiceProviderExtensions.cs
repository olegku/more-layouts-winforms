using System;
using System.ComponentModel.Design;

namespace MoreLayouts.WinForms.Design
{
    internal static class ServiceProviderExtensions
    {
        public static T GetService<T>(this IServiceProvider serviceProvider) => (T)serviceProvider.GetService(typeof(T));

        public static void SubstituteService<T>(this IServiceContainer serviceContainer, Func<IServiceContainer, T, T> factory)
        {
            var serviceType = typeof(T);
            var originalService = (T)serviceContainer.GetService(serviceType);
            serviceContainer.RemoveService(serviceType);

            var newService = factory(serviceContainer, originalService);
            serviceContainer.AddService(serviceType, newService);
        }
    }
}