using EventApp.InterfaceAdapters.RestApi.Dtos;
using EventApp.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventApp.InterfaceAdapters.RestApi.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [Route("new")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserDto createUserDto)
        {
            var result = await _userService.CreateUserAsync(createUserDto.Name);

            if (result.IsSuccess)
            {
                return Created($"api/users/{result.Value}", result.Value);
            }

            return Conflict(result.Error);
        }
    }
}