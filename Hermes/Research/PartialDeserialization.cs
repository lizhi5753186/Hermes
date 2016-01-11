//using System;
//using System.Collections.Generic;

//namespace ConsoleApplication3
//{
//    public interface IMessage
//    {

//    }

//    public class InternalMessage
//    {
//        public IDictionary<string, string> Headers { get; set; }
//        public IMessage Message { get; set; }
//    }

//    public class MyMessage : IMessage
//    {
//        public string Name { get; set; }
//        public string LastName { get; set; }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var internalMessage = new InternalMessage()
//            {
//                Headers = new Dictionary<string, string>()
//                {
//                    ["type"] = typeof(MyMessage).ToString()
//                },

//                Message = new MyMessage()
//                {
//                    Name = "Tiaan",
//                    LastName = "de Klerk"
//                }
//            };

//            var json = Newtonsoft.Json.JsonConvert.SerializeObject(internalMessage);
//            Console.WriteLine(json);

//            var parsedJson = Newtonsoft.Json.Linq.JObject.Parse(json);
//            var headers = parsedJson["Headers"].ToObject<Dictionary<string, string>>();

//            var toType = Type.GetType(headers["type"], true);
//            var obj = parsedJson["Message"].ToObject(toType) as MyMessage;

//            //var toType = Type.GetType(headers["type"], true);
//            //var obj = (MyMessage)Newtonsoft.Json.JsonConvert.DeserializeObject(parsedMessage, toType);
//            //var obj = (MyMessage)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(MyMessage));

//            if (obj != null)
//            {
//                Console.WriteLine(obj.Name);
//            }
//            else
//            {
//                Console.WriteLine("Null object");
//            }

//            Console.ReadKey();
//        }
//    }
//}
