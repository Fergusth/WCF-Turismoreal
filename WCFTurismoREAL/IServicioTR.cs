using Biblioteca;
using ConectorOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFTurismoREAL
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioTR
    {
        // USUARIOS
        [OperationContract]
        Usuario Login(string dni, string pass);
        [OperationContract]
        bool crearUsuario(string DNI, string NOMBRE, string APELLIDOS, string CORREO_ELECTRONICO, string DIRECCION, int TELEFONO, short ROL_ID_ROL, string EXTRANJERO, string FRECUENTE);
        [OperationContract]
        List<Usuario> listarUsuarios();
        [OperationContract]
        bool editarUsuario(string DNI, string NOMBRE, string APELLIDOS, string CORREO_ELECTRONICO, string DIRECCION, int TELEFONO, short ROL_ID_ROL, string EXTRANJERO, string FRECUENTE);
        [OperationContract]
        bool eliminarUsuario(string dni);
        // DEPARTAMENTOS
        [OperationContract]
        bool crearDepartamento(string dIRECCION, short cANT_BANIOS, short cANT_DORMITORIOS, int pRECIO_DIARIO, string dESCRIPCION, string cONDICIONES_USO, short cIUDAD_ID, string iNTERNET, string cALEFACCION, int pROM_MES_DIVIDENDO, int pROM_MES_CONTRIBUCIONES);
        [OperationContract]
        bool modificarDepartamento(short iD, string dIRECCION, short cANT_BANIOS, short cANT_DORMITORIOS, int pRECIO_DIARIO, string dESCRIPCION, string cONDICIONES_USO, short cIUDAD_ID, string iNTERNET, string cALEFACCION, int pROM_MES_DIVIDENDO, int pROM_MES_CONTRIBUCIONES);
        [OperationContract]
        bool eliminarDepartamento(int id);
        [OperationContract]
        List<Departamento> listarDepartamentos();
        [OperationContract]
        List<Departamento> departamentosDisponiblesPorFecha(DateTime inicio, DateTime fin, int idciudad);
        [OperationContract]
        List<Ciudad> listaCiudades();
        // INVENTARIO
        [OperationContract]
        bool crearInventario(string nOMBRE, int pRECIO, string iMPORTANTE, string eSTADO, short dEPARTAMENTO_ID);
        [OperationContract]
        bool modificarInventario(int id, string nOMBRE, int pRECIO, string iMPORTANTE, string eSTADO, short dEPARTAMENTO_ID);
        [OperationContract]
        bool eliminarInventario(int id);
        [OperationContract]
        List<Inventario> listarInventario(int depa_id);
        // SERVICIOS EXTRA
        [OperationContract]
        bool crearServicioExtra(string nOMBRE_SERVICIO_EX, int pRECIO_ACTUAL);
        [OperationContract]
        bool modificarServicioExtra(short id, string nOMBRE_SERVICIO_EX, int pRECIO_ACTUAL);
        [OperationContract]
        bool eliminarServicioExtra(int id);
        [OperationContract]
        List<ServicioExtra> ListarServiciosExtra();
        [OperationContract]
        bool contratarServicioExtra(short serv, short res);
        // ACOMPAÑANTE
        [OperationContract]
        bool crearAcompaniante(string dNI, string nOMBRE_COMPLETO, string eXTRANJERO, string cORREO, int tELEFONO);
        [OperationContract]
        Acompaniante buscarAcompaniante(string dni);
        // Tour
        [OperationContract]
        List<ServicioTour> buscarToursPorFechaYCiudad(DateTime fecha_inicio, DateTime fecha_fin, int ciudad_id);
        [OperationContract]
        bool contratarServicioTour(short serv, short res);
        // Reserva
        [OperationContract]
        Reserva crearReserva(DateTime fECHA_CHECKIN, DateTime fECHA_CHECKOUT, string hORA_CHECKIN, string hORA_CHECKOUT, string uSUARIO_DNI, int pRECIO_TOTAL, int tOTAL_PAGADO, string eSTADO, string fORMA_PAGO);
        [OperationContract]
        bool contratoReservaDepartamento(int id_reserva, int id_departamento);
        [OperationContract]
        List<Multa> listaMultasUsuario(string dni);
        [OperationContract]
        bool tieneMultas(string dni);
        [OperationContract]
        bool pagarMulta(int multa_id, int pago);
        [OperationContract]
        int getPorcentajeAnticipo();
        [OperationContract]
        FlowResponse generarLinkPago(int precio, string correo, string urlRet);
    }
}
