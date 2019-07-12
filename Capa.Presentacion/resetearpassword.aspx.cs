using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa.Negocio;

namespace Capa.Presentacion
{
    public partial class resetearpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Acceso a = new Acceso();
            a.Usuario = txtCorreo.Text;
            if (a.ObtenerPreguntas())
            {
                panelPregunta.Visible = true;
                panelEmail.Visible = false;
                lbPregunta.Text = a.Pregunta;
                Session["usuario"] = a;
            }else
            {
                validarCorreo.Text = "El correo ingresado no existe en nuestro sistema. Cont&aacute;ctese con nosotros para verificar su email.";
                validarCorreo.IsValid = false;
            }
        }

        protected void btnCambiarClave_Click(object sender, EventArgs e)
        {
            if(txtNuevaClave1.Text==string.Empty || txtNuevaClave2.Text == string.Empty)
            {
                claveVacia.IsValid = false;
            }else
            {
                Acceso a = (Acceso)Session["usuario"];
                Encrypt en = new Encrypt();
                a.Clave = en.SHA1(txtNuevaClave2.Text);
                if (a.ModificarClave())
                {
                    panelNuevaClave.Visible = false;
                    panelPrincipal.Visible = false;
                    panelExito.Visible = true;
                    HttpContext.Current.Session.Remove("usuario");
                }
            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            Acceso a = (Acceso)Session["usuario"];
            Encrypt enc = new Encrypt();
            string respuesta = enc.SHA1(txtRespuesta.Text);
            a.Usuario = txtCorreo.Text;
            a.ObtenerPreguntas();
            if (respuesta.Equals(a.Respuesta))
            {
                panelPregunta.Visible = false;
                panelNuevaClave.Visible = true;
            }else
            {
                validarRespuesta.Text = "La respuesta no corresponde a la ingresada en la base de datos.";
                validarRespuesta.IsValid = false;
            }
        }
    }
}