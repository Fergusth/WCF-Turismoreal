//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConectorOracle
{
    using System;
    using System.Collections.Generic;
    
    public partial class REPARACION
    {
        public long ID { get; set; }
        public string DESCRIPCION { get; set; }
        public System.DateTime FECHA { get; set; }
        public int PRECIO { get; set; }
        public short DEPARTAMENTO_ID { get; set; }
    
        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }
    }
}
