﻿using System.Configuration;
using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Collections
{
    internal class PublisherCollection :
        ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
            => ConfigurationElementCollectionType.BasicMap;

        protected override ConfigurationElement CreateNewElement()
        {
            return new MessageConfigurationElement();
        }

        protected override object GetElementKey(
            ConfigurationElement element
            )
        {
            return ((MessageConfigurationElement)element).Type;
        }

        internal MessageConfigurationElement this[int index]
        {
            get
            {
                return (MessageConfigurationElement)BaseGet(index);
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

        internal new MessageConfigurationElement this[string name]
            => (MessageConfigurationElement)BaseGet(name);

        protected override string ElementName
            => "message";
    }
}