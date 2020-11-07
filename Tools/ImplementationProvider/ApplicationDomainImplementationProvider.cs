using System;
using System.Collections.Generic;
using System.Linq;

namespace Tools.ImplementationProvider
{
    /// <inheritdoc />
    /// <summary>  
    ///  Provides all implementations of a type within the execution context of the application domain
    /// </summary>
    /// <remarks>Use with caution in regards of performance. Should only be used if needed.</remarks> 
    public class ApplicationDomainImplementationProvider<T> : IImplementationTypeProvider<T>
    {
        public IEnumerable<Type> Provide()
        {
            return typeof(T).IsInterface
                ? AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(p => typeof(T).IsAssignableFrom(p) && !p.IsAbstract)
                    .Select(t => t)
                : AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(p => p.IsSubclassOf(typeof(T)) && !p.IsAbstract)
                    .Select(t => t);
        }
    }
}