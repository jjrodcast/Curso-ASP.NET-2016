using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaLogicaNegocio
{
    public class EspecialidadLN
    {
        #region "PATRON SINGLETON"
        private static EspecialidadLN objEspecialidad = null;
        private EspecialidadLN() { }
        public static EspecialidadLN getInstance()
        {
            if (objEspecialidad == null)
            {
                objEspecialidad = new EspecialidadLN();
            }
            return objEspecialidad;
        }
        #endregion

        public List<Especialidad> Listar()
        {
            try
            {
                return EspecialidadDAO.getInstance().Listar();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
    }
}
