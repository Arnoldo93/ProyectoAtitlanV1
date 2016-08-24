using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DDatosCentro
    {
        public int Id_Centro
        {
            get; set;
        }

        public string Nombre
        {
            get; set;
        }
        public int Id_Municipio
        {
            get; set;
        }

        public int Id_tipo
        {
            get; set;
        }
        public int Telefono
        {
            get; set;
        }
        public string Direccion
        {
            get; set;
        }
        public byte Estado
        {
            get; set;
        }
    }
}
