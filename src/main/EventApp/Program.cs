﻿using EventApp.InterfaceAdapters.DataStorage;
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
                var hobbyId = hobbyService.CreateHobbyAsync("TestHobby").Result.Value;

                var userRepository = new NHibernateUserRepository(session);
                var userService = new UserService(userRepository);
                var userId = userService.CreateUserAsync("TestUser").Result.Value;

                var messageRepository = new NHibernateMessageRepository(session);

                var campaignRepository = new NHibernateCampaignRepository(session);
                var campaignService = new CampaignService(userRepository, campaignRepository, hobbyRepository, messageRepository);
                var campignId = campaignService.CreateCampaignAsync(userId, "TestCampaign", new List<Guid> { hobbyId }).Result.Value;
            }
        }
    }
}
