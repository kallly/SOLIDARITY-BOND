using System;

namespace solidarity_bond
{
    class ConnectionComptoir
    {
        public STR_MSG connection(STR_MSG str_msg)
        {
            
            str_msg.data["success"] = "FLAG";
            return str_msg;
        }
    }
}
