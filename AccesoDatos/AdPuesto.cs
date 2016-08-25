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

        public static bool Guardar(Dpuesto g)
        {
            try
            {

                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                MySqlCommand cmd = new MySqlCommand();
                
                   // setear parametros del command
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    cmd.CommandText = "insertarPue";
                    //asignar paramentros
                    cmd.Parameters.AddWithValue("@id", g.Id_puesto);
                    cmd.Parameters.AddWithValue("@nom", g.Nombre_puesto);

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

        public static bool Actualizar(Dpuesto c)
        {
            MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    // setear parametros del command
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    cmd.CommandText = "ActualizarPue";
                    //asignar paramentros
                    cmd.Parameters.AddWithValue("@id", c.Id_puesto);
                    cmd.Parameters.AddWithValue("@nom", c.Nombre_puesto);

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

        //Eliminar

        public static bool Eliminar(Dpuesto c)
        {
            MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    // setear parametros del command
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    cmd.CommandText = "EliminarPue";
                    //asignar paramentros
                    cmd.Parameters.AddWithValue("@id", c.Id_puesto);
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
