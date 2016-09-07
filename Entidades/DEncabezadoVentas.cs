using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DEncabezadoVentas
    {
        public int idventa { get; set; }
        public decimal total { get; set; }
        public DateTime fecharealizado { get; set; }
        public int idempleado { get; set; }
        public int idmoneda { get; set; }
        public int idcliente { get; set; }
        public int idcentro { get; set; }

        //detalle de venta

        public List<DDetalleVenta> listardetalleventa { get; set; }
    }
}
