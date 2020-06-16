using System;

namespace solidarity_bond
{
    public struct ReservationStruct
    {
        public int id;
        public string address,username;
        public DateTime date;
        public string todo;
        public bool livraison,pre_expedition,expedition;
        public DateTime livraison_date,pre_expedition_date,expedition_date;
    }
    class ReservationMap
    {
        public STR_MSG Select(STR_MSG str_msg)
        {
            str_msg.data["query"] = "SELECT * FROM reservation;";
            Console.WriteLine(str_msg.data["query"]);
            return str_msg;
        }
        public STR_MSG SelectByUser(STR_MSG str_msg)
        {
            str_msg.data["query"] = "SELECT * FROM reservation " +
            "WHERE ( username='" + str_msg.username + "');";
            Console.WriteLine(str_msg.data["query"]);
            return str_msg;
        }
        public STR_MSG Insert(STR_MSG str_msg)
        {
            str_msg.data["query"] = "INSERT INTO reservation " +
            "(adress,date,username) " +
            "VALUES ('" + str_msg.data["struct"].address + "','" + 
            str_msg.data["struct"].date.ToString("yyyy-MM-dd") + "','" + 
            str_msg.username + "');";
            Console.WriteLine(str_msg.data["query"]);
            return str_msg;
        }
        public STR_MSG UpdateEtape(STR_MSG str_msg)
        {
            str_msg.data["query"] = "UPDATE reservation SET " +
            "todo='" + str_msg.data["struct"].todo + "'," +
            "livraison=" + ((str_msg.data["struct"].livraison == "true")?"1":"0") + "," +
            "livraison_date='" + str_msg.data["struct"].livraison_date.ToString("yyyy-MM-dd") + "'," +
            "pre_expedition=" + ((str_msg.data["struct"].pre_expedition == "true")?"1":"0") + "," +
            "pre_expedition_date='" + str_msg.data["struct"].pre_expedition_date.ToString("yyyy-MM-dd") + "'," +
            "expedition=" + ((str_msg.data["struct"].expedition == "true")?"1":"0") + "," +
            "expedition_date='" + str_msg.data["struct"].expedition_date.ToString("yyyy-MM-dd") + "' " +
            "WHERE ( id=" + str_msg.data["struct"].id + ");";
            Console.WriteLine(str_msg.data["query"]);
            return str_msg;
        }
    }
}
