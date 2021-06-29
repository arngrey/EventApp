using EventApp.Abstractions.Common;

namespace EventApp.Abstractions.User
{
    /// <summary>
    /// Репозиторий пользователей.
    /// </summary>
    public interface IUserRepository : IRepository<IUser>
    {
    }
}
