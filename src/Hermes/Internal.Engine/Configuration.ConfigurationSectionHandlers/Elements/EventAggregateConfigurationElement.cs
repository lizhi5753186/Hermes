﻿using System.Configuration;
using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Collections;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements
{
    internal class EventAggregateConfigurationElement :
        ConfigurationElement
    {
        [ConfigurationProperty("publishers", IsRequired = false)]
        internal PublisherCollection Publishers
        {
            get { return this["publishers"] as PublisherCollection; }
            set { this["publishers"] = value; }
        }

        [ConfigurationProperty("subscribers", IsRequired = false)]
        internal SubscriberCollection Subscribers
        {
            get { return this["subscribers"] as SubscriberCollection; }
            set { this["subscribers"] = value; }
        }
    }
}
