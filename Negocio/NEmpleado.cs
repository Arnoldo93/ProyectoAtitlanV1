﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class NEmpleado
    {
        public static List<DEmpleado> ListaPuesto()
        {
            return AdEmpleado.ListaPuesto();
        }

        public static bool Agregar(DEmpleado e)
        {
            return AdEmpleado.Agregar(e);
        }

        public static bool Actualizar(DEmpleado e)
        {
            return AdEmpleado.Actualizar(e);
        }

        public static bool Eliminar(DEmpleado e)
        {
            return AdEmpleado.Eliminar(e);
        }
    }
}