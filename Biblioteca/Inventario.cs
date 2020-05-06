using ConectorOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Inventario
    {
        [DataMember]
        public int ID_INV { get; set; }
        [DataMember]
        public string NOMBRE { get; set; }
        [DataMember]
        public int PRECIO { get; set; }
        [DataMember]
        public string IMPORTANTE { get; set; }
        [DataMember]
        public string ESTADO { get; set; }
        [DataMember]
        public short DEPARTAMENTO_ID { get; set; }
        [DataMember]
        public string ACTIVADO { get; set; }

        public Inventario(int iD_INV, string nOMBRE, int pRECIO, string iMPORTANTE, string eSTADO, short dEPARTAMENTO_ID, string aCTIVADO)
        {
            ID_INV = iD_INV;
            NOMBRE = nOMBRE;
            PRECIO = pRECIO;
            IMPORTANTE = iMPORTANTE;
            ESTADO = eSTADO;
            DEPARTAMENTO_ID = dEPARTAMENTO_ID;
            ACTIVADO = aCTIVADO;
        }

        public Inventario()
        {
        }

        public bool crearInventario()
        {
            try
            {
                CommonBC.ModeloEntity.CREARINVENTARIO(NOMBRE, PRECIO, IMPORTANTE, ESTADO, DEPARTAMENTO_ID);
                CommonBC.ModeloEntity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarInventario()
        {
            try
            {
                CommonBC.ModeloEntity.MODIFICARINVENTARIO(ID_INV, NOMBRE, PRECIO, IMPORTANTE, ESTADO, DEPARTAMENTO_ID);
                CommonBC.ModeloEntity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarInventario(int inv_id)
        {
            try
            {
                CommonBC.ModeloEntity.ELIMINARINVENTARIO(inv_id);
                CommonBC.ModeloEntity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Inventario> listarInventario(int depa_id)
        {
            List<Inventario> objs_inventario = new List<Inventario>();
            List<INVENTARIO> bd_objs_inventario = CommonBC.ModeloEntity.INVENTARIO.Where(inv => inv.ACTIVADO == "1" && inv.DEPARTAMENTO_ID == depa_id).ToList();
            foreach (INVENTARIO item in bd_objs_inventario)
            {
                Inventario inv = new Inventario();
                inv.ID_INV = int.Parse(item.ID_INV);
                inv.NOMBRE = item.NOMBRE;
                inv.PRECIO = item.PRECIO;
                inv.IMPORTANTE = item.IMPORTANTE;
                inv.ESTADO = item.ESTADO;
                inv.DEPARTAMENTO_ID = item.DEPARTAMENTO_ID;
                objs_inventario.Add(inv);
            }
            return objs_inventario;
        }
    }
}
