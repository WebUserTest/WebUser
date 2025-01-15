using Microsoft.AspNetCore.Mvc;
using Moq;
using WebUser.Api.Controllers;
using WebUser.Api.Models;
using WebUser.Api.Services;

namespace UserAPI.xUnitTests
{
    public class UsersControllerTests
    {
        private readonly UsersController _controller;
        private readonly Mock<IUserService> _mockService;
        public UsersControllerTests()
        {
            _mockService = new Mock<IUserService>();
            _controller = new UsersController(_mockService.Object);
        }
        [Fact]
        public void GetUser_ReturnsOkResultWithUser()
        {
            // Arrange
            var userId = 1;
            var expectedUser = new User { Id = 1, Name = "John Doe", Email = "john@example.com" };
            _mockService.Setup(service => service.GetUserById(userId)).Returns(expectedUser);
            // Act
            var result = _controller.GetUserById(userId) as OkObjectResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedUser, result.Value);
        }
        [Fact]
        public void GetUser_ReturnsNotFoundWhenUserNotFound()
        {
            // Arrange
            var userId = 99;
            _mockService.Setup(service => service.GetUserById(userId)).Returns((User)null);
            // Act
            var result = _controller.GetUserById(userId) as NotFoundResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }
        [Fact]
        public void GetAllUsers_ReturnsOkResultWithListOfUsers()
        {
            // Arrange
            var expectedUsers = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com" }
            };
            _mockService.Setup(service => service.GetAllUsers()).Returns(expectedUsers);
            // Act
            var result = _controller.GetAllUsers() as OkObjectResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedUsers, result.Value);
        }
        [Fact]
        public void AddUser_ReturnsCreatedAtAction()
        {
            // Arrange
            var newUser = new User { Id = 3, Name = "Sam Wilson", Email = "sam@example.com" };
            // Act
            var result = _controller.AddUser(newUser) as CreatedAtActionResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal("GetUserById", result.ActionName);
            Assert.Equal(newUser.Id, ((User)result.Value).Id);
        }
        [Fact]
        public void UpdateUser_ReturnsNoContent()
        {
            // Arrange
            var updatedUser = new User { Id = 1, Name = "John Updated", Email = "john.updated@example.com" };
            _mockService.Setup(service => service.UpdateUser(updatedUser));
            // Act
            var result = _controller.UpdateUser(10, updatedUser) as NoContentResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }
        [Fact]
        public void DeleteUser_ReturnsNoContent()
        {
            // Arrange
            var userId = 1;
            _mockService.Setup(service => service.DeleteUser(userId));
            // Act
            var result = _controller.DeleteUser(userId) as NoContentResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }
    }
}
