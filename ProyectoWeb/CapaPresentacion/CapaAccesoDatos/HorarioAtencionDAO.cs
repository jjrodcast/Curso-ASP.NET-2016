using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class HorarioAtencionDAO
    {
        #region "PATRON SINGLETON"
        private static HorarioAtencionDAO daoHorarioAtencion = null;
        private HorarioAtencionDAO() { }
        public static HorarioAtencionDAO getInstance()
        {
            if (daoHorarioAtencion == null)
            {
                daoHorarioAtencion = new HorarioAtencionDAO();
            }
            return daoHorarioAtencion;
        }
        #endregion

        public HorarioAtencion RegistrarHorarioAtencion(HorarioAtencion objHorarioAtencion)
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            HorarioAtencion objHorario = null;

            try
            {
                cmd = new SqlCommand("spRegistrarHorarioAtencion", conexion);
                cmd.Parameters.AddWithValue("@prmIdMedico", objHorarioAtencion.Medico.IdMedico);
                cmd.Parameters.AddWithValue("@prmHora", objHorarioAtencion.Hora.hora);
                cmd.Parameters.AddWithValue("@prmFecha", objHorarioAtencion.Fecha);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objHorario = new HorarioAtencion() 
                    {
                        IdHorarioAtencion = Convert.ToInt32(dr["idHorarioAtencion"].ToString()),
                        Fecha = Convert.ToDateTime(dr["fecha"].ToString()),
                        Hora = new Hora() 
                        {
                            IdHora = Convert.ToInt32(dr["idHora"].ToString()),
                            hora = dr["hora"].ToString()
                        },
                        Estado = Convert.ToBoolean(dr["estado"].ToString())
                    };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return objHorario;
        }

        public List<HorarioAtencion> Listar(Int32 idMedico)
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<HorarioAtencion> Lista = null;

            try
            {
                cmd = new SqlCommand("spListaHorariosAtencion", conexion);
                cmd.Parameters.AddWithValue("@prmIdMedico",idMedico);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                dr = cmd.ExecuteReader();

                Lista = new List<HorarioAtencion>();

                while (dr.Read())
                {
                    // llenamos los objetos
                    HorarioAtencion objHorario = new HorarioAtencion();
                    objHorario.IdHorarioAtencion = Convert.ToInt32(dr["idHorarioAtencion"].ToString());
                    objHorario.Fecha = Convert.ToDateTime(dr["fecha"].ToString());
                    objHorario.Hora = new Hora()
                    {
                        hora = dr["hora"].ToString()
                    };

                    Lista.Add(objHorario);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return Lista;
        }
    }
}
