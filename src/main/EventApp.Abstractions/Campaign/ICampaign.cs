using System.Collections.Generic;

namespace EventApp.Entities
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
        public User Administrator { get; set; }

        /// <summary>
        /// Задает или получает список хобби, указанных кампании.
        /// </summary>
        public List<Hobby> Hobbies { get; set; }

        /// <summary>
        /// Задает или получает список участников кампании.
        /// </summary>
        public List<User> Participants { get; set; }

        /// <summary>
        /// Задает или получает список сообщений кампании.
        /// </summary>
        public List<Message> Messages { get; set; }
    }
}
