using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocio{
    public class CommonBC
    {
        private static FermeEntities _fermeEntities;
        public static FermeEntities DBConexion
        {
            get
            {
                if (_fermeEntities == null)
                {
                    _fermeEntities = new FermeEntities();

                }
                return _fermeEntities;
            }
        }
    }
}
