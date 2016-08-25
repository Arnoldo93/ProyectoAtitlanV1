using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using AccesoDatos;

namespace Negocio
{
    public class NMedida
    {
        public static DataTable ListaMedida()
        {
            return AdMedida.ListaMedida();
        }

        public static bool Agregar(DMedida e)
        {
            return AdMedida.Agregar(e);
        }

        public static bool Actualizar(DMedida e)
        {
            return AdMedida.Actualizar(e);
        }

        public static bool Eliminar(DMedida e)
        {
            return AdMedida.Eliminar(e);
        }

        public static int id()
        {
            return AdMedida.Id();
        }
    }
}
