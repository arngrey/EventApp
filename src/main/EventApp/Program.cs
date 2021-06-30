using EventApp.InterfaceAdapters;
using EventApp.UseCases;
using System;
using System.Collections.Generic;

namespace EventApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sessionFactory = SessionFactoryCreator.Create();
            
            using (var session = sessionFactory.OpenSession())
            {
                var hobbyRepository = new NHibernateHobbyRepository(session);
                var hobbyService = new HobbyService(hobbyRepository);
                var hobbyId = hobbyService.CreateHobby("TestHobby").Value;

                var userRepository = new NHibernateUserRepository(session);
                var userService = new UserService(userRepository);
                var userId = userService.CreateUser("TestUser").Value;

                var campaignRepository = new NHibernateCampaignRepository(session);
                var campaignService = new CampaignService(userRepository, campaignRepository, hobbyRepository);
                var campignId = campaignService.CreateCampaign(userId, "TestCampaign", new List<Guid> { hobbyId }).Value;
            }
        }
    }
}
