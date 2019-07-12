using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio
{
    public class Producto
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _idProducto;

        public string IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private int _precio;

        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        private int _cantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        private int _stock;

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
        private int _stockCritico;

        public int StockCritico
        {
            get { return _stockCritico; }
            set { _stockCritico = value; }
        }
        private int _tipoProductoId;

        public int TipoProducId
        {
            get { return _tipoProductoId; }
            set { _tipoProductoId = value; }
        }

        public Producto()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            IdProducto = string.Empty;
            Descripcion = string.Empty;
            Precio = 0;
            Cantidad = 0;
            Stock = 0;
            StockCritico = 0;
            TipoProducId = 0;
        }
        public bool Create()
        {
            try
            {
                PRODUCTO producto = new PRODUCTO();
                producto.ID = this.Id;
                producto.ID_PRODUCTO = this.IdProducto;
                producto.DESCRIPCION = this.Descripcion;
                producto.PRECIO = this.Precio;
                producto.STOCK = this.Stock;
                producto.STOCK_CRITICO = this.StockCritico;
                producto.TIPO_PRODUCTO_ID = this.TipoProducId;

                CommonBC.DBConexion.PRODUCTO.Add(producto);
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
                PRODUCTO producto = CommonBC.DBConexion.PRODUCTO.First(p => p.ID == this.Id);
                producto.ID_PRODUCTO = this.IdProducto;
                producto.DESCRIPCION = this.Descripcion;
                producto.PRECIO = this.Precio;
                producto.STOCK = this.Stock;
                producto.STOCK_CRITICO = this.StockCritico;
                producto.TIPO_PRODUCTO_ID = this.TipoProducId;

                CommonBC.DBConexion.Entry(producto).State = System.Data.EntityState.Modified;
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
                PRODUCTO producto = CommonBC.DBConexion.PRODUCTO.First(p => p.ID == this.Id);
                CommonBC.DBConexion.PRODUCTO.Remove(producto);
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
                PRODUCTO producto = CommonBC.DBConexion.PRODUCTO.First(p => p.ID == this.Id);
                this.IdProducto = producto.ID_PRODUCTO;
                this.Descripcion = producto.DESCRIPCION;
                this.Precio = (int)producto.PRECIO;
                this.Stock = (int)producto.STOCK;
                this.StockCritico = (int)producto.STOCK_CRITICO;
                this.TipoProducId = (int)producto.TIPO_PRODUCTO_ID;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<Producto> ListadoPorProducto(int i)
        {
            try
            {
                var query = (from tipoproducto in CommonBC.DBConexion.TIPO_PRODUCTO
                             join producto in CommonBC.DBConexion.PRODUCTO on tipoproducto.FAMILIA_PRODUCTO_ID equals i
                             where producto.TIPO_PRODUCTO_ID == tipoproducto.ID
                             select new
                             {
                                 producto.ID,
                                 producto.ID_PRODUCTO,
                                 producto.DESCRIPCION,
                                 producto.PRECIO,
                                 producto.STOCK,
                                 producto.STOCK_CRITICO,
                                 producto.TIPO_PRODUCTO_ID
                             }).ToList();
                List<Producto> productolist = new List<Producto>();
                foreach (var temp in query)
                {
                    Producto _producto = new Producto();
                    _producto.Id = (int) temp.ID;
                    _producto.IdProducto = temp.ID_PRODUCTO;
                    _producto.Descripcion = temp.DESCRIPCION;
                    _producto.Precio = (int)temp.PRECIO;
                    _producto.Stock = (int)temp.STOCK;
                    _producto.StockCritico = (int)temp.STOCK_CRITICO;
                    _producto.TipoProducId = (int)temp.TIPO_PRODUCTO_ID;
                    productolist.Add(_producto);

                }
                return productolist;

            }
            catch (Exception)
            {

                return new List<Producto>();
            }
        }
        
    }
}
