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
    
    public partial class SERVICIO_TOURS
    {
        public SERVICIO_TOURS()
        {
            this.RESERVA_TOUR = new HashSet<RESERVA_TOUR>();
        }
    
        public short ID_TOUR { get; set; }
        public string HORA_LLEGADA { get; set; }
        public string HORA_SALIDA { get; set; }
        public int PRECIO_ACTUAL { get; set; }
        public string DISPONIBLE { get; set; }
        public System.DateTime FECHA { get; set; }
        public short ZONA_TOUR_ID_ZONA { get; set; }
        public Nullable<short> MES_TEMP_DESDE { get; set; }
        public Nullable<short> MES_TEMP_HASTA { get; set; }
    
        public virtual ICollection<RESERVA_TOUR> RESERVA_TOUR { get; set; }
        public virtual ZONA_TOUR ZONA_TOUR { get; set; }
    }
}
