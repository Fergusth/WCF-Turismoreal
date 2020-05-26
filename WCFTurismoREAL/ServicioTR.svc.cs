using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Biblioteca;
using RestSharp;
using ConectorOracle;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace WCFTurismoREAL
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioTR" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioTR.svc o ServicioTR.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioTR : IServicioTR
    {
        // CRUD USUARIOS
        public Usuario Login(string dni, string pass)
        {
            Usuario u = new Usuario();
            return u.login(dni, pass);
        }
        public bool crearUsuario(string DNI, string NOMBRE, string APELLIDOS, string CORREO_ELECTRONICO, string DIRECCION, int TELEFONO, short ROL_ID_ROL, string EXTRANJERO, string FRECUENTE)
        {
            Usuario u = new Usuario();
            u.DNI = DNI;
            u.NOMBRE = NOMBRE;
            u.APELLIDOS = APELLIDOS;
            u.CORREO_ELECTRONICO = CORREO_ELECTRONICO;
            u.DIRECCION = DIRECCION;
            u.TELEFONO = TELEFONO;
            u.ROL_ID_ROL = ROL_ID_ROL;
            u.EXTRANJERO = EXTRANJERO;
            u.FRECUENTE = FRECUENTE;
            return u.crearUsuario();
        }
        public List<Usuario> listarUsuarios()
        {
            Usuario u = new Usuario();
            return u.listarUsuarios();
        }
        public bool editarUsuario(string DNI, string NOMBRE, string APELLIDOS, string CORREO_ELECTRONICO, string DIRECCION, int TELEFONO, short ROL_ID_ROL, string EXTRANJERO, string FRECUENTE)
        {
            Usuario u = new Usuario();
            u.DNI = DNI;
            u.NOMBRE = NOMBRE;
            u.APELLIDOS = APELLIDOS;
            u.CORREO_ELECTRONICO = CORREO_ELECTRONICO;
            u.DIRECCION = DIRECCION;
            u.TELEFONO = TELEFONO;
            u.ROL_ID_ROL = ROL_ID_ROL;
            u.EXTRANJERO = EXTRANJERO;
            u.FRECUENTE = FRECUENTE;
            return u.modificarUsuario();
        }
        public bool eliminarUsuario(string dni)
        {
            Usuario u = new Usuario();
            return u.eliminarUsuario(dni);
        }

        // CRUD DEPARTAMENTOS

        public bool crearDepartamento(string dIRECCION, short cANT_BANIOS, short cANT_DORMITORIOS, int pRECIO_DIARIO, string dESCRIPCION, string cONDICIONES_USO, short cIUDAD_ID, string iNTERNET, string cALEFACCION, int pROM_MES_DIVIDENDO, int pROM_MES_CONTRIBUCIONES)
        {
            Departamento depa = new Departamento();
            depa.DIRECCION = dIRECCION;
            depa.CANT_BANIOS = cANT_BANIOS;
            depa.CANT_DORMITORIOS = cANT_DORMITORIOS;
            depa.PRECIO_DIARIO = pRECIO_DIARIO;
            depa.DESCRIPCION = dESCRIPCION;
            depa.CONDICIONES_USO = cONDICIONES_USO;
            depa.CIUDAD_ID = cIUDAD_ID;
            depa.INTERNET = iNTERNET;
            depa.CALEFACCION = cALEFACCION;
            depa.PROM_MES_DIVIDENDO = pROM_MES_DIVIDENDO;
            depa.PROM_MES_CONTRIBUCIONES = pROM_MES_CONTRIBUCIONES;
            return depa.crearDepartamento();
        }

        public bool modificarDepartamento(short iD, string dIRECCION, short cANT_BANIOS, short cANT_DORMITORIOS, int pRECIO_DIARIO, string dESCRIPCION, string cONDICIONES_USO, short cIUDAD_ID, string iNTERNET, string cALEFACCION, int pROM_MES_DIVIDENDO, int pROM_MES_CONTRIBUCIONES)
        {
            Departamento depa = new Departamento();
            depa.ID = iD;
            depa.DIRECCION = dIRECCION;
            depa.CANT_BANIOS = cANT_BANIOS;
            depa.CANT_DORMITORIOS = cANT_DORMITORIOS;
            depa.PRECIO_DIARIO = pRECIO_DIARIO;
            depa.DESCRIPCION = dESCRIPCION;
            depa.CONDICIONES_USO = cONDICIONES_USO;
            depa.CIUDAD_ID = cIUDAD_ID;
            depa.INTERNET = iNTERNET;
            depa.CALEFACCION = cALEFACCION;
            depa.PROM_MES_DIVIDENDO = pROM_MES_DIVIDENDO;
            depa.PROM_MES_CONTRIBUCIONES = pROM_MES_CONTRIBUCIONES;
            return depa.modificarDepartamento();
        }

        public bool eliminarDepartamento(int id)
        {
            Departamento depa = new Departamento();
            return depa.eliminarDepartamento(id);
        }

        public List<Departamento> listarDepartamentos()
        {
            Departamento depa = new Departamento();
            return depa.listarDepartamentos();
        }

        public List<Departamento> departamentosDisponiblesPorFecha(DateTime inicio, DateTime fin, int idciudad)
        {
            Departamento depa = new Departamento();
            return depa.departamentosDisponiblesPorFecha(inicio, fin, idciudad);
        }

        public List<Ciudad> listaCiudades()
        {
            Ciudad c = new Ciudad();
            return c.listaCiudades();
        }

        // CRUD INVENTARIO

        public bool crearInventario(string nOMBRE, int pRECIO, string iMPORTANTE, string eSTADO, short dEPARTAMENTO_ID)
        {
            Inventario inv = new Inventario();
            inv.NOMBRE = nOMBRE;
            inv.PRECIO = pRECIO;
            inv.IMPORTANTE = iMPORTANTE;
            inv.ESTADO = eSTADO;
            inv.DEPARTAMENTO_ID = dEPARTAMENTO_ID;
            return inv.crearInventario();
        }

        public bool modificarInventario(int id, string nOMBRE, int pRECIO, string iMPORTANTE, string eSTADO, short dEPARTAMENTO_ID)
        {
            Inventario inv = new Inventario();
            inv.ID_INV = id;
            inv.NOMBRE = nOMBRE;
            inv.PRECIO = pRECIO;
            inv.IMPORTANTE = iMPORTANTE;
            inv.ESTADO = eSTADO;
            inv.DEPARTAMENTO_ID = dEPARTAMENTO_ID;
            return inv.modificarInventario();
        }

        public bool eliminarInventario(int id)
        {
            Inventario inv = new Inventario();
            return inv.eliminarInventario(id);
        }

        public List<Inventario> listarInventario(int depa_id)
        {
            Inventario inv = new Inventario();
            return inv.listarInventario(depa_id);
        }

        // CRUD SERVICIOS EXTRA

        public bool crearServicioExtra(string nOMBRE_SERVICIO_EX, int pRECIO_ACTUAL)
        {
            ServicioExtra servicioExtra = new ServicioExtra();
            servicioExtra.NOMBRE_SERVICIO_EX = nOMBRE_SERVICIO_EX;
            servicioExtra.PRECIO_ACTUAL = pRECIO_ACTUAL;
            return servicioExtra.crearServicioExtra();
        }

        public bool modificarServicioExtra(short id, string nOMBRE_SERVICIO_EX, int pRECIO_ACTUAL)
        {
            ServicioExtra servicioExtra = new ServicioExtra();
            servicioExtra.ID = id;
            servicioExtra.NOMBRE_SERVICIO_EX = nOMBRE_SERVICIO_EX;
            servicioExtra.PRECIO_ACTUAL = pRECIO_ACTUAL;
            return servicioExtra.modificarServicioExtra();
        }

        public bool eliminarServicioExtra(int id)
        {
            ServicioExtra servicioExtra = new ServicioExtra();
            return servicioExtra.eliminarServicioExtra(id);
        }

        public List<ServicioExtra> ListarServiciosExtra()
        {
            ServicioExtra servicioExtra = new ServicioExtra();
            return servicioExtra.listarServicioExtra();
        }

        public bool contratarServicioExtra(short serv, short res)
        {
            ServicioExtra ser = new ServicioExtra();
            return ser.contratarServicioExtra(serv, res);
        }

        // Acompañantes

        public bool crearAcompaniante(string dNI, string nOMBRE_COMPLETO, string eXTRANJERO, string cORREO, int tELEFONO)
        {
            Acompaniante acompaniante = new Acompaniante();
            acompaniante.DNI = dNI;
            acompaniante.NOMBRE_COMPLETO = nOMBRE_COMPLETO;
            acompaniante.EXTRANJERO = eXTRANJERO;
            acompaniante.CORREO = cORREO;
            acompaniante.TELEFONO = tELEFONO;
            return acompaniante.crearAcompaniante();
        }

        public Acompaniante buscarAcompaniante(string dni)
        {
            Acompaniante acompaniante = new Acompaniante();
            return acompaniante.buscarAcompaniante(dni);
        }

        // Tour

        public List<ServicioTour> buscarToursPorFechaYCiudad(DateTime fecha_inicio, DateTime fecha_fin, int ciudad_id)
        {
            ServicioTour serv = new ServicioTour();
            return serv.buscarToursPorFechaYCiudad(fecha_inicio, fecha_fin, ciudad_id);
        }
        public bool contratarServicioTour(short serv, short res)
        {
            ServicioTour servi = new ServicioTour();
            return servi.contratarServicioTour(serv, res);
        }

        // Reserva

        public Reserva crearReserva(DateTime fECHA_CHECKIN, DateTime fECHA_CHECKOUT, string hORA_CHECKIN, string hORA_CHECKOUT, string uSUARIO_DNI, int pRECIO_TOTAL, int tOTAL_PAGADO, string eSTADO, string fORMA_PAGO)
        {
            Reserva res = new Reserva();
            res.FECHA_CHECKIN = fECHA_CHECKIN;
            res.FECHA_CHECKOUT = fECHA_CHECKOUT;
            res.HORA_CHECKIN = hORA_CHECKIN;
            res.HORA_CHECKOUT = hORA_CHECKOUT;
            res.USUARIO_DNI = uSUARIO_DNI;
            res.PRECIO_TOTAL = pRECIO_TOTAL;
            res.TOTAL_PAGADO = tOTAL_PAGADO;
            res.ESTADO = eSTADO;
            res.FORMA_PAGO = fORMA_PAGO;

            return res.crearReserva();
        }

        public bool contratoReservaDepartamento(int id_reserva, int id_departamento)
        {
            Reserva res = new Reserva();
            return res.contratoReservaDepartamento(id_reserva, id_departamento);
        }

        public List<Multa> listaMultasUsuario(string dni)
        {
            Multa m = new Multa();
            return m.listaMultasUsuario(dni);
        }
        
        public bool tieneMultas(string dni)
        {
            return new Multa().tieneMultas(dni);
        }

        public bool pagarMulta(int multa_id, int pago)
        {
            return new Multa().pagar_multa(multa_id, pago);
        }

        public int getPorcentajeAnticipo()
        {
            PARAMETROS p = CommonBC.ModeloEntity.PARAMETROS.Where(pa => pa.NOMBRE == "ANTICIPO" && pa.TIPO == "ARRIENDO").First();
            return int.Parse(p.VALOR);
        }

        public FlowResponse generarLinkPago(int precio, string correo, string urlRet)
        {
            // Variables de consulta
            int randomNumber = new Random().Next(10, 80);
            var amount = precio;
            var commerceOrder = stringAleatorio(randomNumber);
            var currency = "CLP";
            var email = correo;
            var paymentMethod = 9;
            var subject = "Pago depa";
            var urlConfirmation = "https://www.google.cl/";
            var urlReturn = urlRet;
            var apiKey = "4B7AF68B-9EFB-4692-BF3B-41C7LAE010D8";
            var secretKey = "fb6eefb6ab2f2b2599630e6bde657f13bf93c053";
            var toSign = "amount=" + amount +
                         "&apiKey=" + apiKey +
                         "&commerceOrder=" + commerceOrder +
                         "&currency=" + currency +
                         "&email=" + email +
                         "&paymentMethod=" + paymentMethod +
                         "&subject=" + subject +
                         "&urlConfirmation=" + urlConfirmation +
                         "&urlReturn=" + urlReturn;
            var signature = GetHash(toSign, secretKey);

            // Magia de la api

            var client = new RestClient("https://sandbox.flow.cl/api");
            var request = new RestRequest("payment/create", Method.POST);
            request.AddParameter("apiKey", apiKey);
            request.AddParameter("commerceOrder", commerceOrder);
            request.AddParameter("subject", subject);
            request.AddParameter("currency", currency);
            request.AddParameter("amount", amount);
            request.AddParameter("email", email);
            request.AddParameter("paymentMethod", paymentMethod);
            request.AddParameter("urlConfirmation", urlConfirmation);
            request.AddParameter("urlReturn", urlReturn);
            request.AddParameter("s", signature);

            IRestResponse response = client.Execute(request);
            var resp = JsonConvert.DeserializeObject<FlowResponse>(response.Content);
            var ret = resp.url + "?token=" + resp.token;
            return resp;
        }
        public static string GetHash(string text, string key)
        {
            // change according to your needs, an UTF8Encoding
            // could be more suitable in certain situations
            ASCIIEncoding encoding = new ASCIIEncoding();

            byte[] textBytes = encoding.GetBytes(text);
            byte[] keyBytes = encoding.GetBytes(key);

            byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
        public string stringAleatorio(int longitud)
        {
            Guid miGuid = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "");
            return token;
        }
    }
}

public class FlowResponse
{
    public string url;
    public string token;
    public string flowOrder;
}