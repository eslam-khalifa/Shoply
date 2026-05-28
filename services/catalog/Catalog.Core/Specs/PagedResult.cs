using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Specs
{
    public class PagedResult<T> where T : class
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
        public IReadOnlyList<T?> Data { get; set; }

        public PagedResult(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            Data = data;
        }

        public PagedResult()
        {
        }
    }
}
