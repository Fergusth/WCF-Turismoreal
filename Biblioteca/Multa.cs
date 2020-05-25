using ConectorOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Multa
    {
        public int ID_MULTA { get; set; }
        public int TOTAL_MULTA { get; set; }
        public int TOTAL_PAGADO { get; set; }
        public string PAGADO { get; set; }
        public string DESCRIPCION { get; set; }
        public short RESERVA_ID_RESERVA { get; set; }

        public Multa()
        {
        }

        public Multa(int iD_MULTA, int tOTAL_MULTA, int tOTAL_PAGADO, string pAGADO, string dESCRIPCION, short rESERVA_ID_RESERVA)
        {
            ID_MULTA = iD_MULTA;
            TOTAL_MULTA = tOTAL_MULTA;
            TOTAL_PAGADO = tOTAL_PAGADO;
            PAGADO = pAGADO;
            DESCRIPCION = dESCRIPCION;
            RESERVA_ID_RESERVA = rESERVA_ID_RESERVA;
        }

        public List<Multa> listaMultasUsuario(string dni)
        {
            List<MULTA> bd_multas = CommonBC.ModeloEntity.MULTA.Where(m => m.RESERVA.USUARIO_DNI == dni).ToList();
            List<Multa> multas = new List<Multa>();

            foreach (MULTA item in bd_multas)
            {
                Multa multa = new Multa(item.ID_MULTA, item.TOTAL_MULTA, item.TOTAL_PAGADO, item.PAGADO, item.DESCRIPCION, item.RESERVA_ID_RESERVA);
                multas.Add(multa);
            }

            return multas;
        }

        public bool tieneMultas(string dni)
        {
            return listaMultasUsuario(dni).Count > 0;
        }

        public bool pagar_multa(int multa_id, int pago)
        {
            ATEntities entity = new ATEntities();
            MULTA multa = entity.MULTA.Where(m => m.ID_MULTA == multa_id).First();

            if (pago >= multa.TOTAL_PAGADO)
            {
                multa.PAGADO = "1";
            }
            multa.TOTAL_PAGADO = multa.TOTAL_PAGADO + pago;
            entity.SaveChanges();
            return true;
        }

    }
}
