using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;
using System.Security.Cryptography;

namespace Capa.Negocio
{
    public class Acceso
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _usuario;
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _clave;
        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        private string _pregunta;
        public string Pregunta
        {
            get { return _pregunta; }
            set { _pregunta = value; }
        }

        private string _respuesta;
        public string Respuesta
        {
            get { return _respuesta; }
            set { _respuesta = value; }
        }

        private int _usuarioId;
        public int UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        private int _proveedorId;
        public int ProveedorId
        {
            get { return _proveedorId; }
            set { _proveedorId = value; }
        }
        public Acceso()
        {
            Init();
        }

        private void Init()
        {

            ID = 0;
            Usuario = string.Empty;
            Clave = string.Empty;
            Pregunta = string.Empty;
            Respuesta = string.Empty;
            UsuarioId = 0;
            ProveedorId = 0;

        }
        public bool Login()
        {
            try
            {
                Datos.ACCESO ac = CommonBC.DBConexion.ACCESO.First(b => b.USUARIO.ToUpper().Equals(this.Usuario.ToUpper()) && b.CLAVE.Equals(this.Clave));
                this.ID = int.Parse(ac.ID.ToString());
                this.Usuario = ac.USUARIO;                
                if (ac.USUARIO_ID != null)
                {
                    this.UsuarioId = int.Parse(ac.USUARIO_ID.ToString());
                    this.ProveedorId = 0;
                }else
                {
                    this.ProveedorId = int.Parse(ac.PROVEEDOR_ID.ToString());
                    this.UsuarioId = 0;
                }
                return true;
            }
            catch (Exception err)
            {

                return false;
            }
        }

        public bool Agregar()
        {
            try
            {
                Datos.ACCESO ac = new ACCESO();
                ac.ID = this.ID;
                ac.USUARIO = this.Usuario;
                ac.CLAVE = this.Clave;
                ac.PREGUNTA = this.Pregunta;
                ac.RESPUESTA = this.Respuesta;
                ac.USUARIO_ID = this.UsuarioId;
                ac.PROVEEDOR_ID = this.ProveedorId;
                CommonBC.DBConexion.ACCESO.Add(ac);
                CommonBC.DBConexion.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarMailPorProveedor()
        {
            try
            {
                Datos.ACCESO ac = CommonBC.DBConexion.ACCESO.First(b => b.PROVEEDOR_ID == this.ProveedorId);
                ac.USUARIO = this.Usuario;
                CommonBC.DBConexion.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarMailPorCliente()
        {
            try
            {
                Datos.ACCESO ac = CommonBC.DBConexion.ACCESO.First(b => b.USUARIO_ID == this.UsuarioId);
                ac.USUARIO = this.Usuario;
                CommonBC.DBConexion.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ActualizarPreguntaRespuestaProveedor()
        {
            try
            {
                ACCESO ac = CommonBC.DBConexion.ACCESO.First(b => b.PROVEEDOR_ID == this.ProveedorId);
                ac.PREGUNTA = this.Pregunta;
                ac.RESPUESTA = this.Respuesta;
                CommonBC.DBConexion.Entry(ac).State = System.Data.EntityState.Modified;
                CommonBC.DBConexion.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarPreguntaRespuesta()
        {
            try
            {
                ACCESO ac = CommonBC.DBConexion.ACCESO.First(b => b.USUARIO_ID == this.UsuarioId);
                ac.PREGUNTA = this.Pregunta;
                ac.RESPUESTA = this.Respuesta;
                CommonBC.DBConexion.Entry(ac).State = System.Data.EntityState.Modified;
                CommonBC.DBConexion.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarClave()
        {
            try
            {
                Datos.ACCESO ac = CommonBC.DBConexion.ACCESO.First(b => b.USUARIO_ID == this.UsuarioId);
                ac.CLAVE = this.Clave;
                CommonBC.DBConexion.Entry(ac).State = System.Data.EntityState.Modified;
                CommonBC.DBConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ModificarClaveProveedor()
        {
            try
            {
                Datos.ACCESO ac = CommonBC.DBConexion.ACCESO.First(b => b.PROVEEDOR_ID == this.ProveedorId);
                ac.CLAVE = this.Clave;
                CommonBC.DBConexion.Entry(ac).State = System.Data.EntityState.Modified;
                CommonBC.DBConexion.SaveChanges();
                return true;
                    
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Eliminar()
        {
            try
            {
                ACCESO ac = CommonBC.DBConexion.ACCESO.Find(ID);
                CommonBC.DBConexion.ACCESO.Remove(ac);
                CommonBC.DBConexion.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ObtenerDatosAcceso(int id)
        {
            try
            {
                ACCESO a = CommonBC.DBConexion.ACCESO.First(b => b.USUARIO_ID == id);
                this.ID = (int)a.ID;
                this.Usuario = a.USUARIO;
                this.Clave = a.CLAVE;
                this.Pregunta = a.PREGUNTA;
                this.UsuarioId = (int)a.USUARIO_ID;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ObtenerDatosAccesoProveedor(int id)
        {
            try
            {
                ACCESO a = CommonBC.DBConexion.ACCESO.First(b => b.PROVEEDOR_ID == id);
                this.ID = (int)a.ID;
                this.Usuario = a.USUARIO;
                this.Clave = a.CLAVE;
                this.Pregunta = a.PREGUNTA;
                this.ProveedorId = (int)a.PROVEEDOR_ID;
                return true;
                
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Leer()
        {
            try
            {
                ACCESO ac = CommonBC.DBConexion.ACCESO.Find(this.ID);
                this.Usuario = ac.USUARIO;
                this.Clave = ac.CLAVE;
                this.Pregunta = ac.PREGUNTA;
                this.Respuesta = ac.RESPUESTA;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static string SHA1(string str)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public bool ObtenerPreguntas()
        {
            try
            {
                ACCESO a = CommonBC.DBConexion.ACCESO.First(b => b.USUARIO.ToLower().Equals(this.Usuario.ToLower()));
                this.ID = (int)a.ID;
                this.Clave = a.CLAVE;
                this.Pregunta = a.PREGUNTA;
                this.Respuesta = a.RESPUESTA;
                this.UsuarioId = (int)a.USUARIO_ID;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Acceso> ListadoPreguntas()
        {
            try
            {

                List<ACCESO> accesoPre = CommonBC.DBConexion.ACCESO.ToList();
                List<Acceso> acp= new List<Acceso>();
                foreach (ACCESO temp in accesoPre)
                {
                    Acceso _acp= new Acceso();
                    _acp.ID = (int)temp.ID;
                    _acp.Pregunta = temp.PREGUNTA;
                    acp.Add(_acp);

                }
                return acp;
            }
            catch (Exception)
            {

                return new List<Acceso>();
            }


        }



    }
    
}
