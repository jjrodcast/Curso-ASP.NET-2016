using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
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

        public Empleado AccesoSistema(String user, String pass)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Empleado objEmpleado = null;
            SqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spAccesoSistema", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUser", user);
                cmd.Parameters.AddWithValue("@prmPass", pass);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objEmpleado = new Empleado();
                    objEmpleado.ID = Convert.ToInt32(dr["idEmpleado"].ToString());
                    objEmpleado.Usuario = dr["usuario"].ToString();
                    objEmpleado.Clave = dr["clave"].ToString();
                    objEmpleado.Nombre = dr["nombres"].ToString();
                    objEmpleado.ApPaterno = dr["apPaterno"].ToString();
                    objEmpleado.ApMaterno = dr["apMaterno"].ToString();
                    objEmpleado.NroDocumento = dr["nroDocumento"].ToString();
                    objEmpleado.Estado = true;
                }
            }
            catch (Exception ex)
            {
                objEmpleado = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objEmpleado;
        }

        public Empleado BuscarEmpleado(String nroDocumento)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Empleado objEmpleado = new Empleado();

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spBuscarEmpleado", con);
                cmd.Parameters.AddWithValue("@prmNroDocumento", nroDocumento);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objEmpleado.ID = Convert.ToInt32(dr["idEmpleado"].ToString());
                    objEmpleado.Nombre = dr["nombres"].ToString();
                    objEmpleado.ApPaterno = dr["apPaterno"].ToString();
                    objEmpleado.ApMaterno = dr["apMaterno"].ToString();
                    objEmpleado.NroDocumento = dr["nroDocumento"].ToString();
                    objEmpleado.RTipoEmpleado.Descripcion = dr["usuario"].ToString();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return objEmpleado;
        }

    }
}
