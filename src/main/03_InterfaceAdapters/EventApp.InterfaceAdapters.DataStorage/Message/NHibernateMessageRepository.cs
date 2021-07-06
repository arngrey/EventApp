using EventApp.Entities;
using NHibernate;

namespace EventApp.InterfaceAdapters.DataStorage
{
    public class NHibernateMessageRepository: NHibernateRepository<Message>, IMessageRepository
    {
        public NHibernateMessageRepository(ISession session) : base(session)
        {
        }
    }
}
