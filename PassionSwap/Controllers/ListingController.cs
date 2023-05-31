using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PassionSwap.Models;
using PassionSwap.Services;

namespace PassionSwap.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/listings")]
    public class ListingController : ControllerBase
    {
        private readonly IListingService _listingService;

        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpGet]
        public IActionResult GetAllListings()
        {
            var listings = _listingService.GetAllListings();
            return Ok(listings);
        }

        [HttpGet("{id}")]
        public IActionResult GetListingById(int id)
        {
            var listing = _listingService.GetListingById(id);
            if (listing == null)
            {
                return NotFound();
            }
            return Ok(listing);
        }

        [HttpPost]
        public IActionResult AddListing(Listing listing)
        {
            _listingService.AddListing(listing);
            return CreatedAtAction(nameof(GetListingById), new { id = listing.Id }, listing);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateListing(int id, Listing listing)
        {
            if (id != listing.Id)
            {
                return BadRequest();
            }
            try
            {
                _listingService.UpdateListing(listing);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteListing(int id)
        {
            _listingService.DeleteListing(id);
            return NoContent();
        }
    }

}
