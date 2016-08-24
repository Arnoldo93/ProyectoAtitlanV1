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
    public class NFamilia
    {
        public static List<DFamilia> ListaFamilias()
        {
            return AdFamilia.ListaFamilia();
        }

        public static bool Agregar(DFamilia e)
        {
            return AdFamilia.Agregar(e);
        }

        public static bool Actualizar(DFamilia e)
        {
            return AdFamilia.Actualizar(e);
        }

        public static bool Eliminar(DFamilia e)
        {
            return AdFamilia.Eliminar(e);
        }
    }
}
