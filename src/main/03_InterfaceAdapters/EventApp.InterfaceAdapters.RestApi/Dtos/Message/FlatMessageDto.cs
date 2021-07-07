using System;

namespace EventApp.InterfaceAdapters.RestApi.Dtos
{
    public class FlatMessageDto
    {
        /// <summary>
        /// Идентификатор сообщения.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Задаёт или получает пользователя-отправителя сообщения.
        /// </summary>
        public Guid SenderId { get; set; }

        /// <summary>
        /// Задаёт или получает кампанию, в которую отправлено сообщение.
        /// </summary>
        public virtual Guid CampaignId { get; set; }

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
