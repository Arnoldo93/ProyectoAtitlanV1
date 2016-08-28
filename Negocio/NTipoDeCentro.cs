using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class NTipoDeCentro
    {
        public static DataTable ListaTipoDeCliente()
        {
            return AdTipoDeCliente.ListaTipoDeCliente();
        }

        public static bool Agregar(DTipoDeCliente e)
        {
            return AdTipoDeCliente.Agregar(e);
        }

        public static bool Actualizar(DTipoDeCliente e)
        {
            return AdTipoDeCliente.Actualizar(e);
        }

        public static bool Eliminar(DTipoDeCliente e)
        {
            return AdTipoDeCliente.Eliminar(e);
        }

        public static int id()
        {
            return AdTipoDeCliente.Id();
        }
    }
}
