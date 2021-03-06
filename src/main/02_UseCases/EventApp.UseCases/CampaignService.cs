using EventApp.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

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
        private readonly IRepository<User> _userRepository;

        /// <summary>
        /// Репозиторий кампаний.
        /// </summary>
        private readonly IRepository<Campaign> _campaignRepository;

        /// <summary>
        /// Репозиторий хобби.
        /// </summary>
        private readonly IRepository<Hobby> _hobbyRepository;

        /// <summary>
        /// Репозиторий сообщений.
        /// </summary>
        private readonly IRepository<Message> _messageRepository;

        public CampaignService(IRepository<User> userRepository, IRepository<Campaign> campaignRepository,
            IRepository<Hobby> hobbyRepository, IRepository<Message> messageRepository)
        {
            _userRepository = userRepository;
            _campaignRepository = campaignRepository;
            _hobbyRepository = hobbyRepository;
            _messageRepository = messageRepository;
        }

        /// <summary>
        /// Создать кампанию.
        /// </summary>
        /// <param name="administratorId">Пользователь-администратор кампании.</param>
        /// <param name="name">Наименование кампании.</param>
        /// <param name="hobbyIds">Список идентификаторов хобби.</param>
        /// <returns>Идентификатор созданной кампании.</returns>
        public async Task<Result<Guid>> CreateCampaignAsync(Guid administratorId, string name, IList<Guid> hobbyIds)
        {
            var administrator = await _userRepository.GetByIdAsync(administratorId);

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

            await _campaignRepository.SaveAsync(newCampaign);

            return Result.Success(newCampaign.Id);
        }

        /// <summary>
        /// Добавить участника в кампанию.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="campaignId">Идентификатор кампании.</param>
        public async Task<Result> AddParticipantAsync(Guid userId, Guid campaignId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                return Result.Failure("Не найден пользователь по идентификатору.");
            }

            var campaign = await _campaignRepository.GetByIdAsync(campaignId);

            if (campaign == null)
            {
                return Result.Failure("Не найденa кампания по идентификатору.");
            }

            if (campaign.Participants.Contains(user))
            {
                return Result.Failure("Пользователь уже состоит в кампании.");
            }

            campaign.Participants.Add(user);

            await _campaignRepository.SaveAsync(campaign);

            return Result.Success();
        }

        /// <summary>
        /// Отправить пользовательское сообщение в кампанию.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="campaignId">Идентификатор кампании.</param>
        public async Task<Result> SendMessageAsync(Guid userId, Guid campaignId, string text)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                return Result.Failure("Не найден пользователь по идентификатору.");
            }

            var campaign = await _campaignRepository.GetByIdAsync(campaignId);

            if (campaign == null)
            {
                return Result.Failure("Не найденa кампания по идентификатору.");
            }

            if (!campaign.Participants.Contains(user))
            {
                return Result.Failure("Пользователь не состоит в кампании.");
            }

            var newMessage = new Message
            {
                Id = Guid.NewGuid(),
                Sender = user,
                Campaign = campaign,
                Text = text,
                Created = DateTime.Now
            };

            await _messageRepository.SaveAsync(newMessage);

            return Result.Success();
        }

        /// <summary>
        /// Получить список сообщений кампании.
        /// </summary>
        /// <param name="campaignId">Идентификатор кампании.</param>
        /// <returns>Список сообщений.</returns>
        public async Task<Result<List<Message>>> GetMessagesAsync(Guid campaignId)
        {
            var campaign = await _campaignRepository.GetByIdAsync(campaignId);

            if (campaign == null)
            {
                return Result.Failure<List<Message>>("Не найденa кампания по идентификатору.");
            }

            var messages = await _messageRepository.GetAllAsync();
            var result = messages
                .Where(message => message.Campaign.Id == campaignId)
                .ToList();

            return Result.Success(result);
        }

        /// <summary>
        /// Получить список всех кампаний.
        /// </summary>
        /// <returns>Список кампаний.</returns>
        public async Task<Result<IList<Campaign>>> GetCampaignsAsync()
        {
            var result = await _campaignRepository.GetAllAsync();
            return Result.Success(result);
        }
    }
}
