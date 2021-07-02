using EventApp.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.InterfaceAdapters
{
    /// <summary>
    /// Репозиторий, реализуемый NHibernate'ом.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public class NHibernateRepository<T> : IRepository<T> where T : Entity
    {
        /// <summary>
        /// Открытая сессия работы в БД.
        /// </summary>
        private ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        /// <inheritdoc cref="IRepository{T}.GetAll"/>
        public IList<T> GetAll()
        {
            return _session.QueryOver<T>()
                .List<T>()
                .ToList();
        }

        /// <inheritdoc cref="IRepository{T}.GetById"/>
        public T GetById(Guid id)
        {
            return _session.Get<T>(id);
        }

        /// <inheritdoc cref="IRepository{T}.Save"/>
        public void Save(T entity)
        {
            _session.Save(entity);
            _session.Flush();
        }

        /// <inheritdoc cref="IRepository{T}.GetAllAsync"/>
        public async Task<IList<T>> GetAllAsync()
        {
            return await _session.QueryOver<T>()
                .ListAsync<T>();
        }

        /// <inheritdoc cref="IRepository{T}.GetByIdAsync"/>
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _session.GetAsync<T>(id);
        }

        /// <inheritdoc cref="IRepository{T}.SaveAsync"/>
        public async Task SaveAsync(T entity)
        {
            await _session.SaveAsync(entity);
            await _session.FlushAsync();
        }
    }
}
