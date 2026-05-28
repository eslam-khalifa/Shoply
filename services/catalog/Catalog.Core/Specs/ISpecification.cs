using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Specs
{
    public interface ISpecification<T>
    {
        FilterDefinition<T>? Filter { get; }
        SortDefinition<T>? Sort { get; }
        int Limit { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
