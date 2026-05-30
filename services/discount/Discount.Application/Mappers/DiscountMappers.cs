using Discount.Core.Entities;
using Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Mappers
{
    public static class DiscountMappers
    {
        public static CouponModel ToCouponModel(this Coupon coupon)
        {
            if (coupon is null)
                return null;
            return new CouponModel
            {
                Id = coupon.Id,
                Amount = coupon.Amount,
                Description = coupon.Description,
                ProductName = coupon.ProductName
            };
        }

        public static Coupon ToCoupon(this CouponModel couponModel)
        {
            if (couponModel is null)
                return null;
            return new Coupon
            {
                Amount = couponModel.Amount,
                Description = couponModel.Description,
                Id = couponModel.Id,
                ProductName = couponModel.ProductName
            };
        }
    }
}
