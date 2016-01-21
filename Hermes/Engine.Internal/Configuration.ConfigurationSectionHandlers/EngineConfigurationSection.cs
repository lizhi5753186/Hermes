using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers
{
    public class EngineConfigurationSection : 
        ConfigurationSection
    {
    }

    public class TransportConfigurationElement :
        ConfigurationElement
    {
    }

    public class RabbitMqConfigurationElement : 
        ConfigurationElement
    {
        [ConfigurationProperty("exchanges", DefaultValue = "default", IsRequired = false)]
        public ExchangesConfigurationElement Exchanges
        {
            get; set;
        }
    }

    public class ExchangesConfigurationElement : 
        ConfigurationElement
    {
        [ConfigurationProperty("exchange", DefaultValue = "default", IsRequired = true)]
        public ExchangeConfigurationElementCollection Exchange
        {
            get { return (ExchangeConfigurationElementCollection)this["exchange"]; }
            set { this["exchanges"] = value; } 
        }
    }

    public class ExchangeConfigurationElement : 
        ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "default", IsRequired = true)]
        public string Name { get; set; }

    }

    public class ExchangeConfigurationElementCollection :
        ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ExchangeConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ExchangeConfigurationElement)element).Name;
        }
    }






    public class MsmqConfigurationElement :
    ConfigurationElement
    {

    }
}
