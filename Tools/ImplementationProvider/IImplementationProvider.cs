using System;
using System.Collections.Generic;

namespace Tools.ImplementationProvider
{
    /// <summary>  
    ///  Interface to provide implementations of a type
    /// <typeparam name="T">Type of which you want the implementations from</typeparam>  
    /// </summary>  
    public interface IImplementationInstanceProvider<out T>
    {
        IEnumerable<T> Provide();
    }
    public interface IImplementationTypeProvider<out T>
    {
        IEnumerable<Type> Provide();
    }
}