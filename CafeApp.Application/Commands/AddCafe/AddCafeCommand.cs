using CafeApp.Application.Commands.AddEmployee;
using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using MediatR;

namespace CafeApp.Application.Commands.AddCafe
{
    public record AddCafeCommand : IRequest<CafeEntity>
    {
        public AddCafeDto Cafe { get; set; }
        public AddCafeCommand(AddCafeDto cafe)
        {
            Cafe = cafe;
        }
    }
}
