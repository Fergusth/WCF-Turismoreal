using ConectorOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class ServicioTour
    {
        [DataMember]
        public short ID_TOUR { get; set; }
        [DataMember]
        public string HORA_LLEGADA { get; set; }
        [DataMember]
        public string HORA_SALIDA { get; set; }
        [DataMember]
        public int PRECIO_ACTUAL { get; set; }
        [DataMember]
        public string DISPONIBLE { get; set; }
        [DataMember]
        public DateTime FECHA { get; set; }
        [DataMember]
        public string ZONA_TOUR { get; set; }

        public ServicioTour(short iD_TOUR, string hORA_LLEGADA, string hORA_SALIDA, int pRECIO_ACTUAL, string dISPONIBLE, DateTime fECHA, string zONA_TOUR)
        {
            ID_TOUR = iD_TOUR;
            HORA_LLEGADA = hORA_LLEGADA;
            HORA_SALIDA = hORA_SALIDA;
            PRECIO_ACTUAL = pRECIO_ACTUAL;
            DISPONIBLE = dISPONIBLE;
            FECHA = fECHA;
            ZONA_TOUR = zONA_TOUR;
        }

        public ServicioTour()
        {
        }

        public List<ServicioTour> buscarToursPorFechaYCiudad(DateTime fecha, int ciudad_id)
        {
            List<ServicioTour> servicios = new List<ServicioTour>();
            List<SERVICIO_TOURS> bd_servicios = CommonBC.ModeloEntity.SERVICIO_TOURS.Where(st => st.FECHA == fecha && st.ZONA_TOUR.CIUDAD_ID == ciudad_id && st.DISPONIBLE == "1").ToList();

            foreach (SERVICIO_TOURS item in bd_servicios)
            {
                ServicioTour serv = new ServicioTour();
                serv.ID_TOUR = item.ID_TOUR;
                serv.HORA_LLEGADA = item.HORA_LLEGADA;
                serv.HORA_SALIDA = item.HORA_SALIDA;
                serv.PRECIO_ACTUAL = item.PRECIO_ACTUAL;
                serv.DISPONIBLE = item.DISPONIBLE;
                serv.FECHA = item.FECHA;
                serv.ZONA_TOUR = item.ZONA_TOUR.NOMBRE_ZONA;
            }

            return servicios;
        }

        public bool contratarServicioTour(short serv, short res)
        {
            try
            {
                SERVICIO_TOURS servicio = CommonBC.ModeloEntity.SERVICIO_TOURS.Where(s => s.ID_TOUR == serv).First();
                RESERVA_TOUR ser = new RESERVA_TOUR();

                ser.RESERVA_ID_RESERVA = res;
                ser.SERVICIO_TOURS_ID_TOUR = serv;
                ser.PRECIO_CONTRATADO = servicio.PRECIO_ACTUAL;



                ATEntities tr = CommonBC.ModeloEntity;
                tr.RESERVA_TOUR.Add(ser);
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
