using ConectorOracle;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Usuario
    {
        [DataMember]
        public string DNI { get; set; }
        [DataMember]
        public string NOMBRE { get; set; }
        [DataMember]
        public string APELLIDOS { get; set; }
        [DataMember]
        public string CORREO_ELECTRONICO { get; set; }
        [DataMember]
        public string DIRECCION { get; set; }
        [DataMember]
        public int TELEFONO { get; set; }
        [DataMember]
        public string CONTRASENIA { get; set; }
        [DataMember]
        public string ACTIVADO { get; set; }
        [DataMember]
        public short ROL_ID_ROL { get; set; }
        [DataMember]
        public string EXTRANJERO { get; set; }
        [DataMember]
        public string FRECUENTE { get; set; }

        public Usuario()
        {
           
        }

        public Usuario(string dNI, string nOMBRE, string aPELLIDOS, string cORREO_ELECTRONICO, string dIRECCION, int tELEFONO, string cONTRASENIA, string aCTIVADO, short rOL_ID_ROL, string eXTRANJERO, string fRECUENTE)
        {
            DNI = dNI;
            NOMBRE = nOMBRE;
            APELLIDOS = aPELLIDOS;
            CORREO_ELECTRONICO = cORREO_ELECTRONICO;
            DIRECCION = dIRECCION;
            TELEFONO = tELEFONO;
            CONTRASENIA = cONTRASENIA;
            ACTIVADO = aCTIVADO;
            ROL_ID_ROL = rOL_ID_ROL;
            EXTRANJERO = eXTRANJERO;
            FRECUENTE = fRECUENTE;
        }

        public Usuario login(string dni, string pass)
        {
            Usuario user = new Usuario();
            string password = Md5.Encriptar(pass);
            List <ConectorOracle.USUARIO> ususarios = CommonBC.ModeloEntity.USUARIO.Where(us => us.DNI == dni && us.CONTRASENIA == password).ToList();
            CommonBC.ModeloEntity.SaveChanges();
            foreach (ConectorOracle.USUARIO item in ususarios)
            {
                user.DNI = item.DNI;
                user.NOMBRE = item.NOMBRE;
                user.APELLIDOS = item.APELLIDOS;
                user.ROL_ID_ROL = item.ROL_ID;
            }
            return user;
        }
        public bool crearUsuario()
        {
            try
            {
                string pass = CrearPasswordAleatoria(10);
                CommonBC.ModeloEntity.CREARUSUARIO(DNI, NOMBRE, APELLIDOS, CORREO_ELECTRONICO, DIRECCION, TELEFONO, Md5.Encriptar(pass), ROL_ID_ROL, EXTRANJERO, FRECUENTE);
                CommonBC.ModeloEntity.SaveChanges();
                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(CORREO_ELECTRONICO));
                email.From = new MailAddress("contacto.turismoreal@gmail.com");
                email.Subject = "Bienvenido a Turismo Real";
                email.Body = "" +
                    "<h2>Se ha creado tu cuenta en Turismo real<h2>" +
                    "Tu contraseña es: <h1>" + pass + "<h1>" +
                    "No la compartas con nadie... Saludos" +
                    "";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("contacto.turismoreal@gmail.com", "turismoreal8569"),
                    EnableSsl = true
                };

                var output = "";

                try
                {
                    client.Send(email);
                    email.Dispose();
                    output = "Corre electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error enviando correo electrónico: " + ex.Message;
                }

                Console.WriteLine(output);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public string CrearPasswordAleatoria(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }

        public bool eliminarUsuario(string dni)
        {
            try
            {
                CommonBC.ModeloEntity.ELIMINARUSUARIO(dni);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarUsuario()
        {
            try
            {
                CommonBC.ModeloEntity.MODIFICARUSUARIO(DNI, NOMBRE, APELLIDOS, CORREO_ELECTRONICO, DIRECCION, TELEFONO, ROL_ID_ROL, EXTRANJERO, FRECUENTE);
                CommonBC.ModeloEntity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Usuario> listarUsuarios()
        {
            List<Usuario> users = new List<Usuario>();
            List<USUARIO> ususarios = CommonBC.ModeloEntity.USUARIO.Where(us => us.ACTIVADO == "1").ToList();
            foreach (USUARIO item in ususarios)
            {
                Usuario user = new Usuario();
                user.DNI = item.DNI;
                user.NOMBRE = item.NOMBRE;
                user.APELLIDOS = item.APELLIDOS;
                user.CORREO_ELECTRONICO = item.CORREO_ELECTRONICO;
                user.DIRECCION = item.DIRECCION;
                user.TELEFONO = item.TELEFONO;
                user.ROL_ID_ROL = item.ROL_ID;
                user.EXTRANJERO = item.EXTRANJERO;
                user.FRECUENTE = item.FRECUENTE;
                users.Add(user);
            }
            return users;
        }
    }
}
