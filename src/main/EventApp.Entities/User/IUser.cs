using System.Collections.Generic;

namespace EventApp.Entities
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Задаёт или получает идентификатор пользователя.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Задает или получает имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Задает или получает перечисление кампаний, участником которых является пользователь.
        /// </summary>
        public List<Campaign> JoinedCampaigns { get; set; }
    }
}
