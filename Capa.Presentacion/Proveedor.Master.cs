using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capa.Presentacion
{
    public partial class Proveedor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginName1.FormatString = Session["proveedor"].ToString();
        }

        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Remove("proveedor");
        }
    }
}