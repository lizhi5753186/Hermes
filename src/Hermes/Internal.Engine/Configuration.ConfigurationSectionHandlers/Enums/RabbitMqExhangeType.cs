namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Enums
{
    /// <summary>
    /// Describes the RabbitMq exchange types.
    /// </summary>
    public enum RabbitMqExchangeType
    {
        /// <summary>
        /// amq.direct
        /// </summary>
        Direct,

        /// <summary>
        /// amq.fanout (This is the default if no type specified).
        /// </summary>
        Fanout,

        /// <summary>
        /// amq.topic
        /// </summary>
        Topic,

        /// <summary>
        /// amq.match
        /// </summary>
        Headers
    }
}
