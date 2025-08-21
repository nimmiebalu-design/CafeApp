using CafeApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Queries.GetCafes
{
    public class GetCafesQueryHandler: IRequestHandler<GetCafesQuery, List<GetCafesDto>>
    {
        private readonly ICafeRepository _cafeRepository;
        public GetCafesQueryHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }
        public async Task<List<GetCafesDto>> Handle(GetCafesQuery request, CancellationToken cancellationToken)
        {
            var cafes = await _cafeRepository.GetCafesAsync();
            // Filter by location if provided
            if (!string.IsNullOrEmpty(request.Location))
            {
                cafes = cafes.Where(c => c.location.Contains(request.Location, StringComparison.OrdinalIgnoreCase)).ToList();
                // Return empty list if location is invalid (i.e., no match)
                if (!cafes.Any())
                    return new List<GetCafesDto>();
            }
            return cafes.Select(c => new GetCafesDto
            {
                id = c.id,
                name = c.name,
                description = c.description,
                employee_count = c.Employees?.Count() ?? 0,
                location = c.location,
            })
            .OrderByDescending(c => c.employee_count)
            .ToList();
        }
    }
}
