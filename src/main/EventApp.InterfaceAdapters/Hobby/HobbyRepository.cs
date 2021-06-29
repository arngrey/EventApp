using EventApp.Abstractions.Hobby;
using System.Collections.Generic;

namespace EventApp.InterfaceAdapters.Hobby
{
    /// <inheritdoc/>
    public class HobbyRepository : IHobbyRepository
    {
        /// <inheritdoc/>
        public List<IHobby> GetAll()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public IHobby GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public void Save(IHobby entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
