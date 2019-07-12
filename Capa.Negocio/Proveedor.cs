using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio
{
    public class Proveedor
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _rut;

        public string Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _telefono;

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _rubro;

        public string Rubro
        {
            get { return _rubro; }
            set { _rubro = value; }
        }

        private string _mail;

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public Proveedor()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            Rut = string.Empty;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Rubro = string.Empty;
            Mail = string.Empty;

        }

        public bool Create()
        {
            try
            {
                PROVEEDOR proveedor = new PROVEEDOR();
                proveedor.ID = this.Id;
                proveedor.RUT = this.Rut;
                proveedor.NOMBRE = this.Nombre;
                proveedor.DIRECCION = this.Direccion;
                proveedor.TELEFONO = this.Telefono;
                proveedor.RUBRO = this.Rubro;
                proveedor.MAIL = this.Mail;

                CommonBC.DBConexion.PROVEEDOR.Add(proveedor);
                CommonBC.DBConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public string ObtenerNombrePorId(int id)
        {
            try
            {
                PROVEEDOR pr = CommonBC.DBConexion.PROVEEDOR.First(b => b.ID == id);
                return pr.NOMBRE;
            }catch (Exception)
            {
                return "";
            }
        }

        public bool Update()
        {
            try
            {

                PROVEEDOR proveedor = CommonBC.DBConexion.PROVEEDOR.First(b => b.ID == this.Id);
                proveedor.RUT = this.Rut;
                proveedor.NOMBRE = this.Nombre;
                proveedor.DIRECCION = this.Direccion;
                proveedor.TELEFONO = this.Telefono;
                proveedor.RUBRO = this.Rubro;
                proveedor.MAIL = this.Mail;

                CommonBC.DBConexion.Entry(proveedor).State = System.Data.EntityState.Modified;
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
                PROVEEDOR proveedor = CommonBC.DBConexion.PROVEEDOR.First(b => b.ID == this.Id);
                CommonBC.DBConexion.PROVEEDOR.Remove(proveedor);
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
                PROVEEDOR proveedor = CommonBC.DBConexion.PROVEEDOR.First(b => b.ID == this.Id);
                this.Rut = proveedor.RUT;
                this.Nombre = proveedor.NOMBRE;
                this.Direccion = proveedor.DIRECCION;
                this.Telefono = proveedor.TELEFONO;
                this.Rubro = proveedor.RUBRO;
                this.Mail = proveedor.MAIL;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
