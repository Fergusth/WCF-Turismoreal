using ConectorOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Departamento
    {
        [DataMember]
        public short ID { get; set; }
        [DataMember]
        public string DIRECCION { get; set; }
        [DataMember]
        public short CANT_BANIOS { get; set; }
        [DataMember]
        public short CANT_DORMITORIOS { get; set; }
        [DataMember]
        public int PRECIO_DIARIO { get; set; }
        [DataMember]
        public string DESCRIPCION { get; set; }
        [DataMember]
        public string ACTIVADO { get; set; }
        [DataMember]
        public string CONDICIONES_USO { get; set; }
        [DataMember]
        public short CIUDAD_ID { get; set; }
        [DataMember]
        public string INTERNET { get; set; }
        [DataMember]
        public string CALEFACCION { get; set; }
        [DataMember]
        public int PROM_MES_DIVIDENDO { get; set; }
        [DataMember]
        public int PROM_MES_CONTRIBUCIONES { get; set; }
        public Departamento()
        {

        }
        public Departamento(short iD, string dIRECCION, short cANT_BANIOS, short cANT_DORMITORIOS, int pRECIO_DIARIO, string dESCRIPCION, string aCTIVADO, string cONDICIONES_USO, short cIUDAD_ID, string iNTERNET, string cALEFACCION, int pROM_MES_DIVIDENDO, int pROM_MES_CONTRIBUCIONES)
        {
            ID = iD;
            DIRECCION = dIRECCION;
            CANT_BANIOS = cANT_BANIOS;
            CANT_DORMITORIOS = cANT_DORMITORIOS;
            PRECIO_DIARIO = pRECIO_DIARIO;
            DESCRIPCION = dESCRIPCION;
            ACTIVADO = aCTIVADO;
            CONDICIONES_USO = cONDICIONES_USO;
            CIUDAD_ID = cIUDAD_ID;
            INTERNET = iNTERNET;
            CALEFACCION = cALEFACCION;
            PROM_MES_DIVIDENDO = pROM_MES_DIVIDENDO;
            PROM_MES_CONTRIBUCIONES = pROM_MES_CONTRIBUCIONES;
        }

        public bool crearDepartamento()
        {
            try
            {
                CommonBC.ModeloEntity.CREARDEPTO(CANT_BANIOS, CANT_DORMITORIOS, PRECIO_DIARIO, DIRECCION, CIUDAD_ID, DESCRIPCION, CONDICIONES_USO, INTERNET, CALEFACCION, PROM_MES_DIVIDENDO, PROM_MES_CONTRIBUCIONES);
                CommonBC.ModeloEntity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarDepartamento()
        {
            try
            {
                CommonBC.ModeloEntity.MODIFICADEPARTAMENTO(ID, CANT_BANIOS, CANT_DORMITORIOS, PRECIO_DIARIO, DIRECCION, CIUDAD_ID, DESCRIPCION, CONDICIONES_USO, INTERNET, CALEFACCION, PROM_MES_DIVIDENDO, PROM_MES_CONTRIBUCIONES);
                CommonBC.ModeloEntity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarDepartamento(int id)
        {
            try
            {
                CommonBC.ModeloEntity.ELIMINARDEPA(id);
                CommonBC.ModeloEntity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Departamento> listarDepartamentos()
        {
            List<Departamento> departamentos = new List<Departamento>();
            List<DEPARTAMENTO> bd_departamentos = CommonBC.ModeloEntity.DEPARTAMENTO.Where(d => d.ACTIVADO == "1").ToList();
            foreach (DEPARTAMENTO item in bd_departamentos)
            {
                Departamento dep = new Departamento();
                dep.ID = item.ID;
                dep.DIRECCION = item.DIRECCION;
                dep.CANT_BANIOS = item.CANT_BANIOS;
                dep.CANT_DORMITORIOS = item.CANT_DORMITORIOS;
                dep.PRECIO_DIARIO = item.PRECIO_DIARIO;
                dep.DESCRIPCION = item.DESCRIPCION;
                dep.CONDICIONES_USO = item.CONDICIONES_USO;
                dep.CIUDAD_ID = item.CIUDAD_ID;
                dep.INTERNET = item.INTERNET;
                dep.CALEFACCION = item.CALEFACCION;
                dep.PROM_MES_DIVIDENDO = item.PROM_MES_DIVIDENDO;
                dep.PROM_MES_CONTRIBUCIONES = item.PROM_MES_CONTRIBUCIONES;
                departamentos.Add(dep);
            }
            return departamentos;
        }
        public List<Departamento> departamentosDisponiblesPorFecha(DateTime inicio, DateTime fin, int ciudad_id)
        {
            List<Departamento> departamentos = new List<Departamento>();
            List<RESERVA> reservas = CommonBC.ModeloEntity.RESERVA.Where(r =>
                inicio >= r.FECHA_CHECKIN &&
                inicio <= r.FECHA_CHECKOUT ||
                fin >= r.FECHA_CHECKIN &&
                fin <= r.FECHA_CHECKOUT ||
                inicio <= r.FECHA_CHECKIN && 
                fin >= r.FECHA_CHECKOUT && r.ESTADO != "CANCELADA").ToList();

            List<MANTENCION> mantenciones = CommonBC.ModeloEntity.MANTENCION.Where(m =>
                inicio >= m.FECHA_INICIO &&
                inicio <= m.FECHA_TERMINO ||
                fin >= m.FECHA_INICIO &&
                fin <= m.FECHA_TERMINO ||
                inicio <= m.FECHA_INICIO &&
                fin >= m.FECHA_TERMINO).ToList();

            List<DEPARTAMENTO> depas = CommonBC.ModeloEntity.DEPARTAMENTO.Where(d => d.ACTIVADO == "1" && d.CIUDAD_ID == ciudad_id).ToList();
            foreach (DEPARTAMENTO item in depas)
            {
                bool disponible = true;

                foreach (RESERVA r in reservas)
                {
                    foreach (DEPARTAMENTO depa in r.DEPARTAMENTO.ToList())
                    {
                        if (depa.ID == item.ID)
                        {
                            disponible = false;
                        }
                    }
                }

                foreach (MANTENCION mant in mantenciones)
                {
                    if (mant.DEPARTAMENTO_ID == item.ID)
                    {
                        disponible = false;
                    }
                }
                if (disponible)
                {
                    Departamento dep = new Departamento();
                    dep.ID = item.ID;
                    dep.DIRECCION = item.DIRECCION;
                    dep.CANT_BANIOS = item.CANT_BANIOS;
                    dep.CANT_DORMITORIOS = item.CANT_DORMITORIOS;
                    dep.PRECIO_DIARIO = item.PRECIO_DIARIO;
                    dep.DESCRIPCION = item.DESCRIPCION;
                    dep.CONDICIONES_USO = item.CONDICIONES_USO;
                    dep.CIUDAD_ID = item.CIUDAD_ID;
                    dep.INTERNET = item.INTERNET;
                    dep.CALEFACCION = item.CALEFACCION;
                    dep.PROM_MES_DIVIDENDO = item.PROM_MES_DIVIDENDO;
                    dep.PROM_MES_CONTRIBUCIONES = item.PROM_MES_CONTRIBUCIONES;
                    departamentos.Add(dep);
                }

            }
            return departamentos;
        }

        public bool between(DateTime date, DateTime inicio, DateTime fin)
        {
            if (date >= inicio && date <= fin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
