using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa.Negocio;

namespace Capa.Presentacion
{
    public partial class mis_ordenes_proveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Compra compras = new Compra();

                gridOrdenes.DataSource = compras.ObtenerOrdenesProveedor((int)Session["idproveedor"]);
                gridOrdenes.DataBind();

            }
        }

        protected void gridOrdenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.CompareTo("VerDetalles") == 0)
            {
                panelPrincipal.Visible = false;
                panelDetalles.Visible = true;
                int compraID = (int)gridOrdenes.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
                CargarDetalle(compraID);
            }
        }

        private void CargarDetalle(int compraID)
        {
            CompraProducto cp = new CompraProducto();
            List<CompraProducto> lcp = cp.ObtenerDetalleCompra(compraID);
            gridDetalles.DataSource = lcp;
            gridDetalles.DataBind();
        }

        protected void gridOrdenes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
            {
                if (!e.Row.Cells[1].Text.Equals("&nbsp;"))
                {
                    DateTime d = DateTime.Parse(e.Row.Cells[1].Text);
                    e.Row.Cells[1].Text = d.ToShortDateString();
                }
            }
        }

        protected void gridDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gridDetalles_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("mis-ordenes-proveedor.aspx");
        }
    }
}