using EventApp.Entities;
using NHibernate;

namespace EventApp.InterfaceAdapters
{
    /// <summary>
    /// Репозиторий кампаний, реализуемый NHibernate'ом.
    /// </summary>
    public class NHibernateCampaignRepository : NHibernateRepository<Campaign>, ICampaignRepository
    {
        public NHibernateCampaignRepository(ISession session) : base(session)
        {
        }
    }
}
