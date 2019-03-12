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
    public partial class Home : System.Web.UI.MasterPage
    {
        List<Permiso> ListaPermisos = new List<Permiso>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSessionEmpleado"] != null)
                {
                    Empleado objEmpeado = (Empleado)Session["UserSessionEmpleado"];
                    txtUser.Text = objEmpeado.Nombre;
                }
            }
        }
    }
}