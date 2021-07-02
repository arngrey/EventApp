using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventApp.Entities
{
    /// <summary>
    /// Репозиторий.
    /// </summary>
    /// <typeparam name="T">Тип модели.</typeparam>
    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        /// Получить сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        public T GetById(Guid id);

        /// <summary>
        /// Получить все сущности.
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAll();

        /// <summary>
        /// Сохранить сущность.
        /// </summary>
        /// <param name="entity">Сохраняемая сущность.</param>
        /// <returns>Идентификатор.</returns>
        public void Save(T entity);

        /// <summary>
        /// Асинхронно получить сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        public Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Асинхронно получить все сущности.
        /// </summary>
        /// <returns></returns>
        public Task<IList<T>> GetAllAsync();

        /// <summary>
        /// Асинхронно сохранить сущность.
        /// </summary>
        /// <param name="entity">Сохраняемая сущность.</param>
        /// <returns>Идентификатор.</returns>
        public Task SaveAsync(T entity);
    }
}
