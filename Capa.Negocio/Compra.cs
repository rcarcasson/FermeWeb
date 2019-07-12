using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio
{
    public class Compra
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _numOrden;

        public int NumOrden
        {
            get { return _numOrden; }
            set { _numOrden = value; }
        }
        private DateTime _fechaDocumento;

        public DateTime FechaDocumento
        {
            get { return _fechaDocumento; }
            set { _fechaDocumento = value; }
        }
        private char _recepcionado;

        public char Recepcionado
        {
            get { return _recepcionado; }
            set { _recepcionado = value; }
        }
        private int _proveedorId;

        public int ProveedorId
        {
            get { return _proveedorId; }
            set { _proveedorId = value; }
        }

        public Compra()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            NumOrden = 0;
            FechaDocumento = DateTime.Now;
            Recepcionado = ' ';
            ProveedorId = 0;
        }
        public bool Create()
        {
            try
            {
                COMPRA compra = new COMPRA();
                compra.ID = this.Id;
                compra.NUM_ORDEN = this.NumOrden;
                compra.FECHA_DOCUMENTO = this.FechaDocumento;
                compra.RECEPCIONADO = char.ToString(this.Recepcionado);
                compra.PROVEEDOR_ID = this.ProveedorId;
                CommonBC.DBConexion.COMPRA.Add(compra);
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
                COMPRA compra = CommonBC.DBConexion.COMPRA.First(c => c.ID == this.Id);
                compra.NUM_ORDEN = this.NumOrden;
                compra.FECHA_DOCUMENTO = this.FechaDocumento;
                compra.RECEPCIONADO = char.ToString(this.Recepcionado);
                compra.PROVEEDOR_ID = this.ProveedorId;
                CommonBC.DBConexion.Entry(compra).State = System.Data.EntityState.Modified;

                CommonBC.DBConexion.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Compra> ObtenerOrdenesProveedor(int id)
        {
            try
            {
                List<Compra> lista = new List<Compra>();
                List<COMPRA> compras = CommonBC.DBConexion.COMPRA.Where(b => b.PROVEEDOR_ID == id).ToList();

                foreach(COMPRA temp in compras)
                {
                    Compra c = new Compra();
                    c.Id = (int)temp.ID;
                    c.FechaDocumento = temp.FECHA_DOCUMENTO;
                    c.NumOrden = (int)temp.NUM_ORDEN;
                    c.Recepcionado = char.Parse(temp.RECEPCIONADO);
                    lista.Add(c);
                        
                }
                return lista;
            }
            catch (Exception)
            {
                return new List<Compra>();
            }
        }
        public bool Delete()
        {
            try
            {
                COMPRA compra = CommonBC.DBConexion.COMPRA.First(c => c.ID == this.Id);
                CommonBC.DBConexion.COMPRA.Remove(compra);
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
                COMPRA compra = CommonBC.DBConexion.COMPRA.First(c => c.ID == this.Id);
                this.NumOrden = (int)compra.NUM_ORDEN;
                this.FechaDocumento = compra.FECHA_DOCUMENTO;
                this.Recepcionado = char.Parse(compra.RECEPCIONADO);
                this.ProveedorId = (int)compra.PROVEEDOR_ID;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
