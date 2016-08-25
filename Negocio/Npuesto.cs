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
    public class Npuesto
    {
        public static DataTable ListaPuesto()
        {
            return AdPuesto.ListaPuesto();
        }

        //public static bool Agregar(Dpuesto e)
        //{
        //    return AdPuesto.Guardar(e);
        //}

        public static bool Guardar(Dpuesto e)
        {
            return AdPuesto.Guardar(e);
        }

        public static bool Actualizar(Dpuesto e)
        {
            return AdPuesto.Actualizar(e);
        }

        public static bool Eliminar(Dpuesto e)
        {
            return AdPuesto.Eliminar(e);
        }

        public static int Id()
        {
            return AdPuesto.Id();
        }

    }
}
