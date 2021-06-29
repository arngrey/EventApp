using EventApp.Entities;
using NHibernate;

namespace EventApp.InterfaceAdapters
{
    /// <summary>
    /// Репозиторий кампаний, реализуемый NHibernate'ом.
    /// </summary>
    public class NHibernateUserRepository : NHibernateRepository<IUser>, IUserRepository
    {
        public NHibernateUserRepository(ISession session) : base(session)
        {
        }
    }
}
