using Discount.Grpc.Protos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Commands
{
    public class CreateDiscountCommand : IRequest<CouponModel>
    {
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public CreateDiscountCommand(string productName, int amount, string description)
        {
            ProductName = productName;
            Amount = amount;
            Description = description;
        }
    }
}
