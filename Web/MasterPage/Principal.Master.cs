using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeitoCaipira.MasterPage
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<int> teste = new List<int>();
            teste.Add(1);
            teste.Add(1);
            teste.Add(1);
            teste.Add(1);
            
            dtlParceiro.DataSource = teste;
            dtlParceiro.DataBind();
        }
    }
}