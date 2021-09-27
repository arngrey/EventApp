using FluentNHibernate.Mapping;
using EventApp.Entities;

namespace EventApp.InterfaceAdapters.DataStorage
{
    /// <summary>
    /// Сопоставление полей DTO и полей сущности пользователь.
    /// </summary>
    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.Login);
            Map(x => x.Password);
        }
    }
}
