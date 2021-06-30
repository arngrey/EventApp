using System;

namespace EventApp.Entities
{
    /// <summary>
    /// Сущность.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Задаёт или получает идентификатор сущности.
        /// </summary>
        public virtual Guid? Id { get; set; }
    }
}
