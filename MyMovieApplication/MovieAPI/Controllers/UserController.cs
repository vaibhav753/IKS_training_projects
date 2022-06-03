using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MovieApp.Business.Services;
using MyMovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userServices;

        public UserController(UserService userService)
        {
            _userServices = userService;
        }

        [HttpGet("SelectUsers")]
        public IActionResult SelectUsers()
        {
            return Ok(_userServices.selectUser());
        }

        [HttpPost("Register")]
        public IActionResult Register(UserModel userModel)
        {
            return Ok(_userServices.Register(userModel));
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            return Ok(_userServices.deleteUser(userId));
        }

        [HttpPost("Login")]
        public IActionResult Login(UserModel userModel)
        {
            return Ok(_userServices.Login(userModel));
        }

        [HttpGet("findUserById")]
        public IActionResult findUserById(int id)
        {
            return Ok(_userServices.findUserById(id));
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser(UserModel userModel)
        {
            return Ok(_userServices.EditUser(userModel));
        }

    }
}
