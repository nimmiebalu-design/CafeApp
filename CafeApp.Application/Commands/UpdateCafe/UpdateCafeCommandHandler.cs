using CafeApp.Application.Commands.AddEmployee;
using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.UpdateCafe
{
    public class UpdateCafeCommandHandler(ICafeRepository CafeRepository) : IRequestHandler<UpdateCafeCommand, CafeEntity>
    {
        public async Task<CafeEntity> Handle(UpdateCafeCommand request, CancellationToken cancellationToken)
            {
            if (request.CafeDto != null)
            {
                var existingCafe = await CafeRepository.GetCafeByIdAsync(request.CafeDto.id);
                if (existingCafe == null) return null;
                existingCafe.name = request.CafeDto.name;
                existingCafe.location = request.CafeDto.location;
                existingCafe.description = request.CafeDto.description;
                existingCafe.logo = request.CafeDto.logo;
                return await CafeRepository.UpdateCafeAsync(existingCafe);         
            }
            throw new ArgumentException("Cafe not found or invalid data provided.", nameof(request.CafeDto));

        }

    }
}
