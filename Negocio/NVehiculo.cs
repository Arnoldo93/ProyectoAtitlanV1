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
    public class NVehiculo
    {
        public static DataTable ListadoVechiculos()
        {
            return AdVehiculo.ListaVehiculos();
        }

        public static int Id()
        {
            return AdVehiculo.Id();
        }

        public static bool agregar(DVehiculo e)
        {
            return AdVehiculo.Agregar(e);
        }

        public static bool actualizar(DVehiculo e)
        {
            return AdVehiculo.Actualizar(e);
        }

        public static bool eliminar(DVehiculo e)
        {
            return AdVehiculo.Eliminar(e);
        }



    }
}
