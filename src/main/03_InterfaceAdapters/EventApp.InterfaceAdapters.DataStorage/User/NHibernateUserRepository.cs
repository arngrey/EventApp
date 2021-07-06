﻿using EventApp.Entities;
using NHibernate;

namespace EventApp.InterfaceAdapters.DataStorage
{
    /// <summary>
    /// Репозиторий кампаний, реализуемый NHibernate'ом.
    /// </summary>
    public class NHibernateUserRepository : NHibernateRepository<User>, IUserRepository
    {
        public NHibernateUserRepository(ISession session) : base(session)
        {
        }
    }
}
