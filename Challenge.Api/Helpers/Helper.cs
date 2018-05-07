using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Challenge.Api.Helpers
{
    public static class Helper
    {
        public static string GetDateTimePrefix(this DateTime now)
        {


            return now.Year.ToString()
                    + (now.Month < 10 ? "0" : String.Empty) + now.Month.ToString()
                    + (now.Day < 10 ? "0" : String.Empty) + now.Day.ToString()
                    + "_"
                    + (now.Hour < 10 ? "0" : String.Empty) + now.Hour.ToString()
                    + "."
                    + (now.Minute < 10 ? "0" : String.Empty) + now.Minute.ToString()
                    + "."
                    + (now.Second < 10 ? "0" : String.Empty) + now.Second.ToString()
                    + now.Millisecond.ToString();
        }

        public static string RenderRazorViewToString(string viewName, object model, ViewDataDictionary viewData = null)
        {
            


            if (viewData == null)
            {
                viewData = new ViewDataDictionary();
            }
            viewData.Model = model;
            viewData.Add("SiteName", "AldamarITB");
            viewData.Add("HomeLink", "http://intranet.aldamaritb.com");

            using (var writer = new StringWriter())
            {
                var routeData = new RouteData();
                routeData.Values.Add("controller", "test");
                var fakeControllerContext = new ControllerContext(new HttpContextWrapper(new HttpContext(new HttpRequest(null, "http://google.com", null), new HttpResponse(null))), routeData, new FakeController());
                var razorViewEngine = new RazorViewEngine();
                var razorViewResult = razorViewEngine.FindView(fakeControllerContext, viewName, "", false);

                var viewContext = new ViewContext(fakeControllerContext, razorViewResult.View, new ViewDataDictionary(viewData), new TempDataDictionary(), writer);
                razorViewResult.View.Render(viewContext, writer);
                return writer.ToString();
            }

        }

        public static string GenerateSlug(this string phrase, int length)
        {
            string str = phrase.RemoveAccent().ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= length ? str.Length : length).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        //public static string Encrypt(this string PlainText)
        //{
        //    return AESEncryption.Encrypt(PlainText, new t_gst_web_conf().GetValueById(WebConfigKeys.ENC1),
        //                                            new t_gst_web_conf().GetValueById(WebConfigKeys.ENC2), "SHA1", 2,
        //                                            new t_gst_web_conf().GetValueById(WebConfigKeys.ENC3), 256);

        //}

        //public static string Decrypt(this string CipherText)
        //{
        //    return AESEncryption.Decrypt(CipherText, new t_gst_web_conf().GetValueById(WebConfigKeys.ENC1),
        //                                            new t_gst_web_conf().GetValueById(WebConfigKeys.ENC2), "SHA1", 2,
        //                                            new t_gst_web_conf().GetValueById(WebConfigKeys.ENC3), 256);

        //}

        public static string DateFriendly(DateTime myDate)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - myDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 0)
            {
                return "not yet";
            }
            if (delta < 1 * MINUTE)
            {
                return ts.Seconds == 1 ? "1 second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 2 * MINUTE)
            {
                return "1 minute ago";
            }
            if (delta < 45 * MINUTE)
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 90 * MINUTE)
            {
                return "1 hour ago";
            }
            if (delta < 24 * HOUR)
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 48 * HOUR)
            {
                return "yesterday";
            }
            if (delta < 30 * DAY)
            {
                return ts.Days + " days ago";
            }
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "1 month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "1 year ago" : years + " years ago";
            }
        }
    }

    public class FakeController : ControllerBase { protected override void ExecuteCore() { } }

    /* CLASE CIF */
    /// <summary>
    /// Representa un número. En la clase se desglosan las distintas opciones que se puedan
    /// encontrar
    /// </summary>
    public class NumeroNif
    {
        /// <summary>
        /// Tipos de Códigos.
        /// </summary>
        /// <remarks>Aunque actualmente no se utilice el término CIF, se usa en la enumeración
        /// por comodidad</remarks>
        private enum TiposCodigosEnum { NIF, NIE, CIF }

        // Número tal cual lo introduce el usuario
        private string numero;
        private TiposCodigosEnum tipo;

        /// <summary>
        /// Parte de Nif: En caso de ser un Nif intracomunitario, permite obtener el cógido del país
        /// </summary>
        public string CodigoIntracomunitario { get; internal set; }
        internal bool EsIntraComunitario { get; set; }

        /// <summary>
        /// Parte de Nif: Letra inicial del Nif, en caso de tenerla
        /// </summary>
        public string LetraInicial { get; internal set; }

        /// <summary>
        /// Parte de Nif: Bloque numérico del NIF. En el caso de un NIF de persona física,
        /// corresponderá al DNI
        /// </summary>
        public int Numero { get; internal set; }

        /// <summary>
        /// Parte de Nif: Dígito de control. Puede ser número o letra
        /// </summary>
        public string DigitoControl { get; internal set; }

        /// <summary>
        /// Valor que representa si el Nif introducido es correcto
        /// </summary>
        public bool EsCorrecto { get; internal set; }

        /// <summary>
        /// Cadena que representa el tipo de Nif comprobado:
        ///     - NIF : Número de identificación fiscal de persona física
        ///     - NIE : Número de identificación fiscal extranjería
        ///     - CIF : Código de identificación fiscal (Entidad jurídica)
        /// </summary>
        public string TipoNif { get { return tipo.ToString(); } }

        /// <summary>
        /// Constructor. Al instanciar la clase se realizan todos los cálculos
        /// </summary>
        /// <param name="numero">Cadena de 9 u 11 caracteres que contiene el DNI/NIF
        /// tal cual lo ha introducido el usuario para su verificación</param>
        private NumeroNif(string numero)
        {
            // Se eliminan los carácteres sobrantes
            numero = EliminaCaracteres(numero);

            // Todo en maýusculas
            numero = numero.ToUpper();

            // Comprobación básica de la cadena introducida por el usuario
            if (numero.Length != 9 && numero.Length != 11)
                throw new ArgumentException("El NIF no tiene un número de caracteres válidos");

            this.numero = numero;
            Desglosa();

            switch (tipo)
            {
                case TiposCodigosEnum.NIF:
                case TiposCodigosEnum.NIE:
                    this.EsCorrecto = CompruebaNif();
                    break;
                case TiposCodigosEnum.CIF:
                    this.EsCorrecto = CompruebaCif();
                    break;
            }
        }

        #region Preparación del número (desglose)

        /// <summary>
        /// Realiza un desglose del número introducido por el usuario en las propiedades
        /// de la clase
        /// </summary>
        private void Desglosa()
        {
            Int32 n;
            if (numero.Length == 11)
            {
                // Nif Intracomunitario
                EsIntraComunitario = true;
                CodigoIntracomunitario = numero.Substring(0, 2);
                LetraInicial = numero.Substring(2, 1);
                Int32.TryParse(numero.Substring(3, 7), out n);
                DigitoControl = numero.Substring(10, 1);
                tipo = GetTipoDocumento(LetraInicial[0]);
            }
            else
            {
                // Nif español
                tipo = GetTipoDocumento(numero[0]);
                EsIntraComunitario = false;
                if (tipo == TiposCodigosEnum.NIF)
                {
                    LetraInicial = string.Empty;
                    Int32.TryParse(numero.Substring(0, 8), out n);
                }
                else
                {
                    LetraInicial = numero.Substring(0, 1);
                    Int32.TryParse(numero.Substring(1, 7), out n);
                    if (numero.Substring(0, 1).ToString() == "Y")
                        n = n + 10000000;
                    if (numero.Substring(0, 1).ToString() == "Z")
                        n = n + 20000000;
                }
                DigitoControl = numero.Substring(8, 1);
            }
            Numero = n;
        }

        /// <summary>
        /// En base al primer carácter del código, se obtiene el tipo de documento que se intenta
        /// comprobar
        /// </summary>
        /// <param name="letra">Primer carácter del número pasado</param>
        /// <returns>Tipo de documento</returns>
        private TiposCodigosEnum GetTipoDocumento(char letra)
        {
            Regex regexNumeros = new Regex("[0-9]");
            if (regexNumeros.IsMatch(letra.ToString()))
                return TiposCodigosEnum.NIF;

            Regex regexLetrasNIE = new Regex("[XYZ]");
            if (regexLetrasNIE.IsMatch(letra.ToString()))
                return TiposCodigosEnum.NIE;

            Regex regexLetrasCIF = new Regex("[ABCDEFGHJPQRSUVNW]");
            if (regexLetrasCIF.IsMatch(letra.ToString()))
                return TiposCodigosEnum.CIF;

            throw new ApplicationException("El código no es reconocible");
        }

        /// <summary>
        /// Eliminación de todos los carácteres no numéricos o de texto de la cadena
        /// </summary>
        /// <param name="numero">Número tal cual lo escribe el usuario</param>
        /// <returns>Cadena de 9 u 11 carácteres sin signos</returns>
        private string EliminaCaracteres(string numero)
        {
            // Todos los carácteres que no sean números o letras
            string caracteres = @"[^\w]";
            Regex regex = new Regex(caracteres);
            return regex.Replace(numero, "");
        }

        #endregion

        #region Cálculos

        private bool CompruebaNif()
        {
            return DigitoControl == GetLetraNif();
        }

        /// <summary>
        /// Cálculos para la comprobación del Cif (Entidad jurídica)
        /// </summary>
        private bool CompruebaCif()
        {
            string[] letrasCodigo = { "J", "A", "B", "C", "D", "E", "F", "G", "H", "I" };

            string n = Numero.ToString("0000000");
            Int32 sumaPares = 0;
            Int32 sumaImpares = 0;
            Int32 sumaTotal = 0;
            Int32 i = 0;
            //            string digitoCalculado;
            bool retVal = false;

            // Recorrido por todos los dígitos del número
            for (i = 0; i < n.Length; i++)
            {
                Int32 aux;
                Int32.TryParse(n[i].ToString(), out aux);

                if ((i + 1) % 2 == 0)
                {
                    // Si es una posición par, se suman los dígitos
                    sumaPares += aux;
                }
                else
                {
                    // Si es una posición impar, se multiplican los dígitos por 2 
                    aux = aux * 2;

                    // se suman los dígitos de la suma
                    sumaImpares += SumaDigitos(aux);
                }
            }
            // Se suman los resultados de los números pares e impares
            sumaTotal += sumaPares + sumaImpares;

            // Se obtiene el dígito de las unidades
            Int32 unidades = sumaTotal % 10;

            // Si las unidades son distintas de 0, se restan de 10
            if (unidades != 0)
                unidades = 10 - unidades;

            switch (LetraInicial)
            {
                // Sólo números
                case "A":
                case "B":
                case "E":
                case "H":
                    retVal = DigitoControl == unidades.ToString();
                    break;

                // Sólo letras
                case "K":
                case "P":
                case "Q":
                case "S":
                    retVal = DigitoControl == letrasCodigo[unidades];
                    break;

                default:
                    retVal = (DigitoControl == unidades.ToString())
                            || (DigitoControl == letrasCodigo[unidades]);
                    break;
            }

            return retVal;

        }

        /// <summary>
        /// Obtiene la suma de todos los dígitos
        /// </summary>
        /// <returns>de 23, devuelve la suma de 2 + 3</returns>
        private Int32 SumaDigitos(Int32 digitos)
        {
            string sNumero = digitos.ToString();
            Int32 suma = 0;

            for (Int32 i = 0; i < sNumero.Length; i++)
            {
                Int32 aux;
                Int32.TryParse(sNumero[i].ToString(), out aux);
                suma += aux;
            }
            return suma;
        }

        /// <summary>
        /// Obtiene la letra correspondiente al Dni
        /// </summary>
        private string GetLetraNif()
        {
            int indice = Numero % 23;
            return "TRWAGMYFPDXBNJZSQVHLCKET"[indice].ToString();
        }

        /// <summary>
        /// Obtiene una cadena con el número de identificación completo
        /// </summary>
        public override string ToString()
        {
            string nif;
            string formato = "{0:0000000}";

            if (tipo == TiposCodigosEnum.CIF && LetraInicial == "")
                formato = "{0:00000000}";
            if (tipo == TiposCodigosEnum.NIF)
                formato = "{0:00000000}";

            nif = EsIntraComunitario ? CodigoIntracomunitario :
                string.Empty + LetraInicial + string.Format(formato, Numero) + DigitoControl;
            return nif;
        }

        #endregion

        /// <summary>
        /// Comprobación de un número de identificación fiscal español
        /// </summary>
        /// <param name="numero">Numero a analizar</param>
        /// <returns>Instancia de <see cref="NumeroNif"/> con los datos del número.
        /// Destacable la propiedad <seealso cref="NumeroNif.EsCorrecto"/>, que contiene la verificación
        /// </returns>
        public static NumeroNif CompruebaNif(string numero)
        {
            return new NumeroNif(numero);
        }


    }
}