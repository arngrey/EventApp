using CSharpFunctionalExtensions;
using EventApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <returns>Идентификатор созданного пользователя.</returns>
        public async Task<Result<Guid>> CreateUserAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Guid>("Имя пользователя обязательно.");
            }

            var users = await _userRepository.GetAllAsync();

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

            await _userRepository.SaveAsync(newUser);

            return Result.Success(newUser.Id);
        }
    }
}
