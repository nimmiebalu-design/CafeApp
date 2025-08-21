using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.DeleteCafe
{
    public record DeleteCafeCommand :IRequest<bool>
    {
        public Guid CafeId { get; set; }
        public DeleteCafeCommand(Guid cafeid)
        {
            CafeId = cafeid;
        }
       
    }
}
