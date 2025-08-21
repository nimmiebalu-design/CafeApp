using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.AddCafe
{
    public class AddCafeHandler(ICafeRepository CafeRepository) : IRequestHandler<AddCafeCommand, CafeEntity>
    {
        public async Task<CafeEntity> Handle(AddCafeCommand request, CancellationToken cancellationToken)
        {
            var cafeentity = new CafeEntity
            {
                id = Guid.NewGuid(),
                name = request.Cafe.name,
                description = request.Cafe.description,
                location = request.Cafe.location,
                logo = request.Cafe.logo,
            };
            return await CafeRepository.AddCafeAsync(cafeentity);
        }
    }
}
