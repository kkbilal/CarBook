using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Commands.FooterCommands
{
    public class RemoveFooterCommand : IRequest
    {
        public int FooterId { get; set; }

        public RemoveFooterCommand(int footerId)
        {
            FooterId = footerId;
        }
    }
}
