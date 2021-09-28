using AutoMapper;
using EventApp.Models;
using System;

namespace EventApp.InterfaceAdapters.RestApi.Dtos
{
    [AutoMap(typeof(User))]
    public class FlatUserDto
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; set; }
    }
}
