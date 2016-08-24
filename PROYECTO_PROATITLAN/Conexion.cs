using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace PROYECTO_PROATITLAN
{
     public class Conexion
    {
        public string Seconecto()
        {
            return "Database=proatitlan;Data Source=localhost;User Id=root;Password=arnoldo69";
        }
    }
}
