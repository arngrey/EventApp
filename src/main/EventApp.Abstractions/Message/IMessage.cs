using EventApp.Abstractions.User;
using System;

namespace EventApp.Abstractions.Message
{
    /// <summary>
    /// Сообщение.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Задаёт или получает идентификатор сообщения.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Задаёт или получает пользователя-отправителя сообщения.
        /// </summary>
        public IUser Sender { get; set; }

        /// <summary>
        /// Задаёт или получает текст сообщения.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Задаёт или получает дату и время создания сообщения.
        /// </summary>
        public DateTime Created { get; set; }
    }
}
