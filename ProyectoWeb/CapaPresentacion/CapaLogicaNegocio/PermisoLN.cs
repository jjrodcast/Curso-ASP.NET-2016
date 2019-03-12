using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class PermisoLN
    {
        #region "PATRON SINGLETON"
        private static PermisoLN objPermiso = null;
        private PermisoLN() { }
        public static PermisoLN getInstance()
        {
            if (objPermiso == null)
            {
                objPermiso = new PermisoLN();
            }
            return objPermiso;
        }
        #endregion

        public bool RegistrarEliminarPermiso(Permiso objPermiso, Int32 opcion)
        {
            try
            {
                return PermisoDAO.getInstance().RegistrarEliminarPermiso(objPermiso, opcion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Menu> ListarMenuPermisos(Int32 IdEmpleado, Int32 opcion)
        {
            try
            {
                return PermisoDAO.getInstance().ListarMenuPermisos(IdEmpleado, opcion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
