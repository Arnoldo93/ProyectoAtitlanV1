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
    public class AdEmpleado
    {
        
        // metodos
        public static DEmpleado EntidadEmpleado(MySqlDataReader entidad)
        {
            var e = new DEmpleado();
            e.Id_Empleado= Convert.ToInt32(entidad["Id_Empleado"]);
            e.Nombre =Convert.ToString( entidad["Nombre_Empleado"]);
            e.Direccion = Convert.ToString(entidad["Direccion"]);
            e.Telefono = Convert.ToInt32(entidad["Telefono"]);
            e.Usuario = Convert.ToString(entidad["Usuario"]);
            e.Contrase_a = Convert.ToString(entidad["Contrase_a"]);
            e.Estado_Empleado = Convert.ToByte(entidad["Estado_Empleado"]);
            e.Id_Puesto = Convert.ToInt32(entidad["Id_Puesto"]);
            e.Id_Centro = Convert.ToInt32(entidad["Id_Centro"]);
            return e;
        }

        //Listar
        //public static List<DEmpleado> ListaPuesto()
        //{
        //    var lista = new List<DEmpleado>();
        //    using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
        //    {
        //        var consulta = " select * from empleado";
        //        var cmd = new MySqlCommand(consulta, cn);
        //        cn.Open();
        //        var dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lista.Add(EntidadEmpleado(dr));
        //        }
        //        return lista;
        //    }
        //}



        //agregar

        public static bool Agregar(DEmpleado c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "insert into empleado values(@id,@nom,@dir,@tel,@usu,@pasw,@est,@idpuesto,@idcentro)";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Empleado);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@dir", c.Direccion);
                cmd.Parameters.AddWithValue("@tel", c.Telefono);
                cmd.Parameters.AddWithValue("@usu", c.Usuario);
                cmd.Parameters.AddWithValue("@pasw", c.Contrase_a);
                cmd.Parameters.AddWithValue("@est", c.Estado_Empleado);
                cmd.Parameters.AddWithValue("@idpuesto", c.Id_Puesto);
                cmd.Parameters.AddWithValue("@idcentro", c.Id_Centro);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool Actualizar(DEmpleado c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update empleado set Id_Empleado=@id,Nombre_Empleado=@nom ,Direccion=@dir,Telefono=@tel,Usuario=@usu,Contrase_a=@pasw,Estado_Empleado=@est,Id_Puesto=@idpuesto,Id_Centro=@idcentro where Id_Empleado=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Empleado);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@dir", c.Direccion);
                cmd.Parameters.AddWithValue("@tel", c.Telefono);
                cmd.Parameters.AddWithValue("@usu", c.Usuario);
                cmd.Parameters.AddWithValue("@pasw", c.Contrase_a);
                cmd.Parameters.AddWithValue("@est", c.Estado_Empleado);
                cmd.Parameters.AddWithValue("@idpuesto", c.Id_Puesto);
                cmd.Parameters.AddWithValue("@idcentro", c.Id_Centro);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

        }

        //metodo para verificar si existe
        public static bool Existe(DEmpleado u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select ifnull(Nombre_Empleado,1) from empleado where Nombre_Empleado=@nom";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nom", u.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DEmpleado c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from empleado where Id_Empleado=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Empleado);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        //id
        public static int Id()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select IFNULL (max(Id_Empleado),0) from empleado";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //Listar
        public static DataTable ListaEmpleado()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "SELECT empleado.Id_Empleado,empleado.Nombre_Empleado,empleado.Direccion,empleado.Telefono,empleado.Usuario,empleado.Contrase_a,empleado.Estado_Empleado,empleado.Id_Puesto,puesto.Nombre_Puesto,empleado.Id_Centro,centro.Nombre_centro FROM proatitlan.empleado, proatitlan.puesto,proatitlan.centro where empleado.Id_Puesto= puesto.Id_Puesto and empleado.Id_Centro=centro.Id_Centro;";
                MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
                MySqlDataAdapter mdatos = new MySqlDataAdapter(consulta, cnn);
                cnn.Open();
                DataTable dtDatos = new DataTable();
                mdatos.Fill(dtDatos);
                return dtDatos;
            }
        }

        //Login
        public static int loguin(DEmpleado c)
        {
           using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
                {
                    var consulta = "Select count(Id_Empleado) from empleado where Usuario like @usu and Contrase_a like @pasw";
                    var cmd = new MySqlCommand(consulta,cn);
                    cmd.Parameters.AddWithValue("@usu", c.Usuario);
                    cmd.Parameters.AddWithValue("@pasw", c.Contrase_a);
                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
        }
    }
}
