using EventApp.InterfaceAdapters;
using EventApp.UseCases;
using System;
using System.Collections.Generic;

namespace EventApp
{
    class Program
    {
        static async void Main(string[] args)
        {
            var sessionFactory = SessionFactoryCreator.Create();
            
            using (var session = sessionFactory.OpenSession())
            {
                var hobbyRepository = new NHibernateHobbyRepository(session);
                var hobbyService = new HobbyService(hobbyRepository);
                var hobbyId = (await hobbyService.CreateHobbyAsync("TestHobby")).Value;

                var userRepository = new NHibernateUserRepository(session);
                var userService = new UserService(userRepository);
                var userId = (await userService.CreateUserAsync("TestUser")).Value;

                var campaignRepository = new NHibernateCampaignRepository(session);
                var campaignService = new CampaignService(userRepository, campaignRepository, hobbyRepository);
                var campignId = (await campaignService.CreateCampaignAsync(userId, "TestCampaign", new List<Guid> { hobbyId })).Value;
            }
        }
    }
}
