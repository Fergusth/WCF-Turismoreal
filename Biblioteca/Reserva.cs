using ConectorOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Reserva
    {
        [DataMember]
        public short ID_RESERVA { get; set; }
        [DataMember]
        public DateTime FECHA_CHECKIN { get; set; }
        [DataMember]
        public DateTime FECHA_CHECKOUT { get; set; }
        [DataMember]
        public string HORA_CHECKIN { get; set; }
        [DataMember]
        public string HORA_CHECKOUT { get; set; }
        [DataMember]
        public string USUARIO_DNI { get; set; }
        [DataMember]
        public int PRECIO_TOTAL { get; set; }
        [DataMember]
        public int TOTAL_PAGADO { get; set; }
        [DataMember]
        public string ESTADO { get; set; }
        [DataMember]
        public string FORMA_PAGO { get; set; }

        public Reserva(short iD_RESERVA, DateTime fECHA_CHECKIN, DateTime fECHA_CHECKOUT, string hORA_CHECKIN, string hORA_CHECKOUT, string uSUARIO_DNI, int pRECIO_TOTAL, int tOTAL_PAGADO, string eSTADO, string fORMA_PAGO)
        {
            ID_RESERVA = iD_RESERVA;
            FECHA_CHECKIN = fECHA_CHECKIN;
            FECHA_CHECKOUT = fECHA_CHECKOUT;
            HORA_CHECKIN = hORA_CHECKIN;
            HORA_CHECKOUT = hORA_CHECKOUT;
            USUARIO_DNI = uSUARIO_DNI;
            PRECIO_TOTAL = pRECIO_TOTAL;
            TOTAL_PAGADO = tOTAL_PAGADO;
            ESTADO = eSTADO;
            FORMA_PAGO = fORMA_PAGO;
        }

        public Reserva()
        {
        }

        public Reserva crearReserva()
        {
            List<RESERVA> reservas = CommonBC.ModeloEntity.RESERVA.ToList();
            int max = 1;

            foreach (RESERVA item in reservas)
            {
                if (item.ID_RESERVA > max)
                {
                    max = item.ID_RESERVA;
                }
            }
            max = max + 1;

            RESERVA Res = new RESERVA();
            Res.ID_RESERVA = short.Parse(max.ToString());
            Res.FECHA_CHECKIN = FECHA_CHECKIN;
            Res.FECHA_CHECKOUT = FECHA_CHECKOUT;
            Res.HORA_CHECKIN = HORA_CHECKIN;
            Res.HORA_CHECKOUT = HORA_CHECKOUT;
            Res.USUARIO_DNI = USUARIO_DNI;
            Res.PRECIO_TOTAL = PRECIO_TOTAL;
            Res.TOTAL_PAGADO = TOTAL_PAGADO;
            Res.ESTADO = ESTADO;
            Res.FORMA_PAGO = FORMA_PAGO;

            ATEntities tr = CommonBC.ModeloEntity;
            tr.RESERVA.Add(Res);
            tr.SaveChanges();

            Reserva thisReserva = new Reserva();

            thisReserva.ID_RESERVA = Res.ID_RESERVA;
            thisReserva.FECHA_CHECKIN = Res.FECHA_CHECKIN;
            thisReserva.FECHA_CHECKOUT = Res.FECHA_CHECKOUT;
            thisReserva.HORA_CHECKIN = Res.HORA_CHECKIN;
            thisReserva.HORA_CHECKOUT = Res.HORA_CHECKOUT;
            thisReserva.USUARIO_DNI = Res.USUARIO_DNI;
            thisReserva.PRECIO_TOTAL = Res.PRECIO_TOTAL;
            thisReserva.TOTAL_PAGADO = Res.TOTAL_PAGADO;
            thisReserva.ESTADO = Res.ESTADO;
            thisReserva.FORMA_PAGO = Res.FORMA_PAGO;

            return thisReserva;
        }

        public bool contratoReservaDepartamento(int id_reserva, int id_departamento)
        {
            try
            {
                ATEntities tr = CommonBC.ModeloEntity;
                RESERVA res = tr.RESERVA.Where(r => r.ID_RESERVA == id_reserva).First();
                DEPARTAMENTO dep = tr.DEPARTAMENTO.Where(d => d.ID == id_departamento).First();

                List<INVENTARIO> invs = tr.INVENTARIO.Where(inv => inv.DEPARTAMENTO_ID == dep.ID).ToList();

                foreach (INVENTARIO item in invs)
                {
                    CHECKLIST check = new CHECKLIST();
                    check.RESERVA_ID_RESERVA = res.ID_RESERVA;
                    check.INVENTARIO_ID_INV = item.ID_INV;
                    check.ESTADO_ENTREGA = item.ESTADO;
                    check.ESTADO_DEVUELTO = item.ESTADO;
                    check.DESCRIPCION = "POR_REVISAR";
                    tr.CHECKLIST.Add(check);
                }

                res.DEPARTAMENTO.Add(dep);
                tr.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
