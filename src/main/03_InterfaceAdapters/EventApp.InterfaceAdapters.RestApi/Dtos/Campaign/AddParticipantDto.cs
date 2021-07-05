using System;

namespace EventApp.InterfaceAdapters.RestApi.Dtos
{
    public class AddParticipantDto
    {
        /// <summary>
        /// Идентификатор добавляемого пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор кампании.
        /// </summary>
        public Guid CampaignId { get; set; }
    }
}
