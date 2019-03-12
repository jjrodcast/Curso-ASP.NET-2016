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
    public class ReporteDAO
    {
        #region "PATRON SINGLETON"
        private static ReporteDAO daoReporte = null;
        private ReporteDAO() { }
        public static ReporteDAO getInstance()
        {
            if (daoReporte == null)
            {
                daoReporte = new ReporteDAO();
            }
            return daoReporte;
        }
        #endregion


        public List<Cita> ListarCitasPorMedico(Int32 IdMedico)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Cita> Lista = new List<Cita>();

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spReporteCitasAtendidasPorMedico", con);
                cmd.Parameters.AddWithValue("@prmIdMedico", IdMedico);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cita objCita = CrearObjeto(dr);
                    Lista.Add(objCita);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return Lista;
        }

        private Cita CrearObjeto(SqlDataReader dr)
        {
            Cita objCita = new Cita();
            objCita.Paciente.Nombres = dr["nombres"].ToString();
            objCita.Paciente.ApPaterno = dr["apPaterno"].ToString();
            objCita.Paciente.ApMaterno = dr["apMaterno"].ToString();
            objCita.IdCita = Convert.ToInt32(dr["idCita"].ToString());
            //objCita.FechaReserva = Convert.ToDateTime(dr["fechaReserva"].ToString());
            //objCita.Paciente.PHistoriaClinica.FechaApertura = Convert.ToDateTime(dr["fechaApertura"].ToString());
            Diagnostico objDiagnostico = new Diagnostico();
            //objDiagnostico.FechaEmision = Convert.ToDateTime(dr["fechaEmision"].ToString());
            objDiagnostico.Observacion = dr["observacion"].ToString();
            objCita.Paciente.PHistoriaClinica.LDiagnostico.Add(objDiagnostico);

            return objCita;
        }
    }
}
