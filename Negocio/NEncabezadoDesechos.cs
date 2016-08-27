using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Entidades;
using AccesoDatos;

namespace Negocio
{
    public class NEncabezadoDesechos
    {
        public static List<DEncabezadoDesecho> ListaEncabezadoDesechos(DateTime fec_ini,DateTime fec_fin)
        {
            return AdEncabezadoDesecho.ListaEncabezadoIngreso(fec_ini,fec_fin);
        }

        public static bool Agregar(DEncabezadoDesecho e)
        {
            return AdEncabezadoDesecho.Agregar(e);
        }

        public static int id()
        {
            return AdEncabezadoDesecho.Id();
        }

        public static DataTable ListadoDetalleDesechos()
        {
            return AdEncabezadoDesecho.ListaDeDechosDetalle();
        }
    }
}
