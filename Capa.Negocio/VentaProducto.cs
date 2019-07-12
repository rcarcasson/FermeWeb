using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Negocio
{
    public class VentaProducto
    {
        public string CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public int PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public VentaProducto()
        {
            this.Void();
        }

        private void Void()
        {
            CodigoProducto = string.Empty;
            Descripcion = string.Empty;
            PrecioUnitario = 0;
            Cantidad = 0;
        }

        public List<VentaProducto> ObtenerDetalleVenta(int id)
        {
            try
            {
                var query = (from detalleventa in CommonBC.DBConexion.DETALLE_VENTA
                             join producto in CommonBC.DBConexion.PRODUCTO on detalleventa.VENTA_ID equals id
                             where producto.ID == detalleventa.PRODUCTO_ID
                             select new
                             {
                                 producto.ID_PRODUCTO,
                                 producto.DESCRIPCION,
                                 detalleventa.PRECIO,
                                 detalleventa.CANTIDAD
                             }).ToList();
                List<VentaProducto> ventaprod = new List<VentaProducto>();
                foreach (var temp in query)
                {
                    VentaProducto _ventaprod = new VentaProducto();
                    _ventaprod.CodigoProducto = temp.ID_PRODUCTO;
                    _ventaprod.Descripcion = temp.DESCRIPCION;
                    _ventaprod.PrecioUnitario = (int)temp.PRECIO;
                    _ventaprod.Cantidad = (int)temp.CANTIDAD;
                    ventaprod.Add(_ventaprod);
                }
                return ventaprod;
            }
            catch (Exception)
            {
                return new List<VentaProducto>();
            }
        }
    }
}
