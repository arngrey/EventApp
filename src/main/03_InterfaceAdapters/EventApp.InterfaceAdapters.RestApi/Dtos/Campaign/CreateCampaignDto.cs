using System;
using System.Collections.Generic;

namespace EventApp.InterfaceAdapters.RestApi.Dtos
{
    public class CreateCampaignDto
    {
        /// <summary>
        /// Задает или получает наименование кампании.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Задает или получает администратора кампании.
        /// </summary>
        public Guid AdministratorId { get; set; }

        /// <summary>
        /// Задает или получает список хобби, указанных кампании.
        /// </summary>
        public IList<Guid> HobbyIds { get; set; }
    }
}
