//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capa.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROVEEDOR
    {
        public PROVEEDOR()
        {
            this.ACCESO = new HashSet<ACCESO>();
            this.COMPRA = new HashSet<COMPRA>();
        }
    
        public decimal ID { get; set; }
        public string RUT { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string RUBRO { get; set; }
        public string MAIL { get; set; }
    
        public virtual ICollection<ACCESO> ACCESO { get; set; }
        public virtual ICollection<COMPRA> COMPRA { get; set; }
    }
}