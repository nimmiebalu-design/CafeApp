using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Queries.GetEmployees
{
    public record GetEmployeesQuery : IRequest<IEnumerable<GetEmployeesDto>>
    {
        public Guid? CafeId { get; }

        public GetEmployeesQuery(Guid? cafeid)
        {
            CafeId = cafeid;
        }
    }

}

