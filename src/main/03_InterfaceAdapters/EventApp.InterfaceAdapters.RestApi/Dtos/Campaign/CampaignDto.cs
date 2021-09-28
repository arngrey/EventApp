using AutoMapper;
using EventApp.Models;
using System;
using System.Collections.Generic;

namespace EventApp.InterfaceAdapters.RestApi.Dtos
{
    [AutoMap(typeof(Campaign))]
    public class CampaignDto
    {
        /// <summary>
        /// Задаёт или получает идентификатор кампании.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Задает или получает наименование кампании.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Задает или получает администратора кампании.
        /// </summary>
        public FlatUserDto Administrator { get; set; }

        /// <summary>
        /// Задает или получает список хобби, указанных кампании.
        /// </summary>
        public IList<FlatHobbyDto> Hobbies { get; set; }

        /// <summary>
        /// Задает или получает список участников кампании.
        /// </summary>
        public IList<FlatUserDto> Participants { get; set; }

        /// <summary>
        /// Задает или получает список сообщений кампании.
        /// </summary>
        public IList<FlatMessageDto> Messages { get; set; }
    }
}
