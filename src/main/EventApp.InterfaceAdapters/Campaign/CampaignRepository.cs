using EventApp.Abstractions.Campaign;
using System.Collections.Generic;

namespace EventApp.InterfaceAdapters.Campaign
{
    /// <inheritdoc/>
    public class CampaignRepository : ICampaignRepository
    {
        /// <inheritdoc/>
        public List<ICampaign> GetAll()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public ICampaign GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public void Save(ICampaign entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
