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
    public class NDesechos
    {
        public static DataTable ListaDesechos()
        {
            return AdDesechos.ListaDesecho();
        }

        public static bool Agregar(DDesechos e)
        {
            return AdDesechos.Agregar(e);
        }

        public static bool Actualizar(DDesechos e)
        {
            return AdDesechos.Actualizar(e);
        }

        public static bool Eliminar(DDesechos e)
        {
            return AdDesechos.Eliminar(e);
        }

        public static int Id()
        {
            return AdDesechos.Id();
        }
    }
}
