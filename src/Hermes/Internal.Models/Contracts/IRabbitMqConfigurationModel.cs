using System.Collections.Generic;

namespace Hermes.Internal.Models.Contracts
{
    internal interface IRabbitMqConfigurationModel
    {
        IEnumerable<IPublisher> Publishers { get; set; }
        IEnumerable<ISubscriber> Subscribers { get; set; }
    }
}
