using System;
using AutoMapper;

namespace PetrolMuffin.AutoMapper.Extensions
{
    internal sealed class MappingFromFunc<TSource, TDestination, TSourceProp, TResult> : IMappingFromFunc<TSource, TDestination, TSourceProp, TResult>
    {
        public IMappingExpression<TSource, TDestination>         MappingExpression { get; }
        public Func<TSource, TDestination, TSourceProp, TResult> FromExpression    { get; }

        internal MappingFromFunc(IMappingExpression<TSource, TDestination> mappingExpression, Func<TSource, TDestination, TSourceProp, TResult> fromExpression)
        {
            MappingExpression = mappingExpression;
            FromExpression = fromExpression;
        }
    }
}