using System;
using System.Linq.Expressions;
using AutoMapper;
using JetBrains.Annotations;

namespace PetrolMuffin.AutoMapper.Extensions
{
    [PublicAPI]
    public static class MapperExtensions
    {
        /// <summary>
        ///   Adds a mapping from the source property
        /// </summary>
        /// <param name="mappingExpression">Source mapping expression</param>
        /// <param name="fromExpression">Source property expression</param>
        /// <typeparam name="TSource">The source type</typeparam>
        /// <typeparam name="TDest">The destination type</typeparam>
        /// <typeparam name="TProp">The source property type</typeparam>
        /// <returns>Mapping from expression</returns>
        /// <remarks>Always use this method first when creating a mapping. Then use the <see cref="To{TSource,TDest,TProp}(IMappingFromExpression{TSource,TDest,TProp},Expression{Func{TDest,TProp}})"/> method to complete the mapping.</remarks>
        public static IMappingFromExpression<TSource, TDest, TProp> From<TSource, TDest, TProp>(this IMappingExpression<TSource, TDest> mappingExpression,
                                                                                                Expression<Func<TSource, TProp>> fromExpression) =>
            new MappingFromExpression<TSource, TDest, TProp>(mappingExpression, fromExpression);

        /// <summary>
        ///   Adds a mapping from the source property
        /// </summary>
        /// <param name="mappingExpression">Source mapping expression</param>
        /// <param name="fromExpression">Source property expression</param>
        /// <typeparam name="TSource">The source type</typeparam>
        /// <typeparam name="TDest">The destination type</typeparam>
        /// <typeparam name="TSourceProp">The source property type</typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <returns>Mapping from function</returns>
        /// <remarks>Always use this method first when creating a mapping. Then use the <see cref="To{TSource,TDest,TProp,TResult}(IMappingFromFunc{TSource,TDest,TProp,TResult},Expression{Func{TDest,TProp}})"/> method to complete the mapping.</remarks>
        public static IMappingFromFunc<TSource, TDest, TSourceProp, TResult> From<TSource, TDest, TSourceProp, TResult>(
            this IMappingExpression<TSource, TDest> mappingExpression, Func<TSource, TDest, TSourceProp, TResult> fromExpression) =>
            new MappingFromFunc<TSource, TDest, TSourceProp, TResult>(mappingExpression, fromExpression);

        /// <summary>
        ///   Adds a mapping from the source property
        /// </summary>
        /// <param name="mapping">Source mapping</param>
        /// <param name="toExpression">Destination property expression</param>
        /// <typeparam name="TSource">The source type</typeparam>
        /// <typeparam name="TDest">The destination type</typeparam>
        /// <typeparam name="TProp">The source property type</typeparam>
        /// <returns>Mapping expression</returns>
        public static IMappingExpression<TSource, TDest> To<TSource, TDest, TProp>(this IMappingFromExpression<TSource, TDest, TProp> mapping,
                                                                                   Expression<Func<TDest, TProp>> toExpression) =>
            mapping.MappingExpression.ForMember(toExpression, source => source.MapFrom(mapping.FromExpression));

        /// <summary>
        ///   Adds a mapping from the source property
        /// </summary>
        /// <param name="mapping">Source mapping</param>
        /// <param name="toExpression">Destination property expression</param>
        /// <typeparam name="TSource">The source type</typeparam>
        /// <typeparam name="TDest">The destination type</typeparam>
        /// <typeparam name="TProp">The source property type</typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <returns>Mapping expression</returns>
        public static IMappingExpression<TSource, TDest> To<TSource, TDest, TProp, TResult>(this IMappingFromFunc<TSource, TDest, TProp, TResult> mapping,
                                                                                            Expression<Func<TDest, TProp>> toExpression) =>
            mapping.MappingExpression.ForMember(toExpression, source => source.MapFrom(mapping.FromExpression));
    }
}