using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using AccesoDatos;

namespace Negocio
{
    public class NEncabezadoVenta
    {
        public static bool AgregarEncabezado(DEncabezadoVentas e)
        {
            return AdEncabezadoVenta.AgregarEncabezadoventa(e);
        }

        public static bool DetalleEncabezado(DEncabezadoVentas e)
        {
            return AdEncabezadoVenta.DetalleEncabezadoventa(e);
        }

        public static bool EliminarEncabezado(int idd)
        {
            return AdEncabezadoVenta.EliminarEncabezadoVenta(idd);
        }

        public static bool EliminarDetalleEncabezado(int id)
        {
            return AdEncabezadoVenta.eliminardetalleVenta(id);
        }

        public static int idencabezado()
        {
            return AdEncabezadoVenta.Idencabezadoventa();
        }

        public static int iddetalle()
        {
            return AdEncabezadoVenta.Iddetalleventa();
        }

        public static bool ActualizarTotalVenta(DEncabezadoVentas e)
        {
            return AdEncabezadoVenta.ActualizarTotalEncabezado(e);
        }

        public static DataTable BusquedaVentasPorFechas(DateTime fec,DateTime fec1)
        {
            return AdEncabezadoVenta.BuscarVentasPorFecha(fec,fec1);
        }
    }
}
