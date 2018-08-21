using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaLogicaNegocio
{
    public class DiagnosticoLN
    {
        #region "PATRON SINGLETON"
        private static DiagnosticoLN objDiagnostico = null;
        private DiagnosticoLN() { }
        public static DiagnosticoLN getInstance()
        {
            if (objDiagnostico == null)
            {
                objDiagnostico = new DiagnosticoLN();
            }
            return objDiagnostico;
        }
        #endregion

        public bool RegistrarDiagnostico(Diagnostico objDiagnostico)
        {
            try
            {
                return DiagnosticoDAO.getInstance().RegistrarDiagnostico(objDiagnostico);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
