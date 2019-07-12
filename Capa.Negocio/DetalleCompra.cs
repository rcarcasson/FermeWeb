using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio
{
    public class DetalleCompra
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
        private int _compraId;

        public int CompraId
        {
            get { return _compraId; }
            set { _compraId = value; }
        }
        private int _productoId;

        public int ProductoId
        {
            get { return _productoId; }
            set { _productoId = value; }
        }
        private char _aceptada;

        public char Aceptada
        {
            get { return _aceptada; }
            set { _aceptada = value; }
        }
        private string _observacion;

        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }

        public DetalleCompra()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            Cantidad = 0;
            CompraId = 0;
            ProductoId = 0;
            Aceptada = ' ';
            Observacion = string.Empty;
        }
        public bool Create()
        {
            try
            {
                DETALLE_COMPRA dc = new DETALLE_COMPRA();
                dc.ID = this.Id;
                dc.CANTIDAD = this.Cantidad;
                dc.COMPRA_ID = this.CompraId;
                dc.PRODUCTO_ID = this.ProductoId;
                dc.ACEPTADA = char.ToString(this.Aceptada);
                dc.OBSERVACION = this.Observacion;
                CommonBC.DBConexion.DETALLE_COMPRA.Add(dc);
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
                DETALLE_COMPRA dc = CommonBC.DBConexion.DETALLE_COMPRA.First(d => d.ID == this.Id);
                dc.CANTIDAD = this.Cantidad;
                dc.COMPRA_ID = this.CompraId;
                dc.PRODUCTO_ID = this.ProductoId;
                dc.ACEPTADA = char.ToString(this.Aceptada);
                dc.OBSERVACION = this.Observacion;
                CommonBC.DBConexion.Entry(dc).State = System.Data.EntityState.Modified;
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
                DETALLE_COMPRA dc = CommonBC.DBConexion.DETALLE_COMPRA.First(d => d.ID == this.Id);
                CommonBC.DBConexion.DETALLE_COMPRA.Remove(dc);
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
                DETALLE_COMPRA dc = CommonBC.DBConexion.DETALLE_COMPRA.First(d => d.ID == this.Id);
                
                this.Cantidad = (int)dc.CANTIDAD;
                this.CompraId = (int)dc.COMPRA_ID;
                this.ProductoId = (int)dc.PRODUCTO_ID;
                this.Aceptada= char.Parse(dc.ACEPTADA);
                this.Observacion = dc.OBSERVACION;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
