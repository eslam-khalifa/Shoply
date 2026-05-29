using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Responses
{
    public class ShoppingCartResponse
    {
        public string UserName { get; set; }
        public List<ShoppingCartItemResponse?> Items { get; set; } = new List<ShoppingCartItemResponse>();

        public ShoppingCartResponse() { }
        public ShoppingCartResponse(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (ShoppingCartItemResponse shoppingCartItem in Items)
                {
                    totalPrice += shoppingCartItem.UnitPrice * shoppingCartItem.Quantity;
                }
                return totalPrice;
            }
        }
    }
}
