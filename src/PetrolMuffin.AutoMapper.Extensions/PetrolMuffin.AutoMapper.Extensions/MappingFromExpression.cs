using System;
using System.Linq.Expressions;
using AutoMapper;

namespace PetrolMuffin.AutoMapper.Extensions
{
    internal sealed class MappingFromExpression<TSource, TDestination, TProperty> : IMappingFromExpression<TSource, TDestination, TProperty>
    {
        public IMappingExpression<TSource, TDestination> MappingExpression { get; }
        public Expression<Func<TSource, TProperty>>      FromExpression    { get; }

        internal MappingFromExpression(IMappingExpression<TSource, TDestination> mappingExpression, Expression<Func<TSource, TProperty>> fromExpression)
        {
            MappingExpression = mappingExpression;
            FromExpression = fromExpression;
        }
    }
}