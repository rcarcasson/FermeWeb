using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa.Negocio;

namespace Capa.Presentacion
{
    public partial class mis_ordenes_cliente : System.Web.UI.Page
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
                Venta ventas = new Venta();

                gridOrdenes.DataSource = ventas.ObtenerOrdenesdeCliente((int)Session["idusuario"]);
                gridOrdenes.DataBind();

            }
        }

        protected void gridOrdenes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
            {
                if (!e.Row.Cells[1].Text.Equals("&nbsp;"))
                {
                    DateTime d = DateTime.Parse(e.Row.Cells[1].Text);
                    e.Row.Cells[1].Text = d.ToShortDateString();
                    e.Row.Cells[2].Text = "$ " + e.Row.Cells[2].Text;
                }
            }
        }

        protected void gridDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gridOrdenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.CompareTo("VerDetalles") == 0)
            {
                panelPrincipal.Visible = false;
                panelDetalles.Visible = true;
                int ventaID = (int)gridOrdenes.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
                CargarDetalle(ventaID);
            }
        }

        private void CargarDetalle(int ventaID)
        {
            VentaProducto vp = new VentaProducto();
            List<VentaProducto> lvp = vp.ObtenerDetalleVenta(ventaID);
            gridDetalles.DataSource = lvp;
            gridDetalles.DataBind();

            if (lvp != null)
            {
                int Total = 0, IVA = 0, TotalFinal = 0;
                for (int i = 0; i < lvp.Count; i++)
                {
                    Total = Total + (lvp[i].Cantidad * lvp[i].PrecioUnitario);
                }
                IVA = ((Total * 19) / 100);
                TotalFinal = Total + IVA;
                lbNeto.Text = Total.ToString();
                lbIva.Text = IVA.ToString();
                lbTotal.Text = TotalFinal.ToString();
            }
            else
            {
                lbTotal.Text = "0";
                lbIva.Text = "0";
                lbNeto.Text = "0";
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("mis-ordenes-cliente.aspx");
        }

        protected void gridDetalles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
            {
                if (!e.Row.Cells[2].Text.Equals("&nbsp;"))
                {
                    int total = int.Parse(e.Row.Cells[2].Text) * int.Parse(e.Row.Cells[3].Text);
                    e.Row.Cells[4].Text = "$ " + total;
                    e.Row.Cells[2].Text = "$ " + e.Row.Cells[2].Text;
                }
            }
        }
    }
}