using System.Collections.Generic;

namespace EventApp.Entities
{
    /// <inheritdoc/>
    public class User: IUser
    {
        /// <inheritdoc/>

        public long? Id { get; set; }

        /// <inheritdoc/>

        public string Name { get; set; }

        /// <inheritdoc/>

        public List<Campaign> JoinedCampaigns { get; set; }
    }
}
