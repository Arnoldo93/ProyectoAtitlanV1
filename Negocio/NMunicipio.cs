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
    public class NMunicipio
    {
        public static List<DMunicipio> ListaPuesto()
        {
            return AdMunicipio.Listamunicipios();
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
    }
}
