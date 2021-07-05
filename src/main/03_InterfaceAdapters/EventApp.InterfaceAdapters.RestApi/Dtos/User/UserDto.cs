using AutoMapper;
using AutoMapper.Configuration.Annotations;
using EventApp.Entities;
using System;

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
    }
}
