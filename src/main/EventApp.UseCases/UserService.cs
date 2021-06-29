using EventApp.Entities;
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
        public void CreateUser(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                // Имя пользователя обязательно
                return;
            }

            var users = _userRepository.GetAll();

            if (users.Any(u => u.Name == name))
            {
                // Пользователь с таким именем уже существует
                return;
            }

            var newUser = new User
            {
                Id = null,
                Name = name,
                JoinedCampaigns = new List<Campaign>()
            };

            _userRepository.Save(newUser);
        }

        /// <summary>
        /// Получить пользователя по имени.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <returns></returns>
        public User GetUserByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                // Имя пользователя обязательно
                return null;
            }

            var users = _userRepository.GetAll();

            if (!users.Any(u => u.Name == name))
            {
                // Пользователь с таким именем не найден
                return null;
            }

            return users.Find(u => u.Name == name);
        }
    }
}
