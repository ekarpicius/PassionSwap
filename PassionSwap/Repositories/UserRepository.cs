using Microsoft.EntityFrameworkCore;
using PassionSwap.Data;
using PassionSwap.Models;

namespace PassionSwap.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PassionSwap_DbContext _context;

        public UserRepository(PassionSwap_DbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Listing> GetUserListings(int userId)
        {
            return _context.Users.Include(u => u.Listings).Single(u => u.Id == userId).Listings;
        }

        public void AddListingToUser(int userId, Listing listing)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                user.Listings.Add(listing);
                _context.SaveChanges();
            }
        }
    }
}
