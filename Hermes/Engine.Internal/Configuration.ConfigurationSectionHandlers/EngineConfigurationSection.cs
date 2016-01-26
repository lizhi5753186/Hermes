using System.Configuration;

namespace Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers
{
    public class EngineConfigurationSection : 
        ConfigurationSection
    {
        [ConfigurationProperty("transport", IsRequired = false)]
        public TransportConfigurationElement Transport
        {
            get { return this["transport"] as TransportConfigurationElement; }
            set { this["transport"] = value; }
        }
    }

    public class TransportConfigurationElement :
        ConfigurationElement
    {
        [ConfigurationProperty("rabbitMq", IsRequired = false)]
        public RabbitMqConfigurationElement RabbitMq
        {
            get { return this["rabbitMq"] as RabbitMqConfigurationElement; }
            set { this["rabbitMq"] = value; }
        }

        [ConfigurationProperty("msmq", IsRequired = false)]
        public MsmqConfigurationElement Msmq
        {
            get { return this["msmq"] as MsmqConfigurationElement; }
            set { this["msmq"] = value; }
        }
    }

    public class RabbitMqConfigurationElement :
        ConfigurationElement
    {
        [ConfigurationProperty("exchanges", IsRequired = false, IsDefaultCollection = true)]
        public ExchangeCollection Exchanges
            => this["exchanges"] as ExchangeCollection;
    }



    public class ExchangeCollection : 
        ConfigurationElementCollection
    {
        // TODO: Implement ctor...

        public override ConfigurationElementCollectionType CollectionType
            => ConfigurationElementCollectionType.BasicMap;

        protected override ConfigurationElement CreateNewElement()
        {
            return new ExchangeConfigurationElement();
        }

        protected override object GetElementKey(
            ConfigurationElement element
            )
        {
            return ((ExchangeConfigurationElement)element).Name;
        }

        public ExchangeConfigurationElement this[int index]
        {
            get
            {
                return (ExchangeConfigurationElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                BaseAdd(index, value);
            }
        }

        public new ExchangeConfigurationElement this[string name]
            => (ExchangeConfigurationElement)BaseGet(name);

        public int IndexOf(
            ExchangeConfigurationElement element
            )
        {
            return BaseIndexOf(element);
        }

        protected override void BaseAdd(
            ConfigurationElement element
            )
        {
            BaseAdd(element, false);
        }

        protected override string ElementName
            => "exchange";
    }

    public class ExchangeConfigurationElement : 
        ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "default", IsRequired = true)]
        public string Name { get; set; }
    }



    public class MsmqConfigurationElement :
        ConfigurationElement
    {

    }
}
