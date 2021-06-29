using EventApp.Abstractions.Hobby;
using EventApp.Abstractions.Message;
using EventApp.Abstractions.User;
using System.Collections.Generic;

namespace EventApp.Abstractions.Campaign
{
    /// <summary>
    /// Кампания.
    /// </summary>
    public interface ICampaign
    {
        /// <summary>
        /// Задаёт или получает идентификатор кампании.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Задает или получает наименование кампании.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Задает или возвращает администратора кампании.
        /// </summary>
        public IUser Administrator { get; set; }

        /// <summary>
        /// Задает или получает список хобби, указанных кампании.
        /// </summary>
        public List<IHobby> Hobbies { get; set; }

        /// <summary>
        /// Задает или получает список участников кампании.
        /// </summary>
        public List<IUser> Participants { get; set; }

        /// <summary>
        /// Задает или получает список сообщений кампании.
        /// </summary>
        public List<IMessage> Messages { get; set; }
    }
}
