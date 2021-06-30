using CSharpFunctionalExtensions;
using EventApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventApp.UseCases
{
    /// <summary>
    /// Сервис по работе с пользователями.
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Репозиторий пользователей.
        /// </summary>
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <returns>Идентификатор созданного пользователя.</returns>
        public Result<Guid> CreateUser(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Guid>("Имя пользователя обязательно.");
            }

            var users = _userRepository.GetAll();

            if (users.Any(u => u.Name == name))
            {
                return Result.Failure<Guid>("Пользователь с таким именем уже существует.");
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                JoinedCampaigns = new List<Campaign>()
            };

            _userRepository.Save(newUser);

            return Result.Success(newUser.Id);
        }

        /// <summary>
        /// Получить пользователя по имени.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <returns></returns>
        public Result<User> GetUserByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<User>("Имя пользователя обязательно.");
            }

            var users = _userRepository.GetAll();

            if (!users.Any(u => u.Name == name))
            {
                return Result.Failure<User>("Пользователь с таким именем не найден.");
            }

            var result = users.Find(u => u.Name == name);

            return Result.Success<User>(result);
        }
    }
}
