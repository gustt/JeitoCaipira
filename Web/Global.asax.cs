using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using References.Security;
using References.Common;

namespace JeitoCaipira
{
    public class Global : System.Web.HttpApplication
    {
        public UserContext UsuarioLogado
        {
            get
            {
                if (HttpContext.Current.Session["UsuarioLogado"] != null)
                    return (UserContext)HttpContext.Current.Session["UsuarioLogado"];
                else
                    return null;
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Add("UsuariosAtivos", new Dictionary<string, References.Security.UserContext>());
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Dictionary<string, References.Security.UserContext> UsuarioAtivos =
                Application["UsuariosAtivos"] as Dictionary<string, References.Security.UserContext>;

            if (UsuarioAtivos.ContainsKey(this.Session.SessionID))
                UsuarioAtivos.Remove(this.Session.SessionID);

            Application["UsuariosAtivos"] = UsuarioAtivos;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}