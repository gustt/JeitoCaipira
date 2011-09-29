using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using References.Common;
using References.Security;

namespace References.Web.UI
{
    public class UserControlBase : UserControl
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
        public UserControlBase()
            : base()
        {
        }
        #endregion
    }
}
