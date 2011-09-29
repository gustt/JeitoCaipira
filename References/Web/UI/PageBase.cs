using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using References.Common;
using References.Security;

namespace References.Web.UI
{
    public class PageBase : Page
    {
        #region Propriedades
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
        #endregion
        #region Eventos
        public PageBase() : base() { }
        protected override void OnLoad(EventArgs e)
        {
            //string caminhoLogin = string.Concat(WebConfigurationManager.AppSettings["AUTH_LOGIN_PAGE"],
            //            "?ReturnPage=",
            //            HttpContext.Current.Request.Url);

            //string LoginPage = WebConfigurationManager.AppSettings["AUTH_LOGIN_PAGE"];

            //if (HttpContext.Current.Request.FilePath.IndexOf("Login") == -1)
            //{
            //    if (UsuarioLogado == null)
            //        HttpContext.Current.Response.Redirect(caminhoLogin);

            //    bool possuiPerfil = false;
            //    if (WebConfigurationManager.AppSettings["AUTH_PERFIL_PAGINA"] != null)
            //    {
            //        string[] perfis = WebConfigurationManager.AppSettings["AUTH_PERFIL_PAGINA"].Split(',');
            //        for (int index = 0; index < perfis.Length; index++)
            //        {
            //            Enumerations.TipoPerfil _tipoPerfil =
            //                (Enumerations.TipoPerfil)perfis[index].ToInt();
            //            if(UsuarioLogado.TipoPerfil == _tipoPerfil)
            //            {
            //                possuiPerfil = true;
            //                break;
            //            }
            //        }
            //    }

            //    if (!possuiPerfil)
            //        HttpContext.Current.Response.Redirect(caminhoLogin);
            //}

            base.OnLoad(e);
        }
        #endregion
        #region Metodos
        public void AutenticarUsuario(UserContext UsuarioLogado)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Add("UsuarioLogado", UsuarioLogado);
        }
        #endregion
    }
}
