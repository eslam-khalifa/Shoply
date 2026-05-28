using Catalog.Core.Specs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure
{
    public static class SpecificationEvaluator<T> where T : class
    {
        public static IFindFluent<T, T> GetQuery(IMongoCollection<T> collection, ISpecification<T> spec)
        {
            var query = collection.Find(spec.Filter);

            if (spec.Sort != null)
            {
                query = query.Sort(spec.Sort);
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Limit(spec.Limit);
            }

            return query;
        }
    }
}
