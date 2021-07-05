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
            CreateMap<Campaign, CampaignDto>()
                .ForMember(nameof(CampaignDto.AdministratorId), x => x.MapFrom(y => y.Administrator.Id))
                .ForMember(nameof(CampaignDto.HobbyIds), x => x.MapFrom(y => y.Hobbies.Select(z => z.Id)))
                .ForMember(nameof(CampaignDto.ParticipantIds), x => x.MapFrom(y => y.Participants.Select(z => z.Id)))
                .ForMember(nameof(CampaignDto.MessageIds), x => x.MapFrom(y => y.Messages.Select(z => z.Id)));

            CreateMap<Message, MessageDto>()
                .ForMember(nameof(MessageDto.SenderId), x => x.MapFrom(y => y.Sender.Id))
                .ForMember(nameof(MessageDto.CampaignId), x => x.MapFrom(y => y.Campaign.Id));
        }
    }
}
