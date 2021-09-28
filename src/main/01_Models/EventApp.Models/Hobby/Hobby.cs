namespace EventApp.Models
{
    /// <summary>
    /// Хобби.
    /// </summary>
    public class Hobby: Entity
    {
        /// <summary>
        /// Задает или получает наименование хобби.
        /// </summary>
        public virtual string Name { get; set; }
    }
}
