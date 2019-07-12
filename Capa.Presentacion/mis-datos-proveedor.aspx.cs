using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa.Negocio;

namespace Capa.Presentacion
{
    public partial class mis_datos_proveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Negocio.Proveedor proveedor = new Negocio.Proveedor();
                int idProveedor = (int)Session["idproveedor"];
                proveedor.Id = idProveedor;
                proveedor.Read();
                txtNombre.Text = proveedor.Nombre;
                txtRut.Text = proveedor.Rut;
                txtDireccion.Text = proveedor.Direccion;
                txtTelefono.Text = proveedor.Telefono;
                txtEmail.Text = proveedor.Mail.ToLower();
                txtRubro.Text = proveedor.Rubro;

                Acceso a = new Acceso();
                a.ObtenerDatosAccesoProveedor(idProveedor);

                if (a.Pregunta != null)
                {
                    txtPregunta.Text = a.Pregunta;
                }
            }
        }

        protected void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            Negocio.Proveedor p = new Negocio.Proveedor();
            p.Id = (int)Session["idproveedor"];
            p.Nombre = txtNombre.Text;
            p.Rut = txtRut.Text;
            p.Direccion = txtDireccion.Text;
            p.Telefono = txtTelefono.Text;
            p.Rubro = txtRubro.Text;
            p.Mail = txtEmail.Text;

            p.Update();

            Acceso a = new Acceso();
            a.ProveedorId = (int)Session["idproveedor"];
            a.Usuario = txtEmail.Text.ToLower();

            a.ModificarMailPorProveedor();

            panelDatos.Visible = false;
            panelMisDatos.Visible = true;
            Session["usuario"] = txtNombre.Text;
        }

        protected void btnActualizarClave_Click(object sender, EventArgs e)
        {
            Acceso a = new Acceso();
            a.ObtenerDatosAccesoProveedor((int)Session["idproveedor"]);

            Encrypt enc = new Encrypt();
            string claveActual = enc.SHA1(txtClaveActual.Text);
            if (claveActual.Equals(a.Clave))
            {
                string nuevaClave = enc.SHA1(txtNuevaClave2.Text);
                a.Clave = nuevaClave;
                a.ModificarClaveProveedor();
                panelDatos.Visible = false;
                panelClave.Visible = true;
            }else
            {
                reqValClave.Text = "La clave actual no es correcta.";
                reqValClave.IsValid = false;
            }
        }

        protected void btnActualizarPregunta_Click(object sender, EventArgs e)
        {
            Acceso a = new Acceso();
            a.ObtenerDatosAccesoProveedor((int)Session["idproveedor"]);

            Encrypt enc = new Encrypt();
            string claveActual = enc.SHA1(txtClave.Text);
            if (claveActual.Equals(a.Clave))
            {
                string nuevaRespuesta = enc.SHA1(txtRespuesta.Text);
                a.Pregunta = txtPregunta.Text;
                a.Respuesta = nuevaRespuesta;
                a.ActualizarPreguntaRespuestaProveedor();
                panelDatos.Visible = false;
                panelPregunta.Visible = true;
            }else
            {
                reqClave2.Text = "La clave actual no es correcta.";
                reqClave2.IsValid = false;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index-proveedor.aspx");
        }

        protected void btnAceptar2_Click(object sender, EventArgs e)
        {
            Response.Redirect("index-proveedor.aspx");

        }

        protected void btnAceptar3_Click(object sender, EventArgs e)
        {
            Response.Redirect("index-proveedor.aspx");

        }
    }
}