using AutoMapper;
using EventApp.Models;
using System;

namespace EventApp.InterfaceAdapters.RestApi.Dtos
{
    [AutoMap(typeof(Hobby))]
    public class FlatHobbyDto
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
