using PassionSwap.Data;
using PassionSwap.Models;

namespace PassionSwap.Repositories
{
    public class ListingRepository : IListingRepository
    {
        private readonly PassionSwap_DbContext _context;

        public ListingRepository(PassionSwap_DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Listing> GetAllListings()
        {
            return _context.Listings.ToList();
        }

        public Listing GetListingById(int id)
        {
            return _context.Listings.Find(id);
        }

        public void AddListing(Listing listing)
        {
            _context.Listings.Add(listing);
            _context.SaveChanges();
        }

        public void UpdateListing(Listing listing)
        {
            _context.Listings.Update(listing);
            _context.SaveChanges();
        }

        public void DeleteListing(int id)
        {
            var listing = _context.Listings.Find(id);
            if (listing != null)
            {
                _context.Listings.Remove(listing);
                _context.SaveChanges();
            }
        }
    }
}
