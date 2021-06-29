﻿using EventApp.Abstractions.Campaign;
using EventApp.Abstractions.Hobby;
using EventApp.Abstractions.Message;
using EventApp.Abstractions.User;
using EventApp.Models.Campaign;
using EventApp.Models.Message;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EventApp.UseCases
{
    public class CampaignService
    {
        /// <summary>
        /// Репозиторий пользователей.
        /// </summary>
        private IUserRepository _userRepository;

        /// <summary>
        /// Репозиторий кампаний.
        /// </summary>
        private ICampaignRepository _campaignRepository;

        /// <summary>
        /// Репозиторий хобби.
        /// </summary>
        private IHobbyRepository _hobbyRepository;

        public CampaignService(IUserRepository userRepository, ICampaignRepository campaignRepository, IHobbyRepository hobbyRepository)
        {
            _userRepository = userRepository;
            _campaignRepository = campaignRepository;
            _hobbyRepository = hobbyRepository;
        }

        /// <summary>
        /// Создать кампанию.
        /// </summary>
        /// <param name="administratorId">Пользователь-администратор кампании.</param>
        /// <param name="name">Наименование кампании.</param>
        /// <param name="hobbyIds">Список идентификаторов хобби.</param>
        public void CreateCampaign(long administratorId, string name, List<long> hobbyIds)
        {
            var administrator = _userRepository.GetById(administratorId);

            if (administrator == null)
            {
                // Не найден пользователь по идентификатору
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                // Наименование не должно быть пустым
                return;
            }

            var hobbies = hobbyIds
                .Select(_hobbyRepository.GetById)
                .Where(hobby => hobby != null)
                .ToList();

            var newCampaign = new Campaign
            {
                Id = null,
                Name = name,
                Administrator = administrator,
                Hobbies = hobbies,
                Participants = new List<IUser>(),
                Messages = new List<IMessage>()
            };

            _campaignRepository.Save(newCampaign);
        }

        /// <summary>
        /// Отправить пользовательское сообщение в кампанию.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="campaignId">Идентификатор кампании.</param>
        public void SendMessage(long userId, long campaignId, string text)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
            {
                // Не найден пользователь по идентификатору
                return;
            }

            var campaign = _campaignRepository.GetById(campaignId);

            if (campaign == null)
            {
                // Не найденa кампания по идентификатору
                return;
            }

            if (!user.JoinedCampaigns.Contains(campaign))
            {
                // Пользователь не состоит в кампании
                return;
            }

            var newMessage = new Message
            {
                Id = null,
                Sender = user,
                Text = text,
                Created = DateTime.Now
            };

            campaign.Messages.Add(newMessage);

            _campaignRepository.Save(campaign);
        }

        /// <summary>
        /// Получить список сообщений кампании.
        /// </summary>
        /// <param name="campaignId">Идентификатор кампании.</param>
        /// <returns>Список сообщений.</returns>
        public List<IMessage> GetMessages(long campaignId)
        {
            var campaign = _campaignRepository.GetById(campaignId);

            if (campaign == null)
            {
                // Не найденa кампания по идентификатору
            }

            return campaign.Messages;
        }

        /// <summary>
        /// Получить список всех кампаний.
        /// </summary>
        /// <returns>Список кампаний.</returns>
        public List<ICampaign> GetAllCampaigns()
        {
            return _campaignRepository.GetAll();
        }
    }
}