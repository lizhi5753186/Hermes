using System.Configuration;
using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Collections
{
    internal class HostCollection : 
        ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
            => ConfigurationElementCollectionType.BasicMap;

        protected override ConfigurationElement CreateNewElement()
        {
            return new HostConfigurationElement();
        }

        protected override object GetElementKey(
            ConfigurationElement element
            )
        {
            return ((HostConfigurationElement)element).Name;
        }

        internal HostConfigurationElement this[int index]
        {
            get
            {
                return (HostConfigurationElement)BaseGet(index);
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

        internal new HostConfigurationElement this[string name]
            => (HostConfigurationElement)BaseGet(name);

        protected override string ElementName
            => "host";
    }
}