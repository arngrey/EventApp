using CSharpFunctionalExtensions;
using EventApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
        /// Регистрация нового пользователя.
        /// </summary>
        /// <param name="login">Имя пользователя.</param>
        /// <returns>Идентификатор созданного пользователя.</returns>
        public async Task<Result<Guid>> SignUpAsync(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
            {
                return Result.Failure<Guid>("Логин пользователя обязателен.");
            }

            if (string.IsNullOrEmpty(password))
            {
                return Result.Failure<Guid>("Пароль обязателен.");
            }

            var users = await _userRepository.GetAllAsync();

            if (users.Any(u => u.Login == login))
            {
                return Result.Failure<Guid>("Пользователь с таким логином уже существует.");
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Login = login,
                Password = password
            };

            await _userRepository.SaveAsync(newUser);

            return Result.Success(newUser.Id);
        }

        /// <summary>
        /// Аутентификация пользователя.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>Информация о пользователе.</returns>
        public async Task<Result<User>> SignInAsync(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
            {
                return Result.Failure<User>("Логин пользователя обязателен.");
            }

            if (string.IsNullOrEmpty(password))
            {
                return Result.Failure<User>("Пароль обязателен.");
            }

            var users = await _userRepository.GetAllAsync();

            if (!users.Any(u => u.Login == login && u.Password == password))
            {
                return Result.Failure<User>("Введены неверные логин или пароль.");
            }

            var user = users.First(u => u.Login == login && u.Password == password);

            return Result.Success(user);
        }
    }
}
