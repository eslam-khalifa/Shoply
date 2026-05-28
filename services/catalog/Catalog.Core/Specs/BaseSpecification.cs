using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Specs
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {

        public FilterDefinition<T> Filter { get; set; } = Builders<T>.Filter.Empty;
        public SortDefinition<T>? Sort { get; private set; }
        public int Skip { get; private set; }
        public int Limit { get; private set; }
        public bool IsPagingEnabled { get; private set; }

        protected void AddFilter(FilterDefinition<T> filter)
        {
            if (Filter != Builders<T>.Filter.Empty)
                Filter = Builders<T>.Filter.And(Filter, filter);
        }

        protected void ApplySort(SortDefinition<T> sort)
        {
            Sort = sort;
        }

        protected void ApplyPaging(int skip, int limit)
        {
            Skip = skip;
            Limit = limit;
            IsPagingEnabled = true;
        }
    }
}
