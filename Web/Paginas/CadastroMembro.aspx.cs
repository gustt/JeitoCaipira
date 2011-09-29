using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeitoCaipira.Paginas
{
    public partial class CadastroMembro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_OnClick(object sender, EventArgs e)
        {
            ucCadastroMembro.Save();
        }

    }
}