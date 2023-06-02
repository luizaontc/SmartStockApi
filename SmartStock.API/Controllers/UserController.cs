using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using SmartStock.Service.Services.Interface;

namespace SmartStock.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> NewUser(User user)
        {
            var newUser = await _userService.NewUser(user);

            if (user != null) 
            { 
                return Ok(); 
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            var newUser = await _userService.UpdateUser(user);

            if (user != null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var deleteUser = await _userService.DeleteUserById(id);

            if (deleteUser != null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult Authenticate(UserDTO user)
        {
            try
            {
                var login = _userService.Authenticate(user);

                return Ok(login);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            
        }
    }
}
