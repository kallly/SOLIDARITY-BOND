using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace solidarity_bond
{
    class ReservationExecutionEngine
    {
        private ReservationComponent reservationComponent;
        private StockComponent stockComponent;
        public ReservationExecutionEngine()
        {
            reservationComponent = new ReservationComponent();
        }
        public STR_MSG Get_reservations(STR_MSG str_msg)
        {
            return reservationComponent.Get_reservations(str_msg);;
        }
        public STR_MSG Get_reservations_by_user(STR_MSG str_msg)
        {
            return reservationComponent.Get_reservations_by_user(str_msg);;
        }
        public STR_MSG Add_reservation(STR_MSG str_msg)
        {
            return reservationComponent.Add_reservation(str_msg);;
        }
        public STR_MSG Update_reservation(STR_MSG str_msg)
        {   
            STR_MSG temp = new STR_MSG();
            temp.data = new Dictionary<string, dynamic>
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
            temp.data["struct"] = new ReservationStruct();
            temp.data["struct"].todo = (string)str_msg.data["struct"].todo;
            temp.data["struct"].livraison = (bool)str_msg.data["struct"].livraison;
            temp.data["struct"].livraison_date = (DateTime)str_msg.data["struct"].livraison_date;
            temp.data["struct"].pre_expedition = (bool)str_msg.data["struct"].pre_expedition;
            temp.data["struct"].pre_expedition_date = (DateTime)str_msg.data["struct"].pre_expedition_date;
            temp.data["struct"].expedition = (bool)str_msg.data["struct"].expedition;
            temp.data["struct"].expedition_date = (DateTime)str_msg.data["struct"].expedition_date;
            temp.data["struct"].id = (int)str_msg.data["struct"].id;

            STR_MSG temp2 = str_msg;
            if(((bool)str_msg.data["struct"].pre_expedition) && !((bool)str_msg.data["struct"].expedition)){
                stockComponent = new StockComponent();

                temp2 = reservationComponent.Get_reservations_by_id(temp);
                int quantite = temp2.data["result"].Rows[0]["quantite"];

                Console.WriteLine(JsonConvert.SerializeObject(temp2.data["result"].Rows[0]));

                StockStruct stock = new StockStruct();
                stock.objet = temp2.data["result"].Rows[0]["objet"];
                str_msg.data["struct"] = stock;
                str_msg = stockComponent.Get_stock(str_msg);
                Console.WriteLine(JsonConvert.SerializeObject(temp2.data["result"].Rows[0]));
                str_msg.data["struct"].stock = str_msg.data["result"].Rows[0]["nombre"] - quantite;
                str_msg = stockComponent.Update_stock(str_msg);

            }
            return reservationComponent.Update_reservation(temp);
        }
    }
}
