using EventApp.Entities;
using NHibernate;

namespace EventApp.InterfaceAdapters
{
    /// <summary>
    /// Репозиторий хобби, реализуемый NHibernate'ом.
    /// </summary>
    public class NHibernateHobbyRepository : NHibernateRepository<IHobby>, IHobbyRepository
    {
        public NHibernateHobbyRepository(ISession session) : base(session)
        {
        }
    }
}
