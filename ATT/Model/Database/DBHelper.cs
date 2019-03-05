using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Model.Database
{
    class DBHelper
    {
        readonly static string ConnectionString = "server=konverdev.ru;user=admin;password=1111;database=apteka";
        static MySqlConnection Connection;
        public static MySqlConnection GetConnect()
        {
            try
            {
                if (Connection == null)
                {
                    Connection = new MySqlConnection(ConnectionString);
                }
                return Connection;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
