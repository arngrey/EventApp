namespace EventApp.Models
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User: Entity
    {
        /// <summary>
        /// Задает или получает логин пользователя.
        /// </summary>
        public virtual string Login { get; set; }

        /// <summary>
        /// Задает или получает пароль пользователя.
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Задает или получает имя пользователя.
        /// </summary>
        public virtual string FirstName { get; set; }
    }
}
