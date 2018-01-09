using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DataConfig
    {
        static DataConfig _instance;
        public static DataConfig Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DataConfig();
                }
                return _instance;
            }
        }

        string connstr = @"Data Source = DESKTOP-3BDG4J1\SQLEXPRESS; Initial Catalog = shop; Integrated Security = true";
        SqlConnection connect()
        {
            return new SqlConnection(connstr);
        }

        public DataTable GetTable(string sql)
        {
            var conn = connect();
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable GetTable(string sql, SqlParameter[] parameters)
        {
            var conn = connect();
            conn.Open();
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddRange(parameters);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public int ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            var conn = connect();
            conn.Open();
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddRange(parameters);
            int r = command.ExecuteNonQuery();
            conn.Close();
            return r;
        }

        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, new SqlParameter[0]);
        }

        public object ExecuteScalar(string sql, SqlParameter[] parameters)
        {
            var conn = connect();
            conn.Open();
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddRange(parameters);
            var ob = command.ExecuteScalar();
            conn.Close();
            return ob;
        }

    }
}
