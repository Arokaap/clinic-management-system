using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.DAL
{
    public class EmpleadoDAO
    {
        #region "PATRON SINGLETON"
        private static EmpleadoDAO daoEmpleado = null;

        private EmpleadoDAO() { }

        public static EmpleadoDAO getInstance()
        {
            if (daoEmpleado == null)
            {
                daoEmpleado = new EmpleadoDAO();
            }

            return daoEmpleado;
        }
        #endregion

        public Empleado AccesoSistema(string user, string pass)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Empleado empleado = null;
            SqlDataReader dr = null;

            try
            {
                conexion = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spAccesoSistema", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUser", user);
                cmd.Parameters.AddWithValue("@prmPass", pass);
                conexion.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    empleado = new Empleado();
                    empleado.IdEmpleado = Convert.ToInt32(dr["idEmpleado"].ToString());
                    empleado.Usuario = dr["usuario"].ToString();
                    empleado.Clave = dr["clave"].ToString();
                }
            }
            catch (Exception ex)
            {
                empleado = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return empleado;
        }
    }
}
