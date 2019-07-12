using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio
{
    public class FamiliaProducto
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _idFamilia;

        public string IdFamilia
        {
            get { return _idFamilia; }
            set { _idFamilia = value; }
        }
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public FamiliaProducto()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            IdFamilia = string.Empty;
            Descripcion = string.Empty;
        }
        public bool Create()
        {
            try
            {
                FAMILIA_PRODUCTO fp = new FAMILIA_PRODUCTO();
                fp.ID = this.Id;
                fp.ID_FAMILIA = this.IdFamilia;
                fp.DESCRIPCION = this.Descripcion;
                CommonBC.DBConexion.FAMILIA_PRODUCTO.Add(fp);
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
                FAMILIA_PRODUCTO fp = CommonBC.DBConexion.FAMILIA_PRODUCTO.First(f => f.ID == this.Id);
                fp.ID_FAMILIA = this.IdFamilia;
                fp.DESCRIPCION = this.Descripcion;
                CommonBC.DBConexion.Entry(fp).State = System.Data.EntityState.Modified;
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
                FAMILIA_PRODUCTO fp = CommonBC.DBConexion.FAMILIA_PRODUCTO.First(f => f.ID == this.Id);
                CommonBC.DBConexion.FAMILIA_PRODUCTO.Remove(fp);
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
                FAMILIA_PRODUCTO fp = CommonBC.DBConexion.FAMILIA_PRODUCTO.First(f => f.ID == this.Id);
                this.IdFamilia = fp.ID_FAMILIA;
                this.Descripcion = fp.DESCRIPCION;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<FamiliaProducto> Listado()
        {
            try
            {

                List<FAMILIA_PRODUCTO> familia_producto = CommonBC.DBConexion.FAMILIA_PRODUCTO.ToList();
                List<FamiliaProducto> familia = new List<FamiliaProducto>();
                foreach (FAMILIA_PRODUCTO temp in familia_producto)
                {
                    FamiliaProducto _familia = new FamiliaProducto();
                    _familia.Id = (int)temp.ID;
                    _familia.Descripcion = temp.DESCRIPCION;
                    familia.Add(_familia);

                }
                return familia;
            }
            catch (Exception)
            {

                return new List<FamiliaProducto>();
            }
            

        }
    }
}
