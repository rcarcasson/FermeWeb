using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio
{
    public class LogPrecio
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private int _precioAntiguo;

        public int PrecioAntiguo
        {
            get { return _precioAntiguo; }
            set { _precioAntiguo = value; }
        }
        private int _precioNuevo;

        public int PrecioNuevo
        {
            get { return _precioNuevo; }
            set { _precioNuevo = value; }
        }
        
        public LogPrecio()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            Fecha = DateTime.Now;
            PrecioAntiguo = 0;
            PrecioNuevo = 0;
        }
        public bool Create()
        {
            try
            {
                LOG_PRECIO log = new LOG_PRECIO();
                log.ID = this.Id;
                log.FECHA = this.Fecha;
                log.PRECIO_ANTIGUO = this.PrecioAntiguo;
                log.PRECIO_NUEVO = this.PrecioNuevo;
                CommonBC.DBConexion.LOG_PRECIO.Add(log);
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
                LOG_PRECIO log = CommonBC.DBConexion.LOG_PRECIO.First(l => l.ID == this.Id);
                log.FECHA = this.Fecha;
                log.PRECIO_ANTIGUO = this.PrecioAntiguo;
                log.PRECIO_NUEVO = this.PrecioNuevo;
                CommonBC.DBConexion.Entry(log).State = System.Data.EntityState.Modified;
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
                LOG_PRECIO log = CommonBC.DBConexion.LOG_PRECIO.First(l => l.ID == this.Id);
                CommonBC.DBConexion.LOG_PRECIO.Remove(log);
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
                LOG_PRECIO log = CommonBC.DBConexion.LOG_PRECIO.First(l => l.ID == this.Id);
                this.Fecha = log.FECHA;
                this.PrecioAntiguo = (int)log.PRECIO_ANTIGUO;
                this.PrecioNuevo = (int)log.PRECIO_NUEVO;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
