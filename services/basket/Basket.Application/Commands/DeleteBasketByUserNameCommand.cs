using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commands
{
    // Unit in mediatr is like void, it means the command doesn't return any data
    // it is a readonly struct that has a static member called value which we use to return from the handler
    public class DeleteBasketByUserNameCommand : IRequest<Unit>
    {
        public string UserName { get; set; }
        public DeleteBasketByUserNameCommand(string userName)
        {
            UserName = userName;
        }
    }
}
