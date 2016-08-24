using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static List<DEmpleado> ListaPuesto()
        {
            var lista = new List<DEmpleado>();
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = " select * from empleado";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(EntidadEmpleado(dr));
                }
                return lista;
            }
        }

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
                var consulta = "select ifnull(Id_Empleado,1) from puesto where Nombre_Empleado=@nombre";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DEmpleado c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from puesto where Id_Puesto=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Empleado);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }
    }
}
