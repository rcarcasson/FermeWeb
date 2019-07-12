
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio
{
    public class Configuracion
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _empresa;

        public string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }
        private string _rut;

        public string Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }
        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        private string _correo;

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        private char _moneda;

        public char Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        public Configuracion()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            Rut = string.Empty;
            Empresa = string.Empty;
            Direccion = string.Empty;
            Correo = string.Empty;
            Moneda = ' ';
        }
        public bool Create()
        {
            try
            {
                CONFIGURACION conf = new CONFIGURACION();
                conf.ID = this.Id;
                conf.RUT = this.Rut;
                conf.EMPRESA = this.Empresa;
                conf.DIRECCION = this.Direccion;
                conf.CORREO = this.Correo;
                conf.MONEDA = char.ToString(this.Moneda);
                CommonBC.DBConexion.CONFIGURACION.Add(conf);
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
                CONFIGURACION conf = CommonBC.DBConexion.CONFIGURACION.First(co => co.ID == this.Id);
                conf.RUT = this.Rut;
                conf.EMPRESA = this.Empresa;
                conf.DIRECCION = this.Direccion;
                conf.CORREO = this.Correo;
                conf.MONEDA = char.ToString(this.Moneda);
                CommonBC.DBConexion.Entry(conf).State = System.Data.EntityState.Modified;
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
                CONFIGURACION conf = CommonBC.DBConexion.CONFIGURACION.First(co => co.ID == this.Id);

                CommonBC.DBConexion.CONFIGURACION.Remove(conf);
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
                CONFIGURACION conf = CommonBC.DBConexion.CONFIGURACION.First(co => co.ID == this.Id);
                this.Rut = conf.RUT;
                this.Empresa = conf.EMPRESA;
                this.Direccion = conf.DIRECCION;
                this.Correo = conf.CORREO;
                this.Moneda= char.Parse(conf.MONEDA);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
