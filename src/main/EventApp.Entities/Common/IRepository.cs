using System;
using System.Collections.Generic;

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
        public List<T> GetAll();

        /// <summary>
        /// Сохранить сущность.
        /// </summary>
        /// <param name="entity">Сохраняемая сущность.</param>
        /// <returns>Идентификатор.</returns>
        public void Save(T entity);
    }
}
