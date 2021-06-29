using EventApp.Abstractions.Campaign;
using EventApp.Abstractions.User;

namespace EventApp.UseCases
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Репозиторий пользователей.
        /// </summary>
        private IUserRepository _userRepository;

        /// <summary>
        /// Репозиторий кампаний.
        /// </summary>
        private ICampaignRepository _campaignRepository;

        public UserService(IUserRepository userRepository, ICampaignRepository campaignRepository)
        {
            _userRepository = userRepository;
            _campaignRepository = campaignRepository;
        }

        /// <summary>
        /// Добавить пользователя в кампанию.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="campaignId">Идентификатор кампании.</param>
        public void JoinCampaign(long userId, long campaignId)
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

            if (user.JoinedCampaigns.Contains(campaign))
            {
                // Пользователь уже состоит в кампании
                return;
            }

            user.JoinedCampaigns.Add(campaign);

            _userRepository.Save(user);
        }
    }
}
