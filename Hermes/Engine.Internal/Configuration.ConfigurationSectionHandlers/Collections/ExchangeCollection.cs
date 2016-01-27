using System.Configuration;
using Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Elements;

namespace Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Collections
{
    public class ExchangeCollection : 
        ConfigurationElementCollection
    {
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

        protected override string ElementName
            => "exchange";
    }
}