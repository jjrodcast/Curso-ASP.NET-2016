using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaLogicaNegocio
{
    public class MenuLN
    {
        #region "PATRON SINGLETON"
        private static MenuLN objMenu = null;
        private MenuLN() { }
        public static MenuLN getInstance()
        {
            if (objMenu == null)
            {
                objMenu = new MenuLN();
            }
            return objMenu;
        }
        #endregion

        public bool RegistrarMenu(Menu menu)
        {
            try
            {
                return MenuDAO.getInstance().RegistrarMenu(menu);
            }
            catch (Exception e) { throw e; }
        }


        public bool ActualizarMenu(Menu menu)
        {
            try
            {
                return MenuDAO.getInstance().ActualizarMenu(menu);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EliminarMenu(Int32 id)
        {
            try
            {
                return MenuDAO.getInstance().EliminarMenu(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Menu> ListarMenuPrincipal()
        {
            try
            {
                return MenuDAO.getInstance().ListarMenuPrincipal();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Permiso ListarMenu()
        {
            try
            {
                return MenuDAO.getInstance().ListarMenu();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Permiso ListarMenuPorEmpleado(Int32 IdEmpleado)
        {
            try
            {
                return MenuDAO.getInstance().ListarMenuPorEmpleado(IdEmpleado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
