using PassionSwap.Data;
using PassionSwap.Models;

namespace PassionSwap
{
    public class DbInit
    {
        public static void Init(PassionSwap_DbContext context)
        {
            if (context.Users.Any() || context.Listings.Any())
            {
                return;
            }

            var users = new[]
            {
                new User { Name = "test1", Email = "test1@test.com", Password = "test1" },
                new User { Name = "test2", Email = "test2@test.com", Password = "test2" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var listings = new[]
            {
                new Listing { Title = "listing1", Description = "description1", UserId = users[0].Id },
                new Listing { Title = "listing2", Description = "description2", UserId = users[1].Id },
            };

            context.Listings.AddRange(listings);
            context.SaveChanges();
        }
    }
}
