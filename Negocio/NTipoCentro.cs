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
    public class NTipoCentro
    {
        public static List<DTipoCentro> ListaPuesto()
        {
            return AdTipoCentro.ListaPuesto();
        }

        public static bool Agregar(DTipoCentro e)
        {
            return AdTipoCentro.Agregar(e);
        }

        public static bool Actualizar(DTipoCentro e)
        {
            return AdTipoCentro.Actualizar(e);
        }

        public static bool Eliminar(DTipoCentro e)
        {
            return AdTipoCentro.Eliminar(e);
        }
    }
}
