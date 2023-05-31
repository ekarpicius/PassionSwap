using PassionSwap.Models;

namespace PassionSwap.Repositories
{
    public interface IListingRepository
    {
        IEnumerable<Listing> GetAllListings();
        Listing GetListingById(int id);
        void AddListing(Listing listing);
        void UpdateListing(Listing listing);
        void DeleteListing(int id);
    }
}
