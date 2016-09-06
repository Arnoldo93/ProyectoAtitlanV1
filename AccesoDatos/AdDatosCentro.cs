using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class AdDatosCentro
    {
        // metodos
        public static DDatosCentro EntidadDatosCentro(MySqlDataReader entidad)
        {
            var e = new DDatosCentro();
            e.Id_Centro = Convert.ToInt32(entidad["Id_Centro"]);
            e.Nombre = Convert.ToString(entidad["Nombre_centro"]);
            e.Id_Municipio = Convert.ToInt32(entidad["Id_Municipio"]);
            e.Id_tipo = Convert.ToInt32(entidad["Id_Tipo"]);
            e.Telefono = Convert.ToInt32(entidad["Telefono"]);
            e.Direccion = Convert.ToString(entidad["Direccion"]);
            e.Estado = Convert.ToByte(entidad["Estado_centro"]);
            return e;
        }

        ////Listar
        //public static List<DDatosCentro> ListaDatosCentro()
        //{
        //    var lista = new List<DDatosCentro>();
        //    using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
        //    {
        //        var consulta = " select * from centro";
        //        var cmd = new MySqlCommand(consulta, cn);
        //        cn.Open();
        //        var dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lista.Add(EntidadDatosCentro(dr));
        //        }
        //        return lista;
        //    }
        //}

        //agregar

        public static bool Agregar(DDatosCentro c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "InsertarCentro";

                cmd.Parameters.AddWithValue("@id", c.Id_Centro);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@idmuni", c.Id_Municipio);
                cmd.Parameters.AddWithValue("@idtipo", c.Id_tipo);
                cmd.Parameters.AddWithValue("@tel", c.Telefono);
                cmd.Parameters.AddWithValue("@dir", c.Direccion);
                cmd.Parameters.AddWithValue("@esta", c.Estado);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool Actualizar(DDatosCentro c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "actualizarCentro";

                cmd.Parameters.AddWithValue("@id", c.Id_Centro);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@idmuni", c.Id_Municipio);
                cmd.Parameters.AddWithValue("@idtipo", c.Id_tipo);
                cmd.Parameters.AddWithValue("@tel", c.Telefono);
                cmd.Parameters.AddWithValue("@dir", c.Direccion);
                cmd.Parameters.AddWithValue("@esta", c.Estado);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                return false;
            }

        }

        //metodo para verificar si existe
        public static bool Existe(DDatosCentro u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select ifnull(Nombre_centro,1) from centro where Nombre_centro=@nombre";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DDatosCentro c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "EliminarCentro";

                cmd.Parameters.AddWithValue("@id", c.Id_Centro);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        //id
        public static int Id()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select IFNULL (max(Id_Centro),0) from centro";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //centro en el que esta el empleado
        public static DataTable CentroEmpleado(int idempleado)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "Select centro.Id_Centro,centro.Nombre_centro from empleado,centro where centro.Id_Centro=empleado.Id_Centro and Id_Empleado=@idem";
                var cmd = new MySqlCommand(consulta, cn);
                MySqlDataAdapter mdatos = new MySqlDataAdapter(cmd);
                DataTable dtDatos = new DataTable();
                cmd.Parameters.AddWithValue("@idem", idempleado);
                cn.Open();
                mdatos.Fill(dtDatos);
                return dtDatos;
            }
        }

        //Listar
        public static DataTable ListaCentro()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "SELECT centro.Id_Centro, centro.Nombre_centro,centro.Id_Municipio,municipio.Nombre as Nombre_Municipio,centro.Id_Tipo,tipo_centro.Nombre as Nombre_Tipo,centro.Telefono,centro.Direccion,centro.Estado_centro FROM amsclaeg_sistema.centro, amsclaeg_sistema.municipio,amsclaeg_sistema.tipo_centro where centro.Id_Municipio = municipio.Id_Municipio and centro.Id_Tipo = tipo_centro.Id_Tipo";
                MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
                MySqlDataAdapter mdatos = new MySqlDataAdapter(consulta, cnn);
                cnn.Open();
                DataTable dtDatos = new DataTable();
                mdatos.Fill(dtDatos);
                return dtDatos;
            }
        }
    }
}
