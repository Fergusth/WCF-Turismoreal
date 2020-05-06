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
    
    public partial class RESERVA
    {
        public RESERVA()
        {
            this.MULTA = new HashSet<MULTA>();
            this.CHECKLIST = new HashSet<CHECKLIST>();
            this.RESERVA_SERVICIO = new HashSet<RESERVA_SERVICIO>();
            this.RESERVA_TOUR = new HashSet<RESERVA_TOUR>();
            this.RESERVA_TRANSPORTE = new HashSet<RESERVA_TRANSPORTE>();
            this.ACOMPAÑANTE = new HashSet<ACOMPAÑANTE>();
        }
    
        public short ID_RESERVA { get; set; }
        public System.DateTime FECHA_CHECKIN { get; set; }
        public System.DateTime FECHA_CHECKOUT { get; set; }
        public string HORA_CHECKIN { get; set; }
        public string HORA_CHECKOUT { get; set; }
        public string USUARIO_DNI { get; set; }
        public short DEPARTAMENTO_ID_DEPARTAMENTO { get; set; }
        public int PRECIO_TOTAL { get; set; }
        public int TOTAL_PAGADO { get; set; }
        public string ESTADO { get; set; }
    
        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }
        public virtual ICollection<MULTA> MULTA { get; set; }
        public virtual ICollection<CHECKLIST> CHECKLIST { get; set; }
        public virtual ICollection<RESERVA_SERVICIO> RESERVA_SERVICIO { get; set; }
        public virtual ICollection<RESERVA_TOUR> RESERVA_TOUR { get; set; }
        public virtual ICollection<RESERVA_TRANSPORTE> RESERVA_TRANSPORTE { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual ICollection<ACOMPAÑANTE> ACOMPAÑANTE { get; set; }
    }
}
