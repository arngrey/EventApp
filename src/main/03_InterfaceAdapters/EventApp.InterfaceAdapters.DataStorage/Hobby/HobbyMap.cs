using EventApp.Entities;
using FluentNHibernate.Mapping;

namespace EventApp.InterfaceAdapters
{
    /// <summary>
    /// Сопоставление полей DTO и полей сущности хобби.
    /// </summary>
    public class HobbyMap: ClassMap<Hobby>
    {
        public HobbyMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
        }
    }
}
