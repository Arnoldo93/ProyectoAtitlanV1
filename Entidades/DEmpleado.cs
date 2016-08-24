using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DEmpleado
    {
        public int Id_Empleado
        {
            get; set;
        }

        public string Nombre
        {
            get; set;
        }
        public string Direccion
        {
            get; set;
        }

        public int Telefono
        {
            get; set;
        }
        public string Usuario
        {
            get; set;
        }
        public string Contrase_a
        {
            get; set;
        }
        public byte Estado_Empleado
        {
            get; set;
        }

        public int Id_Puesto
        {
            get; set;
        }

        public int Id_Centro
        {
            get; set;
        }
    }
}
