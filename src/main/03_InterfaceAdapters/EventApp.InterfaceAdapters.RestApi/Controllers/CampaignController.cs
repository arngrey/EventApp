using AutoMapper;
using EventApp.InterfaceAdapters.RestApi.Dtos;
using EventApp.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventApp.InterfaceAdapters.RestApi.Controllers
{
    [Route("api/campaigns")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly CampaignService _campaignService;
        private readonly IMapper _mapper;

        public CampaignController(CampaignService campaignService, IMapper mapper)
        {
            _campaignService = campaignService;
            _mapper = mapper;
        }

        [Route("new")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCampaignDto createCampaignDto)
        {
            var result = await _campaignService.CreateCampaignAsync(
                createCampaignDto.AdministratorId, createCampaignDto.Name, createCampaignDto.HobbyIds);

            if (result.IsSuccess)
            {
                return Created($"api/campaigns/{result.Value}", result.Value);
            }

            return Conflict(result.Error);
        }

        [Route("{id}/addparticipant")]
        [HttpPost]
        public async Task<IActionResult> AddParticipantAsync([FromBody] AddParticipantDto addParticipantDto)
        {
            var result = await _campaignService.AddParticipantAsync(addParticipantDto.UserId, addParticipantDto.CampaignId);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return Conflict(result.Error);
        }

        [Route("{id}/sendmessage")]
        [HttpPost]
        public async Task<IActionResult> SendMessageAsync([FromBody] SendMessageDto sendMessageDto)
        {
            var result = await _campaignService.SendMessageAsync(sendMessageDto.UserId, sendMessageDto.CampaignId, sendMessageDto.Text);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return Conflict(result.Error);
        }

        [Route("{id}/messages")]
        [HttpGet]
        public async Task<IActionResult> GetMessagesAsync(Guid id)
        {
            var result = await _campaignService.GetMessagesAsync(id);

            if (result.IsSuccess)
            {
                var messageDtos = _mapper.Map<IList<MessageDto>>(result.Value);
                return Ok(messageDtos);
            }

            return Conflict(result.Error);
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetCampaignsAsync()
        {
            var result = await _campaignService.GetCampaignsAsync();

            if (result.IsSuccess)
            {
                var campaignDtos = _mapper.Map<IList<CampaignDto>>(result.Value);
                return Ok(campaignDtos);
            }

            return Conflict(result.Error);
        }
    }
}