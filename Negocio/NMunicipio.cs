using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using AccesoDatos;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class NMunicipio
    {
        public static DataTable ListaMunicipios()
        {
            return AdMunicipio.ListaMunicipio();
        }

        public static bool Agregar(DMunicipio e)
        {
            return AdMunicipio.Agregar(e);
        }

        public static bool Actualizar(DMunicipio e)
        {
            return AdMunicipio.Actualizar(e);
        }

        public static bool Eliminar(DMunicipio e)
        {
            return AdMunicipio.Eliminar(e);
        }

        public static int Id()
        {
            return AdMunicipio.Id();
        }
    }
}
