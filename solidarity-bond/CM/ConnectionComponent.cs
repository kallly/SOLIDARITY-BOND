using System;
using System.Data;

namespace solidarity_bond
{
    class ConnectionComponent
    {
        private CAD_SQL cad;
        private ConnectionMap connectionMap = new ConnectionMap();

        private STR_MSG ExecSQL(STR_MSG str_msg)
        {
            // Call data access component
            if (str_msg.data["query"] != string.Empty)
            {
                // Call CAD
                cad = new CAD_SQL(str_msg);
                // Exec query
                str_msg = cad.ExecQuery(str_msg);
                // Check result
                if (((DataTable)str_msg.data["result"]).Rows.Count > 1)
                {
                    str_msg.data["success"] = "SQL query executed successfully.";
                    str_msg.data["error"] = string.Empty;
                }
                else
                {
                    str_msg.data["success"] = string.Empty;
                    str_msg.data["error"] = "The SQL result table is empty.";
                }
            }
            else
            {
                str_msg.data["success"] = string.Empty;
                str_msg.data["error"] = "The SQL query is empty.";
            }
            return str_msg;
        }

        public STR_MSG Connection(STR_MSG str_msg)
        {   
            return ExecSQL(connectionMap.Connection(str_msg));
        }
    }
}
