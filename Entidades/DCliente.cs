using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DCliente
    {
        public int idcliente { get; set; }
        public string nombre { get; set; }
        public int idcategoria { get; set; }
        public string direccion { get; set; }
        public string ubicacion { get; set; }
        public int zona { get; set; }
        public int telefono { get; set; }
        public string contacto { get; set; }
        public string correo { get; set; }
    }
}
