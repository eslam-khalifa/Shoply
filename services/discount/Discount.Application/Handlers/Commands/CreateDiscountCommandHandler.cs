using Discount.Application.Commands;
using Discount.Application.Mappers;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Handlers.Commands
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, CouponModel>
    {
        private readonly IDiscountRepository discountRepository;

        public CreateDiscountCommandHandler(IDiscountRepository discountRepository)
        {
            this.discountRepository = discountRepository;
        }

        public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = new Coupon
            {
                ProductName = request.ProductName,
                Amount = request.Amount,
                Description = request.Description
            };
            await discountRepository.CreateDiscount(coupon);
            var couponModel = coupon.ToCouponModel();
            return couponModel;
        }
    }
}
