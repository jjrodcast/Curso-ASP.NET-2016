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
    public class CitaDAO
    {
        #region "PATRON SINGLETON"
        private static CitaDAO daoCita = null;
        private CitaDAO() { }
        public static CitaDAO getInstance()
        {
            if (daoCita == null)
            {
                daoCita = new CitaDAO();
            }
            return daoCita;
        }
        #endregion

        public bool RegistrarCita(Cita objCita)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarCita", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMedico", objCita.Medico.IdMedico);
                cmd.Parameters.AddWithValue("@idPaciente", objCita.Paciente.IdPaciente);
                cmd.Parameters.AddWithValue("@fechaReserva", objCita.FechaReserva);
                cmd.Parameters.AddWithValue("@hora", objCita.Hora);
                
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

    }
}
