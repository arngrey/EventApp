using EventApp.Entities;
using NHibernate;
using System.Collections.Generic;

namespace EventApp.InterfaceAdapters
{
    /// <summary>
    /// Репозиторий, реализуемый NHibernate'ом.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public class NHibernateRepository<T> where T : class
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
        public List<T> GetAll()
        {
            return _session.QueryOver<T>()
                .List<T>() as List<T>;
        }

        /// <inheritdoc cref="IRepository{T}.GetById"/>
        public T GetById(long id)
        {
            return _session.Get<T>(id);
        }

        /// <inheritdoc cref="IRepository{T}.GetById"/>
        public void Save(T entity)
        {
            _session.Save(entity);
        }
    }
}
