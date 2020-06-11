using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace solidarity_bond
{
    class Program
    {
        static void Main(string[] args)
        {
            
            STR_MSG str_msg = new STR_MSG();
            str_msg.username = "baudry";
            str_msg.password = "password";
            str_msg.application = "solidarity_app_console";
            str_msg.version = "1.0";

             str_msg.data = new Dictionary<string, dynamic>
            {
                { "operation", string.Empty },
                { "query", string.Empty },
                { "struct_name", string.Empty },
                { "struct", null },
                { "result", null },
                { "affectedRows", 0 },
                { "success", string.Empty },
                { "error", string.Empty }
            };

            str_msg.data["operation"] = "connection";
            
            String temp = JsonConvert.SerializeObject(str_msg);
            Console.WriteLine(temp + "<EOF>");

            /*STR_MSG result;
            result = (STR_MSG)JsonConvert.DeserializeObject<STR_MSG>(temp);*/

            Service service = new Service();
            service.StartListening();
        }
    }
}
