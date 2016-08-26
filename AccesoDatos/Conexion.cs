using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Conexion
    {
        public static string Cadena
        {
            get
            {
                try
                {
                    return "Database=proatitlan;Data Source=localhost;User Id=root;Password=database;Allow User Variables=True";
                }

                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
