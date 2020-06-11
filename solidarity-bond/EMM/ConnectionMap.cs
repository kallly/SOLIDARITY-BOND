using System;

namespace solidarity_bond
{
    class ConnectionMap
    {
        public STR_MSG Connection(STR_MSG str_msg)
        {
            str_msg.data["query"] = "SELECT * FROM person " +
            "WHERE username=" + str_msg.username + " AND " + "password=" + str_msg.password;
            Console.WriteLine(str_msg.data["query"]);
            str_msg.data["query"] = " ";
            return str_msg;
        }
    }
}
