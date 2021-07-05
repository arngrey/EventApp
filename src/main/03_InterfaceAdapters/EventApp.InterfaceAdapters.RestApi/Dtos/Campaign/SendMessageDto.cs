using System;

namespace EventApp.InterfaceAdapters.RestApi.Dtos
{
    public class SendMessageDto
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор кампании.
        /// </summary>
        public Guid CampaignId { get; set; }

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Text { get; set; }
    }
}
