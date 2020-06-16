using System;

namespace solidarity_bond
{
    public struct StockStruct
    {
        public string objet;
        public int stock;
    }
    class StockMap
    {
        public STR_MSG SelectByName(STR_MSG str_msg)
        {
            str_msg.data["query"] = "SELECT * FROM stock " +
            "WHERE ( objet='" + str_msg.data["struct"].objet + "');";
            Console.WriteLine(str_msg.data["query"]);
            return str_msg;
        }
        public STR_MSG UpdateByName(STR_MSG str_msg)
        {
            str_msg.data["query"] = "UPDATE stock " +
            " SET nombre=" + str_msg.data["struct"].stock +
            " WHERE ( objet='" + str_msg.data["struct"].objet + "');";
            Console.WriteLine(str_msg.data["query"]);
            return str_msg;
        }
    }
}
