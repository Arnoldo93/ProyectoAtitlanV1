using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class NDatosCentro
    {
        public static List<DDatosCentro> ListaDatosCentro()
        {
            return AdDatosCentro.ListaDatosCentro();
        }

        public static bool Agregar(DDatosCentro e)
        {
            return AdDatosCentro.Agregar(e);
        }

        public static bool Actualizar(DDatosCentro e)
        {
            return AdDatosCentro.Actualizar(e);
        }

        public static bool Eliminar(DDatosCentro e)
        {
            return AdDatosCentro.Eliminar(e);
        }
    }
}
