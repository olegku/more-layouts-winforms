﻿using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using EnvDTE;

namespace MoreLayouts.WinForms.Design
{
    internal class MoreDesignerServices
    {
        private MoreDesignerServices()
        {
        }

        public static void Initialize(IDesignerHost service)
        {
            if (service.GetService<MoreDesignerServices>() != null) return;

            service.AddService(typeof(MoreDesignerServices), new MoreDesignerServices());
            service.AddService(typeof(IDebugOutputPane), (container, type) => new DebugOutputPane(container));
            service.SubstituteService<ITypeDescriptorFilterService>((container, originalService) => new ExtendedTypeDescriptorFilterService(originalService));
        }
    }


    public interface IChildDesignerFilter
    {
        void FilterProperties(IComponent component, IDictionary properties);
    }


    public interface IDebugOutputPane
    {
        void WriteLine(string message);
    }

    internal class ExtendedTypeDescriptorFilterService : ITypeDescriptorFilterService
    {
        private readonly ITypeDescriptorFilterService _originalService;

        public ExtendedTypeDescriptorFilterService(ITypeDescriptorFilterService originalService)
        {
            _originalService = originalService;
        }

        public bool FilterAttributes(IComponent component, IDictionary attributes) => _originalService.FilterAttributes(component, attributes);

        public bool FilterEvents(IComponent component, IDictionary events) => _originalService.FilterEvents(component, events);

        public bool FilterProperties(IComponent component, IDictionary properties) => _originalService.FilterProperties(component, properties) | 
                                                                                      FilterMoreProperties(component, properties);

        private static bool FilterMoreProperties(IComponent component, IDictionary properties)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));
            if (properties == null) throw new ArgumentNullException(nameof(properties));

            if (GetParentDesigner(component) is IChildDesignerFilter childFilter)
            {
                childFilter.FilterProperties(component, properties);
                return true;
            }

            return false;
        }

        private static IDesigner GetParentDesigner(IComponent component)
        {
            var componentDesigner = component.Site?.GetService<IDesignerHost>()?.GetDesigner(component);
            return (componentDesigner as ITreeDesigner)?.Parent;
        }
    }


    internal class DebugOutputPane : IDebugOutputPane
    {
        private readonly IServiceProvider _serviceProvider;

        public DebugOutputPane(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void WriteLine(string message)
        {
            var outputPane = GetDebugOutputPane(_serviceProvider);
            if (outputPane == null) return;

            outputPane.Activate();
            outputPane.OutputString(message + Environment.NewLine);
        }

        public OutputWindowPane GetDebugOutputPane(IServiceProvider serviceProvider)
        {
            const string /*EnvDTE.Constants.*/vsWindowKindOutput = "{34E76E81-EE4A-11D0-AE2E-00A0C90FFFC3}";

            var dte = serviceProvider.GetService<DTE>();
            var outputWindow = (OutputWindow)dte.Windows.Item(vsWindowKindOutput).Object;

            return outputWindow.OutputWindowPanes
                .OfType<OutputWindowPane>()
                .FirstOrDefault(pane => pane.Name == "Debug");
        }
    }

}