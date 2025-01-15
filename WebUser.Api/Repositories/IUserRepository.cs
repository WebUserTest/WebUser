using WebUser.Api.Models;

namespace WebUser.Api.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}
