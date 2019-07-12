using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio
{
    public class DetalleVenta
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _cantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        private int _total;

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }
        private int _ventaId;

        public int VentaId
        {
            get { return _ventaId; }
            set { _ventaId = value; }
        }
        private int _productoId;

        public int ProductoId
        {
            get { return _productoId; }
            set { _productoId = value; }
        }
        private int _precio;

        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public DetalleVenta()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            Cantidad = 0;
            Total = 0;
            VentaId = 0;
            ProductoId = 0;
            Precio = 0;
        }



        public bool CrearDetalleVenta()
        {
            try
            {
                DETALLE_VENTA dv = new DETALLE_VENTA();
                dv.CANTIDAD = this.Cantidad;
                dv.VENTA_ID = this.VentaId;
                dv.PRODUCTO_ID = this.ProductoId;
                dv.PRECIO = this.Precio;

                CommonBC.DBConexion.DETALLE_VENTA.Add(dv);
                CommonBC.DBConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Update()
        {
            try
            {
                DETALLE_VENTA dv = CommonBC.DBConexion.DETALLE_VENTA.First(d => d.ID == this.Id);
                dv.CANTIDAD = this.Cantidad;
                dv.VENTA_ID = this.VentaId;
                dv.PRODUCTO_ID = this.ProductoId;
                dv.PRECIO = this.Precio;

                CommonBC.DBConexion.Entry(dv).State = System.Data.EntityState.Modified;
                CommonBC.DBConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete()
        {
            try
            {
                DETALLE_VENTA dv = CommonBC.DBConexion.DETALLE_VENTA.First(d => d.ID == this.Id);
                CommonBC.DBConexion.DETALLE_VENTA.Remove(dv);
                CommonBC.DBConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Read()
        {
            try
            {
                DETALLE_VENTA dv = CommonBC.DBConexion.DETALLE_VENTA.First(d => d.ID == this.Id);
                this.Cantidad = (int)dv.CANTIDAD;
                this.VentaId = (int)dv.VENTA_ID;
                this.ProductoId = (int)dv.PRODUCTO_ID;
                this.Precio = (int)dv.PRECIO;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
