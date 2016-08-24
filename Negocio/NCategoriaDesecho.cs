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
    public class NCategoriaDesecho
    {
        public static List<DCategoriaDesecho> ListaCategoriasDesecho()
        {
            return AdCategoriaDesecho.ListaCategoriaDesecho();
        }

        public static bool Agregar(DCategoriaDesecho e)
        {
            return AdCategoriaDesecho.Agregar(e);
        }

        public static bool Actualizar(DCategoriaDesecho e)
        {
            return AdCategoriaDesecho.Actualizar(e);
        }

        public static bool Eliminar(DCategoriaDesecho e)
        {
            return AdCategoriaDesecho.Eliminar(e);
        }
    }
}
