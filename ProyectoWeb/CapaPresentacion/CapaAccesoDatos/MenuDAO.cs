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
    public class MenuDAO
    {
        #region "PATRON SINGLETON"
        private static MenuDAO daoMenu = null;
        private MenuDAO() { }
        public static MenuDAO getInstance()
        {
            if (daoMenu == null)
            {
                daoMenu = new MenuDAO();
            }
            return daoMenu;
        }
        #endregion

        public bool RegistrarMenu(Menu menu)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            bool response = false;

            try
            {
                conn = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarMenu", conn);
                cmd.Parameters.AddWithValue("@prmNombre", menu.Nombre);
                cmd.Parameters.AddWithValue("@prmIsSubmenu", menu.IsSubMenu);
                cmd.Parameters.AddWithValue("@prmUrl", menu.Url);
                cmd.Parameters.AddWithValue("@prmMenuParent", menu.IdMenuParent);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                cmd.ExecuteNonQuery();

                response = true;
            }
            catch (Exception e)
            {
                response = false;
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return response;
        }

        public bool ActualizarMenu(Menu menu)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            bool response = false;

            try
            {
                conn = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizaMenu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMenu", menu.IdMenu);
                cmd.Parameters.AddWithValue("@prmNombreMenu", menu.Nombre);
                cmd.Parameters.AddWithValue("@prmUrlMenu", menu.Url);
                cmd.Parameters.Add("@prmIdMenuParent", menu.IdMenuParent);
                cmd.Parameters.Add("@prmIsSubMenu", menu.IsSubMenu);
                cmd.Parameters.Add("@prmEstado", menu.Estado);
                conn.Open();

                cmd.ExecuteNonQuery();

                response = true;

            }
            catch (Exception e)
            {
                response = false;
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return response;
        }

        public bool EliminarMenu(Int32 id)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            bool response = false;

            try
            {
                conn = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spEliminarMenu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMenu", id);
                conn.Open();

                cmd.ExecuteNonQuery();

                response = true;

            }
            catch (Exception e)
            {
                response = false;
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return response;
        }

        public Permiso ListarMenu()
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            SqlDataReader dr = null;
            Permiso objPermiso = new Permiso();

            try
            {
                conn = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarMenu", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objPermiso.PMenu.Add(CrearMenuListado(dr));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return objPermiso;
        }

        public Permiso ListarMenuPorEmpleado(Int32 IdEmpleado)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            SqlDataReader dr = null;
            Permiso objPermiso = new Permiso();

            try
            {
                conn = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spMenuPorEmpleado", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdEmpleado", IdEmpleado);

                conn.Open();

                dr = cmd.ExecuteReader();
                Permiso objPermisoTemp = new Permiso();
                while (dr.Read())
                {
                    objPermisoTemp.PMenu.Add(CrearMenu(dr, objPermisoTemp));
                }
                objPermiso = OrdenarMenu(objPermisoTemp);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return objPermiso;
        }

        public List<Menu> ListarMenuPrincipal()
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            SqlDataReader dr = null;
            List<Menu> Lista = new List<Menu>();

            try
            {
                conn = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListaMenuPrincipal", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Menu objMenu = new Menu();
                    objMenu.IdMenu = Convert.ToInt32(dr["idMenu"].ToString());
                    objMenu.Nombre = dr["nombre"].ToString();
                    Lista.Add(objMenu);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return Lista;
        }

        private Menu CrearMenuListado(SqlDataReader dr)
        {
            Menu objMenu = new Menu();
            objMenu.IdMenu = Convert.ToInt32(dr["idMenu"].ToString());
            objMenu.Nombre = dr["nombre"].ToString();
            objMenu.Url = dr["url"].ToString();
            objMenu.IsSubMenu = Convert.ToBoolean(dr["isSubmenu"].ToString());
            objMenu.IdMenuParent = Convert.ToInt32(dr["idMenuParent"].ToString());
            objMenu.Estado = Convert.ToBoolean(dr["estado"].ToString());
            objMenu.Show = Convert.ToBoolean(dr["show"].ToString());

            return objMenu;
        }

        private Menu CrearMenu(SqlDataReader dr, Permiso objPermiso)
        {
            Menu objMenu = new Menu();
            objMenu.IdMenu = Convert.ToInt32(dr["idMenu"].ToString());
            objMenu.Nombre = dr["nombre"].ToString();
            objMenu.Url = dr["url"].ToString();
            objMenu.IsSubMenu = Convert.ToBoolean(dr["isSubmenu"].ToString());
            objMenu.IdMenuParent = Convert.ToInt32(dr["idMenuParent"].ToString());
            objMenu.Estado = Convert.ToBoolean(dr["MEstado"].ToString());
            objPermiso.Estado = Convert.ToBoolean(dr["Estado"].ToString());
            objMenu.Show = Convert.ToBoolean(dr["show"].ToString());

            return objMenu;
        }

        private Permiso OrdenarMenu(Permiso objPermiso)
        {
            var SubMenus = objPermiso.PMenu.Where(p => p.IsSubMenu).Select(x => x).ToList();
            objPermiso.PMenu.RemoveAll(m => m.IsSubMenu);

            foreach (Menu menu in objPermiso.PMenu)
            {
                menu.SubMenu = SubMenus.Where(sm => sm.IdMenuParent == menu.IdMenu).Select(sm => sm).ToList();
            }
            return objPermiso;
        }
    }
}
