using AutoMapper;
using EventApp.Entities;
using EventApp.InterfaceAdapters.RestApi.Dtos;
using System.Linq;

namespace EventApp.InterfaceAdapters.RestApi.Utils
{
    public class EntityProfile : Profile
    {
        public EntityProfile() 
        {
            CreateMap<Campaign, FlatCampaignDto>()
                .ForMember(nameof(FlatCampaignDto.AdministratorId), x => x.MapFrom(y => y.Administrator.Id))
                .ForMember(nameof(FlatCampaignDto.HobbyIds), x => x.MapFrom(y => y.Hobbies.Select(z => z.Id)))
                .ForMember(nameof(FlatCampaignDto.ParticipantIds), x => x.MapFrom(y => y.Participants.Select(z => z.Id)))
                .ForMember(nameof(FlatCampaignDto.MessageIds), x => x.MapFrom(y => y.Messages.Select(z => z.Id)));

            CreateMap<Message, FlatMessageDto>()
                .ForMember(nameof(FlatMessageDto.SenderId), x => x.MapFrom(y => y.Sender.Id))
                .ForMember(nameof(FlatMessageDto.CampaignId), x => x.MapFrom(y => y.Campaign.Id));
        }
    }
}
