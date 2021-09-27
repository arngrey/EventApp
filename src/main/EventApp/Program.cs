using EventApp.Entities;
using EventApp.InterfaceAdapters.DataStorage;
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
                var hobbyRepository = new NHibernateRepository<Hobby>(session);
                var hobbyService = new HobbyService(hobbyRepository);
                var hobbyId = hobbyService.CreateHobbyAsync("TestHobby").Result.Value;

                var userRepository = new NHibernateRepository<User>(session);
                var userService = new UserService(userRepository);
                var userId = userService.SignUpAsync("TestUser", "TestPassword").Result.Value;

                var messageRepository = new NHibernateRepository<Message>(session);

                var campaignRepository = new NHibernateRepository<Campaign>(session);
                var campaignService = new CampaignService(userRepository, campaignRepository, hobbyRepository, messageRepository);
                var campignId = campaignService.CreateCampaignAsync(userId, "TestCampaign", new List<Guid> { hobbyId }).Result.Value;
            }
        }
    }
}
