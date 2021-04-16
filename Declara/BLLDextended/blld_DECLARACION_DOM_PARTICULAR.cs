using Declara_V2.BLL;
using Declara_V2.DALD;
using Declara_V2.Exceptions;
using Declara_V2.MODELextended;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Declara_V2.BLLD
{
    // Extended
    public partial class blld_DECLARACION_DOM_PARTICULAR : bll_DECLARACION_DOM_PARTICULAR
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_DECLARACION_DOM_PARTICULAR.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_DECLARACION_DOM_PARTICULAR.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_DECLARACION_DOM_PARTICULAR.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_DECLARACION_DOM_PARTICULAR.NID_DECLARACION; }
        //        }


        //        public String C_CODIGO_POSTAL
        //        {
        //          get { return datos_DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTAL; }
        //          set { datos_DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTAL = value; }
        //        }


        new public Int32 NID_PAIS
        {
            get => datos_DECLARACION_DOM_PARTICULAR.NID_PAIS;
            set
            {
                if (!value.Equals(datos_DECLARACION_DOM_PARTICULAR.NID_PAIS))
                {
                    datos_DECLARACION_DOM_PARTICULAR.oPais = null;
                    datos_DECLARACION_DOM_PARTICULAR.oEntidad = null;
                    datos_DECLARACION_DOM_PARTICULAR.oMunicipio = null;
                }
                datos_DECLARACION_DOM_PARTICULAR.NID_PAIS = value;
            }
        }


        new public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA;
            set
            {
                if (!value.Equals(datos_DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA))
                {
                    datos_DECLARACION_DOM_PARTICULAR.oEntidad = null;
                    datos_DECLARACION_DOM_PARTICULAR.oMunicipio = null;
                }
                datos_DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA = value;
            }
        }


        public String V_ENTIDAD_FEDERATIVA
        {
            get => datos_DECLARACION_DOM_PARTICULAR.V_ENTIDAD_FEDERATIVA;
            set
            {
                if (!value.Equals(datos_DECLARACION_DOM_PARTICULAR.V_ENTIDAD_FEDERATIVA))
                {
                    datos_DECLARACION_DOM_PARTICULAR.oEntidad = null;
                    datos_DECLARACION_DOM_PARTICULAR.oMunicipio = null;
                }
                datos_DECLARACION_DOM_PARTICULAR.V_ENTIDAD_FEDERATIVA = value;
            }
        }


        public String V_MUNICIPIO
        {
            get => datos_DECLARACION_DOM_PARTICULAR.V_MUNICIPIO;
            set
            {
                if (!value.Equals(datos_DECLARACION_DOM_PARTICULAR.V_MUNICIPIO))
                {
                    datos_DECLARACION_DOM_PARTICULAR.oEntidad = null;
                    datos_DECLARACION_DOM_PARTICULAR.oMunicipio = null;
                }
                datos_DECLARACION_DOM_PARTICULAR.V_MUNICIPIO = value;
            }
        }

        new public String CID_MUNICIPIO
        {
            get => datos_DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO;
            set
            {
                if (!value.Equals(datos_DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO))
                    datos_DECLARACION_DOM_PARTICULAR.oMunicipio = null;
                datos_DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO = value;
            }
        }


        [StringLength(255)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String V_COLONIA
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DOM_PARTICULAR.V_COLONIA))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DOM_PARTICULAR.V_COLONIA);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DOM_PARTICULAR.V_COLONIA = String.Empty;
                else
                    datos_DECLARACION_DOM_PARTICULAR.V_COLONIA = Encripta(value);
            }
        }

        [StringLength(2048)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String V_DOMICILIO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIO))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIO);
            }
            private set
            {
                if (lValidaLongitudDomicilio)
                {
                    if (value.Trim().Length < 0)
                        throw new CustomException("La longitud del domicilio debe ser por lo menos de 8 caractéres");
                    else
                        datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIO = Encripta(value.Trim());
                }
                else
                {
                    if (String.IsNullOrEmpty(value.Trim()))
                        datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIO = String.Empty;
                    else
                        datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIO = Encripta(value.Trim());
                }
            }
        }

        private Boolean lValidaLongitudDomicilio { get; set; } = true;
        private String _V_CALLE { get; set; }
        public String V_CALLE
        {
            get
            {
                if (_V_CALLE == null)
                {
                    if ((V_DOMICILIO.Split('|').Length - 1) != 2)
                    {
                        lValidaLongitudDomicilio = false;
                        V_DOMICILIO = String.Concat(String.Empty, '|', String.Empty, '|', String.Empty);
                        return String.Empty;
                    }
                    _V_CALLE = V_DOMICILIO.Split('|')[0];
                    return _V_CALLE;
                }
                else
                {
                    return _V_CALLE;
                }
            }
            set
            {
                if (value == null)
                {
                    _V_CALLE = String.Empty;
                }
                else
                {
                    _V_CALLE = value.Replace("|", String.Empty);
                    V_DOMICILIO = String.Concat(_V_CALLE, '|', _V_NUMERO_INTERNO, '|', _V_NUMERO_EXTERNO);
                }
            }
        }
        private String _V_NUMERO_INTERNO { get; set; }
        public String V_NUMERO_INTERNO
        {
            get
            {
                if (_V_NUMERO_INTERNO == null)
                {
                    if ((V_DOMICILIO.Split('|').Length - 1) != 2)
                        return String.Empty;
                    _V_NUMERO_INTERNO = V_DOMICILIO.Split('|')[1];
                    return _V_NUMERO_INTERNO;
                }
                else
                {
                    return _V_NUMERO_INTERNO;
                }
            }
            set
            {
                if (value == null)
                {
                    _V_NUMERO_INTERNO = String.Empty;
                }
                else
                {
                    _V_NUMERO_INTERNO = value.Replace("|", String.Empty);
                    V_DOMICILIO = String.Concat(_V_CALLE, '|', _V_NUMERO_INTERNO, '|', _V_NUMERO_EXTERNO);
                }
            }
        }

        private String _V_NUMERO_EXTERNO { get; set; }
        public String V_NUMERO_EXTERNO
        {
            get
            {
                if (_V_NUMERO_EXTERNO == null)
                {
                    if ((V_DOMICILIO.Split('|').Length - 1) != 2)
                        return String.Empty;
                    _V_NUMERO_EXTERNO = V_DOMICILIO.Split('|')[2];
                    return _V_NUMERO_EXTERNO;
                }
                else
                {
                    return _V_NUMERO_EXTERNO;
                }
            }
            set
            {
                if (value == null)
                {
                    _V_NUMERO_EXTERNO = String.Empty;
                }
                else
                {
                    _V_NUMERO_EXTERNO = value.Replace("|", String.Empty);
                    V_DOMICILIO = String.Concat(_V_CALLE, '|', _V_NUMERO_INTERNO, '|', _V_NUMERO_EXTERNO);
                }
            }
        }

        [StringLength(511)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String V_CORREO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DOM_PARTICULAR.V_CORREO))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DOM_PARTICULAR.V_CORREO);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DOM_PARTICULAR.V_CORREO = String.Empty;
                else
                    datos_DECLARACION_DOM_PARTICULAR.V_CORREO = Encripta(value);
            }
        }

        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String V_TEL_PARTICULAR
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR = String.Empty;
                else
                    datos_DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR = Encripta(value);
            }
        }

        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String V_TEL_CELULAR
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR = String.Empty;
                else
                    datos_DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR = Encripta(value);
            }
        }


        public String V_PAIS => datos_DECLARACION_DOM_PARTICULAR.V_PAIS;


        new public String E_OBSERVACIONES
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES = String.Empty;
                else
                    datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES = Encripta(value);
            }
        }
        new public String E_OBSERVACIONES_MARCADO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES_MARCADO))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES_MARCADO);
            }
            set
            {
                ValidarEstadoTestado(NID_ESTADO_TESTADO);

                if (String.IsNullOrEmpty(value.Trim().Trim('|').Trim('|')))
                {
                    datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES_MARCADO = String.Empty;
                    datos_DECLARACION_DOM_PARTICULAR.V_OBSERVACIONES_TESTADO = String.Empty;
                }
                else
                {
                    datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES_MARCADO = Encripta(value);
                    datos_DECLARACION_DOM_PARTICULAR.V_OBSERVACIONES_TESTADO = Testa(value);

                }
            }
        }



        new public String V_OBSERVACIONES_TESTADO => String.IsNullOrEmpty(datos_DECLARACION_DOM_PARTICULAR.V_OBSERVACIONES_TESTADO) ? String.Empty : datos_DECLARACION_DOM_PARTICULAR.V_OBSERVACIONES_TESTADO.Replace("¦", "█");


        #endregion


        #region *** Constructores (Extended) ***

        public blld_DECLARACION_DOM_PARTICULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_CALLE, String V_NUMERO_EXTERNO, String V_NUMERO_INTERNO, String V_CORREO, String V_TEL_PARTICULAR, String V_TEL_CELULAR, String E_OBSERVACIONES, String V_ENTIDAD_FEDERATIVA, String V_MUNICIPIO)
   : base()
        {
            if (!String.IsNullOrEmpty(V_COLONIA)) V_COLONIA = Encripta(V_COLONIA);

            if (!String.IsNullOrEmpty(V_CORREO)) V_CORREO = Encripta(V_CORREO);
            if (!String.IsNullOrEmpty(V_TEL_CELULAR)) V_TEL_CELULAR = Encripta(V_TEL_CELULAR);
            if (!String.IsNullOrEmpty(V_TEL_PARTICULAR)) V_TEL_PARTICULAR = Encripta(V_TEL_PARTICULAR);
            //if (V_DOMICILIO.Length < 8)
            //    throw new CustomException("La longitud del domicilio debe ser por lo menos de 8 caractéres");
            if (!String.IsNullOrEmpty(V_DOMICILIO)) V_DOMICILIO = Encripta(V_DOMICILIO);
            this.E_OBSERVACIONES = E_OBSERVACIONES;
            String E_OBSERVACIONES_MARCADO = null;
            String E_OBSERVACIONES_TESTADO = null;
            Int32 NID_ESTADO_TESTADO = 0;
            this.V_CALLE = V_CALLE;
            this.V_NUMERO_EXTERNO = V_NUMERO_EXTERNO;
            this.V_NUMERO_INTERNO = V_NUMERO_INTERNO;
            this.V_ENTIDAD_FEDERATIVA = V_ENTIDAD_FEDERATIVA;
            this.V_MUNICIPIO = V_MUNICIPIO;
            datos_DECLARACION_DOM_PARTICULAR = new dald_DECLARACION_DOM_PARTICULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIO, V_CORREO, V_TEL_PARTICULAR, V_TEL_CELULAR, datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, E_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, V_ENTIDAD_FEDERATIVA, V_MUNICIPIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting);
        }



        public void GuardarDireccion(String V_ENTIDAD_FEDERATIVA, String V_MUNICIPIO)
        {
            DECLARACION_DOM_PARTICULAR registro = new DECLARACION_DOM_PARTICULAR();
            //        blld_DECLARACION_DOM_PARTICULAR oDep = new blld_DECLARACION_DOM_PARTICULAR();

            // registro.VID_NOMBRE = VID_NOMBRE;
            //registro.VID_FECHA = VID_FECHA;
            //registro.VID_HOMOCLAVE = VID_HOMOCLAVE;
            //registro.NID_DECLARACION = NID_DECLARACION;
            //registro.V_ENTIDAD_FEDERATIVA = V_ENTIDAD_FEDERATIVA;
            // registro.V_MUNICIPIO = V_MUNICIPIO;


            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();

            MODELDeclara_V2.DECLARACION_DOM_PARTICULAR oDep = ((from p in db.DECLARACION_DOM_PARTICULAR
                                                                where p.VID_NOMBRE == VID_NOMBRE &&
                                                                      p.VID_FECHA == VID_FECHA &&
                                                                      p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                                                      p.NID_DECLARACION == NID_DECLARACION
                                                                select p).First());
            oDep.V_ENTIDAD_FEDERATIVA = V_ENTIDAD_FEDERATIVA;
            oDep.V_MUNICIPIO = V_MUNICIPIO;



            db.Entry(oDep).State = System.Data.Entity.EntityState.Modified;
            //db.DECLARACION_DOM_PARTICULAR.Remove(registro);
            //db.DECLARACION_DOM_PARTICULAR.Add(registro);
            db.SaveChanges();
        }
        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
