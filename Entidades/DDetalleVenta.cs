using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DDetalleVenta
    {
        public int idventa { get; set; }
        public int iddetalleventa { get; set; }
        public int iddesecho { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal subtotal { get; set; }
    }
}
