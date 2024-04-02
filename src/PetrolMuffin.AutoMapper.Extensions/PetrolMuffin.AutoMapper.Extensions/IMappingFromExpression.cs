using System;
using System.Linq.Expressions;
using AutoMapper;
using JetBrains.Annotations;

namespace PetrolMuffin.AutoMapper.Extensions
{
    [PublicAPI]
    public interface IMappingFromExpression<TSource, TDestination, TProperty>
    {
        /// <summary>
        ///   The mapping expression to which the mapping is being added.
        /// </summary>
        IMappingExpression<TSource, TDestination> MappingExpression { get; }
        
        /// <summary>
        ///   The expression that will be used to map the source property to the destination property.
        /// </summary>
        Expression<Func<TSource, TProperty>>      FromExpression    { get; }
    }
}