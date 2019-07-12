using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa.Negocio;

namespace Capa.Presentacion
{
    public partial class index_cliente : System.Web.UI.Page
    {
        List<Producto> listadoproducto;
        static int indicelista;
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
                FamiliaProducto fp = new FamiliaProducto();
                listaProductos.DataSource = fp.Listado();
                listaProductos.DataBind();
                indicelista = 0;
            }
        }

        private void VerProducto(int id)
        {
            Producto p = new Producto();
            p.Id = id;
            if (p.Read())
            {
                lbTipoProducto.Text = p.Descripcion;
                lbStock.Text = p.Stock.ToString();
                lbPrecio.Text = p.Precio.ToString();
                txtCantidad.Text = "0";
                lbTotal.Text = "0";
                lbId.Text = p.Id.ToString();
            }
        }

        protected void listaProductos_Click(object sender, BulletedListEventArgs e)
        {
            indicelista = e.Index;
            lbTipoProducto.Text = listaProductos.Items[e.Index].Text;
            panelSaludo.Visible = false;
            panelProductos.Visible = true;
            panelAgregarAlCarro.Visible = false;
            panelAgregadoAlCarro.Visible = false;
            Producto p = new Producto();
            CargarProductos(p.ListadoPorProducto(int.Parse(listaProductos.Items[e.Index].Value)));
        }


        private void CargarProductos(List<Producto> productos)
        {
            if (productos.Count != 0)
            {
                gridProductos.Visible = true;
                panelSinExistencias.Visible = false;
                gridProductos.DataSource = productos;
                gridProductos.DataBind();
            }
            else
            {
                gridProductos.Visible = false;
                panelSinExistencias.Visible = true;
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                int cantidad;
                if (int.TryParse(txtCantidad.Text, out cantidad))
                {
                    lbTotal.Text = (int.Parse(lbPrecio.Text) * cantidad).ToString();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            p.Id = int.Parse(lbId.Text);
            p.Cantidad = int.Parse(txtCantidad.Text);
            if (p.Read())
            {
                int cantidad = int.Parse(txtCantidad.Text);
                if (cantidad <= 0 || cantidad > p.Stock)
                {
                    lbAlertaCarro.Text = "La cantidad no puede ser 0 ni mayor al stock.";
                    return;
                }
                Boolean existe = false;
                for (int i = 0; i < listadoproducto.Count; i++)
                {
                    if (listadoproducto[i].Id == int.Parse(lbId.Text))
                    {
                        listadoproducto[i].Cantidad = int.Parse(txtCantidad.Text);
                        existe = true;
                    }
                }
                if (!existe)
                {
                    listadoproducto.Add(p);
                }
                Session["carro"] = listadoproducto;
                panelAgregarAlCarro.Visible = false;
                panelAgregadoAlCarro.Visible = true;
                lbCantidadCarro.Text = listadoproducto.Count.ToString();
            }
        }

        protected void gridProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.CompareTo("AgregarAlCarro") == 0)
            {
                panelProductos.Visible = false;
                panelSaludo.Visible = false;
                panelAgregarAlCarro.Visible = true;
                int prodID = (int)gridProductos.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
                VerProducto(prodID);
            }
        }

        protected void gridProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
            {
                e.Row.Cells[3].Text = "$ " + e.Row.Cells[3].Text;
            }
        }

        protected void btnAceptarProceso_Click(object sender, EventArgs e)
        {
            lbTipoProducto.Text = listaProductos.Items[indicelista].Text;
            panelSaludo.Visible = false;
            panelProductos.Visible = true;
            panelAgregarAlCarro.Visible = false;
            panelAgregadoAlCarro.Visible = false;
            lbAlertaCarro.Visible = false;
            Producto p = new Producto();
            CargarProductos(p.ListadoPorProducto(int.Parse(listaProductos.Items[indicelista].Value)));
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            lbTipoProducto.Text = listaProductos.Items[indicelista].Text;
            panelSaludo.Visible = false;
            panelProductos.Visible = true;
            panelAgregarAlCarro.Visible = false;
            panelAgregadoAlCarro.Visible = false;
            lbAlertaCarro.Visible = false;
            Producto p = new Producto();
            CargarProductos(p.ListadoPorProducto(int.Parse(listaProductos.Items[indicelista].Value)));

        }
    }
}