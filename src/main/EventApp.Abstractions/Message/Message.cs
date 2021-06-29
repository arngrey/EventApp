using System;

namespace EventApp.Entities
{
    /// <inheritdoc/>
    public class Message: IMessage
    {
        /// <inheritdoc/>
        public long? Id { get; set; }

        /// <inheritdoc/>
        public IUser Sender { get; set; }

        /// <inheritdoc/>
        public string Text { get; set; }

        /// <inheritdoc/>
        public DateTime Created { get; set; }
    }
}
