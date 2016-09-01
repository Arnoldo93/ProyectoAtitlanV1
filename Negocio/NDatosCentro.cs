using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class NDatosCentro
    {
        public static DataTable ListaDatosCentro()
        {
            return AdDatosCentro.ListaCentro();
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

        public static int Id()
        {
            return AdDatosCentro.Id();
        }

        public static DataTable CentroEmpleado(int idempleado)
        {
            return AdDatosCentro.CentroEmpleado(idempleado);
        }
    }
}
