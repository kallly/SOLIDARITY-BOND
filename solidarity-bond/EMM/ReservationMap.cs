using System;

namespace solidarity_bond
{
    public struct ReservationStruct
    {
        public int id;
        public string address,username;
        public DateTime date;
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
    }
}
