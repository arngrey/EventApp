using EventApp.Abstractions.Hobby;

namespace EventApp.Models.Hobby
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
