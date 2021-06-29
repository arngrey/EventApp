namespace EventApp.Entities
{
    /// <inheritdoc/>
    public class Hobby: IHobby
    {
        /// <inheritdoc/>
        public long? Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }
    }
}
