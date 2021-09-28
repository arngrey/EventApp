using System;

namespace EventApp.Models
{
    /// <summary>
    /// Сообщение.
    /// </summary>
    public class Message: Entity
    {
        /// <summary>
        /// Задаёт или получает пользователя-отправителя сообщения.
        /// </summary>
        public virtual User Sender { get; set; }

        /// <summary>
        /// Задаёт или получает кампанию, в которую отправлено сообщение.
        /// </summary>
        public virtual Campaign Campaign { get; set; }

        /// <summary>
        /// Задаёт или получает текст сообщения.
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        /// Задаёт или получает дату и время создания сообщения.
        /// </summary>
        public virtual DateTime Created { get; set; }
    }
}
