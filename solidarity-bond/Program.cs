using System;
using Newtonsoft.Json;

namespace solidarity_bond
{
    class Program
    {
        static void Main(string[] args)
        {
            STR_MSG str_msg = new STR_MSG();
            
            Console.WriteLine(JsonConvert.SerializeObject(str_msg));
            Service service = new Service();
            service.StartListening();
        }
    }
}
