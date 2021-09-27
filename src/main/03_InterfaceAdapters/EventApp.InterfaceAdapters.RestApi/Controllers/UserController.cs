using AutoMapper;
using EventApp.InterfaceAdapters.RestApi.Dtos;
using EventApp.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventApp.InterfaceAdapters.RestApi.Controllers
{
    [Authorize]
    [Route("/api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUpAsync([FromBody] SignUpDto signUpDto)
        {
            var result = await _userService.SignUpAsync(signUpDto.Login, signUpDto.Password);

            if (result.IsSuccess)
            {
                return Created($"api/users/{result.Value}", result.Value);
            }

            return Conflict(result.Error);
        }

        [AllowAnonymous]
        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> SignInAsync([FromBody] SignInDto signInDto)
        {
            var result = await _userService.SignInAsync(signInDto.Login, signInDto.Password);

            if (result.IsSuccess)
            {
                var userDto = _mapper.Map<UserDto>(result.Value);
                return Ok(userDto);
            }

            return BadRequest(result.Error);
        }
    }
}