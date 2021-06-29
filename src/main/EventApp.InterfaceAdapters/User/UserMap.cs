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
            Not.LazyLoad();

            Id(x => x.Id);
            Map(x => x.Name);
            HasManyToMany(x => x.JoinedCampaigns)
                .Table("CampaignParticipant");
        }
    }
}
