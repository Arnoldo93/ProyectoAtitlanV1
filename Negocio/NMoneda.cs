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
    public class NMoneda
    {
        public static DataTable ListarMoneda()
        {
            return AdMoneda.ListaMoneda();
        }

        public static bool Guardar(DMoneda e)
        {
            return AdMoneda.Agregar(e);
        }

        public static bool Actualizar(DMoneda e)
        {
            return AdMoneda.Actualizar(e);
        }

        public static bool Eliminar(DMoneda e)
        {
            return AdMoneda.Eliminar(e);
        }

        public static int Id()
        {
            return AdMoneda.Id();
        }

    }
}
