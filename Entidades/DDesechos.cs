using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DDesechos
    {
        public int Id_desecho
        {
            get; set;
        }

        public string Nombre
        {
            get; set;
        }
        public int Id_familia
        {
            get; set;
        }

        public int Id_categoria
        {
            get; set;
        }
        public int Id_subcategoria
        {
            get; set;
        }
        public decimal Cantida_peso
        {
            get; set;
        }
        public int Id_medida
        {
            get; set;
        }

        public int Volumen
        {
            get; set;
        }

        public double Precio_costo
        {
            get; set;
        }

        public double PrecioVenta
        {
            get; set;
        }

        public byte Estado_desecho
        {
            get; set;
        }
    }
}
