using System.Configuration;
using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Collections
{
    internal class ExchangeCollection : 
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

        internal ExchangeConfigurationElement this[int index]
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

        internal new ExchangeConfigurationElement this[string name]
            => (ExchangeConfigurationElement)BaseGet(name);

        protected override string ElementName
            => "exchange";
    }
}