using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["UserSession"] != null)
                //{
                //    txtUser.Text = (String)Session["UserSession"];
                //}
                if (Session["UserSessionObjeto"] != null)
                {
                    Empleado objEmpleado = (Empleado)Session["UserSessionObjeto"];

                    txtUser.Text = objEmpleado.Nombre;
                }
            }
        }
    }
}