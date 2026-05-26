using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool?>
    {
        private readonly IProductRepository productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<bool?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productFromCommand = request.ToProduct();
            var isProductUpdated = await productRepository.UpdateAsync(productFromCommand);
            return isProductUpdated;
        }
    }
}
