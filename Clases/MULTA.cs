//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clases
{
    using System;
    using System.Collections.Generic;
    
    public partial class MULTA
    {
        public int ID_MULTA { get; set; }
        public int TOTAL_MULTA { get; set; }
        public int TOTAL_PAGADO { get; set; }
        public string PAGADO { get; set; }
        public string DESCRIPCION { get; set; }
        public short RESERVA_ID_RESERVA { get; set; }
    
        public virtual RESERVA RESERVA { get; set; }
    }
}
