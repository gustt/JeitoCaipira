using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using References.Web.UI;

namespace JeitoCaipira.Login
{
    public partial class Login : References.Web.UI.PageBase
    {
        #region Propriedades
        public string ReturnPage
        {
            get
            {
                if (Request.QueryString["ReturnPage"] != null)
                    return Request.QueryString["ReturnPage"];
                else
                    return null;
            }
        }
        #endregion
        #region Eventos
        protected void lnkLogar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Logar
                if (this.UsuarioLogado == null || this.UsuarioLogado.TipoPerfil != References.Common.Enumerations.TipoPerfil.NaoDefinido)
                {
                    DBLayers.BLL.Regras.Usuario rUsr = new DBLayers.BLL.Regras.Usuario();
                    rUsr.Select(txtUserID.Text, txtSenhas.Text);

                    if (rUsr.Instance != null)
                    {

                        #region Verificar se usuario esta logado em outro lugar
                        if (Application["UsuariosAtivos"] != null)
                        {
                            Dictionary<string, References.Security.UserContext> UsuarioAtivos =
                                     Application["UsuariosAtivos"] as Dictionary<string, References.Security.UserContext>;

                            foreach (References.Security.UserContext usuariologado in UsuarioAtivos.Values)
                            {
                                if (usuariologado.UserID.Equals(rUsr.Instance.UserID))
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "_alert",
                                            "alert(\"Usuário já esta logado em outra máquina!\")", true);
                                    return;
                                }
                            }
                        }
                        #endregion


                        this.AutenticarUsuario(
                            new References.Security.UserContext()
                            {
                                NomeUsuario = rUsr.Instance.NomeAdministrador,
                                UserID = rUsr.Instance.UserID,
                                TipoPerfil = (References.Common.Enumerations.TipoPerfil)rUsr.Instance.TipoPerfil
                            });

                        RegistarUsuario();

                        if (!string.IsNullOrEmpty(ReturnPage))
                            Response.Redirect(ReturnPage);
                        else
                            Response.Redirect("~/Default.aspx");
                    }
                }
                else if (!string.IsNullOrEmpty(ReturnPage))
                {
                    RegistarUsuario();
                    Response.Redirect(ReturnPage);
                }
                else
                {
                    RegistarUsuario();
                    Response.Redirect("~/Default.aspx");
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        public void RegistarUsuario()
        {
            Dictionary<string, References.Security.UserContext> UsuarioAtivos =
                             Application["UsuariosAtivos"] as Dictionary<string, References.Security.UserContext>;

            if (!UsuarioAtivos.ContainsKey(Session.SessionID))
            {
                UsuarioAtivos.Add(Session.SessionID, UsuarioLogado);
                Application["UsuariosAtivos"] = UsuarioAtivos;
            }
        }
    }
}