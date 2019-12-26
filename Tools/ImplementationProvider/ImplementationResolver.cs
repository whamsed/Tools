using System;
using System.Collections.Generic;

namespace Tools.ImplementationProvider
{
    public static class ImplementationResolver
    {
        /// <summary>
        /// Gets all non abstract implementation of a type within its own assembly(!) and returns them in a list
        /// </summary>
        /// <returns>A list with instances of all non abstract implementations of a type</returns>
        public static IEnumerable<T> GetAllImplementationInstancesFor<T>()
        {
            return GetAllImplementationInstancesFor(new AssemblyImplementationInstanceProvider<T>());
        }

        public static IEnumerable<T> GetAllImplementationInstancesFor<T>(IImplementationInstanceProvider<T> implementationProvider)
        {
            return implementationProvider.Provide();
        }

        /// <summary>
        /// Gets all non abstract implementation of a type within the execution context of this application domain and returns them in a list
        /// </summary>
        /// <returns>A list with instances of all non abstract implementations of a type</returns>
        public static IEnumerable<T> GetAllImplementationInstancesInProjectFor<T>()
        {
            return GetAllImplementationInstancesFor(new ApplicationDomainImplementationInstanceProvider<T>());
        }

        public static IEnumerable<Type> GetAllImplementationTypesFor<T>(IImplementationTypeProvider<T> implementationProvider)
        {
            return implementationProvider.Provide();
        }

        public static IEnumerable<Type> GetAllImplementationTypesFor<T>()
        {
            return GetAllImplementationTypesFor(new AssemblyImplementationProvider<T>());
        }

        public static IEnumerable<Type> GetAllImplementationTypesInProjectFor<T>()
        {
            return GetAllImplementationTypesFor(new ApplicationDomainImplementationProvider<T>());
        }
    }
}