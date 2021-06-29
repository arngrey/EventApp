using EventApp.Abstractions.Campaign;
using EventApp.Abstractions.Hobby;
using EventApp.Abstractions.Message;
using EventApp.Abstractions.User;
using System.Collections.Generic;

namespace EventApp.Models.Campaign
{
    /// <inheritdoc/>
    public class Campaign: ICampaign
    {
        /// <inheritdoc/>
        public long? Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public IUser Administrator { get; set; }

        /// <inheritdoc/>
        public List<IHobby> Hobbies { get; set; }

        /// <inheritdoc/>
        public List<IUser> Participants { get; set; }

        /// <inheritdoc/>
        public List<IMessage> Messages { get; set; }
    }
}
