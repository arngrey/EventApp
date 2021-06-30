using EventApp.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace EventApp.UseCases
{
    /// <summary>
    /// Сервис по работе с кампаниями.
    /// </summary>
    public class CampaignService
    {
        /// <summary>
        /// Репозиторий пользователей.
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Репозиторий кампаний.
        /// </summary>
        private readonly ICampaignRepository _campaignRepository;

        /// <summary>
        /// Репозиторий хобби.
        /// </summary>
        private readonly IHobbyRepository _hobbyRepository;

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
        /// <returns>Идентификатор созданной кампании.</returns>
        public Result<Guid> CreateCampaign(Guid administratorId, string name, List<Guid> hobbyIds)
        {
            var administrator = _userRepository.GetById(administratorId);

            if (administrator == null)
            {
                return Result.Failure<Guid>("Не найден пользователь по идентификатору.");
            }

            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Guid>("Наименование не должно быть пустым.");
            }

            var hobbies = hobbyIds
                .Select(_hobbyRepository.GetById)
                .Where(hobby => hobby != null)
                .ToList();

            var newCampaign = new Campaign
            {
                Id = Guid.NewGuid(),
                Name = name,
                Administrator = administrator,
                Hobbies = hobbies,
                Participants = new List<User>(),
                Messages = new List<Message>()
            };

            _campaignRepository.Save(newCampaign);

            return Result.Success(newCampaign.Id);
        }

        /// <summary>
        /// Добавить участника в кампанию.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="campaignId">Идентификатор кампании.</param>
        public Result AddParticipant(Guid userId, Guid campaignId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
            {
                return Result.Failure("Не найден пользователь по идентификатору.");
            }

            var campaign = _campaignRepository.GetById(campaignId);

            if (campaign == null)
            {
                return Result.Failure("Не найденa кампания по идентификатору.");
            }

            if (campaign.Participants.Contains(user))
            {
                return Result.Failure("Пользователь уже состоит в кампании.");
            }

            campaign.Participants.Add(user);

            _campaignRepository.Save(campaign);

            return Result.Success();
        }

        /// <summary>
        /// Отправить пользовательское сообщение в кампанию.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="campaignId">Идентификатор кампании.</param>
        public Result SendMessage(Guid userId, Guid campaignId, string text)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
            {
                return Result.Failure("Не найден пользователь по идентификатору.");
            }

            var campaign = _campaignRepository.GetById(campaignId);

            if (campaign == null)
            {
                return Result.Failure("Не найденa кампания по идентификатору.");
            }

            if (!user.JoinedCampaigns.Contains(campaign))
            {
                return Result.Failure("Пользователь не состоит в кампании.");
            }

            var newMessage = new Message
            {
                Id = Guid.NewGuid(),
                Sender = user,
                Text = text,
                Created = DateTime.Now
            };

            campaign.Messages.Add(newMessage);

            _campaignRepository.Save(campaign);

            return Result.Success();
        }

        /// <summary>
        /// Получить список сообщений кампании.
        /// </summary>
        /// <param name="campaignId">Идентификатор кампании.</param>
        /// <returns>Список сообщений.</returns>
        public Result<List<Message>> GetMessages(Guid campaignId)
        {
            var campaign = _campaignRepository.GetById(campaignId);

            if (campaign == null)
            {
                return Result.Failure<List<Message>>("Не найденa кампания по идентификатору.");
            }

            var result = campaign.Messages.ToList();

            return Result.Success<List<Message>>(result);
        }

        /// <summary>
        /// Получить список всех кампаний.
        /// </summary>
        /// <returns>Список кампаний.</returns>
        public Result<List<Campaign>> GetAllCampaigns()
        {
            var result = _campaignRepository.GetAll();
            return Result.Success<List<Campaign>>(result);
        }
    }
}
