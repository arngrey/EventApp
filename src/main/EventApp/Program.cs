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
                var userRepository = new NHibernateUserRepository(session);
                var userService = new UserService(userRepository);
                userService.CreateUser("TestUser");
                var user = userService.GetUserByName("TestUser");

                var hobbyRepository = new NHibernateHobbyRepository(session);
                var hobbyService = new HobbyService(hobbyRepository);
                hobbyService.CreateHobby("TestHobby");
                var hobby = hobbyService.GetHobbyByName("TestHobby");

                var campaignRepository = new NHibernateCampaignRepository(session);
                var campaignService = new CampaignService(userRepository, campaignRepository, hobbyRepository);
                campaignService.CreateCampaign(user.Id.Value, "TestCampaign", new List<long> { hobby.Id.Value });
            }
        }
    }
}
