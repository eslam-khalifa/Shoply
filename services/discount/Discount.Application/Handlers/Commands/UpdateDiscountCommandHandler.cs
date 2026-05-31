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
    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, CouponModel>
    {
        private readonly IDiscountRepository discountRepository;

        public UpdateDiscountCommandHandler(IDiscountRepository discountRepository)
        {
            this.discountRepository = discountRepository;
        }

        public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = new Coupon
            {
                Amount = request.Amount,
                Description = request.Description,
                Id = request.Id,
                ProductName = request.ProductName
            };
            await discountRepository.UpdateDiscount(coupon);
            return coupon.ToCouponModel();
        }
    }
}
