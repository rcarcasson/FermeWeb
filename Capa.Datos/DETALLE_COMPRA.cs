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
    
    public partial class DETALLE_COMPRA
    {
        public decimal ID { get; set; }
        public decimal CANTIDAD { get; set; }
        public decimal COMPRA_ID { get; set; }
        public decimal PRODUCTO_ID { get; set; }
        public string ACEPTADA { get; set; }
        public string OBSERVACION { get; set; }
    
        public virtual COMPRA COMPRA { get; set; }
        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
