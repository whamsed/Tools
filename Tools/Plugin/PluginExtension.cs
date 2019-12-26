using Microsoft.Extensions.DependencyInjection;
using Tools.ImplementationProvider;

namespace Tools.Plugin
{
    public static class PluginExtension
    {
        public static IServiceCollection ConfigurePlugins<T>(this IServiceCollection serviceCollection)
        {
            
            var pluginTypes = ImplementationResolver.GetAllImplementationTypesInProjectFor<T>();

            foreach (var pluginType in pluginTypes)
            {
                serviceCollection.Add(new ServiceDescriptor(typeof(T), pluginType, ServiceLifetime.Singleton));
            }

            return serviceCollection;
        }
    }
}