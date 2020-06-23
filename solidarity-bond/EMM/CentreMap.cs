using System;

namespace solidarity_bond
{
    public struct CentreStruct
    {
        public string centre;
    }
    public class CentreMap
    {
        public STR_MSG SELECT(STR_MSG str_msg)
        {
            str_msg.data["query"] = "SELECT * FROM centre;";
            Console.WriteLine(str_msg.data["query"]);
            return str_msg;
        }
    }
}