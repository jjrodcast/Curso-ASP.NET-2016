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
    public class MedicoDAO
    {
        #region "PATRON SINGLETON"
        private static MedicoDAO daoMedico = null;
        private MedicoDAO() { }
        public static MedicoDAO getInstance()
        {
            if (daoMedico == null)
            {
                daoMedico = new MedicoDAO();
            }
            return daoMedico;
        }
        #endregion


        public Medico BuscarMedico(String dni)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Medico objMedico = null;
            SqlDataReader dr = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spBuscarMedico", conexion);
                cmd.Parameters.AddWithValue("@prmDni", dni);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // instanciar nuestro objeto
                    objMedico = new Medico()
                    {
                        IdMedico = Convert.ToInt32(dr["idMedico"].ToString()),
                        ID = Convert.ToInt32(dr["idEmpleado"].ToString()),
                        Nombre = dr["nombre"].ToString(),
                        ApPaterno = dr["apPaterno"].ToString(),
                        ApMaterno = dr["apMaterno"].ToString(),
                        Especialidad = new Especialidad() 
                        {
                            IdEspecialidad = Convert.ToInt32(dr["idEspecialidad"].ToString()),
                            Descripcion = dr["descripcion"].ToString(),
                        },
                        Estado = Convert.ToBoolean(dr["estadoMedico"].ToString())
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
            return objMedico;
        }

    }
}
