using ConectorOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Ciudad
    {
        [DataMember]
        public short ID { get; set; }
        [DataMember]
        public string NOMBRE_CIUDAD { get; set; }
        [DataMember]
        public string REGION { get; set; }

        public Ciudad(short iD, string nOMBRE_CIUDAD, string rEGION)
        {
            ID = iD;
            NOMBRE_CIUDAD = nOMBRE_CIUDAD;
            REGION = rEGION;
        }

        public Ciudad()
        {
        }
        
        public List<Ciudad> listaCiudades()
        {
            List<Ciudad> ciudades = new List<Ciudad>();
            List<CIUDAD> bd_ciudades = CommonBC.ModeloEntity.CIUDAD.ToList();
            // Comentario de prueba GIT
            foreach (CIUDAD item in bd_ciudades)
            {
                Ciudad c = new Ciudad();
                c.ID = item.ID;
                c.NOMBRE_CIUDAD = item.NOMBRE_CIUDAD;
                c.REGION = item.REGION;
                ciudades.Add(c);
            }
            return ciudades;
        }
    }
}
