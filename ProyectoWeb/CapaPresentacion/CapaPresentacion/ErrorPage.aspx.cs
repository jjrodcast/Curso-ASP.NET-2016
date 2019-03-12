using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
        }

        protected void btnReturnError_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserSessionEmpleado"] != null)
            {
                Response.Redirect("PanelGeneral.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}