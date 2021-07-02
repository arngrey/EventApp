using EventApp.Entities;
using NHibernate;

namespace EventApp.InterfaceAdapters
{
    /// <summary>
    /// Репозиторий хобби, реализуемый NHibernate'ом.
    /// </summary>
    public class NHibernateHobbyRepository : NHibernateRepository<Hobby>, IHobbyRepository
    {
        public NHibernateHobbyRepository(ISession session) : base(session)
        {
        }
    }
}
