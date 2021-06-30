using System.Collections.Generic;

namespace EventApp.Entities
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User: Entity
    {
        /// <summary>
        /// Задает или получает имя пользователя.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Задает или получает перечисление кампаний, участником которых является пользователь.
        /// </summary>
        public virtual IList<Campaign> JoinedCampaigns { get; set; }
    }
}
