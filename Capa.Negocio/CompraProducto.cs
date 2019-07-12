using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Negocio
{
    public class CompraProducto
    {
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }

        public CompraProducto()
        {
            this.Void();
        }

        private void Void()
        {
            ProductoId = string.Empty;
            Descripcion = string.Empty;
            Cantidad = 0;
            Observacion = string.Empty;
        }

        public List<CompraProducto> ObtenerDetalleCompra(int id)
        {
            try
            {
                var query = (from detallecompra in CommonBC.DBConexion.DETALLE_COMPRA
                             join producto in CommonBC.DBConexion.PRODUCTO on detallecompra.COMPRA_ID equals id
                             where producto.ID == detallecompra.PRODUCTO_ID
                             select new
                             {
                                 producto.ID_PRODUCTO,
                                 producto.DESCRIPCION,
                                 detallecompra.CANTIDAD,
                                 detallecompra.OBSERVACION

                             }).ToList();
                List<CompraProducto> compraprod = new List<CompraProducto>();
                foreach (var temp in query)
                {
                    CompraProducto cp = new CompraProducto();
                    cp.ProductoId = temp.ID_PRODUCTO;
                    cp.Descripcion = temp.DESCRIPCION;
                    cp.Cantidad = (int)temp.CANTIDAD;
                    if (temp.OBSERVACION == null)
                    {
                        cp.Observacion = string.Empty;
                    }else
                    {
                        cp.Observacion = temp.OBSERVACION;
                    }
                    compraprod.Add(cp);
                }
                return compraprod;
            }
            catch (Exception)
            {
                return new List<CompraProducto>();
            }
        }
    }
}
