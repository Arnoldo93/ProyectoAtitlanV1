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
    public class NCliente
    {
        public static DataTable ListaDatosCliente()
        {
            return AdCliente.ListaClientes();
        }

        public static DataTable BuscarCliente(DCliente e)
        {
            return AdCliente.BuscarPorNombre(e);
        }

        public static bool Agregar(DCliente e)
        {
            return AdCliente.Agregar(e);
        }

        public static bool Actualizar(DCliente e)
        {
            return AdCliente.Actualizar(e);
        }

        public static bool Eliminar(DCliente e)
        {
            return AdCliente.Eliminar(e);
        }

        public static int Id()
        {
            return AdCliente.Id();
        }
    }
}
