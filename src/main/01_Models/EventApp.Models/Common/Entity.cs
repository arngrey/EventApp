using System;

namespace EventApp.Models
{
    /// <summary>
    /// Сущность.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Задаёт или получает идентификатор сущности.
        /// </summary>
        public virtual Guid Id { get; set; }
    }
}
