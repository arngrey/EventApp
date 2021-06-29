using EventApp.Entities;
using FluentNHibernate.Mapping;

namespace EventApp.InterfaceAdapters
{
    /// <summary>
    /// Сопоставление полей DTO и полей сущности хобби.
    /// </summary>
    public class HobbyMap: ClassMap<IHobby>
    {
        public HobbyMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
