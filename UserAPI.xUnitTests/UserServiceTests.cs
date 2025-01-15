using WebUser.Api.Models;
using WebUser.Api.Repositories;
using WebUser.Api.Services;

namespace UserAPI.xUnitTests
{
    public class UserServiceTests
    {
        private readonly UserService _demoService;
        private readonly IUserRepository _mockRepository;
        public UserServiceTests()
        {
            _mockRepository = new UserRepository();
            _demoService = new UserService(_mockRepository);
        }
        [Fact]
        public void GetUserById_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var expectedUser = new User { Id = 10, Name = "John Doe", Email = "john@example.com" };
            // Act
            var result = _demoService.GetUserById(userId);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUser.Id, result.Id);
            Assert.Equal(expectedUser.Name, result.Name);
            Assert.Equal(expectedUser.Email, result.Email);
        }
        [Fact]
        public void GetAllUsers_ReturnsListOfUsers()
        {
            // Arrange
         var expectedUsers = new List<User>
         {
            new User { Id = 1, Name = "John Doe", Email = "john@example.com" },
            new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com" }
         };
         // Act
         var result = _demoService.GetAllUsers();
         // Assert
         Assert.NotNull(result);

         Assert.Equal(expectedUsers.Count, result.Count());
        }
    }
}
