using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa.Negocio;

namespace Capa.Presentacion
{
    public partial class clprocesar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idusuario"] != null)
                {
                    Usuario u = new Usuario();
                    int idusuario = (int)Session["idusuario"];
                    u.ObtenerUsuario(idusuario);
                    txtNombre.Text = u.Nombre;
                    txtRut.Text = u.Rut;
                    txtDireccion.Text = u.Direccion;
                    txtTelefono.Text = u.Telefono;
                    txtEmail.Text = u.Mail;
                    Session["usuario"] = u.ObtenerNombrePorId(idusuario);
                }
                Refrescar();
                CalcularTotales();
            }
        }

        private void Refrescar()
        {
            List<Producto> listado = (List<Producto>)Session["carro"];
            lbCantidadCarro.Text = listado.Count.ToString();
            gridFinal.DataSource = listado;
            gridFinal.DataBind();
        }

        private void CalcularTotales()
        {
            List<Producto> lista = (List<Producto>)Session["carro"];
            if (lista != null)
            {
                int Total = 0, IVA = 0, TotalFinal = 0;
                for (int i = 0; i < lista.Count; i++)
                {
                    Total = Total + (lista[i].Cantidad * lista[i].Precio);
                }
                IVA = ((Total * 19) / 100);
                TotalFinal = Total + IVA;
                lbNeto.Text = Total.ToString();
                lbIva.Text = IVA.ToString();
                lbTotal.Text = TotalFinal.ToString();
            }else
            {
                lbTotal.Text = "0";
                lbIva.Text = "0";
                lbNeto.Text = "0";
            }
        }

        protected void gridFinal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
            {
                string precio = e.Row.Cells[2].Text;
                string cantidad = e.Row.Cells[3].Text;
                int esnumero, esnumero2;
                if (int.TryParse(precio, out esnumero) && int.TryParse(cantidad, out esnumero2))
                {
                    int total = int.Parse(precio) * int.Parse(cantidad);
                    e.Row.Cells[4].Text = "$ " + total;
                    e.Row.Cells[2].Text = "$ " + e.Row.Cells[2].Text;
                }
            }
        }

        protected void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            u.Id = (int)Session["idusuario"];
            u.Nombre = txtNombre.Text;
            u.Rut = txtRut.Text;
            u.Direccion = txtDireccion.Text;
            u.Telefono = txtTelefono.Text;
            u.Mail = txtEmail.Text.ToLower();
            u.UpdatePorCliente();
                //Actualizo el mail del usuario en la tabla acceso
                Acceso a = new Acceso();
                a.UsuarioId = (int)Session["idusuario"];
                a.Usuario = txtEmail.Text.ToLower();
                a.ModificarMailPorCliente();

                //Recupero la información actualizada del cliente.
                Usuario cliente = new Usuario();
                cliente.ObtenerUsuario((int)Session["idusuario"]);


                //Generando Orden de Venta
                List<Usuario> vendedores = u.ObtenerIDVendedores();

                Random rnd = new Random();

                int idVendedor = rnd.Next(1, vendedores.Count);

                Venta venta = new Venta();
                Venta tempventa = new Venta();

                venta.TipoDocumento = cliente.TipoCliente;
                if (cliente.TipoCliente.Equals('B'))
                {
                    venta.NumDocumento = tempventa.NuevoDocumentoBoleta() + 1;
                }else
                {
                    venta.NumDocumento = tempventa.NuevoDocumentoFactura() + 1;
                }
                venta.FechaDocumento = DateTime.Parse(DateTime.Now.ToShortDateString());
                venta.IdCliente = cliente.Id;
                venta.Total = int.Parse(lbNeto.Text);
                venta.UsuarioId = idVendedor;

                venta.CrearVentaOnline();
            Venta otraVenta = new Venta();

                int ventaID = otraVenta.ObtenerUltimoID();
                List<Producto> lista = (List<Producto>)Session["carro"];
                foreach (Producto temp in lista)
                {
                    DetalleVenta dv = new DetalleVenta();
                    dv.Precio = temp.Precio;
                    dv.Cantidad = temp.Cantidad;
                    dv.VentaId = ventaID;
                    dv.ProductoId = temp.Id;

                    dv.CrearDetalleVenta();
                }

    
                Session["usuario"] = u.ObtenerNombrePorId((int)Session["idusuario"]);
                HttpContext.Current.Session.Remove("carro");
            panelPrincipal.Visible = false;
            lbNumOrden.Text = venta.NumDocumento.ToString();
            panelProcesado.Visible = true;
        }
    }
}