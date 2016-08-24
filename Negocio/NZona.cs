using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class NZona
    {
        public static List<DZona> ListaPuesto()
        {
            return AdZona.ListaPuesto();
        }

        public static bool Agregar(DZona e)
        {
            return AdZona.Agregar(e);
        }

        public static bool Actualizar(DZona e)
        {
            return AdZona.Actualizar(e);
        }

        public static bool Eliminar(DZona e)
        {
            return AdZona.Eliminar(e);
        }
    }
}