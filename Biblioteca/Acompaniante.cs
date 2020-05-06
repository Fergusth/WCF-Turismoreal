using ConectorOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Acompaniante
    {

        public string DNI { get; set; }
        public string NOMBRE_COMPLETO { get; set; }
        public string EXTRANJERO { get; set; }
        public string CORREO { get; set; }
        public int TELEFONO { get; set; }

        public Acompaniante()
        {
        }

        public Acompaniante(string dNI, string nOMBRE_COMPLETO, string eXTRANJERO, string cORREO, int tELEFONO)
        {
            DNI = dNI;
            NOMBRE_COMPLETO = nOMBRE_COMPLETO;
            EXTRANJERO = eXTRANJERO;
            CORREO = cORREO;
            TELEFONO = tELEFONO;
        }

        public bool crearAcompaniante()
        {
            try
            {
                ACOMPANIANTE acomp = new ACOMPANIANTE();
                acomp.DNI = DNI;
                acomp.NOMBRE_COMPLETO = NOMBRE_COMPLETO;
                acomp.EXTRANJERO = EXTRANJERO;
                acomp.CORREO = CORREO;
                acomp.TELEFONO = TELEFONO;

                ATEntities tr = CommonBC.ModeloEntity;
                tr.ACOMPANIANTE.Add(acomp);
                tr.SaveChanges();

                return true;
            } catch
            {
                return false;
            }
        }

        public Acompaniante buscarAcompaniante(string dni) {
            Acompaniante aco = new Acompaniante();
            try
            {
                ACOMPANIANTE acomp = CommonBC.ModeloEntity.ACOMPANIANTE.Where(a => a.DNI == dni).First();
                aco.DNI = acomp.DNI;
                aco.CORREO = acomp.CORREO;
                aco.EXTRANJERO = acomp.EXTRANJERO;
                aco.NOMBRE_COMPLETO = acomp.NOMBRE_COMPLETO;
                aco.TELEFONO = int.Parse(acomp.TELEFONO.ToString());
                return aco;
            } catch
            {
                return aco;
            }
        }
    }
}
