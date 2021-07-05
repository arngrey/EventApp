using AutoMapper;
using EventApp.Entities;
using System;

namespace EventApp.InterfaceAdapters.RestApi.Dtos
{
    [AutoMap(typeof(Hobby))]
    public class HobbyDto
    {
        /// <summary>
        /// Идентификатор хобби.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование хобби.
        /// </summary>
        public string Name { get; set; }
    }
}
