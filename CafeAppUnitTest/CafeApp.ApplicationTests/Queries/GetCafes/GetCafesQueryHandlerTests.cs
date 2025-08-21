using CafeApp.Application.Queries.GetCafes;
using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAppTests.CafeApp.ApplicationTests.Queries.GetCafes
{
    public class GetCafesQueryHandlerTests
    {
        [Fact]
        public async Task GetCafesQueryHandler_ShouldReturnAllListOfCafes_WhenLocationIsNull()
        {
            // Arrange
            Guid cafeid = Guid.Parse("FF40F939-52BB-4511-AA3B-07B519403A08");
            var mockCafeRepository = new Mock<ICafeRepository>();
            mockCafeRepository.Setup(repo => repo.GetCafesAsync())
                .ReturnsAsync(new List<CafeEntity>
                {
                    new CafeEntity { id = Guid.NewGuid(), name = "Cafe Mocha", description="A cozy cafe with a variety of coffee and snacks.", location = "Downtown" }
                });
            var handler = new GetCafesQueryHandler(mockCafeRepository.Object);
            // Act
            var result = await handler.Handle(new GetCafesQuery(null), CancellationToken.None);
            // Assert
            Assert.NotNull(result);
            Assert.Contains(result, c => c.location == "Downtown");
        }
        [Fact]
        public async Task GetCafesQueryHandler_ShouldReturnListOfCafesWithHightestEmpCountForGivenLocation()
        {
            // Arrange
            Guid cafeid = Guid.Parse("FF40F939-52BB-4511-AA3B-07B519403A08");
            var mockCafeRepository = new Mock<ICafeRepository>();
            mockCafeRepository.Setup(repo => repo.GetCafesAsync())
                .ReturnsAsync(new List<CafeEntity>
                {
                    new CafeEntity { id = cafeid, name = "Cafe Mocha", description="A cozy cafe with a variety of coffee and snacks.", location = "Downtown" },

                });
            var handler = new GetCafesQueryHandler(mockCafeRepository.Object);
            // Act
            var result = await handler.Handle(new GetCafesQuery("Downtown"), CancellationToken.None);
            // Assert
            Assert.NotNull(result);
            Assert.Contains(result, c => c.name == "Cafe Mocha");
            Assert.Contains(result, c => c.employee_count == 2);
        }
       
        [Fact]
        public async Task GetCafesQueryHandler_ShouldReturnEmptyList_WhenNoCafesFound()
        {
            // Arrange
            var mockCafeRepository = new Mock<ICafeRepository>();
            mockCafeRepository.Setup(repo => repo.GetCafesAsync())
                .ReturnsAsync(new List<CafeEntity>());
            var handler = new GetCafesQueryHandler(mockCafeRepository.Object);
            // Act
            var result = await handler.Handle(new GetCafesQuery("NonExistentLocation"), CancellationToken.None);
            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
       
    }
}
