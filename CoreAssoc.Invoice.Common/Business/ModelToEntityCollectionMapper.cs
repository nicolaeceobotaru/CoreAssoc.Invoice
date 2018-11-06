using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;

namespace CoreAssoc.Invoice.Common.Business
{
    public class ModelToEntityCollectionMapper<TSource, TDestination> :
        ITypeConverter<ICollection<TSource>, ICollection<TDestination>> where TDestination : class
    {
        private readonly Func<string, IMapper> _mapper;

        private readonly Func<TDestination, object> _destinationKeyExpression;

        private readonly Func<TSource, object> _sourceKeyExpression;

        public ModelToEntityCollectionMapper(Expression<Func<TSource, object>> sourcePrimaryKey,
            Expression<Func<TDestination, object>> destinationPrimaryKey, Func<string, IMapper> mapper)
        {
            _mapper = mapper;
            _sourceKeyExpression = sourcePrimaryKey.Compile();
            _destinationKeyExpression = destinationPrimaryKey.Compile();
        }

        public ICollection<TDestination> Convert(ICollection<TSource> source, ICollection<TDestination> destination, ResolutionContext context)
        {
            var mapper = _mapper("");
            foreach (var sourceElement in source)
            {
                var matchedDestination = default(TDestination);

                foreach (var destinationElement in destination)
                {
                    var sourcePrimaryKey = GetPrimaryKey(sourceElement, _sourceKeyExpression);
                    var destinationPrimaryKey = GetPrimaryKey(destinationElement, _destinationKeyExpression);

                    if (string.Equals(sourcePrimaryKey, destinationPrimaryKey, StringComparison.OrdinalIgnoreCase))
                    {
                        mapper.Map(sourceElement, destinationElement);
                        matchedDestination = destinationElement;
                        break;
                    }
                }

                if (matchedDestination == null)
                {
                    matchedDestination = mapper.Map<TDestination>(source);
                    destination.Add(matchedDestination);
                }
            }

            return destination;
        }

        private string GetPrimaryKey<TObject>(object entity, Func<TObject, object> expression)
        {
            var tempId = expression.Invoke((TObject)entity);
            var id = System.Convert.ToString(tempId);
            return id;
        }
    }
}