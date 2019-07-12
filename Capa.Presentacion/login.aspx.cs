using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Capa.Negocio;

namespace Capa.Presentacion
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Acceso ac = new Acceso();
            Encrypt en = new Encrypt();
            ac.Usuario = Login1.UserName;
            ac.Clave = en.SHA1(Login1.Password);
            if (ac.Login())
            {
                if (ac.UsuarioId != 0)
                {
                    Usuario us = new Usuario();
                    e.Authenticated = true;
                    Session["usuario"] = us.ObtenerNombrePorId(ac.UsuarioId);
                    Session["idusuario"] = ac.UsuarioId;
                    FormsAuthentication.SetAuthCookie(Session["usuario"].ToString(), false);

                    Visita visita = new Visita();
                    visita.Usuario = Session["usuario"].ToString();
                    visita.GuardarVisita();
                    Response.Redirect("index-cliente.aspx");
                }else
                {
                    Negocio.Proveedor pro = new Negocio.Proveedor();
                    e.Authenticated = true;
                    Session["proveedor"] = pro.ObtenerNombrePorId(ac.ProveedorId);
                    Session["idproveedor"] = ac.ProveedorId;
                    FormsAuthentication.SetAuthCookie(Session["proveedor"].ToString(), false);

                    Visita visita = new Visita();
                    visita.Usuario = Session["proveedor"].ToString();
                    visita.GuardarVisita();
                    Response.Redirect("index-proveedor.aspx");
                }
            }
        }
    }
}