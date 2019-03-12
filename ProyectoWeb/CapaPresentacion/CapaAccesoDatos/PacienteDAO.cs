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
    public class PacienteDAO
    {
        #region "PATRON SINGLETON"
        private static PacienteDAO daoEmpleado = null;
        private PacienteDAO() { }
        public static PacienteDAO getInstance()
        {
            if (daoEmpleado == null)
            {
                daoEmpleado = new PacienteDAO();
            }
            return daoEmpleado;
        }
        #endregion

        public bool RegistrarPaciente(Paciente objPaciente)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarPaciente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombres", objPaciente.Nombres);
                cmd.Parameters.AddWithValue("@prmApPaterno", objPaciente.ApPaterno);
                cmd.Parameters.AddWithValue("@prmApMaterno", objPaciente.ApMaterno);
                cmd.Parameters.AddWithValue("@prmEdad", objPaciente.Edad);
                cmd.Parameters.AddWithValue("@prmSexo", objPaciente.Sexo);
                cmd.Parameters.AddWithValue("@prmNroDoc", objPaciente.NroDocumento);
                cmd.Parameters.AddWithValue("@prmDireccion", objPaciente.Direccion);
                cmd.Parameters.AddWithValue("@prmTelefono", objPaciente.Telefono);
                cmd.Parameters.AddWithValue("@prmEstado", objPaciente.Estado);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;

            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public List<Paciente> ListarPacientes()
        {
            List<Paciente> Lista = new List<Paciente>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarPacientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // Crear objetos de tipo Paciente
                    Paciente objPaciente = new Paciente();
                    objPaciente.IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString());
                    objPaciente.Nombres = dr["nombres"].ToString();
                    objPaciente.ApPaterno = dr["apPaterno"].ToString();
                    objPaciente.ApMaterno = dr["apMaterno"].ToString();
                    objPaciente.Edad = Convert.ToInt32(dr["edad"].ToString());
                    objPaciente.Sexo = Convert.ToChar(dr["sexo"].ToString());
                    objPaciente.NroDocumento = dr["nroDocumento"].ToString();
                    objPaciente.Direccion = dr["direccion"].ToString();
                    objPaciente.Estado = true;

                    // añadir a la lista de objetos
                    Lista.Add(objPaciente);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Lista;
        }

        public bool Actualizar(Paciente objPaciente)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizarDatosPaciente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdPaciente", objPaciente.IdPaciente);
                cmd.Parameters.AddWithValue("@prmDireccion", objPaciente.Direccion);

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

        public bool Eliminar(int id)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool ok = false;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spEliminarPaciente", conexion);
                cmd.Parameters.AddWithValue("@prmIdPaciente", id);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;

            }
            catch (Exception ex)
            {
                ok = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

        public Paciente BuscarPacienteDNI(string dni)
        {
            SqlConnection conex = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Paciente objPaciente = null;

            try
            {
                conex = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spBuscarPacienteDNI", conex);
                cmd.Parameters.AddWithValue("@prmDni", dni);
                cmd.CommandType = CommandType.StoredProcedure;

                conex.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objPaciente = new Paciente
                    {
                        IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString()),
                        Nombres = dr["Nombres"].ToString(),
                        ApPaterno = dr["ApPaterno"].ToString(),
                        ApMaterno = dr["ApMaterno"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Edad = Convert.ToInt32(dr["Edad"].ToString()),
                        Sexo = Convert.ToChar(dr["Sexo"].ToString())
                    };
                }
            }
            catch (Exception ex)
            {
                objPaciente = null;
                throw ex;
            }
            finally
            {
                conex.Close();
            }
            return objPaciente;
        }

        public Paciente BuscarPacienteIdCita(Int32 idCita)
        {
            SqlConnection conex = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Paciente objPaciente = null;

            try
            {
                conex = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spBuscarPacienteIdCita", conex);
                cmd.Parameters.AddWithValue("@prmIdCita", idCita);
                cmd.CommandType = CommandType.StoredProcedure;

                conex.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objPaciente = new Paciente
                    {
                        IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString()),
                        Nombres = dr["Nombres"].ToString(),
                        ApPaterno = dr["ApPaterno"].ToString(),
                        ApMaterno = dr["ApMaterno"].ToString(),
                        Edad = Convert.ToInt32(dr["Edad"].ToString()),
                        Sexo = Convert.ToChar(dr["Sexo"].ToString())
                    };
                }
            }
            catch (Exception ex)
            {
                objPaciente = null;
                throw ex;
            }
            finally
            {
                conex.Close();
            }
            return objPaciente;
        }

    }
}
