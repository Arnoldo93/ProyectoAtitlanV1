using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entidades
{
    class DEncabezadoDesecho
    {
        //encabezadoingreso
        public int Idencabezado { get; set; }
        public DateTime fecharealizado { get; set; }
        public int idempleado { get; set; }
        public int idcentro { get; set; }

        //lista detalle
        public List<DDetalleIngreso> listardetalle { get; set; }
    }
}
