using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Queries.GetCafes
{
    public record GetCafesQuery : IRequest<List<GetCafesDto>>

    {
        public string? Location { get; }
        public GetCafesQuery(string? location)
        {
            // This constructor can be used to initialize any properties if needed in the future.
            Location = location;
        }
    }
    
}
