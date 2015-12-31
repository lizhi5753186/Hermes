using System;
using System.Collections.Generic;

namespace Hermes
{
    public class InternalMessage : IInternalMessage
    {
        public IDictionary<string, object> Headers { get; set; }
        public object Payload { get; set; }
    }
}
