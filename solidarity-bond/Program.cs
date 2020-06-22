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
            str_msg.password = "baudry";
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

            /* TEST CONNECTION INPUT
            str_msg.data["operation"] = "connection";
            */

            /* TEST STOCK INPUT*/
            str_msg.data["operation"] = "get_stock";
            //str_msg.data["operation"] = "update_stock";
            str_msg.data["struct_name"] = "StockStruct";
            str_msg.data["struct"] = new StockStruct();
            str_msg.data["struct"].objet = "crochetV1";
            //str_msg.data["struct"].stock = 20;
            
            
            /* TEST RESERVATION INPUT*/
            //str_msg.data["operation"] = "get_reservations";
            //str_msg.data["operation"] = "get_reservations_by_user";
            /*
            str_msg.data["operation"] = "add_reservation";
            str_msg.data["struct_name"] = "ReservationStruct";
            str_msg.data["struct"] = new ReservationStruct();
            str_msg.data["struct"].centre = "Aix-en-Provence";
            str_msg.data["struct"].date = DateTime.Now;
            str_msg.data["struct"].username = "client";
            str_msg.data["struct"].objet = "crochetV1";
            */
            /*
            str_msg.data["operation"] = "update_reservation";
            str_msg.data["struct_name"] = "ReservationStruct";
            str_msg.data["struct"] = new ReservationStruct();
            str_msg.data["struct"].id = 1;
            str_msg.data["struct"].todo = "expedition";
            str_msg.data["struct"].livraison = true;
            str_msg.data["struct"].livraison_date = DateTime.Now;
            str_msg.data["struct"].pre_expedition = false;
            str_msg.data["struct"].pre_expedition_date = DateTime.Now;
            str_msg.data["struct"].expedition = false;
            str_msg.data["struct"].expedition_date = DateTime.Now;
            */

            String temp = JsonConvert.SerializeObject(str_msg);
            Console.WriteLine(temp + "<EOF>");

            /*STR_MSG result;
            result = (STR_MSG)JsonConvert.DeserializeObject<STR_MSG>(temp);*/

            Service service = new Service();
            service.StartListening();
        }
    }
}
