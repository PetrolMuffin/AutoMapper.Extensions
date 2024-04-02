using System;
using AutoMapper;
using JetBrains.Annotations;

namespace PetrolMuffin.AutoMapper.Extensions
{
    [PublicAPI]
    public interface IMappingFromFunc<TSource, TDestination, in TSourceProp, out TResult>
    {
        /// <summary>
        ///   The mapping expression to which the mapping is being added.
        /// </summary>
        IMappingExpression<TSource, TDestination>         MappingExpression { get; }
        
        /// <summary>
        ///   The function that will be used to map the source property to the destination property.
        /// </summary>
        Func<TSource, TDestination, TSourceProp, TResult> FromExpression    { get; }
    }
}