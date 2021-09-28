using AutoMapper;
using EventApp.Models;
using System;

namespace EventApp.InterfaceAdapters.RestApi.Dtos
{
    [AutoMap(typeof(Message))]
    public class MessageDto
    {
        /// <summary>
        /// Идентификатор сообщения.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Задаёт или получает пользователя-отправителя сообщения.
        /// </summary>
        public FlatUserDto Sender { get; set; }

        /// <summary>
        /// Задаёт или получает кампанию, в которую отправлено сообщение.
        /// </summary>
        public virtual FlatCampaignDto Campaign { get; set; }

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
