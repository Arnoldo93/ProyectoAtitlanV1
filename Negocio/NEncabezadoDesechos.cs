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

        public static bool AgregarEncabezado(DEncabezadoDesecho e)
        {
            return AdEncabezadoDesecho.AgregarEncabezado(e);
        }

        public static bool DetalleEncabezado(DEncabezadoDesecho e)
        {
            return AdEncabezadoDesecho.DetalleEncabezado(e);
        }

        public static bool EliminarDetalleEncabezado(int id)
        {
            return AdEncabezadoDesecho.eliminardetalle(id);
        }

        public static int idencabezado()
        {
            return AdEncabezadoDesecho.Idencabezado();
        }

        public static int iddetalle()
        {
            return AdEncabezadoDesecho.Iddetalle();
        }

        public static DataTable ListadoDetalleDesechos()
        {
            return AdEncabezadoDesecho.ListaDeDechosDetalle();
        }
    }
}
