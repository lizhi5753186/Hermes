using AutoMapper;

namespace Hermes.Internal.Engine.Configuration.Parser
{
    public class Parser
    {
        public Parser()
        {
            IConfiguration mapConfig = new MapperConfiguration(x =>
            {
                x.CreateMap<object, object>();
            });
        }
    }
}
