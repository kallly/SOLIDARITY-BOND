using System;
using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace solidarity_bond
{
    public class CAD_SQL
    {
        private bool connected;

        private string conString;
        private MySqlConnection sqlConnection;

        public CAD_SQL(STR_MSG str_msg)
        {
            // Init sql connection
            this.conString = @"Server=192.168.1.85; Database=solidarity_bond; Uid=root; Pwd=;";
            try
            {
                this.sqlConnection = new MySqlConnection(conString);
                Console.WriteLine("flag");
            }
            catch (MySqlException e)
            {
                connected = false;
                return;
            }
            connected = true;
        }

        // Used for a login
        public STR_MSG OpenConnection(STR_MSG str_msg)
        {
            // Init sql connection
            string conString = str_msg.data["query"].ToString();
            try
            {
                this.sqlConnection = new MySqlConnection(conString);
                // Init sql objects
                string query = "";
                MySqlCommand sqlCommand = new MySqlCommand(query, this.sqlConnection);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                // Test connection
                sqlCommand.Connection.Open();
                sqlCommand.Connection.Close();
            }
            catch (MySqlException e)
            {
                connected = false;
                str_msg.data["success"] = string.Empty;
                str_msg.data["error"] = "SQL connection failed";
                return str_msg;
            }
            connected = true;
            str_msg.data["success"] = "Successful SQL connection";
            str_msg.data["error"] = string.Empty;
            return str_msg;
        }

        public STR_MSG ExecQuery(STR_MSG str_msg)
        {
            str_msg.data["result"] = GetDataSet((string)str_msg.data["query"], this.conString).Tables[0];
            return str_msg;
        }

        public bool isConnected() { return connected; }


        // Internal treatment
        private int actionRows(string query)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection.Open();
            int nAffectedRows = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return nAffectedRows;
        }
        private DataSet getRows(string query)
        {
            MySqlCommand sqlCommand = new MySqlCommand(query, this.sqlConnection);
            MySqlDataAdapter da = new MySqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            return ds;
        }
        private DataSet GetDataSet(string sqlCommand, string connectionString)
        {
            DataSet ds = new DataSet();
            
            this.sqlConnection.Open();
            MySqlCommand cmd = this.sqlConnection.CreateCommand();
            
            cmd.CommandText = sqlCommand; 

            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            ds.Tables.Add(table);
            
             this.sqlConnection.Close();
            return ds;
        }
        private DataTable getTable(string query)
        {
            return GetDataSet(query, this.conString).Tables[0];
        }
        public int updateRows(string query)
        {
            int result;
            MySqlCommand sqlCommand = new MySqlCommand(query, this.sqlConnection);
            sqlCommand.Connection.Open();
            Debug.WriteLine(query);
            result = sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();

            return result;
        }
        public int addRows(string query)
        {
            int result;
            MySqlCommand sqlCommand = new MySqlCommand(query, this.sqlConnection);
            sqlCommand.Connection.Open();
            Debug.WriteLine(query);
            result = sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();

            return result;
        }
    }
}