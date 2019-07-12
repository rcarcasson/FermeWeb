using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa.Negocio;

namespace Capa.Presentacion
{
    public partial class mis_datos_cliente : System.Web.UI.Page
    {
        List<Producto> listadoproducto;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["carro"] == null)
            {
                listadoproducto = new List<Producto>();
            }
            else
            {
                listadoproducto = (List<Producto>)Session["carro"];

            }
            lbCantidadCarro.Text = listadoproducto.Count.ToString();

            if (!IsPostBack)
            {
                Usuario u = new Usuario();
                int idUsuario = (int)Session["idusuario"];
                u.ObtenerUsuario(idUsuario);

                txtNombre.Text = u.Nombre;
                txtRut.Text = u.Rut;
                txtDireccion.Text = u.Direccion;
                txtTelefono.Text = u.Telefono;
                txtEmail.Text = u.Mail.ToLower();

                Acceso a = new Acceso();
                a.ObtenerDatosAcceso(idUsuario);

                if (a.Pregunta != null)
                {
                    txtPregunta.Text = a.Pregunta;
                }

            }
        }

        protected void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            u.Id = (int)Session["idusuario"];
            u.Nombre = txtNombre.Text;
            u.Rut = txtRut.Text;
            u.Direccion = txtDireccion.Text;
            u.Telefono = txtTelefono.Text;
            u.Mail = txtEmail.Text;

            u.UpdatePorCliente();

            Acceso a = new Acceso();
            a.UsuarioId = (int)Session["idusuario"];
            a.Usuario = txtEmail.Text.ToLower();

            a.ModificarMailPorCliente();

            panelDatos.Visible = false;
            panelMisDatos.Visible = true;
            Session["usuario"] = txtNombre.Text;
                
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index-cliente.aspx");
        }

        protected void btnAceptar2_Click(object sender, EventArgs e)
        {
            Response.Redirect("index-cliente.aspx");
        }

        protected void btnActualizarClave_Click(object sender, EventArgs e)
        {
            Acceso a = new Acceso();
            a.ObtenerDatosAcceso((int)Session["idusuario"]);

            Encrypt enc = new Encrypt();
            string claveActual = enc.SHA1(txtClaveActual.Text);
            if (claveActual.Equals(a.Clave))
            {
                string nuevaClave = enc.SHA1(txtNuevaClave2.Text);
                a.Clave = nuevaClave;
                a.ModificarClave();
                panelDatos.Visible = false;
                panelClave.Visible = true;
            }
            else
            {
                reqValClave.Text = "La clave actual no es correcta.";
                reqValClave.IsValid = false;
            }
        }

        protected void btnAceptar3_Click(object sender, EventArgs e)
        {
            Response.Redirect("index-cliente.aspx");
        }

        protected void btnActualizarPregunta_Click(object sender, EventArgs e)
        {
            Acceso a = new Acceso();
            a.ObtenerDatosAcceso((int)Session["idusuario"]);

            Encrypt enc = new Encrypt();
            string claveActual = enc.SHA1(txtClave.Text);
            if (claveActual.Equals(a.Clave))
            {
                string nuevaRespuesta = enc.SHA1(txtRespuesta.Text);
                a.Pregunta = txtPregunta.Text;
                a.Respuesta = enc.SHA1(txtRespuesta.Text);
                a.ActualizarPreguntaRespuesta();
                panelDatos.Visible = false;
                panelPregunta.Visible = true;
            }
            else
            {
                reqClave2.Text = "La clave actual no es correcta.";
                reqClave2.IsValid = false;
            }

        }
    }
}