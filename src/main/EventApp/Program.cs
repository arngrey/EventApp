using EventApp.InterfaceAdapters;
using EventApp.UseCases;
using System;

namespace EventApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sessionFactory = SessionFactoryCreator.Create();
            
            using (var session = sessionFactory.OpenSession())
            {
                var campaignRepository = new NHibernateCampaignRepository(session);
                var hobbyRepository = new NHibernateHobbyRepository(session);
                var userRepository = new NHibernateUserRepository(session);

                var campaignService = new CampaignService(userRepository, campaignRepository, hobbyRepository);
            }
        }
    }
}
