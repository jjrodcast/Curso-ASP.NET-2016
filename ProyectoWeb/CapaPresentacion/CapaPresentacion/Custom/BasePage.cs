using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CapaPresentacion.Custom
{
    public abstract class BasePage : System.Web.UI.Page
    {
        private SessionManager _sessionManager;

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
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Context.Session != null) 
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