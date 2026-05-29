using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handlers.Commands
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
    {
        private readonly IBasketRepository basketRepository;

        public CreateShoppingCartCommandHandler(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            // TODO: integrate with discount service
            var shoppingCart = await basketRepository.UpdateBasketAsync(new Core.Entities.ShoppingCart
            {
                UserName = request.UserName,
                Items = request.Items.Select(scir => scir.ToShoppingCartItem()).ToList()
            });
            shoppingCart = await basketRepository.UpdateBasketAsync(shoppingCart);
            return shoppingCart.ToShoppingCartResponse();
        }
    }
}
