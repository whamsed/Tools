using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tools.ImplementationProvider;

namespace Tools.Configuration.Section
{
    public static class ConfigurationSectionExtension
    {
        public static IServiceCollection ConfigureConfigurationSections(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            var configSections = ImplementationResolver.GetAllImplementationInstancesInProjectFor<IConfigSection>();

            foreach (var configSection in configSections)
            {
                var type = configSection.GetType();
                var configSectionName = type.Name;
                
                if (configSectionName.EndsWith("Config", StringComparison.OrdinalIgnoreCase))
                {
                    configSectionName = configSectionName.Substring(0,  configSectionName.LastIndexOf("Config", StringComparison.OrdinalIgnoreCase));
                }
                var appConfigSection = configuration.GetSection(configSectionName).Get(type) ?? Activator.CreateInstance(type);
                serviceCollection.AddSingleton(type, appConfigSection);
            }

            return serviceCollection;
        }
    }
}