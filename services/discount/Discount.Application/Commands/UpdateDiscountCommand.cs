using Discount.Grpc.Protos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Commands
{
    public class UpdateDiscountCommand : IRequest<CouponModel>
    {
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }

        public UpdateDiscountCommand(string productName, int amount, int id, string description)
        {
            ProductName = productName;
            Amount = amount;
            Id = id;
            Description = description;
        }
    }
}
