using System;
using System.Configuration;
using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Enums;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements
{
    internal class ExchangeConfigurationElement : 
        ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        internal string Name
        {
            get { return this["name"] as string; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("type", IsRequired = false)]
        internal RabbitMqExchangeType? Type
        {
            get
            {
                if (this["type"] != null)
                {
                    return (RabbitMqExchangeType)this["type"];
                }

                return RabbitMqExchangeType.Fanout;
            }

            set
            {
                this["type"] = value.ToString();
            }
        }
    }
}