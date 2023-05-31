using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PassionSwap.Models;
using PassionSwap.Services;

namespace PassionSwap.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            try
            {
                _userService.UpdateUser(user);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpGet("{id}/listings")]
        public IActionResult GetUserListings(int id)
        {
            var listings = _userService.GetUserListings(id);
            return Ok(listings);
        }

        [HttpPost("{id}/listings")]
        public IActionResult AddListingToUser(int id, Listing listing)
        {
            try
            {
                _userService.AddListingToUser(id, listing);
                return CreatedAtAction(nameof(GetUserListings), new { id = id }, listing);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
