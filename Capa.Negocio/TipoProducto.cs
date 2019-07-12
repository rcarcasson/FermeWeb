using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio
{
    public class TipoProducto
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _secuencia;

        public int Secuencia
        {
            get { return _secuencia; }
            set { _secuencia = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private int _familiaProductoId;

        public int FamiliaProductoId
        {
            get { return _familiaProductoId; }
            set { _familiaProductoId = value; }
        }
        public TipoProducto()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            Secuencia = 0;
            Descripcion = string.Empty;
            FamiliaProductoId = 0;

        }

        public bool Create()
        {
            try
            {
                TIPO_PRODUCTO tproducto = new TIPO_PRODUCTO();
                tproducto.ID = this.Id;
                tproducto.SECUENCIA = this.Secuencia;
                tproducto.DESCRIPCION = this.Descripcion;
                tproducto.FAMILIA_PRODUCTO_ID = this.FamiliaProductoId;
                CommonBC.DBConexion.TIPO_PRODUCTO.Add(tproducto);
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
                TIPO_PRODUCTO tproducto = CommonBC.DBConexion.TIPO_PRODUCTO.First(tp => tp.ID == this.Id);
                tproducto.SECUENCIA = this.Secuencia;
                tproducto.DESCRIPCION = this.Descripcion;
                tproducto.FAMILIA_PRODUCTO_ID = this.FamiliaProductoId;
                CommonBC.DBConexion.Entry(tproducto).State = System.Data.EntityState.Modified;
                CommonBC.DBConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }public bool Delete()
        {
            try
            {
                TIPO_PRODUCTO tproducto = CommonBC.DBConexion.TIPO_PRODUCTO.First(tp => tp.ID == this.Id);
                CommonBC.DBConexion.TIPO_PRODUCTO.Remove(tproducto);
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
                TIPO_PRODUCTO tproducto = CommonBC.DBConexion.TIPO_PRODUCTO.First(tp => tp.ID == this.Id);
                this.Secuencia = (int)tproducto.SECUENCIA;
                this.Descripcion = tproducto.DESCRIPCION;
                this.FamiliaProductoId = (int)tproducto.FAMILIA_PRODUCTO_ID;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<TipoProducto> ObtenerTipos(int id)
        {
            try
            {
                List<TIPO_PRODUCTO> tipo = CommonBC.DBConexion.TIPO_PRODUCTO.Where(b => b.FAMILIA_PRODUCTO_ID==id).ToList();
                List<TipoProducto> tp = new List<TipoProducto>();                
                foreach (TIPO_PRODUCTO tem in tipo)
                {
                    TipoProducto _tp = new TipoProducto();
                    _tp.Id = (int)tem.ID;
                    _tp.Descripcion = tem.DESCRIPCION;
                    _tp.FamiliaProductoId = (int)tem.FAMILIA_PRODUCTO_ID;

                    tp.Add(_tp);
                }

                return tp; 
            }
            catch (Exception)
            {

                throw;
            }

        }

       
    }
}
