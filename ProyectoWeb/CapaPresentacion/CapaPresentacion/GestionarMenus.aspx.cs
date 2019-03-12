using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;
using System.Web.Services;

namespace CapaPresentacion
{
    public partial class GestionarMenus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarMenuPrincipal();
            }
        }

        private void LlenarMenuPrincipal()
        {

            List<CapaEntidades.Menu> ListaMenu = MenuLN.getInstance().ListarMenuPrincipal();

            ddlMenuPrincipal.DataValueField = "idMenu";
            ddlMenuPrincipal.DataTextField = "nombre";
            ddlMenuPrincipal.DataSource = ListaMenu;
            ddlMenuPrincipal.DataBind();

            // Modal
            ddlAMenuPrincipal.DataValueField = "idMenu";
            ddlAMenuPrincipal.DataTextField = "nombre";
            ddlAMenuPrincipal.DataSource = ListaMenu;
            ddlAMenuPrincipal.DataBind();
        }

        [WebMethod]
        public static Permiso ListarMenu()
        {
            return MenuLN.getInstance().ListarMenu();
        }

        [WebMethod]
        public static bool ActualizarDatosMenu(String id, String nombrePermiso, String urlPermiso, String ymenuPrincipal, bool zisActivo, bool zisSubmenu)
        {
            CapaEntidades.Menu objMenu = new CapaEntidades.Menu();
            objMenu.IdMenu = Convert.ToInt32(id);
            objMenu.Nombre = nombrePermiso;
            objMenu.Url = urlPermiso;
            objMenu.IdMenuParent = Convert.ToInt32(ymenuPrincipal);
            objMenu.Estado = zisActivo;
            objMenu.IsSubMenu = zisSubmenu;

            return MenuLN.getInstance().ActualizarMenu(objMenu);
        }

        [WebMethod]
        public static bool EliminarDatosMenu(String id)
        {
            Int32 idMenu = Convert.ToInt32(id);

            return MenuLN.getInstance().EliminarMenu(idMenu);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            CapaEntidades.Menu objMenu = new CapaEntidades.Menu();
            objMenu.Nombre = txtNombrePermiso.Text;
            objMenu.Url = txtUrlPermiso.Text;
            objMenu.IsSubMenu = chkIsSubmenu.Checked;
            objMenu.IdMenuParent = Convert.ToInt32(ddlMenuPrincipal.SelectedItem.Value);

            bool response = MenuLN.getInstance().RegistrarMenu(objMenu);
            if (response)
            {
                Response.Write("<script>alert('REGISTRO CORRECTO.')</script>");
                LlenarMenuPrincipal();
            }
            else
            {
                Response.Write("<script>alert('REGISTRO INCORRECTO.')</script>");
            }
        }
    }
}