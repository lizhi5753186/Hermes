using System.Configuration;
using StructureMap.Building;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements
{
    internal class SubscriberMessageConfigurationElement : 
        MessageConfigurationElement 
    {
        [ConfigurationProperty("concurrency", IsRequired = false)]
        internal SubscriberMessageConcurrencyConfigurationElement Concurrency
        {
            get { return this["concurrency"] as SubscriberMessageConcurrencyConfigurationElement; }
            set { this["concurrency"] = value; }
        }
    }
}