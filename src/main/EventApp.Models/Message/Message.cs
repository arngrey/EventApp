using EventApp.Abstractions.Message;
using EventApp.Abstractions.User;
using System;

namespace EventApp.Models.Message
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
