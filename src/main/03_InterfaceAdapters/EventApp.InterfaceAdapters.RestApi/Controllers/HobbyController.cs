using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventApp.Entities;
using EventApp.InterfaceAdapters.RestApi.Dtos;
using EventApp.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace EventApp.InterfaceAdapters.RestApi.Controllers
{
    [Route("api/hobbies")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly HobbyService _hobbyService;

        public HobbyController(HobbyService hobbyService, IMapper mapper)
        {
            _hobbyService = hobbyService;
            _mapper = mapper;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _hobbyService.GetAllAsync();

            if (result.IsSuccess)
            {
                var hobbiesDto = _mapper.Map<List<HobbyDto>>(result.Value);
                return Ok(hobbiesDto);
            }

            return Conflict(result.Error);
        }
 
        [Route("new")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateHobbyDto createHobbyDto)
        {
            var result = await _hobbyService.CreateHobbyAsync(createHobbyDto.Name);

            if (result.IsSuccess)
            {
                return Created($"api/hobbies/{result.Value}", result.Value);
            }

            return Conflict(result.Error);
        }
    }
}