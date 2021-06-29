using EventApp.Entities;
using FluentNHibernate.Mapping;

namespace EventApp.InterfaceAdapters
{
    /// <summary>
    /// Сопоставление полей DTO и полей сущности сообщения.
    /// </summary>
    public class MessageMap : ClassMap<Message>
    {
        public MessageMap()
        {
            Not.LazyLoad();

            Id(x => x.Id);
            References(x => x.Sender);
            Map(x => x.Text);
            Map(x => x.Created);
        }
    }
}
