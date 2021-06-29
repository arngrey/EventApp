namespace EventApp.Entities
{
    /// <summary>
    /// Хобби.
    /// </summary>
    public interface IHobby
    {
        /// <summary>
        /// Задаёт или получает идентификатор хобби.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Задает или получает наименование хобби.
        /// </summary>
        public string Name { get; set; }
    }
}
