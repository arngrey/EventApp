using EventApp.Entities;
using EventApp.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public IActionResult InternalServerError { get; private set; }

        [Route("new")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(string name)
        {
            try
            {
                var result = await _userService.CreateUserAsync(name);

                if (result.IsSuccess)
                {
                    return Created($"api/users/{result.Value}", result.Value);
                }

                return Conflict(result.Error);
            } catch
            {
                return InternalServerError;
            }

        }
    }
}