using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaPresentacion.Custom;
using System.Web.Services;

namespace CapaPresentacion
{
    public partial class PanelGeneral : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            
            }
        }

        [WebMethod]
        public static bool Logout()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            return true;
        }

    }
}