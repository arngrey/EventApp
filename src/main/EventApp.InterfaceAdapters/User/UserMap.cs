using FluentNHibernate.Mapping;
using EventApp.Entities;

namespace EventApp.InterfaceAdapters
{
    /// <summary>
    /// Сопоставление полей DTO и полей сущности пользователь.
    /// </summary>
    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
            HasManyToMany(x => x.JoinedCampaigns)
                .Table("CampaignParticipant");
        }
    }
}
