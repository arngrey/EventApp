using EventApp.Entities;
using System.Linq;

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
        public void CreateHobby(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                // Наименовани хобби обязательно
                return;
            }

            var hobbies = _hobbyRepository.GetAll();

            if (hobbies.Any(u => u.Name == name))
            {
                // Хобби с таким наименованием уже существует
                return;
            }

            var newHobby = new Hobby
            {
                Id = null,
                Name = name
            };

            _hobbyRepository.Save(newHobby);
        }

        /// <summary>
        /// Получить хобби по наименованию.
        /// </summary>
        /// <param name="name">Наименование хобби.</param>
        /// <returns></returns>
        public Hobby GetHobbyByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                // Наименование хобби обязательно
                return null;
            }

            var hobbies = _hobbyRepository.GetAll();

            if (!hobbies.Any(u => u.Name == name))
            {
                // Хобби с таким наименованием не найдено
                return null;
            }

            return hobbies.Find(u => u.Name == name);
        }
    }
}
