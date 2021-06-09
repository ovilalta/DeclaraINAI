using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Declara_V2.BLLD
{
    // Extended
    public partial class blld_USUARIO : bll_USUARIO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_USUARIO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_USUARIO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_USUARIO.VID_HOMOCLAVE; }
        //        }


        //        public String V_PASSWORD
        //        {
        //          get { return datos_USUARIO.V_PASSWORD; }
        //          set { datos_USUARIO.V_PASSWORD = value; }
        //        }


        //        public String V_NOMBRE
        //        {
        //          get { return datos_USUARIO.V_NOMBRE; }
        //          set { datos_USUARIO.V_NOMBRE = value; }
        //        }


        //        public String V_PRIMER_A
        //        {
        //          get { return datos_USUARIO.V_PRIMER_A; }
        //          set { datos_USUARIO.V_PRIMER_A = value; }
        //        }


        //        public String V_SEGUNDO_A
        //        {
        //          get { return datos_USUARIO.V_SEGUNDO_A; }
        //          set { datos_USUARIO.V_SEGUNDO_A = value; }
        //        }


        //        public DateTime F_NACIMIENTO
        //        {
        //          get { return datos_USUARIO.F_NACIMIENTO; }
        //          set { datos_USUARIO.F_NACIMIENTO = value; }
        //        }


        //        public String V_ACUSE
        //        {
        //          get { return datos_USUARIO.V_ACUSE; }
        //          set { datos_USUARIO.V_ACUSE = value; }
        //        }


        //        public Boolean L_ACTIVO
        //        {
        //          get { return datos_USUARIO.L_ACTIVO; }
        //          set { datos_USUARIO.L_ACTIVO = value; }
        //        }


        //        public System.Nullable<DateTime> F_INGRESO_INSTITUTO
        //        {
        //          get { return datos_USUARIO.F_INGRESO_INSTITUTO; }
        //          set { datos_USUARIO.F_INGRESO_INSTITUTO = value; }
        //        }


        //        public DateTime F_REGISTRO
        //        {
        //          get { return datos_USUARIO.F_REGISTRO; }
        //        }

        private Int32 _NID_SESION { get; set; }
        public Int32 NID_SESION => _NID_SESION;

        public Char C_GENERO => datos_USUARIO.C_GENERO;

        public string V_NOMBRE_COMPLETO => string.Concat(V_NOMBRE, ' ', V_PRIMER_A, ' ', V_SEGUNDO_A);

        new public Boolean L_ACTIVO => datos_USUARIO.L_ACTIVO;

        List<String> _CAT_AGNO;
        private string vID_USUARIO;
        private string v_PASSWORDActual;

        public List<string> CAT_AGNO
        {
            get
            {
                if (_CAT_AGNO is null)
                {
                    _CAT_AGNO = new List<string>();
                    _CAT_AGNO.Add(String.Empty);
                    for (int i = DateTime.Today.Year + 1; i >= 1900; i--)
                    {
                        _CAT_AGNO.Add(i.ToString());
                    }
                }
                return _CAT_AGNO;
            }
        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_USUARIO(String VID_USUARIO, String V_PASSWORD, Boolean L_PREENCRIPTADO)
        {
            Init(VID_USUARIO, V_PASSWORD, L_PREENCRIPTADO, "", "", 1);
            if (datos_USUARIO.V_PASSWORD.Equals(encriptaPass(datos_USUARIO.VID_NOMBRE + datos_USUARIO.VID_FECHA + datos_USUARIO.VID_HOMOCLAVE)))
            {
                CustomException x = new CustomException("La contraseña es igual al R.F.C.");

                x.Data.Add("CambiarPass", true);
                throw new CustomException("La contraseña es igual al R.F.C.", x);
            }
        }

        public blld_USUARIO(String VID_USUARIO, String V_PASSWORD, String V_IP, String V_Maquina, int Control)
        {
            Init(VID_USUARIO, V_PASSWORD, false, V_IP, V_Maquina, Control);
            if (datos_USUARIO.V_PASSWORD.Equals(encriptaPass(datos_USUARIO.VID_NOMBRE + datos_USUARIO.VID_FECHA + datos_USUARIO.VID_HOMOCLAVE)))
            {
                CustomException x = new CustomException("La contraseña es igual al R.F.C.");
                x.Data.Add("CambiarPass", true);
                throw new CustomException("La contraseña es igual al R.F.C.", x);
            }
        }

        public blld_USUARIO(String VID_USUARIO)
        {
            Init(VID_USUARIO, "x", false, "", "", 1);
        }

        internal void Init(String VID_USUARIO, String V_PASSWORD, Boolean L_PREENCRIPTADO, String V_IP, String V_Maquina, int Control)
        {
            VID_USUARIO = FormateaUsuario(VID_USUARIO);
            VID_USUARIO = VID_USUARIO.Trim();
            V_PASSWORD = V_PASSWORD.Trim();

            if (String.IsNullOrEmpty(VID_USUARIO) || String.IsNullOrEmpty(V_PASSWORD))
            {
                throw new CustomException("Los campos no pueden ser vacios");
            }
            String VID_NOMBRE = String.Empty;
            String VID_FECHA = String.Empty;
            String VID_HOMOCLAVE = String.Empty;
            try
            {
                VID_NOMBRE = VID_USUARIO.Substring(0, 4);
                VID_FECHA = VID_USUARIO.Substring(4, 6);
                VID_HOMOCLAVE = VID_USUARIO.Substring(10, 3);
                datos_USUARIO = new dald_USUARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
            }
            catch
            {
            }

            if (String.IsNullOrEmpty(datos_USUARIO.VID_NOMBRE))
            {
                blld__l_USUARIO_CORREO oListaCorreo = new blld__l_USUARIO_CORREO();
                oListaCorreo.V_CORREO = new StringFilter(VID_USUARIO);
                oListaCorreo.select();
                if (oListaCorreo.lista_USUARIO_CORREO.Count == 1)
                {
                    datos_USUARIO = new dald_USUARIO(
                                                      oListaCorreo.lista_USUARIO_CORREO[0].VID_NOMBRE,
                                                      oListaCorreo.lista_USUARIO_CORREO[0].VID_FECHA,
                                                      oListaCorreo.lista_USUARIO_CORREO[0].VID_HOMOCLAVE
                                                    );
                }
                else
                {
                    throw new ArgumentException("El nombre de usuario y/o contraseña no son correctos");
                }
            }

            if (String.IsNullOrEmpty(datos_USUARIO.VID_NOMBRE))
            {
                throw new ArgumentException("El nombre de usuario y/o contraseña no son correctos");
            }

            else
            {
                if (!datos_USUARIO.L_ACTIVO)
                    throw new ArgumentException("El usuario está desactivado");
                if (V_PASSWORD != "x")
                {
                    if (L_PREENCRIPTADO)
                    {
                    }
                    else
                    {
                        V_PASSWORD = encriptaPass(V_PASSWORD);
                    }
                    if (!datos_USUARIO.V_PASSWORD.Equals(V_PASSWORD))
                    {
                        datos_USUARIO = null;
                        throw new ArgumentException("El nombre de usuario y/o contraseña no son correctos");
                    }
                }
                blld_USUARIO_SESION sesion = new blld_USUARIO_SESION(this.VID_NOMBRE
                                                                 , this.VID_FECHA
                                                                 , this.VID_HOMOCLAVE
                                                                 , V_IP
                                                                 , V_Maquina
                                                                 , System.DateTime.Now
                                                                 , System.DateTime.Now.AddMinutes(25)

                );
                this._NID_SESION = sesion.NID_SESION;
            }
        }



        public blld_USUARIO(String VID_USUARIO, String V_PASSWORDActual, String V_PASSWORDNuevo, String V_PASSWORDConfirmacion)
        {
            try
            {
                blld_USUARIO o = new blld_USUARIO(VID_USUARIO, V_PASSWORDActual, false);
            }
            catch (Exception ex)
            {
                if (ex is CustomException && ex.InnerException != null)
                {
                    if (ex.InnerException is CustomException && ex.InnerException.Data.Contains("CambiarPass"))
                    {
                        Init(VID_USUARIO, V_PASSWORDActual, false, "", "", 1);
                        ActualizarContraseña(V_PASSWORDActual, V_PASSWORDNuevo, V_PASSWORDConfirmacion);
                    }
                    else
                    {
                        throw ex;
                    }
                }
                else
                {
                    throw ex;
                }
            }
        }

        public blld_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_PASSWORD, String V_NOMBRE, String V_PRIMER_A, String V_SEGUNDO_A, DateTime F_NACIMIENTO, String V_CORREO, DateTime F_INGRESO_INSTITUTO, Boolean NVO_INGRESO, Boolean OBL_DECLARACION)
      : base()
        {
            if (F_NACIMIENTO > DateTime.Today)
                throw new CustomException(String.Concat("La fecha de nacimiento no puede ser mayor que ", (DateTime.Today).ToString("dd/MMMM/yyy", new CultureInfo("es-MX")).ToUpper()));

            if (F_INGRESO_INSTITUTO > DateTime.Today)
                throw new CustomException(String.Concat("La fecha de ingreso no puede ser mayor que ", (DateTime.Today).ToString("dd/MMMM/yyy", new CultureInfo("es-MX")).ToUpper()));

            VID_NOMBRE = VID_NOMBRE.ToUpper();
            VID_HOMOCLAVE = VID_HOMOCLAVE.ToUpper();

            String V_ACUSE = String.Empty;

            String RFCCalculado = RFC.CalcularRFC(V_NOMBRE
                              , V_PRIMER_A
                              , V_SEGUNDO_A
                              , F_NACIMIENTO);

            if (VID_NOMBRE.Length != 4 ||
                VID_FECHA.Length != 6 ||
                VID_HOMOCLAVE.Length != 3)
                throw new CustomException("La longitud del RFC debe ser exactamente 13");

            String V_RFC = String.Concat(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);

            //IF ingresado por OEVM buscando generar la excepción por el RFC que no reconoce el sistema como válido
            //if (!V_RFC.Equals("CAGT780524LU7")){


            string line;
            bool excep = false;
            var buildDir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.AppDomain.CurrentDomain.RelativeSearchPath ?? "");
            var filePath = buildDir + @"\ExcepcionesRFC.txt";
            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                if (V_RFC.Equals(line))
                {
                    excep = true;
                }
            }

            file.Close();

            if (excep == false)
            {
                if (!V_RFC.Equals(RFCCalculado))
                    throw new CustomException("El R.F.C. no coincide con la validación automatica de los datos proporcionados, por favor verifique el Nombre, Apellidos, Fecha de Nacimiento y R.F.C");
            }



            if (dald_USUARIO_CORREO.ExisteCorreo(V_CORREO))
                throw new CustomException("El correo electrónico ya esta siendo utilizado, capture uno diferente");

            Boolean L_ACTIVO = false;
            V_ACUSE = CalculaAcuse(String.Concat(V_NOMBRE, V_PRIMER_A, V_SEGUNDO_A, this.F_REGISTRO));
            datos_USUARIO = new dald_USUARIO(VID_NOMBRE.ToUpper(), VID_FECHA, VID_HOMOCLAVE.ToUpper(), encriptaPass(V_PASSWORD), V_NOMBRE.ToUpper(), V_PRIMER_A.ToUpper(), V_SEGUNDO_A.ToUpper(), F_NACIMIENTO, V_ACUSE, L_ACTIVO, F_INGRESO_INSTITUTO, NVO_INGRESO, OBL_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException); ;
            Add_USUARIO_CORREOs(V_CORREO, false);

            this.update();
        }
        public blld_USUARIO(Boolean Dif, String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_NOMBRE, String V_PRIMER_A, String V_SEGUNDO_A, DateTime F_NACIMIENTO, String V_CORREO, DateTime F_INGRESO_INSTITUTO)
          : base()
        {
            String V_PASSWORD = String.Concat(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE).ToUpper();

            if (F_NACIMIENTO > DateTime.Today)
                throw new CustomException(String.Concat("La fecha de nacimiento no puede ser mayor que ", (DateTime.Today).ToString("dd/MMMM/yyy", new CultureInfo("es-MX")).ToUpper()));

            if (F_INGRESO_INSTITUTO > DateTime.Today)
                throw new CustomException(String.Concat("La fecha de ingreso no puede ser mayor que ", (DateTime.Today).ToString("dd/MMMM/yyy", new CultureInfo("es-MX")).ToUpper()));

            VID_NOMBRE = VID_NOMBRE.ToUpper();
            VID_HOMOCLAVE = VID_HOMOCLAVE.ToUpper();

            String V_ACUSE = String.Empty;

            String RFCCalculado = RFC.CalcularRFC(V_NOMBRE
                              , V_PRIMER_A
                              , V_SEGUNDO_A
                              , F_NACIMIENTO);


            if (VID_NOMBRE.Length != 4 ||
                VID_FECHA.Length != 6 ||
                VID_HOMOCLAVE.Length != 3)
                throw new CustomException("La longitud del RFC debe ser exactamente 13");

            String V_RFC = String.Concat(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);

            //IF ingresado por OEVM buscando generar la excepción por el RFC que no reconoce el sistema como válido
            string line;
            bool excep = false;
            var buildDir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.AppDomain.CurrentDomain.RelativeSearchPath ?? "");
            var filePath = buildDir + @"\ExcepcionesRFC.txt";
            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                if (V_RFC.Equals(line))
                {
                    excep = true;
                }
            }

            file.Close();

            if (excep == false)
            {
                if (!V_RFC.Equals(RFCCalculado))
                    throw new CustomException("El R.F.C. no coincide con la validación automatica de los datos proporcionados, por favor verifique el Nombre, Apellidos, Fecha de Nacimiento y R.F.C");
            }

            if (dald_USUARIO_CORREO.ExisteCorreo(V_CORREO))
                throw new CustomException("El correo electrónico ya esta siendo utilizado, capture uno diferente");

            Boolean L_ACTIVO = false;
            V_ACUSE = CalculaAcuse(String.Concat(V_NOMBRE, V_PRIMER_A, V_SEGUNDO_A, this.F_REGISTRO));
            datos_USUARIO = new dald_USUARIO(VID_NOMBRE.ToUpper(), VID_FECHA, VID_HOMOCLAVE.ToUpper(), encriptaPass(V_PASSWORD), V_NOMBRE.ToUpper(), V_PRIMER_A.ToUpper(), V_SEGUNDO_A.ToUpper(), F_NACIMIENTO, V_ACUSE, L_ACTIVO, F_INGRESO_INSTITUTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
            Add_USUARIO_CORREOs(V_CORREO, false);

            this.update();
        }

        public blld_USUARIO(string vID_USUARIO, string v_PASSWORDActual)
        {
            this.vID_USUARIO = vID_USUARIO;
            this.v_PASSWORDActual = v_PASSWORDActual;
        }


        #endregion


        #region *** Metodos (Extended) ***

        public void ExtenderSesion()
        {
            blld_USUARIO_SESION o = new blld_USUARIO_SESION(this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_SESION);
            o.F_FIN = DateTime.Now.AddMinutes(25);
            o.update();
        }

        public void FinalizarSesion()
        {
            blld_USUARIO_SESION o = new blld_USUARIO_SESION(this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_SESION);
            o.F_FIN = DateTime.Now.AddMinutes(-1);
            o.update();
            datos_USUARIO = null;
        }

        private String FormateaUsuario(string vID_USUARIO)
        {
            String retorno = vID_USUARIO;
            Boolean lEsRFC = true;

            if (vID_USUARIO.Length == 13 && !vID_USUARIO.Contains(".") && !vID_USUARIO.Contains("@"))
            {
                for (int x = 0; x <= 3; x++)
                {
                    if (!Char.IsLetter(vID_USUARIO[x]))
                    {
                        lEsRFC = false;
                        break;
                    }
                }

                for (int x = 4; x <= 9; x++)
                {
                    if (!Char.IsNumber(vID_USUARIO[x]))
                    {
                        lEsRFC = false;
                        break;
                    }
                }
            }
            else
            {
                lEsRFC = false;
            }

            if (lEsRFC)
                return vID_USUARIO;
            else
            {
                if (!vID_USUARIO.Contains("@"))
                {
                    retorno = retorno + "@inai.org.mx";
                }

                return retorno;
            }
        }

        public static blld_USUARIO_REC_PASS ActualizarPassCodigoRecuperacion(blld_USUARIO_REC_PASS oRecuperacion, String V_CODIGO, String vPassword, String vConfirmacion)
        {
            if (oRecuperacion.F_SOLICITUD > DateTime.Now.AddHours(36))
            {
                oRecuperacion.delete();
                throw new CustomException("El código ha caducado, vuelva a solicitar la recuperación de contraseña");
            }

            if (!V_CODIGO.Equals(blld_USUARIO_REC_PASS.encriptarCodigo(oRecuperacion.VID_NOMBRE, oRecuperacion.VID_FECHA, oRecuperacion.VID_HOMOCLAVE, oRecuperacion.V_CORREO)))
            {
                oRecuperacion.N_USOS++;
                throw new CustomException("El código de recuperación es incorrecto");
            }

            if (String.IsNullOrEmpty(vPassword))
                throw new CustomException("La contraseña no puede ser vacia");

            blld_USUARIO oUsuario = new blld_USUARIO(oRecuperacion.VID_NOMBRE, oRecuperacion.VID_FECHA, oRecuperacion.VID_HOMOCLAVE);
            oUsuario.ActualizarContraseña(vPassword, vConfirmacion);
            oRecuperacion.Clear();
            return oRecuperacion;
        }

        internal void ActualizarContraseña(String PasswordNuevo, String PasswordConfirmacion)
        {
            if (PasswordNuevo.Trim() != PasswordConfirmacion.Trim())
                throw new CustomException("La contraseña no coincide con la confirmación");

            datos_USUARIO.V_PASSWORD = encriptaPass(PasswordNuevo.Trim());
            datos_USUARIO.update();
        }

        public void ActualizarContraseña(String PasswordActual, String PasswordNuevo, String PasswordConfirmacion)
        {
            if (!datos_USUARIO.V_PASSWORD.Equals(encriptaPass(PasswordActual)))
                throw new CustomException("El nombre de usuario y/o contraseña no son correctos");

            if (datos_USUARIO.V_PASSWORD.Equals(encriptaPass(PasswordActual)) == datos_USUARIO.V_PASSWORD.Equals(encriptaPass(PasswordNuevo)))
                throw new CustomException("La nueva contraseña debe ser distinta a la anterior");

            ActualizarContraseña(PasswordNuevo, PasswordConfirmacion);
        }

        private string CalculaAcuse(String str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
            Byte[] encodedBytes = md5.Hash;
            string Hash = BitConverter.ToString(encodedBytes);
            string[] ArrayHash = Hash.Split('-');
            System.Text.StringBuilder Suple = new System.Text.StringBuilder();
            for (int i = 0; i < ArrayHash.Length; i++)
            {
                Suple.Append(ArrayHash[i]);
            }

            return Suple.ToString();
        }

        private static string encriptaPass(string V_PASSWORD)
        {
            String strOverride = "QRTdj+mlvOfANfeIq";
            String strEncodedUser = String.Empty;
            String strEncodedUserAux = String.Empty;
            System.Security.Cryptography.SHA512 sha512 = System.Security.Cryptography.SHA512Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] stream = null;
            Byte[] byt = null;
            StringBuilder sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(String.Concat(V_PASSWORD, strOverride)));
            for (int x = 0; x < stream.Length; x++) sb.AppendFormat("{0:x2}", stream[x]);
            byt = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            strEncodedUser = Convert.ToBase64String(byt);
            foreach (char character in strEncodedUser) strEncodedUserAux += ((Char)(character + (Char)3)).ToString();
            strEncodedUser = strEncodedUserAux;
            strEncodedUserAux = null;
            sb = null;
            stream = null;
            sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(String.Concat(strEncodedUser, strOverride)));
            for (int x = 0; x < stream.Length; x++) sb.AppendFormat("{0:x2}", stream[x]);
            return sb.ToString().ToUpper();
        }

        public void Reload_CONFLICTOs()
        {
            _Reload_CONFLICTOs();
        }

        public void Add_CONFLICTOs(Int32 NID_CONFLICTO, Int32 NID_DEC_ASOS)
        {
            try
            {
                _Add_CONFLICTOs(NID_CONFLICTO, NID_DEC_ASOS);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public void Reload_PATRIMONIOs()
        {
            _Reload_PATRIMONIOs();
        }

        public void Add_PATRIMONIOs(Int32 NID_PATRIMONIO, Int32 NID_TIPO, Decimal M_VALOR, Int32 NID_DEC_INCOR, DateTime F_INCORPORACION, Int32 NID_DEC_ULT_MOD, DateTime F_MODIFICACION, Boolean L_ACTIVO, DateTime F_REGISTRO)
        {
            try
            {
                _Add_PATRIMONIOs(NID_PATRIMONIO, NID_TIPO, M_VALOR, NID_DEC_INCOR, F_INCORPORACION, NID_DEC_ULT_MOD, F_MODIFICACION, L_ACTIVO, F_REGISTRO);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public void Reload_USUARIO_DOMICILIOs()
        {
            _Reload_USUARIO_DOMICILIOs();
        }

        public void Add_USUARIO_DOMICILIOs(Int32 NID_DOMICILIO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String C_CODIGO_POSTAL, String E_DIRECCION, Int32 NID_TIPO_DOMICILIO, Boolean L_ACTIVO)
        {
            try
            {
                _Add_USUARIO_DOMICILIOs(NID_DOMICILIO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, C_CODIGO_POSTAL, E_DIRECCION, NID_TIPO_DOMICILIO, L_ACTIVO);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public void Reload_USUARIO_CORREOs()
        {
            _Reload_USUARIO_CORREOs();
        }

        public void Add_USUARIO_CORREOs(String V_CORREO, Boolean lEnviaConfirmacion)
        {
            try
            {
                _Add_USUARIO_CORREOs(V_CORREO.ToLower(), lEnviaConfirmacion);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public void Add_USUARIO_CORREOs(String V_CORREO, Boolean lEnviaConfirmacion, Boolean confirmado)
        {
            try
            {
                _Add_USUARIO_CORREOs(V_CORREO.ToLower(), lEnviaConfirmacion, confirmado);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public void Reload_DECLARACIONs()
        {
            _Reload_DECLARACIONs();
        }

        //public void Add_DECLARACIONs(Int32 NID_DECLARACION, String C_EJERCICIO, Int32 NID_TIPO_DECLARACION, Int32 NID_ESTADO, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, Boolean L_AUTORIZA_PUBLICAR, DateTime F_REGISTRO, DateTime F_ENVIO, Boolean L_CONFLICTO)
        //{
        //    try
        //    {
        //        _Add_DECLARACIONs(NID_DECLARACION, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_REGISTRO, F_ENVIO, L_CONFLICTO);
        //    }
        //    catch (Exception e)
        //    {
        //        //if (e is ExistingPrimaryKeyException)
        //        //{
        //        //    ///Codigo Para Controlar la Excepcion de clave primaria existente
        //        //}
        //        //else
        //        //{
        //        //    throw e;
        //        //}
        //        throw e;
        //    }
        //}

        public void Reload_USUARIO_SESIONs()
        {
            _Reload_USUARIO_SESIONs();
        }

        public void Add_USUARIO_SESIONs(Int32 NID_SESION, String V_IP, String V_MAQUINA_USUARIO, DateTime F_INICIO, DateTime F_FIN)
        {
            try
            {
                _Add_USUARIO_SESIONs(NID_SESION, V_IP, V_MAQUINA_USUARIO, F_INICIO, F_FIN);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public void Reload_USUARIO_REC_PASSs()
        {
            _Reload_USUARIO_REC_PASSs();
        }

        public void Add_USUARIO_REC_PASSs(String V_CORREO, Int32 N_USOS, DateTime F_SOLICITUD)
        {
            try
            {
                _Add_USUARIO_REC_PASSs(V_CORREO, N_USOS, F_SOLICITUD);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public void principal(string v_CORREO)
        {
            datos_USUARIO.principal(v_CORREO);
        }



        public void CorreoConfirmado(String V_CORREO)
        {
            blld_USUARIO_CORREO CorreoConf = new blld_USUARIO_CORREO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO);

            if (dald_USUARIO_CORREO.CorreoActivo(V_CORREO))
            {

                if (!dald_USUARIO_CORREO.CorreoConfirmado(V_CORREO))
                {

                    CorreoConf.ReConfirmarCorreo(V_CORREO);
                    throw new CustomException("Se envió un correo de activación a: " + V_CORREO);
                }

            }
            else
                throw new CustomException("El correo electrónico debe estar activo para poder confirmarlo");
        }

        public bool CorreoActivoEstado(String V_CORREO)
        {
            if (dald_USUARIO_CORREO.CorreoActivo(V_CORREO))
            {
                return true;
            }
            else
                return false;
        }

        //public void CorreoActivo(String V_CORREO)
        //{
        //    blld_USUARIO_CORREO CorreoAct = new blld_USUARIO_CORREO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO);

        //    if (!dald_USUARIO_CORREO.CorreoActivo(V_CORREO))
        //    {
        //        CorreoAct.L_ACTIVO = true;
        //        CorreoAct.L_CONFIRMADO = false;
        //        CorreoAct.update();

        //        blld_USUARIO_CORREO CorreoConf = new blld_USUARIO_CORREO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO);
        //        CorreoConf.ReConfirmarCorreo(V_CORREO);
        //        throw new CustomException("Correo electrónico activo, se envió un correo de confirmación a <b> " + V_CORREO + " </b>. <br/> Después de confirmarlo actualiza esta página para consultar el estado");
        //    }
        //    else
        //    {
        //        CorreoAct.L_ACTIVO = false;
        //        CorreoAct.L_CONFIRMADO = false;
        //        CorreoAct.update();
        //        throw new CustomException("Correo electrónico desactivado");
        //    }
        //}


        public void RestableceContraseña()
        {
            this.V_PASSWORD = encriptaPass(VID_NOMBRE + VID_FECHA + VID_HOMOCLAVE);
            this.update();
        }


        public void Activar(String V_CORREO, String V_CODIGO)
        {
            if (L_ACTIVO)
                throw new CustomException("El registro ya ha sido activado");

            blld_USUARIO_CORREO oCorreo = new blld_USUARIO_CORREO
                      (
                       VID_NOMBRE
                       , VID_FECHA
                       , VID_HOMOCLAVE
                       , V_CORREO
                       );
            if (oCorreo.L_CONFIRMADO)
                throw new CustomException("El correo electrónico ya ha sido activado");
            if (dald_USUARIO_CORREO.ExisteCorreo(V_CORREO))
                throw new CustomException("El correo electrónico ya ha sido activado en una cuenta diferente");
            if (!V_CODIGO.Equals(blld_USUARIO_REC_PASS.encriptarCodigo(this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, oCorreo.N_CODIGO.ToString())))
                throw new CustomException("Existe un problema con los datos de validación");
            datos_USUARIO.L_ACTIVO = true;
            update();
            oCorreo.Activar(V_CODIGO);
            oCorreo.Clear();
        }

        public void ActivarAdmin(string RFC)
        {
            if (L_ACTIVO)
                throw new CustomException("El RFC: " + RFC + " ya se encontraba activado.");

            datos_USUARIO.L_ACTIVO = true;
           
            update();
        }

        public void Desactivar()
        {
            foreach (blld_USUARIO_CORREO correo in USUARIO_CORREOs)
            {
                correo.DesActivar();
            }
            datos_USUARIO.L_ACTIVO = false;
            update();
        }

        //public void Activar()
        //{
        //    datos_USUARIO.L_ACTIVO = true;
        //    update();
        //}

        #endregion

    }
}
