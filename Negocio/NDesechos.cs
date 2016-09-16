using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class NDesechos
    {
        public static DataTable ListaDesechos()
        {
            return AdDesechos.ListaDesecho();
        }

        public static DataTable ListaDesechosVenta()
        {
            return AdDesechos.listadesechosVenta();
        }

        public static DataTable ListaD()
        {
            return AdDesechos.listd();
        }

        public static bool Agregar(DDesechos e)
        {
            return AdDesechos.Agregar(e);
        }

        public static bool Actualizar(DDesechos e)
        {
            return AdDesechos.Actualizar(e);
        }

        public static bool ActualizarCantidadPeso(DDesechos e)
        {
            return AdDesechos.ActualizarCantidadPeso(e);
        }

        public static bool ActualizarVolumen(DDesechos e)
        {
            return AdDesechos.ActualizarVolumen(e);
        }

        public static bool Eliminar(DDesechos e)
        {
            return AdDesechos.Eliminar(e);
        }

        public static int Id()
        {
            return AdDesechos.Id();
        }

        public static int Volumen(string volumen)
        {
            return AdDesechos.Volumen(volumen);
        }

        public static int CantidadProductoPeso(string cantidad)
        {
            return AdDesechos.CantidadProducto(cantidad);
        }

        public static DataTable obtenercantidadpesodesechos(DDesechos e)
        {
            return AdDesechos.ObtenerCantidadpesodesechos(e);
        }

        public static DataTable obtenerVolumendesechos(DDesechos e)
        {
            return AdDesechos.ObtenerVolumendesechos(e);
        }
    }
}
