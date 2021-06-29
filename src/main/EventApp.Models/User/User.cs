using EventApp.Abstractions.Campaign;
using EventApp.Abstractions.User;
using System.Collections.Generic;

namespace EventApp.Models.User
{
    /// <inheritdoc/>
    public class User: IUser
    {
        /// <inheritdoc/>

        public long? Id { get; set; }

        /// <inheritdoc/>

        public string Name { get; set; }

        /// <inheritdoc/>

        public List<ICampaign> JoinedCampaigns { get; set; }
    }
}
