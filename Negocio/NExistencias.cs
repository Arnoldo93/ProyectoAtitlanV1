using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Entidades;
using AccesoDatos;

namespace Negocio
{
    public class NExistencias
    {
        public static bool Agregar(DExistencias e)
        {
            return AdExistencias.AgregaryActualizar(e);
        }

        public static bool Actualizarexistenciaventa(DExistencias e)
        {
            return AdExistencias.ActualizarExistenciaPorVenta(e);
        }

        public static bool Eliminar (DExistencias e)
        {
            return AdExistencias.Eliminar(e);
        }

        public static DataTable pesoyvolumen(DExistencias e)
        {
            return AdExistencias.pesoyvolumen(e);
        }
    }
}
