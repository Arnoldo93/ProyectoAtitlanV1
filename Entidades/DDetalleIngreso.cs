using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DDetalleIngreso
    {
        //detalle
        public int idencabezado { get; set; }
        public int iddetalle { get; set; }
        public int idVehiculo { get; set; }
        public int iddesecho { get; set; }
        public int cantidad { get; set; }
    }
}
