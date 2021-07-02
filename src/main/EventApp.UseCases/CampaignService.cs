using EventApp.Entities;
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
        public async Task<Result<Guid>> CreateCampaignAsync(Guid administratorId, string name, List<Guid> hobbyIds)
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

            await _campaignRepository.SaveAsync(campaign);

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

            var result = campaign.Messages.ToList();

            return Result.Success<List<Message>>(result);
        }

        /// <summary>
        /// Получить список всех кампаний.
        /// </summary>
        /// <returns>Список кампаний.</returns>
        public async Task<Result<IList<Campaign>>> GetAllCampaignsAsync()
        {
            var result = await _campaignRepository.GetAllAsync();
            return Result.Success(result);
        }
    }
}
