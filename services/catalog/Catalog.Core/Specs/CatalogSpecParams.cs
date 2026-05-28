using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Specs
{
    // any specParams contains four info: pagination, searching, sorting and filtering
    public class CatalogSpecParams
    {
        private const int maxPageSize = 80;
        private int pageSize = 10;
        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                if (value > maxPageSize) pageSize = maxPageSize;
                else if (value <= 0) pageSize = 10;
                else pageSize = value;
            }
        }
        public string? BrandId { get; set; }
        public string? TypeId { get; set; }
        public string? Search { get; set; }
        public string? Sort { get; set; }
    }
}
