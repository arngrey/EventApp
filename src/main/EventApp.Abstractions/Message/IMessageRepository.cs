using EventApp.Abstractions.Common;

namespace EventApp.Abstractions.Message
{
    /// <summary>
    /// Репозиторий сообщений.
    /// </summary>
    public interface IMessageRepository : IRepository<IMessage>
    {
    }
}
