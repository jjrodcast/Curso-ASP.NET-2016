using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class CitaLN
    {
        #region "PATRON SINGLETON"
        private static CitaLN citaLN = null;
        private CitaLN() { }
        public static CitaLN getInstance()
        {
            if (citaLN == null)
            {
                citaLN = new CitaLN();
            }
            return citaLN;
        }
        #endregion

        public bool RegistrarCita(Cita objCita)
        {
            try
            {
                return CitaDAO.getInstance().RegistrarCita(objCita);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cita> ListarCitas()
        {
            try
            {
                return CitaDAO.getInstance().ListarCitas();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarCita(Int32 idCita, string estado)
        {
            try
            {
                return CitaDAO.getInstance().ActualizarCita(idCita, estado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
