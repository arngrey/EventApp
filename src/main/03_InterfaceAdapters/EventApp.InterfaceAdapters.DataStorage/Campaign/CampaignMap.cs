using EventApp.Models;
using FluentNHibernate.Mapping;

namespace EventApp.InterfaceAdapters.DataStorage
{
    /// <summary>
    /// Сопоставление полей DTO и полей сущности кампания.
    /// </summary>
    public class CampaignMap: ClassMap<Campaign>
    {
        public CampaignMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasManyToMany(x => x.Hobbies)
                .Table("CampaignHobby");
            References(x => x.Administrator);
            HasManyToMany(x => x.Participants)
                .Table("CampaignParticipant");
            HasMany(x => x.Messages);
        }
    }
}
