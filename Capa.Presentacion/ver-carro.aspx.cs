using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa.Negocio;

namespace Capa.Presentacion
{
    public partial class ver_carro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["carro"] != null)
            {
                List<Producto> lista = (List<Producto>)Session["carro"];
                lbCantidadCarro.Text = lista.Count.ToString();
                panelCarroVacio.Visible = false;
                panelVerCarro.Visible = true;
            }
            else
            {
                lbCantidadCarro.Text = "0";
                panelCarroVacio.Visible = true;
                panelVerCarro.Visible = false;
            }

            if (!IsPostBack)
            {
                Refrescar();
                CalcularTotales();
            }
        }

        private void Refrescar()
        {
            gridCarro.DataSource = (List<Producto>)Session["carro"];
            gridCarro.DataBind();
        }

        protected void gridCarro_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridCarro.EditIndex = e.NewEditIndex;
            Refrescar();
            CalcularTotales();
        }

        protected void gridCarro_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridCarro.EditIndex = -1;
            lbAlerta.Text = "";
            Refrescar();
            CalcularTotales();
        }

        protected void gridCarro_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                List<Producto> listadoproducto = (List<Producto>)Session["carro"];
                GridViewRow filaeditada = gridCarro.Rows[e.RowIndex];
                int nuevaCantidad;
                if (int.TryParse(e.NewValues[0].ToString(), out nuevaCantidad))
                {
                    if (listadoproducto[e.RowIndex].Stock < nuevaCantidad)
                    {
                        lbAlerta.Text = "No puede ingresar una cantidad mayor al stock actual del producto.";
                        e.Cancel = true;
                    }
                    else if (nuevaCantidad <= 0)
                    {
                        lbAlerta.Text = "No puede ingresar una cantidad menor o igual a cero.";
                        e.Cancel = true;
                    }
                    else
                    {
                        lbAlerta.Text = "";
                        listadoproducto[e.RowIndex].Cantidad = nuevaCantidad;

                        Session["carro"] = listadoproducto;
                        gridCarro.EditIndex = -1;
                        Refrescar();
                        CalcularTotales();
                    }
                }
                else
                {
                    lbAlerta.Text = "El valor ingresado no es v&aacute;lido.";
                    e.Cancel = true;
                }

            }
            catch (Exception)
            {
                lbAlerta.Text = "No puede ingresar un valor vac&iacute;o.";
                e.Cancel = true;

            }
        }

        protected void gridCarro_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
            {
                string precio = e.Row.Cells[3].Text;
                string cantidad = e.Row.Cells[4].Text;
                int esnumero, esnumero2;
                if (int.TryParse(precio,out esnumero) && int.TryParse(cantidad, out esnumero2))
                {
                    int total = int.Parse(precio) * int.Parse(cantidad);
                    e.Row.Cells[5].Text = "$ " + total;
                    e.Row.Cells[3].Text = "$ " + e.Row.Cells[3].Text;
                }
            }
        }

        protected void gridCarro_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Producto> listadoproducto = (List<Producto>)Session["carro"];
            listadoproducto.RemoveAt(e.RowIndex);
            if (listadoproducto.Count == 0)
            {
                HttpContext.Current.Session.Remove("carro");
                lbCantidadCarro.Text = "0";
                lbTotal.Text = "0";
                lbIva.Text = "0";
                lbNeto.Text = "0";
                panelCarroVacio.Visible = true;
                panelVerCarro.Visible = false;
            }
            else
            {
                Session["carro"] = listadoproducto;
                lbCantidadCarro.Text = listadoproducto.Count.ToString();
            }
            gridCarro.EditIndex = -1;
            Refrescar();
            CalcularTotales();

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
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            Server.Transfer("clprocesar.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Remove("carro");
            Response.Redirect("index-cliente.aspx");
        }
    }
}