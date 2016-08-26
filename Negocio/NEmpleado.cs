﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class NEmpleado
    {
        public static DataTable ListaEmpleado()
        {
            return AdEmpleado.ListaEmpleado();
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

        public static DataTable logueo(string usua,string pasw)
        {
            return AdEmpleado.Listalog(usua,pasw);
        }

        public static int id()
        {
            return AdEmpleado.Id();
        }
    }
}
