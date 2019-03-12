using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using CapaEntidades;
using System.IO;

namespace CapaPresentacion.Custom
{
    public abstract class BasePage : System.Web.UI.Page
    {
        public SessionManager _sessionManager;

        protected SessionManager SessionManager
        {
            get { return _sessionManager; }
            set { _sessionManager = value; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            Session["KEYSTORE"] = "0";
            this._sessionManager = new SessionManager(Session);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (HttpContext.Current.Session["UserSessionEmpleado"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                var permisos = Session["Permisos"] as Permiso;

                if (permisos != null)
                {

                    string pageName = Path.GetFileName(Request.Path);
                    var hasMenuPermission = permisos.PMenu.Where(m => m.Url == pageName).Count() > 0;
                    var hasSubMenuPermission = permisos.PMenu.Where(m => m.SubMenu.Count > 0).Select(m => m.SubMenu).Count() > 0;

                    if (!hasSubMenuPermission && !hasMenuPermission) Response.Redirect("BadRequest.aspx");
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (HttpContext.Current.Session != null)
            {
                if (Session.IsNewSession)
                {
                    try
                    {
                        string cookie = Request.Headers["Cookie"];
                        if (cookie != null && cookie.IndexOf("ASP.NET_SessionId") >= 0)
                        {
                            Response.Redirect("~/Login.aspx");
                        }
                    }
                    catch (Exception)
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
               
            }
        }

    }
}