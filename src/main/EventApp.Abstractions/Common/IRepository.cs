using System.Collections.Generic;

namespace EventApp.Abstractions.Common
{
    /// <summary>
    /// Репозиторий.
    /// </summary>
    /// <typeparam name="T">Тип модели.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Получить сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        public T GetById(long id);

        /// <summary>
        /// Получить все сущности.
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll();

        /// <summary>
        /// Сохранить сущность.
        /// </summary>
        /// <param name="entity">Сохраняемая сущность.</param>
        /// <returns>Идентификатор.</returns>
        public void Save(T entity);
    }
}
