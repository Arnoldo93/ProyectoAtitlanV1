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
    public class AdPuesto
    {
        // metodos
        public static Dpuesto EntidadPuesto(MySqlDataReader entidad)
        { 

            var e = new Dpuesto();
            e.Id_puesto = Convert.ToInt32(entidad["Id_Puesto"]);
            e.Nombre_puesto = Convert.ToString(entidad["Nombre_Puesto"]);
            return e;
        }

        ////Listar
        //public static List<Dpuesto> ListaPuesto()
        //{
        //    var lista = new List<Dpuesto>();
        //    using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
        //    {
        //        var consulta = " select * from puesto";
        //        var cmd = new MySqlCommand(consulta, cn);
        //        cn.Open();
        //        var dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lista.Add(EntidadPuesto(dr));
        //        }
        //        return lista;
        //    }
        //}

        
        //agregar

        public static bool Agregar(Dpuesto c)
        {
 
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                    var consulta = "insert into puesto values(@id,@nombre)";
                    //var consulta = "ProcedimientoInsertar";
                    var cmd = new MySqlCommand(consulta, cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", c.Id_puesto);
                    cmd.Parameters.AddWithValue("@nombre", c.Nombre_puesto);
                    cn.Open();

                return Convert.ToBoolean( cmd.ExecuteNonQuery());
            }
        }

        public static bool Guardar(Dpuesto g)
        {
            MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    // setear parametros del command
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    cmd.CommandText = "ProcedimientoInsertar";
                    //asignar paramentros
                    cmd.Parameters.AddWithValue("@id",g.Id_puesto);
                    cmd.Parameters.AddWithValue("@nom",g.Nombre_puesto);

                    //abrir la conexion
                    cn.Open();

                    //ejecutar el query
                   return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    
                } // end try
            }
        }

        public static bool Actualizar(Dpuesto c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update puesto set Id_Puesto=@id, Nombre_Puesto=@nombre where Id_Puesto=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_puesto);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre_puesto);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

        }

        //metodo para verificar si existe
        public static bool Existe(Dpuesto u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {

                var consulta = "select ifnull(Nombre_Puesto,1) from puesto where Nombre_Puesto=@nombre";
                var cmd = new MySqlCommand(consulta, cn);

                cmd.Parameters.AddWithValue("@nombre", u.Nombre_puesto);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(Dpuesto c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from puesto where Id_Puesto=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_puesto);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        //Id ultimo ingresado
        public static int Id()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select IFNULL (max(Id_Puesto),0) from puesto";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //listado
        public static DataTable ListaPuesto()
        {
            string Consulta = "Select * From puesto";
            MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            return dtDatos;
        }

    }
}
