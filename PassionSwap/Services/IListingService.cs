using PassionSwap.Models;

namespace PassionSwap.Services
{
    public interface IListingService
    {
        IEnumerable<Listing> GetAllListings();
        Listing GetListingById(int id);
        void AddListing(Listing listing);
        void UpdateListing(Listing listing);
        void DeleteListing(int id);
    }
}
