using System.Collections.Generic;

namespace EventApp.Entities
{
    /// <inheritdoc/>
    public class Campaign: ICampaign
    {
        /// <inheritdoc/>
        public long? Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public User Administrator { get; set; }

        /// <inheritdoc/>
        public List<Hobby> Hobbies { get; set; }

        /// <inheritdoc/>
        public List<User> Participants { get; set; }

        /// <inheritdoc/>
        public List<Message> Messages { get; set; }
    }
}
