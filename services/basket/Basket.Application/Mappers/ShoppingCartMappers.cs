using Basket.Application.Responses;
using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Mappers
{
    public static class ShoppingCartMappers
    {
        public static ShoppingCartItemResponse? ToShoppingCartItemResponse(this ShoppingCartItem shoppingCartItem)
        {
            if (shoppingCartItem is null)
                return null;
            return new ShoppingCartItemResponse
            {
                Quantity = shoppingCartItem.Quantity,
                UnitPrice = shoppingCartItem.UnitPrice,
                ProductId = shoppingCartItem.ProductId,
                ProductImageUrl = shoppingCartItem.ProductImageUrl,
                ProductName = shoppingCartItem.ProductName
            };
        }

        public static ShoppingCartResponse? ToShoppingCartResponse(this ShoppingCart shoppingCart)
        {
            if (shoppingCart is null)
                return null;
            return new ShoppingCartResponse
            {
                UserName = shoppingCart.UserName,
                Items = shoppingCart.Items.Select(sci => sci?.ToShoppingCartItemResponse()).ToList()
            };
        }
    }
}
