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
    public class AdCliente
    {
        public static DCliente EntidadCliente(MySqlDataReader entidad)
        {
            var e = new DCliente();
            e.idcliente = Convert.ToInt32(entidad["Id_Cliente"]);
            e.nombre = Convert.ToString(entidad["Nombre"]);
            e.idcategoria = Convert.ToInt32(entidad["Id_Categoria"]);
            e.direccion = Convert.ToString(entidad["Direccion"]);
            e.ubicacion = Convert.ToString(entidad["Ubicacion"]);
            e.zona = Convert.ToInt32(entidad["Zona"]);
            e.telefono = Convert.ToInt32(entidad["Telefono"]);
            e.contacto = Convert.ToString(entidad["Contacto"]);
            e.correo = Convert.ToString(entidad["Correo"]);
            return e;
        }

        public static bool Agregar(DCliente c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "InsertarCliente";

                cmd.Parameters.AddWithValue("@id", c.idcliente);
                cmd.Parameters.AddWithValue("@nom", c.nombre);
                cmd.Parameters.AddWithValue("@idcat", c.idcategoria);
                cmd.Parameters.AddWithValue("@dir", c.direccion);
                cmd.Parameters.AddWithValue("@ubi", c.ubicacion);
                cmd.Parameters.AddWithValue("@zona", c.zona);
                cmd.Parameters.AddWithValue("@tel", c.telefono);
                cmd.Parameters.AddWithValue("@cont", c.contacto);
                cmd.Parameters.AddWithValue("@correo", c.correo);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Actualizar(DCliente c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "ActualizarCliente";

                cmd.Parameters.AddWithValue("@id", c.idcliente);
                cmd.Parameters.AddWithValue("@nom", c.nombre);
                cmd.Parameters.AddWithValue("@idcat", c.idcategoria);
                cmd.Parameters.AddWithValue("@dir", c.direccion);
                cmd.Parameters.AddWithValue("@ubi", c.ubicacion);
                cmd.Parameters.AddWithValue("@zona", c.zona);
                cmd.Parameters.AddWithValue("@tel", c.telefono);
                cmd.Parameters.AddWithValue("@cont", c.contacto);
                cmd.Parameters.AddWithValue("@correo", c.correo);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Eliminar(DCliente c)
        {
            MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    // setear parametros del command
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    cmd.CommandText = "EliminarCliente";
                    //asignar paramentros
                    cmd.Parameters.AddWithValue("@id", c.idcliente);
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
                var consulta = "select IFNULL (max(Id_Cliente),0) from cliente";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //listado
        public static DataTable ListaClientes()
        {
            string Consulta = "SELECT cliente.Id_Cliente,cliente.Nombre as Cliente,cliente.Id_Categoria,categoria_cliente.Nombre as Categoria_Cliente,cliente.Direccion,cliente.Ubicacion,cliente.Zona,cliente.Telefono,cliente.Contacto,cliente.Correo FROM cliente,categoria_cliente where cliente.Id_Categoria=categoria_cliente.Id_Categoria;";
            MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            return dtDatos;
        }
    }
}
