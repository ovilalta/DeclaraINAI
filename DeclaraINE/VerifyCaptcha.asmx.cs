using Declara_V2.BLLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;

namespace DeclaraINE
{
    /// <summary>
    /// Summary description for VerifyCaptcha
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VerifyCaptcha : System.Web.Services.WebService
    {

        protected static string ReCaptcha_Key => "6LfyBjYUAAAAADCz5C7cnc-pomCZQvEsXflv240W";
        protected static string ReCaptcha_Secret => "6LfyBjYUAAAAAC7okLUec0kAoGuFsStVMXIbx6YS";

        [WebMethod]
        public String Verify(string response)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + ReCaptcha_Secret + "&response=" + response;
            try
            {
                string retorno;
                retorno = (new WebClient()).DownloadString(url);
                return retorno;
            }
            catch (Exception EX)
            {
                System.IO.File.WriteAllText(String.Concat(clsSistema.CustomLogsFolder + DateTime.Now.Hour, '_', DateTime.Now.Minute, "_", DateTime.Now.Second, DateTime.Now.Millisecond, ".txt"), String.Concat(EX.Message, Environment.NewLine, EX.StackTrace));
                throw EX;
            }
        }
    }
}
