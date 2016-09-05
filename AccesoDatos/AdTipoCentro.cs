using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class AdTipoCentro
    {
        // metodos
        public static DTipoCentro EntidadTipoCentro(MySqlDataReader entidad)
        {
            var e = new DTipoCentro();
            e.Id_Tipocentro= Convert.ToInt32(entidad["Id_Tipo"]);
            e.Nombre = Convert.ToString(entidad["Nombre"]);
            return e;
        }

        ////Listar
        //public static List<DTipoCentro> ListaPuesto()
        //{
        //    var lista = new List<DTipoCentro>();
        //    using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
        //    {
        //        var consulta = " select * from tipo_centro";
        //        var cmd = new MySqlCommand(consulta, cn);
        //        cn.Open();
        //        var dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lista.Add(EntidadTipoCentro(dr));
        //        }
        //        return lista;
        //    }
        //}

        //agregar

        public static bool Agregar(DTipoCentro c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "InsertarTipoCentro";
                
                cmd.Parameters.AddWithValue("@id", c.Id_Tipocentro);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool Actualizar(DTipoCentro c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "ActualizarTipoCentro";

                cmd.Parameters.AddWithValue("@id", c.Id_Tipocentro);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }

        }

        //metodo para verificar si existe
        public static bool Existe(DTipoCentro u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "Select ifnull(Nombre,1) from tipo_centro where Nombre=@nom";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nom", u.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DTipoCentro c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "EliminarTipoCentro";

                cmd.Parameters.AddWithValue("@id", c.Id_Tipocentro);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Id ultimo ingresado
        public static int Id()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select IFNULL (max(Id_Tipo),0) from tipo_centro";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //listado
        public static DataTable ListaTipos()
        {
            string Consulta = "Select * From tipo_centro";
            MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            return dtDatos;
        }
    }
}
