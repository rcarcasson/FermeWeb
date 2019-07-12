using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio
{
    public class Visita
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

        private string _usuario;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public Visita()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            Fecha = DateTime.Now;
            Usuario = string.Empty;
        }
        public bool GuardarVisita()
        {
            try
            {
                VISITA visita = new VISITA();
                visita.ID = this.Id;
                visita.USUARIO = this.Usuario;
                CommonBC.DBConexion.VISITA.Add(visita);
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
                VISITA visita = CommonBC.DBConexion.VISITA.First(v => v.ID == this.Id);
                visita.FECHA = this.Fecha;
                visita.USUARIO = this.Usuario;
                CommonBC.DBConexion.Entry(visita).State = System.Data.EntityState.Modified;
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
                VISITA visita = CommonBC.DBConexion.VISITA.First(v => v.ID == this.Id);
                CommonBC.DBConexion.VISITA.Remove(visita);
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
                VISITA visita = CommonBC.DBConexion.VISITA.First(v => v.ID == this.Id);
                this.Fecha =(DateTime) visita.FECHA;
                this.Usuario = visita.USUARIO;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
