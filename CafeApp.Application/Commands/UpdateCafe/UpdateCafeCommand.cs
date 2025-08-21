using CafeApp.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.UpdateCafe
{
    public record UpdateCafeCommand: IRequest<CafeEntity>
    {
        public UpdateCafeDto  CafeDto {get; }
        public UpdateCafeCommand(UpdateCafeDto cafeDto)
        {
            CafeDto = cafeDto;
        }
    }
}
