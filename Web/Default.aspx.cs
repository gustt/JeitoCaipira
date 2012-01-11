using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeitoCaipira
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<int> teste = new List<int>();
            teste.Add(1);
            teste.Add(1);
            teste.Add(1);
            teste.Add(1);
            teste.Add(1);

            dtlVemPorAi.DataSource = teste;
            dtlVemPorAi.DataBind();
        }
    }
}