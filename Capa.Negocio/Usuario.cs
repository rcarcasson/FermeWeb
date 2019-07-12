using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;
namespace Capa.Negocio
{
    public class Usuario
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

        private string _mail;

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        private string _cargo;

        public string Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        private string _rubro;

        public string Rubro
        {
            get { return _rubro; }
            set { _rubro = value; }
        }

        private char _tipoUsuario;

        public char TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }

        private char _tipoCliente;

        public char TipoCliente
        {
            get { return _tipoCliente; }
            set { _tipoCliente = value; }
        }

        public Usuario()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            Rut = string.Empty;
            Nombre= string.Empty; ;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Mail = string.Empty;
            Cargo = string.Empty;
            Rubro = string.Empty;
            TipoUsuario = ' ';
            TipoCliente = ' ';
        }

        public bool Create()
        {
            try
            {
                USUARIO usuario = new USUARIO();
                usuario.ID = this.Id;
                usuario.RUT = this.Rut;
                usuario.NOMBRE = this.Nombre;
                usuario.DIRECCION = this.Direccion;
                usuario.TELEFONO = this.Telefono;
                usuario.MAIL = this.Mail;
                usuario.CARGO = this.Cargo;
                usuario.TIPO_CLIENTE =char.ToString(this.TipoCliente);
                usuario.TIPO_USUARIO = char.ToString(this.TipoUsuario);

                CommonBC.DBConexion.USUARIO.Add(usuario);
                CommonBC.DBConexion.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdatePorCliente()
        {
            try
            {
                USUARIO usuario = CommonBC.DBConexion.USUARIO.First(b => b.ID == this.Id);
                usuario.RUT = this.Rut;
                usuario.NOMBRE = this.Nombre;
                usuario.DIRECCION = this.Direccion;
                usuario.TELEFONO = this.Telefono;
                usuario.MAIL = this.Mail;

                CommonBC.DBConexion.SaveChanges();
                return true;
            }
            catch (Exception err)
            {

                return false;
            }
        }
        public bool Delete()
        {
            try
            {
                USUARIO usuario = CommonBC.DBConexion.USUARIO.First(b => b.ID == this.Id);
                CommonBC.DBConexion.USUARIO.Remove(usuario);
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
                USUARIO usuario = CommonBC.DBConexion.USUARIO.First(b => b.RUT == this.Rut );
                this.Rut = usuario.RUT;
                this.Nombre = usuario.NOMBRE;
                this.Direccion = usuario.DIRECCION;
                this.Telefono = usuario.TELEFONO;
                this.Mail = usuario.MAIL;
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool ObtenerUsuario(int id)
        {
            try
            {
                Datos.USUARIO us = CommonBC.DBConexion.USUARIO.First(b => b.ID == id);
                this.Id = (int)us.ID;
                this.Rut = us.RUT;
                this.Nombre = us.NOMBRE;
                this.Direccion = us.DIRECCION;
                this.Mail = us.MAIL;
                this.Telefono = us.TELEFONO;
                this.TipoCliente = char.Parse(us.TIPO_CLIENTE);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public String ObtenerNombrePorId(int id)
        {
            try
            {
                Datos.USUARIO us = CommonBC.DBConexion.USUARIO.First(b => b.ID == id);
                return us.NOMBRE;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public List<Usuario> ObtenerIDVendedores()
        {
            try
            {
                List<Usuario> listavendedores = new List<Usuario>();
                List<Datos.USUARIO> usuarios = CommonBC.DBConexion.USUARIO.Where(b => b.TIPO_USUARIO.Equals("V")).ToList();
                foreach(USUARIO temp in usuarios)
                {
                    Usuario u = new Usuario();
                    u.Id = (int)temp.ID;
                    listavendedores.Add(u);
                }
                return listavendedores;
            }
            catch (Exception err)
            {
                return new List<Usuario>();
            }
        }

    }
}
