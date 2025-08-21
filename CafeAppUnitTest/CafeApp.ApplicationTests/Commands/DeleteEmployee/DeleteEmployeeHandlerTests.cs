using CafeApp.Application.Commands.DeleteEmployee;
using CafeApp.Application.Queries.GetEmployees;
using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using Moq;
using System.Reflection.Metadata;

namespace CafeAppTests.CafeApp.ApplicationTests.Commands.DeleteEmployee
{
    public class DeleteEmployeeHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepo;
        private readonly DeleteEmployeeCommandHandler _deleteEmployeeHandler;
        public DeleteEmployeeHandlerTests()
        {
            // Initialize any required services or dependencies here
            _mockEmployeeRepo = new Mock<IEmployeeRepository>();
            _deleteEmployeeHandler = new DeleteEmployeeCommandHandler(_mockEmployeeRepo.Object);
        }
        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenEmployeeExists()
        {
            
        }
        [Fact]
        public async Task Handle_ShouldReturnFalse_WhenEmployeeDoesNotExist()
        {
           
        }
    }

    
}