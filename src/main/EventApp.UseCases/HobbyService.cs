using CSharpFunctionalExtensions;
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
        public Result CreateHobby(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure("Наименовани хобби обязательно.");
            }

            var hobbies = _hobbyRepository.GetAll();

            if (hobbies.Any(u => u.Name == name))
            {
                return Result.Failure("Хобби с таким наименованием уже существует.");
            }

            var newHobby = new Hobby
            {
                Id = null,
                Name = name
            };

            _hobbyRepository.Save(newHobby);

            return Result.Success();
        }

        /// <summary>
        /// Получить хобби по наименованию.
        /// </summary>
        /// <param name="name">Наименование хобби.</param>
        /// <returns></returns>
        public Result<Hobby> GetHobbyByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Hobby>("Наименование хобби обязательно.");
            }

            var hobbies = _hobbyRepository.GetAll();

            if (!hobbies.Any(u => u.Name == name))
            {
                return Result.Failure<Hobby>("Хобби с таким наименованием не найдено.");
            }

            var result = hobbies.Find(u => u.Name == name);
            return Result.Success<Hobby>(result);
        }
    }
}
