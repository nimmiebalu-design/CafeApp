using CafeApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.DeleteCafe
{
    public class DeleteCafeCommandHandler:IRequestHandler<DeleteCafeCommand, bool>
    {
        private readonly ICafeRepository _cafeRepository;
        public DeleteCafeCommandHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }
        public async Task<bool> Handle(DeleteCafeCommand request, CancellationToken cancellationToken)
        {
            if (request.CafeId == Guid.Empty)
            {
                throw new ArgumentException("Cafe ID cannot be null or empty.", nameof(request.CafeId));
            }
            // Validate that the cafe exists before attempting to delete
            var existingCafe = await _cafeRepository.GetCafeByIdAsync(request.CafeId);
            if(existingCafe == null)
            {
                return false; // Cafe does not exist, nothing to delete
            }
            await _cafeRepository.DeleteCafeAsync(existingCafe);
            return true;
;        }
    }
}
