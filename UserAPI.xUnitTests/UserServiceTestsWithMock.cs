using Moq;
using WebUser.Api.Models;
using WebUser.Api.Repositories;
using WebUser.Api.Services;

namespace UserAPI.xUnitTests
{
    public class UserServiceTestsWithMock
    {
        private readonly UserService _demoService;
        private readonly Mock<IUserRepository> _mockRepository;
        public UserServiceTestsWithMock()
        {
            _mockRepository = new Mock<IUserRepository>();
            _demoService = new UserService(_mockRepository.Object);
        }
        [Fact]
        public void GetUserById_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var expectedUser = new User { Id = 10, Name = "John Doe1", Email = "john@example.com" };
            _mockRepository.Setup(repo => repo.GetUserById(userId)).Returns(expectedUser);
            // Act
            var result = _demoService.GetUserById(userId);
            // Assert
            Assert.NotNull(result); 
            Assert.Equal(expectedUser.Id, result.Id); 
            Assert.Equal(expectedUser.Name, result.Name); 
            Assert.Equal(expectedUser.Email, result.Email); 
        }
    }
}
