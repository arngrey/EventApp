using EventApp.Abstractions.User;
using System.Collections.Generic;

namespace EventApp.InterfaceAdapters.User
{
    /// <inheritdoc/>
    public class UserRepository : IUserRepository
    {
        /// <inheritdoc/>
        public List<IUser> GetAll()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public IUser GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public void Save(IUser entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
