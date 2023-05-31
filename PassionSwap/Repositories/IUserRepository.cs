using PassionSwap.Models;

namespace PassionSwap.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);

        IEnumerable<Listing> GetUserListings(int userId);
        void AddListingToUser(int userId, Listing listing);
    }
}
