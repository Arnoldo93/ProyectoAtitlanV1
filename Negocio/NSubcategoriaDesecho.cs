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
    public class NSubcategoriaDesecho
    {
        //public static List<DSubcategoriaDesecho> ListaPuesto()
        //{
        //    return AdSubcategoriaDesecho.ListaSubcategoria();
        //}

        public static bool Agregar(DSubcategoriaDesecho e)
        {
            return AdSubcategoriaDesecho.Agregar(e);
        }

        public static bool Actualizar(DSubcategoriaDesecho e)
        {
            return AdSubcategoriaDesecho.Actualizar(e);
        }

        public static bool Eliminar(DSubcategoriaDesecho e)
        {
            return AdSubcategoriaDesecho.Eliminar(e);
        }

        public static int id()
        {
            return AdSubcategoriaDesecho.Id();
        }

        public static DataTable ListadoSubcategoria()
        {
            return AdSubcategoriaDesecho.ListaPuesto();
        }
    }
}
