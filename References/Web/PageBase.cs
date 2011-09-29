using System;
using System.Configuration;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

namespace References.Web.UI
{
    public class PageBase : System.Web.UI.Page
    {
        //Construtor
        public PageBase() : base()
        {
            //TODO: VALIDAR PERMICAO NA PAGINA
        }
        protected override void OnPreInit(EventArgs e)
        {
            
            base.OnPreInit(e);
        }
        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);
        }
    }
}
