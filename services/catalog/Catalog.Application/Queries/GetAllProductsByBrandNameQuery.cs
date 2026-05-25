using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public class GetAllProductsByBrandNameQuery : IRequest<IList<ProductResponseDto>>
    {
        public string Name { get; }

        public GetAllProductsByBrandNameQuery(string Name)
        {
            this.Name = Name;
        }
    }
}
