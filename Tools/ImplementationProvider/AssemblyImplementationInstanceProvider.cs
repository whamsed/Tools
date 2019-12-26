using System;
using System.Collections.Generic;
using System.Linq;

namespace Tools.ImplementationProvider
{
    /// <inheritdoc />
    /// <summary>  
    ///  Provides all implementations of a type within its own assembly
    /// </summary>
    /// <remarks>Should be used as default, regarding performance</remarks> 
    public class AssemblyImplementationInstanceProvider<T> : IImplementationInstanceProvider<T>
    {
        public IEnumerable<T> Provide()
        {
            return typeof(T).IsInterface
                ? typeof(T)
                    .Assembly.GetTypes()
                    .Where(p => typeof(T).IsAssignableFrom(p) && !p.IsAbstract)
                    .Select(t => (T) Activator.CreateInstance(t))
                : typeof(T)
                    .Assembly.GetTypes()
                    .Where(p => p.IsSubclassOf(typeof(T)) && !p.IsAbstract)
                    .Select(t => (T) Activator.CreateInstance(t));
        }
    }
}