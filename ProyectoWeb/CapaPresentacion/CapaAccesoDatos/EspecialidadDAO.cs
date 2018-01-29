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
    public class EspecialidadDAO
    {
        #region "PATRON SINGLETON"
        private static EspecialidadDAO daoEspecialidad = null;
        private EspecialidadDAO() { }
        public static EspecialidadDAO getInstance()
        {
            if (daoEspecialidad == null)
            {
                daoEspecialidad = new EspecialidadDAO();
            }
            return daoEspecialidad;
        }
        #endregion

        public List<Especialidad> Listar()
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Especialidad> Lista = null;

            try
            {
                Lista = new List<Especialidad>();
                cmd = new SqlCommand("spListarEspecialidades", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                
                conexion.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Especialidad objEspecialidad = new Especialidad();
                    objEspecialidad.IdEspecialidad = Convert.ToInt32(dr["idEspecialidad"].ToString());
                    objEspecialidad.Descripcion = dr["descripcion"].ToString();
                    Lista.Add(objEspecialidad);
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
