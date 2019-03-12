using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class PermisoDAO
    {
        #region "PATRON SINGLETON"
        private static PermisoDAO daoPermiso = null;
        private PermisoDAO() { }
        public static PermisoDAO getInstance()
        {
            if (daoPermiso == null)
            {
                daoPermiso = new PermisoDAO();
            }
            return daoPermiso;
        }
        #endregion

        // Crear Permisos
        public bool RegistrarEliminarPermiso(Permiso objPermiso, Int32 opcion)
        {
            bool response = false;

            using (SqlConnection con = Conexion.getInstance().ConexionBD())
            {
                con.Open();
          
                try
                {
                    foreach (Menu menu in objPermiso.PMenu)
                    {
                        SqlCommand cmd = new SqlCommand("spRegistrarEliminarPermiso", con);
                        cmd.Parameters.AddWithValue("@prmIdMenu", menu.IdMenu);
                        cmd.Parameters.AddWithValue("@prmIdEmpleado", objPermiso.PEmpleado.ID);
                        cmd.Parameters.AddWithValue("@prmOpcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();
                    }
                    response = true;
                }
                catch (Exception)
                {
                    response = false;
                }
                return response;
            }
        }

        // Listado de Menus pero lo manejamos por medio de la clase PermisoDAO
        public List<Menu> ListarMenuPermisos(Int32 IdEmpleado, Int32 opcion)
        {
            List<Menu> Lista = new List<Menu>();
            SqlDataReader dr = null;

            try
            {
                using (SqlConnection con = Conexion.getInstance().ConexionBD())
                {
                    SqlCommand cmd = new SqlCommand("spListarMenuPermisos", con);
                    cmd.Parameters.AddWithValue("@prmIdEmpleado", IdEmpleado);
                    cmd.Parameters.AddWithValue("@prmOption", opcion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Lista.Add(CreateObject(dr));
                    }

                    Lista = CrearMenuSubMenu(Lista);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Lista;
        }

        private Menu CreateObject(SqlDataReader dr)
        {
            Menu objMenu = new Menu();
            objMenu.IdMenu = Convert.ToInt32(dr["IdMenu"].ToString());
            objMenu.Nombre = dr["nombre"].ToString();
            objMenu.IsSubMenu = Convert.ToBoolean(dr["isSubMenu"].ToString());
            objMenu.Url = dr["url"].ToString();
            objMenu.IdMenuParent = Convert.ToInt32(dr["idMenuParent"].ToString());

            return objMenu;
        }

        private List<Menu> CrearMenuSubMenu(List<Menu> ListaMenu)
        {
            var submenus = ListaMenu.Where(m => m.IsSubMenu).ToList();
            var menus = ListaMenu.Where(m => !m.IsSubMenu).ToList();

            foreach (var submenu in submenus)
            {
                foreach (var menu in menus)
                {
                    if (submenu.IdMenuParent == menu.IdMenu)
                    {
                        submenu.SubMenu.Add(menu);
                        break;
                    }
                }
            }

            List<Menu> Lista = new List<Menu>();
            Lista.AddRange(menus);
            Lista.AddRange(submenus);

            return Lista;
        }
    }
}
