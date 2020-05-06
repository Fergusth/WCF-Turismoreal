using ConectorOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class ServicioExtra
    {

        [DataMember]
        public short ID { get; set; }
        [DataMember]
        public string NOMBRE_SERVICIO_EX { get; set; }
        [DataMember]
        public int PRECIO_ACTUAL { get; set; }
        [DataMember]
        public string ACTIVADO { get; set; }

        public ServicioExtra(short iD, string nOMBRE_SERVICIO_EX, int pRECIO_ACTUAL, string aCTIVADO)
        {
            ID = iD;
            NOMBRE_SERVICIO_EX = nOMBRE_SERVICIO_EX;
            PRECIO_ACTUAL = pRECIO_ACTUAL;
            ACTIVADO = aCTIVADO;
        }

        public ServicioExtra()
        {
        }

        public bool crearServicioExtra()
        {
            try
            {
                CommonBC.ModeloEntity.CREARSERVICIOEXTRA(NOMBRE_SERVICIO_EX, PRECIO_ACTUAL);
                CommonBC.ModeloEntity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarServicioExtra()
        {
            try
            {
                CommonBC.ModeloEntity.MODIFICARSERVICIOEXTRA(ID, NOMBRE_SERVICIO_EX, PRECIO_ACTUAL);
                CommonBC.ModeloEntity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarServicioExtra(int id_serv)
        {
            try
            {
                CommonBC.ModeloEntity.ELIMINARSERVICIOEXTRA(id_serv);
                CommonBC.ModeloEntity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ServicioExtra> listarServicioExtra()
        {
            List<ServicioExtra> serviciosExtra = new List<ServicioExtra>();
            List<SERVICIO_EXTRA> bd_serviciosExtra = CommonBC.ModeloEntity.SERVICIO_EXTRA.Where(se => se.ACTIVADO == "1").ToList();
            foreach (SERVICIO_EXTRA item in bd_serviciosExtra)
            {
                ServicioExtra servicio = new ServicioExtra();
                servicio.ID = item.ID;
                servicio.NOMBRE_SERVICIO_EX = item.NOMBRE_SERVICIO_EX;
                servicio.PRECIO_ACTUAL = item.PRECIO_ACTUAL;
                serviciosExtra.Add(servicio);
            }
            return serviciosExtra;
        }

        public bool contratarServicioExtra(short serv, short res)
        {
            try
            {
                SERVICIO_EXTRA servicio = CommonBC.ModeloEntity.SERVICIO_EXTRA.Where(s => s.ID == serv).First();
                RESERVA_SERVICIO ser = new RESERVA_SERVICIO();

                ser.RESERVA_ID_RESERVA = res;
                ser.SERVICIO_EXTRA_ID = serv;
                ser.PRECIO_CONTRATADO = servicio.PRECIO_ACTUAL;



                ATEntities tr = CommonBC.ModeloEntity;
                tr.RESERVA_SERVICIO.Add(ser);
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
