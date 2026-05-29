using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            this.redisCache = redisCache;
        }

        public async Task DeleteBasket(string userName)
        {
            var basket = await redisCache.GetStringAsync(userName);
            if (basket is not null)
            {
                await redisCache.RemoveAsync(userName);
            }
        }

        public async Task<ShoppingCart> GetBasketAsync(string userName)
        {
            var basket = await redisCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart shoppingCart)
        {
            var basket = await redisCache.GetStringAsync(shoppingCart.UserName);
            if (basket is null)
            {
                await redisCache.SetStringAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));
                return await GetBasketAsync(shoppingCart.UserName);
            }
            else
            {
                return await GetBasketAsync(shoppingCart.UserName);
            }
        }
    }
}
