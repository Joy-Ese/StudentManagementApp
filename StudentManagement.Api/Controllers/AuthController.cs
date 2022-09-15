using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.DataObjects;
using StudentManagement.Services.Interfaces;


namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private IUser _userService;

        public AuthController(DataContext context, IUser userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<List<UserViewModel>>> Register(UserDto request)
        {
            var result = await _userService.Register(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<List<UserViewModel>>> Login(UserDto request)
        {
            var result = await _userService.Login(request);
            return Ok(result);
        }


    }
}
