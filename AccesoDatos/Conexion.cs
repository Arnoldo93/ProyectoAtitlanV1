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
                    //return "Database=amsclaeg_sistema;Data Source=66.128.53.23;Port=3306;User Id=amsclaeg_ingsist;Password=GPKJU{5VGgkR;Integrated Security=true;Allow User Variables=true";
                    return "Database=proatitlan;Data Source=localhost;Port=3306;User Id=root;Password=database;Integrated Security=false;Allow User Variables=true";
                }

                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
