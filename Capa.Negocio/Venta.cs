using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio
{
    public class Venta
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private char _tipoDocumento;

        public char TipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }

        private int _numDocumento;

        public int NumDocumento
        {
            get { return _numDocumento; }
            set { _numDocumento = value; }
        }

        private DateTime _fechaDocumento;

        public DateTime FechaDocumento
        {
            get { return _fechaDocumento; }
            set { _fechaDocumento = value; }
        }

        private int _idCliente;

        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        private int _total;

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private int _usuarioId;

        public int UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        public Venta()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            TipoDocumento = ' ';
            NumDocumento = 0;
            FechaDocumento = DateTime.Now;
            IdCliente = 0;
            Total = 0;
            UsuarioId = 0;
        }

        public int NuevoDocumentoBoleta()
        {
            int total = 0;
            try
            {
                total = CommonBC.DBConexion.VENTA.Count(b => b.TIPO_DOCUMENTO.Equals("B"));
                return total;
            }
            catch (Exception err)
            {
                return total;
            }
        }

        public int NuevoDocumentoFactura()
        {
            int total = 0;
            try
            {
                total = CommonBC.DBConexion.VENTA.Count(b => b.TIPO_DOCUMENTO.Equals("F"));
                return total;
            }
            catch (Exception)
            {
                return total;
            }
        }


        public bool CrearVentaOnline()
        {
            try
            {
                Datos.VENTA venta = new Datos.VENTA();
                venta.TIPO_DOCUMENTO = char.ToString(this.TipoDocumento);
                venta.NUM_DOCUMENTO = (int)this.NumDocumento;
                venta.FECHA_DOCUMENTO = this.FechaDocumento;
                venta.ID_CLIENTE = this.IdCliente;
                venta.TOTAL = (int)this.Total;
                venta.USUARIO_ID = (int)this.UsuarioId;
                CommonBC.DBConexion.VENTA.Add(venta);
                CommonBC.DBConexion.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
        public bool Update()
        {
            try
            {
                VENTA venta = CommonBC.DBConexion.VENTA.First(v => v.ID == this.Id);
                venta.TIPO_DOCUMENTO = char.ToString(this.TipoDocumento);
                venta.NUM_DOCUMENTO = this.NumDocumento;
                venta.ID_CLIENTE = this.IdCliente;
                venta.TOTAL = this.Total;
                venta.USUARIO_ID = this.UsuarioId;
                CommonBC.DBConexion.Entry(venta).State = System.Data.EntityState.Modified;
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
                VENTA venta = CommonBC.DBConexion.VENTA.First(v => v.ID == this.Id);
                CommonBC.DBConexion.VENTA.Remove(venta);
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
                VENTA venta = CommonBC.DBConexion.VENTA.First(v => v.ID == this.Id);
                this.TipoDocumento =char.Parse( venta.TIPO_DOCUMENTO);
                this.NumDocumento =(int) venta.NUM_DOCUMENTO;
                this.IdCliente = (int)venta.ID_CLIENTE;
                this.Total = (int)venta.TOTAL;
                this.UsuarioId = (int)venta.USUARIO_ID;

                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public List<Venta> ObtenerOrdenesdeCliente(int idusuario)
        {
            try
            {
                List<Venta> ventas = new List<Venta>();
                List<VENTA> v = CommonBC.DBConexion.VENTA.Where(b => b.ID_CLIENTE == idusuario).ToList();
                foreach (VENTA temp in v)
                {
                    Venta venta = new Venta();
                    venta.Id = (int)temp.ID;
                    venta.NumDocumento = (int)temp.NUM_DOCUMENTO;
                    venta.FechaDocumento = temp.FECHA_DOCUMENTO;
                    venta.Total = (int)temp.TOTAL;
                    ventas.Add(venta);
                }
                return ventas;
            }
            catch (Exception)
            {
                return new List<Venta>();
            }
        }

        public int ObtenerUltimoID()
        {
            try
            {
               Datos.VENTA v = CommonBC.DBConexion.VENTA.OrderByDescending(b => b.ID).FirstOrDefault();
                return (int)v.ID;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
