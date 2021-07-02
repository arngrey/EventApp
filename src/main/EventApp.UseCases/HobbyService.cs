﻿using CSharpFunctionalExtensions;
using EventApp.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.UseCases
{
    /// <summary>
    /// Сервис по работе с хобби.
    /// </summary>
    public class HobbyService
    {
        /// <summary>
        /// Репозиторий хобби.
        /// </summary>
        private readonly IHobbyRepository _hobbyRepository;

        public HobbyService(IHobbyRepository hobbyRepository)
        {
            _hobbyRepository = hobbyRepository;
        }

        /// <summary>
        /// Создание нового хобби.
        /// </summary>
        /// <param name="name">Наименование хобби.</param>
        /// <returns>Идентификатор созданного хобби.</returns>
        public async Task<Result<Guid>> CreateHobbyAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Guid>("Наименовани хобби обязательно.");
            }

            var hobbies = await _hobbyRepository.GetAllAsync();

            if (hobbies.Any(u => u.Name == name))
            {
                return Result.Failure<Guid>("Хобби с таким наименованием уже существует.");
            }

            var newHobby = new Hobby
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            await _hobbyRepository.SaveAsync(newHobby);

            return Result.Success(newHobby.Id);
        }
    }
}
