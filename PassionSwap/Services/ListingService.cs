using PassionSwap.Models;
using PassionSwap.Repositories;

namespace PassionSwap.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;

        public ListingService(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }

        public IEnumerable<Listing> GetAllListings()
        {
            return _listingRepository.GetAllListings();
        }

        public Listing GetListingById(int id)
        {
            return _listingRepository.GetListingById(id);
        }

        public void AddListing(Listing listing)
        {
            _listingRepository.AddListing(listing);
        }

        public void UpdateListing(Listing listing)
        {
            _listingRepository.UpdateListing(listing);
        }

        public void DeleteListing(int id)
        {
            _listingRepository.DeleteListing(id);
        }
    }
}
