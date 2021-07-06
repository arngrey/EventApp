using AutoMapper;
using AutoMapper.Configuration.Annotations;
using EventApp.Entities;
using System;
using System.Collections.Generic;

namespace EventApp.InterfaceAdapters.RestApi
{
    [AutoMap(typeof(User))]
    public class UserDto
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Задает или получает перечисление кампаний, участником которых является пользователь.
        /// </summary>
        public IList<Guid> JoinedCampaignIds { get; set; }
    }
}
