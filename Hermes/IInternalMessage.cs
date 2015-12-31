using System;
using System.Collections.Generic;

namespace Hermes
{
    public enum HeaderType
    {
        System, 
        User
    }

    public interface IInternalMessage
    {
        IDictionary<string, object> Headers { get; set; }
        object Payload { get; set; }
    }
}
