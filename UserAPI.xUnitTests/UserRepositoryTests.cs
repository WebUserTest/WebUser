using Microsoft.AspNetCore.Routing;
using Moq;
using WebUser.Api.Models;
using WebUser.Api.Repositories;
using WebUser.Api.Services;

namespace UserAPI.xUnitTests
{
    public class UserRepositoryTests
    {
        private readonly UserRepository _userRepository;
        public UserRepositoryTests()
        {
            _userRepository = new UserRepository();
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetUserById_ReturnsCorrectUser(int userId)
        {
            // Arrange
           // var userId = 1;
            // Act
            var result = _userRepository.GetUserById(userId);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        }
        [Fact]
        public void GetUserById_ReturnsNullWhenUserNotFound()
        {
            // Arrange
            var userId = 99;
            // Act
            var result = _userRepository.GetUserById(userId);
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public void GetAllUsers_ReturnsAllUsers()
        {
            // Act
            var result = _userRepository.GetAllUsers();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public void AddUser_AddsUserCorrectly()
        {
            // Arrange
            var newUser = new User { Id = 3, Name = "Sam Wilson", Email = "sam@example.com" };
            // Act
            _userRepository.AddUser(newUser);
            var result = _userRepository.GetUserById(3);
            // Assert
            Assert.NotNull(result); 
            Assert.Equal(newUser.Id, result.Id); 
            Assert.Equal(newUser.Name, result.Name);
            Assert.Equal(newUser.Email, result.Email); 
        }
        [Fact]
        public void UpdateUser_UpdatesUserCorrectly()
        {
            // Arrange
            var updatedUser = new User { Id = 1, Name = "John Updated", Email = "john.updated@example.com" };
            // Act
            _userRepository.UpdateUser(updatedUser);
            var result = _userRepository.GetUserById(1);
            // Assert
            Assert.NotNull(result); 
            Assert.Equal(updatedUser.Name, result.Name); 
            Assert.Equal(updatedUser.Email, result.Email); 
        }
        [Fact]
        public void DeleteUser_DeletesUserCorrectly()
        {
            // Arrange
            var userId = 1;
            // Act
            _userRepository.DeleteUser(userId);
            var result = _userRepository.GetUserById(userId);
            // Assert
            Assert.Null(result);
        }
    }
}
