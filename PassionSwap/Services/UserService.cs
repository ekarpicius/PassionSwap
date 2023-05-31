using PassionSwap.Repositories;
using PassionSwap.Models;

namespace PassionSwap.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public IEnumerable<Listing> GetUserListings(int userId)
        {
            return _userRepository.GetUserListings(userId);
        }

        public void AddListingToUser(int userId, Listing listing)
        {
            _userRepository.AddListingToUser(userId, listing);
        }
    }
}
