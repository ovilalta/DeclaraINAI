using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2.BLLD
{
    public class clsSistema
    {
        #region Atributos

        private System.Nullable<Int32> _nIdSistema { get; set; } = null;
        public Int32 nIdSistema
        {
            get
            {
                if (!_nIdSistema.HasValue)
                    _nIdSistema = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["nIdSistema"]);
                return _nIdSistema.Value;
            }
        }

        public static String V_SISTEMA => "Sistema de Declaraciones Patrimoniales DeclaraINAI";

        private static System.Nullable<Boolean> _ThrowUnhandledExceptions { get; set; }
        public static Boolean ThrowUnhandledExceptions
        {
            get
            {
                if (!_ThrowUnhandledExceptions.HasValue)
                    _ThrowUnhandledExceptions = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["ThrowUnhandledExceptions"]);
                return _ThrowUnhandledExceptions.Value;
            }
        }

        private static String _CustomLogsFolder { get; set; }
        public static String CustomLogsFolder
        {
            get
            {
                if (String.IsNullOrEmpty(_CustomLogsFolder))
                    _CustomLogsFolder = System.Configuration.ConfigurationManager.AppSettings["CustomLogsFolder"];
                return _CustomLogsFolder;
            }
        }

        private static String _URL_SISTEMA { get; set; }
        public static String URL_SISTEMA
        {
            get
            {
                if (String.IsNullOrEmpty(_URL_SISTEMA))
                    _URL_SISTEMA = System.Configuration.ConfigurationManager.AppSettings["URL_SISTEMA"];
                return _URL_SISTEMA;
            }
        }


        private static String _RUTA_CORREO_CONFIRMACION { get; set; }
        public static String RUTA_CORREO_CONFIRMACION
        {
            get
            {
                if (String.IsNullOrEmpty(_RUTA_CORREO_CONFIRMACION))
                    _RUTA_CORREO_CONFIRMACION = System.Configuration.ConfigurationManager.AppSettings["RUTA_CORREO_CONFIRMACION"];
                return _RUTA_CORREO_CONFIRMACION;
            }
        }

        private static String _RUTA_ACTIVACION_CORREO { get; set; }
        public static String RUTA_ACTIVACION_CORREO
        {
            get
            {
                if (String.IsNullOrEmpty(_RUTA_ACTIVACION_CORREO))
                    _RUTA_ACTIVACION_CORREO = System.Configuration.ConfigurationManager.AppSettings["RUTA_ACTIVACION_CORREO"];
                return _RUTA_ACTIVACION_CORREO;
            }
        }

        private static String _RUTA_RECUPERACION_PASS { get; set; }
        public static String RUTA_RECUPERACION_PASS
        {
            get
            {
                if (String.IsNullOrEmpty(_RUTA_RECUPERACION_PASS))
                    _RUTA_RECUPERACION_PASS = System.Configuration.ConfigurationManager.AppSettings["RUTA_RECUPERACION_PASS"];
                return _RUTA_RECUPERACION_PASS;
            }
        }

        private static System.Nullable<Boolean> _lActivaCaptcha { get; set; }
        public static Boolean lActivaCaptcha
        {
            get
            {
                if (!_lActivaCaptcha.HasValue)
                    _lActivaCaptcha = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["lActivaCaptcha"]);
                return _lActivaCaptcha.Value;
            }
        }

        private static String _MensajeInicial { get; set; }
        public static String MensajeInicial
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(_MensajeInicial))
                        _MensajeInicial = System.Configuration.ConfigurationManager.AppSettings["MensajeInicial"];
                    if (String.IsNullOrEmpty(_MensajeInicial.Trim()))
                        return String.Empty;
                    return _MensajeInicial;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

        private static String _CorreoSalida { get; set; }
        public static String CorreoSalida
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(_CorreoSalida))
                        _CorreoSalida = System.Configuration.ConfigurationManager.AppSettings["CorreoSalida"];
                    if (String.IsNullOrEmpty(_CorreoSalida.Trim()))
                        return String.Empty;
                    return _CorreoSalida;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

        private static String _ServidorCorreo { get; set; }
        public static String ServidorCorreo
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(_ServidorCorreo))
                        _ServidorCorreo = System.Configuration.ConfigurationManager.AppSettings["ServidorCorreo"];
                    if (String.IsNullOrEmpty(_ServidorCorreo.Trim()))
                        return String.Empty;
                    return _ServidorCorreo;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

        private static System.Nullable<Int32> _PuertoCorreo { get; set; }
        public static Int32 PuertoCorreo
        {
            get
            {
                try
                {
                    if (!_PuertoCorreo.HasValue)
                        _PuertoCorreo = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PuertoCorreo"]);
                    return _PuertoCorreo.Value;
                }
                catch
                {
                    return 0;
                }
            }
        }

        private static System.Nullable<Int32> _nMesBloqueoDeclaracion { get; set; }
        public static Int32 nMesBloqueoDeclaracion
        {
            get
            {
                try
                {
                    if (!_nMesBloqueoDeclaracion.HasValue)
                        _nMesBloqueoDeclaracion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["nMesBloqueoDeclaracion"]);
                    return _nMesBloqueoDeclaracion.Value;
                }
                catch
                {
                    return 4;
                }
            }
        }

        private static System.Nullable<Boolean> _lActivaAviso { get; set; }
        public static Boolean lActivaAviso
        {
            get
            {
                if (!_lActivaAviso.HasValue)
                    _lActivaAviso = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["MostrarAviso"]);
                return _lActivaAviso.Value;
            }
        }
        #endregion

        #region Constructores

        public clsSistema()
        {
        }

        #endregion

        #region metodos

        public static String get_parametro(String VID_PARAMETRO, Int32 NID_PARAMETRO)
        {
            return String.Empty;
        }

        #endregion

    }
}
