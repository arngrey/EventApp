using System.Collections.Generic;

namespace EventApp.Models
{
    /// <summary>
    /// Кампания.
    /// </summary>
    public class Campaign: Entity
    {
        /// <summary>
        /// Задает или получает наименование кампании.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Задает или получает администратора кампании.
        /// </summary>
        public virtual User Administrator { get; set; }

        /// <summary>
        /// Задает или получает список хобби, указанных кампании.
        /// </summary>
        public virtual IList<Hobby> Hobbies { get; set; }

        /// <summary>
        /// Задает или получает список участников кампании.
        /// </summary>
        public virtual IList<User> Participants { get; set; }

        /// <summary>
        /// Задает или получает список сообщений кампании.
        /// </summary>
        public virtual IList<Message> Messages { get; set; }
    }
}
