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
    
    public partial class CIUDAD
    {
        public CIUDAD()
        {
            this.DEPARTAMENTO = new HashSet<DEPARTAMENTO>();
            this.ZONA_TOUR = new HashSet<ZONA_TOUR>();
        }
    
        public short ID { get; set; }
        public string NOMBRE_CIUDAD { get; set; }
        public string REGION { get; set; }
    
        public virtual ICollection<DEPARTAMENTO> DEPARTAMENTO { get; set; }
        public virtual ICollection<ZONA_TOUR> ZONA_TOUR { get; set; }
    }
}
