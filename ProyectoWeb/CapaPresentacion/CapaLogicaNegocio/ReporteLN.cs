using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class ReporteLN
    {
        #region "PATRON SINGLETON"
        private static ReporteLN reporteLN = null;
        private ReporteLN() { }
        public static ReporteLN getInstance()
        {
            if (reporteLN == null)
            {
                reporteLN = new ReporteLN();
            }
            return reporteLN;
        }
        #endregion

        public List<Cita> ReporteCitasPorMedico(Int32 IdMedico)
        {
            try
            {
                return ReporteDAO.getInstance().ListarCitasPorMedico(IdMedico);
            }
            catch (Exception) { throw; }
        }
      
    }
}
