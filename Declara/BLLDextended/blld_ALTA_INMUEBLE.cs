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

namespace Declara_V2.BLLD
{
    // Extended
    public partial class blld_ALTA_INMUEBLE : bll_ALTA_INMUEBLE
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_ALTA_INMUEBLE.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_ALTA_INMUEBLE.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_ALTA_INMUEBLE.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_ALTA_INMUEBLE.NID_DECLARACION; }
        //        }

        //        public Int32 NID_INMUEBLE
        //        {
        //          get { return datos_ALTA_INMUEBLE.NID_INMUEBLE; }
        //        }


        //        public Int32 NID_TIPO
        //        {
        //          get { return datos_ALTA_INMUEBLE.NID_TIPO; }
        //          set { datos_ALTA_INMUEBLE.NID_TIPO = value; }
        //        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public DateTime F_ADQUISICION
        {
            get => datos_ALTA_INMUEBLE.F_ADQUISICION;
            set
            {
                if (value >= DateTime.Today) throw new CustomException("La fecha de adquisición del inmueble debe ser menor a la fecha actual");
                else
                    datos_ALTA_INMUEBLE.F_ADQUISICION = value;
            }
        }

        //        public Int32 NID_TIPO_COMPRA
        //        {
        //          get { return datos_ALTA_INMUEBLE.NID_TIPO_COMPRA; }
        //          set { datos_ALTA_INMUEBLE.NID_TIPO_COMPRA = value; }
        //        }


        //        public Int32 NID_USO
        //        {
        //          get { return datos_ALTA_INMUEBLE.NID_USO; }
        //          set { datos_ALTA_INMUEBLE.NID_USO = value; }
        //        }


        new public String E_UBICACION
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_INMUEBLE.E_UBICACION))
                    return String.Empty;
                return DesEncripta(datos_ALTA_INMUEBLE.E_UBICACION);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    datos_ALTA_INMUEBLE.E_UBICACION = String.Empty;
                }
                //else if (value.Length < 15)
                //{
                //    throw new CustomException("La longitud de la ubicación debe ser por lo menos de 15 caractéres");
                //}
                else
                {
                    if (Encripta(value) != datos_ALTA_INMUEBLE.E_UBICACION)
                    {
                        ValidaUbicacion(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, Encripta(value));
                        datos_ALTA_INMUEBLE.E_UBICACION = Encripta(value);
                    }
                }
            }
        }

        private Boolean lValidaLongitudUbicacion { get; set; } = true;
        //-------------------------------------------------------------------------CODIGO POSTAL---------------------------------------------------------------------
        private String _V_CODIGO_POSTAL { get; set; }

        public String V_CODIGO_POSTAL
        {
            get
            {
                if (_V_CODIGO_POSTAL == null)
                {
                    if ((E_UBICACION.Split('|').Length - 1) != 7)
                    {
                        lValidaLongitudUbicacion = false;
                        E_UBICACION = String.Concat(String.Empty, '|', String.Empty, '|', String.Empty, '|', String.Empty, '|', String.Empty, '|', String.Empty, '|', String.Empty, '|', String.Empty);
                        return String.Empty;
                    }
                    _V_CODIGO_POSTAL = E_UBICACION.Split('|')[0];
                    return _V_CODIGO_POSTAL;
                }
                else
                {
                    return _V_CODIGO_POSTAL;
                }
            }
            set
            {
                if (value == null)
                {
                    _V_CODIGO_POSTAL = String.Empty;
                }
                else
                {
                    _V_CODIGO_POSTAL = value.Replace("|", String.Empty);
                    E_UBICACION = String.Concat(_V_CODIGO_POSTAL, '|', _V_PAIS, '|', _V_ENTIDAD_FEDERATIVA, '|', _V_MUNICIPIO, '|', _V_COLONIA, '|', _V_CALLE, '|', _V_NUMERO_INTERNO, '|', _V_NUMERO_EXTERNO);
                }
            }
        }
        //---------------------------------------------------------------------------PAIS---------------------------------------------------------------------

        private String _V_PAIS { get; set; }
        public String V_PAIS
        {
            get
            {
                if (_V_PAIS == null)
                {
                    if ((E_UBICACION.Split('|').Length - 1) != 7)
                        return String.Empty;
                    _V_PAIS = E_UBICACION.Split('|')[1];
                    return _V_PAIS;
                }
                else
                {
                    return _V_PAIS;
                }
            }
            set
            {
                if (value == null)
                {
                    _V_PAIS = String.Empty;
                }
                else
                {
                    _V_PAIS = value.Replace("|", String.Empty);
                    E_UBICACION = String.Concat(_V_CODIGO_POSTAL, '|', _V_PAIS, '|', _V_ENTIDAD_FEDERATIVA, '|', _V_MUNICIPIO, '|', _V_COLONIA, '|', _V_CALLE, '|', _V_NUMERO_INTERNO, '|', _V_NUMERO_EXTERNO);
                }
            }
        }

        //---------------------------------------------------------------------------ENTIDAD FEDERATIVA---------------------------------------------------------------------

        private String _V_ENTIDAD_FEDERATIVA { get; set; }
        public String V_ENTIDAD_FEDERATIVA
        {
            get
            {
                if (_V_ENTIDAD_FEDERATIVA == null)
                {
                    if ((E_UBICACION.Split('|').Length - 1) != 7)
                        return String.Empty;
                    _V_ENTIDAD_FEDERATIVA = E_UBICACION.Split('|')[2];
                    return _V_ENTIDAD_FEDERATIVA;
                }
                else
                {
                    return _V_ENTIDAD_FEDERATIVA;
                }
            }
            set
            {
                if (value == null)
                {
                    _V_ENTIDAD_FEDERATIVA = String.Empty;
                }
                else
                {
                    _V_ENTIDAD_FEDERATIVA = value.Replace("|", String.Empty);
                    E_UBICACION = String.Concat(_V_CODIGO_POSTAL, '|', _V_PAIS, '|', _V_ENTIDAD_FEDERATIVA, '|', _V_MUNICIPIO, '|', _V_COLONIA, '|', _V_CALLE, '|', _V_NUMERO_INTERNO, '|', _V_NUMERO_EXTERNO);
                }
            }
        }

        //---------------------------------------------------------------------------MUNICIPIO---------------------------------------------------------------------

        private String _V_MUNICIPIO { get; set; }
        public String V_MUNICIPIO
        {
            get
            {
                if (_V_MUNICIPIO == null)
                {
                    if ((E_UBICACION.Split('|').Length - 1) != 7)
                        return String.Empty;
                    _V_MUNICIPIO = E_UBICACION.Split('|')[3];
                    return _V_MUNICIPIO;
                }
                else
                {
                    return _V_MUNICIPIO;
                }
            }
            set
            {
                if (value == null)
                {
                    _V_MUNICIPIO = String.Empty;
                }
                else
                {
                    _V_MUNICIPIO = value.Replace("|", String.Empty);
                    E_UBICACION = String.Concat(_V_CODIGO_POSTAL, '|', _V_PAIS, '|', _V_ENTIDAD_FEDERATIVA, '|', _V_MUNICIPIO, '|', _V_COLONIA, '|', _V_CALLE, '|', _V_NUMERO_INTERNO, '|', _V_NUMERO_EXTERNO);
                }
            }
        }

        //---------------------------------------------------------------------------COLONIA---------------------------------------------------------------------

        private String _V_COLONIA { get; set; }
        public String V_COLONIA
        {
            get
            {
                if (_V_COLONIA == null)
                {
                    if ((E_UBICACION.Split('|').Length - 1) != 7)
                        return String.Empty;
                    _V_COLONIA = E_UBICACION.Split('|')[4];
                    return _V_COLONIA;
                }
                else
                {
                    return _V_COLONIA;
                }
            }
            set
            {
                if (value == null)
                {
                    _V_COLONIA = String.Empty;
                }
                else
                {
                    _V_COLONIA = value.Replace("|", String.Empty);
                    E_UBICACION = String.Concat(_V_CODIGO_POSTAL, '|', _V_PAIS, '|', _V_ENTIDAD_FEDERATIVA, '|', _V_MUNICIPIO, '|', _V_COLONIA, '|', _V_CALLE, '|', _V_NUMERO_INTERNO, '|', _V_NUMERO_EXTERNO);
                }
            }
        }
        //---------------------------------------------------------------------------CALLE---------------------------------------------------------------------

        private String _V_CALLE { get; set; }
        public String V_CALLE
        {
            get
            {
                if (_V_CALLE == null)
                {
                    if ((E_UBICACION.Split('|').Length - 1) != 7)
                        return String.Empty;
                    _V_CALLE = E_UBICACION.Split('|')[5];
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
                    E_UBICACION = String.Concat(_V_CODIGO_POSTAL, '|', _V_PAIS, '|', _V_ENTIDAD_FEDERATIVA, '|', _V_MUNICIPIO, '|', _V_COLONIA, '|', _V_CALLE, '|', _V_NUMERO_INTERNO, '|', _V_NUMERO_EXTERNO);
                }
            }
        }

        //---------------------------------------------------------------------------NUMERO INTERIOR---------------------------------------------------------------------

        private String _V_NUMERO_INTERNO { get; set; }
        public String V_NUMERO_INTERNO
        {
            get
            {
                if (_V_NUMERO_INTERNO == null)
                {
                    if ((E_UBICACION.Split('|').Length - 1) != 7)
                        return String.Empty;
                    _V_NUMERO_INTERNO = E_UBICACION.Split('|')[6];
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
                    E_UBICACION = String.Concat(_V_CODIGO_POSTAL, '|', _V_PAIS, '|', _V_ENTIDAD_FEDERATIVA, '|', _V_MUNICIPIO, '|', _V_COLONIA, '|', _V_CALLE, '|', _V_NUMERO_INTERNO, '|', _V_NUMERO_EXTERNO);
                }
            }
        }

        //---------------------------------------------------------------------------NUMERO EXTERNO---------------------------------------------------------------------

        private String _V_NUMERO_EXTERNO { get; set; }
        public String V_NUMERO_EXTERNO
        {
            get
            {
                if (_V_NUMERO_EXTERNO == null)
                {
                    if ((E_UBICACION.Split('|').Length - 1) != 7)
                        return String.Empty;
                    _V_NUMERO_EXTERNO = E_UBICACION.Split('|')[7];
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
                    E_UBICACION = String.Concat(_V_CODIGO_POSTAL, '|', _V_PAIS, '|', _V_ENTIDAD_FEDERATIVA, '|', _V_MUNICIPIO, '|', _V_COLONIA, '|', _V_CALLE, '|', _V_NUMERO_INTERNO, '|', _V_NUMERO_EXTERNO);
                }
            }
        }



        //        public Decimal N_TERRENO
        //        {
        //          get { return datos_ALTA_INMUEBLE.N_TERRENO; }
        //          set { datos_ALTA_INMUEBLE.N_TERRENO = value; }
        //        }


        //        public Decimal N_CONSTRUCCION
        //        {
        //          get { return datos_ALTA_INMUEBLE.N_CONSTRUCCION; }
        //          set { datos_ALTA_INMUEBLE.N_CONSTRUCCION = value; }
        //        }


        //        public Decimal M_VALOR_INMUEBLE
        //        {
        //          get { return datos_ALTA_INMUEBLE.M_VALOR_INMUEBLE; }
        //          set { datos_ALTA_INMUEBLE.M_VALOR_INMUEBLE = value; }
        //        }


        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_ALTA_INMUEBLE.NID_PATRIMONIO; }
        //          set { datos_ALTA_INMUEBLE.NID_PATRIMONIO = value; }
        //        }

        private List<blld_ALTA_ADEUDO> _ALTA_ADEUDOs;

        public List<blld_ALTA_ADEUDO> ALTA_ADEUDOs
        {
            get
            {
                if (_ALTA_ADEUDOs == null)
                    Reload_ALTA_INMUEBLE_ADEUDOs();
                return _ALTA_ADEUDOs;
            }
        }

        public Decimal M_PAGO_INICIAL
        {
            get => datos_ALTA_INMUEBLE.M_PAGO_INICIAL;
            set => datos_ALTA_INMUEBLE.M_PAGO_INICIAL = value;
        }

        public Boolean L_DONACION
        {
            get
            {
                if (datos_ALTA_INMUEBLE.NID_FORMA_ADQUISICION == 1)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    datos_ALTA_INMUEBLE.NID_FORMA_ADQUISICION = 1;
                else
                    datos_ALTA_INMUEBLE.NID_FORMA_ADQUISICION = null;
            }
        }
        new public String E_REGISTRO_PUBLICO_PROPIEDAD
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_INMUEBLE.E_REGISTRO_PUBLICO_PROPIEDAD))
                    return String.Empty;
                return DesEncripta(datos_ALTA_INMUEBLE.E_REGISTRO_PUBLICO_PROPIEDAD);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_INMUEBLE.E_REGISTRO_PUBLICO_PROPIEDAD = String.Empty;
                else
                    datos_ALTA_INMUEBLE.E_REGISTRO_PUBLICO_PROPIEDAD = Encripta(value);
            }
        }

        new public String E_NOMBRE_TRANSMISOR
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_INMUEBLE.E_NOMBRE_TRANSMISOR))
                    return String.Empty;

                if (datos_ALTA_INMUEBLE.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    return datos_ALTA_INMUEBLE.E_NOMBRE_TRANSMISOR;
                else
                    return DesEncripta(datos_ALTA_INMUEBLE.E_NOMBRE_TRANSMISOR);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_INMUEBLE.E_NOMBRE_TRANSMISOR = String.Empty;
                else
                    if (datos_ALTA_INMUEBLE.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    datos_ALTA_INMUEBLE.E_NOMBRE_TRANSMISOR = value;
                else
                    datos_ALTA_INMUEBLE.E_NOMBRE_TRANSMISOR = Encripta(value);
            }
        }

        new public String E_RFC_TRANSMISOR
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_INMUEBLE.E_RFC_TRANSMISOR))
                    return String.Empty;

                if (datos_ALTA_INMUEBLE.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    return datos_ALTA_INMUEBLE.E_RFC_TRANSMISOR;
                else
                    return DesEncripta(datos_ALTA_INMUEBLE.E_RFC_TRANSMISOR);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_INMUEBLE.E_RFC_TRANSMISOR = String.Empty;
                else
                    if (datos_ALTA_INMUEBLE.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    datos_ALTA_INMUEBLE.E_RFC_TRANSMISOR = value;
                else
                    datos_ALTA_INMUEBLE.E_RFC_TRANSMISOR = Encripta(value);
            }
        }


        new public String E_OBSERVACIONES
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_INMUEBLE.E_OBSERVACIONES))
                    return String.Empty;
                return DesEncripta(datos_ALTA_INMUEBLE.E_OBSERVACIONES);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_INMUEBLE.E_OBSERVACIONES = String.Empty;
                else
                    datos_ALTA_INMUEBLE.E_OBSERVACIONES = Encripta(value);
            }
        }

        // sme

        public String V_FORMA_PAGO => datos_ALTA_INMUEBLE.oFormaPago.V_FORMA_PAGO;
        new public System.Nullable<Int32> NID_FORMA_PAGO
        {
            get => datos_ALTA_INMUEBLE.NID_FORMA_PAGO;
            set
            {
                if (!value.Equals(datos_ALTA_INMUEBLE.NID_FORMA_PAGO))
                {
                    datos_ALTA_INMUEBLE._oFormaPago = null;
                }
                datos_ALTA_INMUEBLE.NID_FORMA_PAGO = value;
            }
        }

        public String V_FORMA_ADQUISICION => datos_ALTA_INMUEBLE.oFormaAdquisicion.V_FORMA_ADQUISICION;
        new public System.Nullable<Int32> NID_FORMA_ADQUISICION
        {
            get => datos_ALTA_INMUEBLE.NID_FORMA_ADQUISICION;
            set
            {
                if (!value.Equals(datos_ALTA_INMUEBLE.NID_FORMA_ADQUISICION))
                {
                    datos_ALTA_INMUEBLE._oFormaAdquisicion = null;
                }
                datos_ALTA_INMUEBLE.NID_FORMA_ADQUISICION = value;
            }
        }

        public String V_VALOR_ADQUISICION => datos_ALTA_INMUEBLE.oValorAdquisicion.V_VALOR_ADQUISICION;
        new public Int32 NID_VALOR_ADQUISICION
        {
            get => datos_ALTA_INMUEBLE.NID_VALOR_ADQUISICION;
            set
            {
                if (!value.Equals(datos_ALTA_INMUEBLE.NID_VALOR_ADQUISICION))
                {
                    datos_ALTA_INMUEBLE._oValorAdquisicion = null;
                }
                datos_ALTA_INMUEBLE.NID_VALOR_ADQUISICION = value;
            }
        }

        public String V_RELACION_TRANSMISOR => datos_ALTA_INMUEBLE.oRelacionTransmisor.V_RELACION_TRANSMISOR;
        new public Int32 NID_RELACION_TRANSMISOR
        {
            get => datos_ALTA_INMUEBLE.NID_RELACION_TRANSMISOR;
            set
            {
                if (!value.Equals(datos_ALTA_INMUEBLE.NID_RELACION_TRANSMISOR))
                {
                    datos_ALTA_INMUEBLE._oRelacionTransmisor = null;
                }
                datos_ALTA_INMUEBLE.NID_RELACION_TRANSMISOR = value;
            }
        }

        public String V_NOMBRE_PAIS => datos_ALTA_INMUEBLE.oPais.V_PAIS;

        public String V_NOMBRE_ENTIDAD_FEDERATIVA => datos_ALTA_INMUEBLE.oEntidad.V_ENTIDAD_FEDERATIVA;

        public String V_NOMBRE_MUNICIPIO => datos_ALTA_INMUEBLE.oMunicipio.V_MUNICIPIO;

        // public Int32 NID_PAIS
        //{
        //    get => Convert.ToInt32(this.V_PAIS);
        //    set
        //    {
        //        if (!value.Equals(datos_ALTA_INMUEBLE.NID_PAIS))
        //        {
        //            datos_ALTA_INMUEBLE._oPais = null;
        //            datos_ALTA_INMUEBLE._oEntidad = null;
        //        }
        //        datos_ALTA_INMUEBLE.NID_PAIS = value;
        //    }
        //}

        //new public String CID_ENTIDAD_FEDERATIVA
        //{
        //    get => datos_ALTA_INMUEBLE.CID_ENTIDAD_FEDERATIVA;
        //    set
        //    {
        //        if (!value.Equals(datos_ALTA_INMUEBLE.CID_ENTIDAD_FEDERATIVA))
        //        {
        //            datos_ALTA_INMUEBLE._oEntidad = null;
        //        }
        //        datos_ALTA_INMUEBLE.CID_ENTIDAD_FEDERATIVA = value;
        //    }
        //}

        //public String V_PAIS => datos_ALTA_INMUEBLE.oPais.V_PAIS;
        //public String V_ENTIDAD_FEDERATIVA => datos_ALTA_INMUEBLE.oEntidad.V_ENTIDAD_FEDERATIVA;

        // sme


        //public String V_FORMA_ADQUISICION { get; set; }




        //new public String E_OBSERVACIONES_MARCADO
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(datos_ALTA_INMUEBLE.E_OBSERVACIONES_MARCADO))
        //            return String.Empty;
        //        return DesEncripta(datos_ALTA_INMUEBLE.E_OBSERVACIONES_MARCADO);
        //    }
        //    set
        //    {
        //        ValidarEstadoTestado(NID_ESTADO_TESTADO);

        //        if (String.IsNullOrEmpty(value.Trim().Trim('|').Trim('|')))
        //        {
        //            datos_ALTA_INMUEBLE.E_OBSERVACIONES_MARCADO = String.Empty;
        //            datos_ALTA_INMUEBLE.V_OBSERVACIONES_TESTADO = String.Empty;
        //        }
        //        else
        //        {
        //            datos_ALTA_INMUEBLE.E_OBSERVACIONES_MARCADO = Encripta(value);
        //            datos_ALTA_INMUEBLE.V_OBSERVACIONES_TESTADO = Testa(value);

        //        }
        //    }
        //}
        //new public String V_OBSERVACIONES_TESTADO => String.IsNullOrEmpty(datos_ALTA_INMUEBLE.V_OBSERVACIONES_TESTADO) ? String.Empty : 
        //                                                                  datos_ALTA_INMUEBLE.V_OBSERVACIONES_TESTADO.Replace("¦", "█");

        blld_ALTA_INMUEBLE_COPROPIETARIO _ALTA_INMUEBLE_COPROPIETARIO { get; set; }

        public blld_ALTA_INMUEBLE_COPROPIETARIO ALTA_INMUEBLE_COPROPIETARIO
        {
            get
            {
                try
                {
                    if (_ALTA_INMUEBLE_COPROPIETARIO == null) 
                    {
                        _ALTA_INMUEBLE_COPROPIETARIO = new blld_ALTA_INMUEBLE_COPROPIETARIO(this.VID_NOMBRE
                                                                                            , this.VID_FECHA
                                                                                            , this.VID_HOMOCLAVE
                                                                                            , this.NID_DECLARACION
                                                                                            , this.NID_INMUEBLE
                                                                                            , 1);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is RowNotFoundException)
                        _ALTA_INMUEBLE_COPROPIETARIO = new blld_ALTA_INMUEBLE_COPROPIETARIO();
                }
                return _ALTA_INMUEBLE_COPROPIETARIO;
            }
            set => _ALTA_INMUEBLE_COPROPIETARIO = value;
        }

        #endregion


        #region *** Constructores (Extended) ***

        public blld_ALTA_INMUEBLE(
                                    String VID_NOMBRE
                                    , String VID_FECHA
                                    , String VID_HOMOCLAVE
                                    , Int32 NID_DECLARACION
                                    , DateTime F_ADQUISICION
                                    , Int32 NID_USO
                                    , Int32 NID_TIPO
                                    , String E_UBICACION
                                    , Decimal N_TERRENO
                                    , Decimal N_CONSTRUCCION
                                    , Decimal M_VALOR_INMUEBLE
                                    , Decimal N_PORCENTAJE_DECLARANTE
                                    , String CID_TIPO_PERSONA_TRANSMISOR
                                    , String E_NOMBRE_TRANSMISOR
                                    , String E_RFC_TRANSMISOR
                                    , Int32 NID_RELACION_TRANSMISOR
                                    , String V_TIPO_MONEDA
                                    , String E_REGISTRO_PUBLICO_PROPIEDAD
                                    , Int32 NID_VALOR_ADQUISICION
                                    , Int32 NID_FORMA_ADQUISICION
                                    , Int32 NID_FORMA_PAGO
                                    , String E_OBSERVACIONES
                                    , String CID_TIPO_PERSONA
                                    , String V_NOMBRE
                                    , String V_RFC
                                    , List<Int32> ListDependientes
                                    )
        : base()
        {
            //if (ListDependientes == null) throw new CustomException("Debe haber al menos un titular");
            //if (ListDependientes.Count == 0) throw new CustomException("Debe haber al menos un titular");
            if (F_ADQUISICION >= DateTime.Today) throw new CustomException("La fecha de adquisición del inmueble debe ser menor que la fecha actual");


            //if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            //{
            //    if (CID_TIPO_PERSONA != "F" && CID_TIPO_PERSONA != "M") throw new CustomException("Falta el tipo de persona del tercero");
            //    if (String.IsNullOrEmpty(V_NOMBRE) || V_NOMBRE.Length < 5) throw new CustomException("Falta especificar el nombre del tercero");
            //    if (!String.IsNullOrEmpty(V_RFC) && ((CID_TIPO_PERSONA == "F" && V_RFC.Length != 13) || (CID_TIPO_PERSONA == "M" && V_RFC.Length != 12))) throw new CustomException("El RFC del tercero es incorrecto");

            //}

            //if (!String.IsNullOrEmpty(this.CID_TIPO_PERSONA_TRANSMISOR))
            //{
            //    if (this.CID_TIPO_PERSONA_TRANSMISOR != "F" && this.CID_TIPO_PERSONA_TRANSMISOR != "M") throw new CustomException("Falta el tipo de persona del transmisor");
            //    if (String.IsNullOrEmpty(this.E_NOMBRE_TRANSMISOR) || (this.CID_TIPO_PERSONA_TRANSMISOR == "F" && DesEncripta(this.E_NOMBRE_TRANSMISOR).Length < 5) || (this.CID_TIPO_PERSONA_TRANSMISOR == "M" && this.E_NOMBRE_TRANSMISOR.Length < 5)) throw new CustomException("Falta especificar el nombre del transmisor");
            //    if (!String.IsNullOrEmpty(this.E_RFC_TRANSMISOR) && ((this.CID_TIPO_PERSONA_TRANSMISOR == "F" && DesEncripta(this.E_RFC_TRANSMISOR).Length != 13)) || (this.CID_TIPO_PERSONA_TRANSMISOR == "M" && this.E_RFC_TRANSMISOR.Length != 12)) throw new CustomException("El RFC del transmisor es incorrecto");

            //}

            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            {
                if (CID_TIPO_PERSONA != "F" && CID_TIPO_PERSONA != "M") throw new CustomException("Falta el tipo de persona del tercero");

                if (String.IsNullOrEmpty(V_NOMBRE)) throw new CustomException("Falta especificar el nombre del tercero");

                if ((CID_TIPO_PERSONA == "F" && V_NOMBRE.Length < 5)) throw new CustomException("Falta especificar el nombre del tercero");

                if (!String.IsNullOrEmpty(V_RFC))
                {
                    if (CID_TIPO_PERSONA == "F")
                        if (V_RFC.Length != 13)
                            throw new CustomException("El RFC del tercero no tiene 13 caracteres");
                        else
                        { }
                    else
                        if (V_RFC.Length != 12)
                        throw new CustomException("El RFC del tercero no tiene 12 caracteres");
                }
            }
            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA_TRANSMISOR))
            {
                if (CID_TIPO_PERSONA_TRANSMISOR != "0")
                {
                    if (CID_TIPO_PERSONA_TRANSMISOR != "F" && CID_TIPO_PERSONA_TRANSMISOR != "M") throw new CustomException("Falta el tipo de persona del transmisor");

                    if (String.IsNullOrEmpty(E_NOMBRE_TRANSMISOR)) throw new CustomException("Falta especificar el nombre del transmisor");

                    if ((CID_TIPO_PERSONA_TRANSMISOR == "F" && E_NOMBRE_TRANSMISOR.Length < 5)) throw new CustomException("Falta especificar el nombre del transmisor");

                    if (!String.IsNullOrEmpty(E_RFC_TRANSMISOR))
                    {
                        if (CID_TIPO_PERSONA_TRANSMISOR == "F")
                            if (E_RFC_TRANSMISOR.Length != 13)
                                throw new CustomException("El RFC del transmisor no tiene 13 caracteres");
                            else
                            { }
                        else
                            if (E_RFC_TRANSMISOR.Length != 12)
                            throw new CustomException("El RFC del transmisor no tiene 12 caracteres");
                    }
                }

            }


            if (V_TIPO_MONEDA.Length < 2) throw new CustomException("Falta el tipo de moneda");
            if (E_REGISTRO_PUBLICO_PROPIEDAD.Length < 4) throw new CustomException("Falta el dato del registro  público de la propiedad");
            if (N_PORCENTAJE_DECLARANTE < 0 || N_PORCENTAJE_DECLARANTE > 100) throw new CustomException("El valor del porcentaje debe estar entre 0 y 100");




            Int32 NID_PATRIMONIO = dald_PATRIMONIO.nNuevo_NID_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            Int32 NID_INMUEBLE = dald_ALTA_INMUEBLE.nNuevo_NID_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            if (E_UBICACION.Length < 15)
                throw new CustomException("La longitud de la ubicación debe ser por lo menos de 15 caractéres");

            E_UBICACION = Encripta(E_UBICACION);


            if (CID_TIPO_PERSONA_TRANSMISOR == "F")
            {
                E_NOMBRE_TRANSMISOR = Encripta(E_NOMBRE_TRANSMISOR);
                E_RFC_TRANSMISOR = Encripta(E_RFC_TRANSMISOR);
            }

            if (CID_TIPO_PERSONA_TRANSMISOR == "0")
            {
                E_NOMBRE_TRANSMISOR = Encripta(E_NOMBRE_TRANSMISOR);
                E_RFC_TRANSMISOR = Encripta(E_RFC_TRANSMISOR);
            }

            E_REGISTRO_PUBLICO_PROPIEDAD = Encripta(E_REGISTRO_PUBLICO_PROPIEDAD);
            E_OBSERVACIONES = Encripta(E_OBSERVACIONES);


            ValidaUbicacion(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, E_UBICACION);

            datos_ALTA_INMUEBLE = new dald_ALTA_INMUEBLE(
                                                              VID_NOMBRE
                                                            , VID_FECHA
                                                            , VID_HOMOCLAVE
                                                            , NID_DECLARACION
                                                            , NID_INMUEBLE
                                                            , NID_TIPO
                                                            , F_ADQUISICION
                                                            , NID_USO
                                                            , E_UBICACION
                                                            , N_TERRENO
                                                            , N_CONSTRUCCION
                                                            , M_VALOR_INMUEBLE
                                                            , NID_PATRIMONIO
                                                            , N_PORCENTAJE_DECLARANTE
                                                            , CID_TIPO_PERSONA_TRANSMISOR
                                                            , E_NOMBRE_TRANSMISOR
                                                            , E_RFC_TRANSMISOR
                                                            , NID_RELACION_TRANSMISOR
                                                            , V_TIPO_MONEDA
                                                            , E_REGISTRO_PUBLICO_PROPIEDAD
                                                            , NID_VALOR_ADQUISICION
                                                            , NID_FORMA_ADQUISICION
                                                            , NID_FORMA_PAGO
                                                            , E_OBSERVACIONES
                                                            , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException
                                                            );

            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            {
                _ALTA_INMUEBLE_COPROPIETARIO = new blld_ALTA_INMUEBLE_COPROPIETARIO(VID_NOMBRE
                , VID_FECHA
                , VID_HOMOCLAVE
                , NID_DECLARACION
                , NID_INMUEBLE
                , 1
                , CID_TIPO_PERSONA
                , V_NOMBRE
                , V_RFC
               );
            }

            if (ListDependientes != null)
            {
                foreach (Int32 nid_Dependiente in ListDependientes)
                {
                    Add_ALTA_INMUEBLE_TITULARs(nid_Dependiente);
                }
            }
        }

        public blld_ALTA_INMUEBLE(
                                    String VID_NOMBRE
                                    , String VID_FECHA
                                    , String VID_HOMOCLAVE
                                    , Int32 NID_DECLARACION
                                    , DateTime F_ADQUISICION
                                    , Int32 NID_USO
                                    , Int32 NID_TIPO
                                    , String E_UBICACION
                                    , Decimal N_TERRENO
                                    , Decimal N_CONSTRUCCION
                                    , Decimal M_VALOR_INMUEBLE
                                    , Decimal M_PAGO_INICIAL
                                    , Boolean L_DONACION
                                    , Decimal N_PORCENTAJE_DECLARANTE
                                    , String CID_TIPO_PERSONA_TRANSMISOR
                                    , String E_NOMBRE_TRANSMISOR
                                    , String E_RFC_TRANSMISOR
                                    , Int32 NID_RELACION_TRANSMISOR
                                    , String V_TIPO_MONEDA
                                    , String E_REGISTRO_PUBLICO_PROPIEDAD
                                    , Int32 NID_VALOR_ADQUISICION
                                    , String E_OBSERVACIONES
                                    , String CID_TIPO_PERSONA
                                    , String V_NOMBRE
                                    , String V_RFC
                                    , List<Int32> ListDependientes
                                    )
       : base()
        {
            //if (ListDependientes == null) throw new CustomException("Debe haber al menos un titular");
            //if (ListDependientes.Count == 0) throw new CustomException("Debe haber al menos un titular");
            if (F_ADQUISICION >= DateTime.Today) throw new CustomException("La fecha de adquisición del inmueble debe ser menor que la fecha actual");

            Int32 NID_PATRIMONIO = dald_PATRIMONIO.nNuevo_NID_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            Int32 NID_INMUEBLE = dald_ALTA_INMUEBLE.nNuevo_NID_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            if (E_UBICACION.Length < 15)
                throw new CustomException("La longitud de la ubicación debe ser por lo menos de 15 caractéres");
            E_UBICACION = Encripta(E_UBICACION);

            ValidaUbicacion(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, E_UBICACION);

            Int32 NID_FORMA_ADQUISICION;
            if (L_DONACION)
                NID_FORMA_ADQUISICION = 1;
            else
                NID_FORMA_ADQUISICION = -1;

            datos_ALTA_INMUEBLE = new dald_ALTA_INMUEBLE(
                                                              VID_NOMBRE
                                                            , VID_FECHA
                                                            , VID_HOMOCLAVE
                                                            , NID_DECLARACION
                                                            , NID_INMUEBLE
                                                            , NID_TIPO
                                                            , F_ADQUISICION
                                                            , NID_USO
                                                            , E_UBICACION
                                                            , N_TERRENO
                                                            , N_CONSTRUCCION
                                                            , M_VALOR_INMUEBLE
                                                            , NID_PATRIMONIO
                                                            , M_PAGO_INICIAL
                                                            , NID_FORMA_ADQUISICION
                                                            , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException
                                                            );
            if (ListDependientes != null) {
                foreach (Int32 nid_Dependiente in ListDependientes)
                {
                    Add_ALTA_INMUEBLE_TITULARs(nid_Dependiente);
                }
            }
        }


        #endregion


        #region *** Metodos (Extended) ***

        internal static void ValidaUbicacion(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String E_UBICACION)
        {

            blld__l_ALTA_INMUEBLE oComprueba = new blld__l_ALTA_INMUEBLE();
            oComprueba.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oComprueba.VID_FECHA = new StringFilter(VID_FECHA);
            oComprueba.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oComprueba.E_UBICACION = new StringFilter(E_UBICACION);
            oComprueba.select();
            if (oComprueba.lista_ALTA_INMUEBLE.Any())
                throw new CustomException("Ya se ha dado de alta un inmueble con esa ubicación");

            blld__l_MODIFICACION_INMUEBLE oCompruebaMod = new blld__l_MODIFICACION_INMUEBLE();
            oCompruebaMod.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oCompruebaMod.VID_FECHA = new StringFilter(VID_FECHA);
            oCompruebaMod.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oCompruebaMod.E_UBICACION = new StringFilter(E_UBICACION);
            oCompruebaMod.select();
            if (oCompruebaMod.lista_MODIFICACION_INMUEBLE.Any())
                throw new CustomException("Ya se ha dado de alta un inmueble con esa ubicación");
        }

        public void Reload_ALTA_INMUEBLE_TITULARs()
        {
            _Reload_ALTA_INMUEBLE_TITULARs();
        }

        public void Add_ALTA_INMUEBLE_TITULARs(Int32 NID_DEPENDIENTE)
        {
            try
            {
                _Add_ALTA_INMUEBLE_TITULARs(NID_DEPENDIENTE, true);
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

        public void Add_ALTA_INMUEBLE_ADEUDOs(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, List<Int32> ListaTitulares)
        {
            try
            {
                if (ALTA_ADEUDOs.Count <= 1)
                {
                    ALTA_ADEUDOs.Add
                        (
                        new blld_ALTA_ADEUDO(VID_NOMBRE
                                            , VID_FECHA
                                            , VID_HOMOCLAVE
                                            , NID_DECLARACION
                                            , NID_PAIS
                                            , CID_ENTIDAD_FEDERATIVA
                                            , V_LUGAR
                                            , NID_INSTITUCION
                                            , V_OTRA
                                            , NID_TIPO_ADEUDO
                                            , F_ADEUDO
                                            , M_ORIGINAL
                                            , M_SALDO
                                            , E_CUENTA
                                            , ListaTitulares
                                            , NID_INMUEBLE
                                            , Convert.ToInt16(1)

                        ));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Add_ALTA_INMUEBLE_ADEUDOs(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, Decimal M_PAGOS, List<Int32> ListaTitulares)
        {
            try
            {
                if (ALTA_ADEUDOs.Count <= 1)
                {
                    ALTA_ADEUDOs.Add
                        (
                        new blld_ALTA_ADEUDO(VID_NOMBRE
                                            , VID_FECHA
                                            , VID_HOMOCLAVE
                                            , NID_DECLARACION
                                            , NID_PAIS
                                            , CID_ENTIDAD_FEDERATIVA
                                            , V_LUGAR
                                            , NID_INSTITUCION
                                            , V_OTRA
                                            , NID_TIPO_ADEUDO
                                            , F_ADEUDO
                                            , M_ORIGINAL
                                            , M_SALDO
                                            , E_CUENTA
                                            , M_PAGOS
                                            , ListaTitulares
                                            , NID_INMUEBLE
                                            , Convert.ToInt16(1)

                        ));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Reload_ALTA_INMUEBLE_ADEUDOs()
        {
            _ALTA_ADEUDOs = new List<blld_ALTA_ADEUDO>();
            foreach (MODELDeclara_V2.ALTA_INMUEBLE_ADEUDO o in datos_ALTA_INMUEBLE._ALTA_INMUEBLE_ADEUDOs)
            {
                try
                {
                    blld_ALTA_ADEUDO oAdeudo = new blld_ALTA_ADEUDO(this.VID_NOMBRE
                                                                    , this.VID_FECHA
                                                                    , this.VID_HOMOCLAVE
                                                                    , this.NID_DECLARACION
                                                                    , o.NID_ADEUDO

                         );
                    _ALTA_ADEUDOs.Add(oAdeudo);
                }
                catch (Exception ex)
                {
                    if (ex is RowNotFoundException)
                    {
                        blld_ALTA_INMUEBLE_ADEUDO ade = new blld_ALTA_INMUEBLE_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, o.NID_ADEUDO);
                        ade.delete();
                    }
                    else
                    {
                        throw ex;
                    }

                }

            }
        }


        public void ClaerAdeudos()
        {
            _ALTA_ADEUDOs = null;
        }

        public void update(List<Int32> ListDependientes, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC)
        {
            //if (ListDependientes == null) throw new CustomException("Debe haber al menos un titular");
            //if (ListDependientes.Count == 0) throw new CustomException("Debe haber al menos un titular");

            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            {
                if (CID_TIPO_PERSONA != "F" && CID_TIPO_PERSONA != "M") throw new CustomException("Falta el tipo de persona del tercero");

                if (String.IsNullOrEmpty(V_NOMBRE)) throw new CustomException("Falta especificar el nombre del tercero");

                if ((CID_TIPO_PERSONA == "F" && V_NOMBRE.Length < 5)) throw new CustomException("Falta especificar el nombre del tercero");

                if (!String.IsNullOrEmpty(V_RFC))
                {
                    if (CID_TIPO_PERSONA == "F")
                        if (V_RFC.Length != 13)
                            throw new CustomException("El RFC del tercero no tiene 13 caracteres");
                        else
                        { }
                    else
                        if (V_RFC.Length != 12)
                        throw new CustomException("El RFC del tercero no tiene 12 caracteres");
                }
            }
            if (!String.IsNullOrEmpty(this.CID_TIPO_PERSONA_TRANSMISOR))
            {
                if (this.CID_TIPO_PERSONA_TRANSMISOR != "F" && this.CID_TIPO_PERSONA_TRANSMISOR != "M") throw new CustomException("Falta el tipo de persona del transmisor");

                if (String.IsNullOrEmpty(this.E_NOMBRE_TRANSMISOR)) throw new CustomException("Falta especificar el nombre del transmisor");

                if ((this.CID_TIPO_PERSONA_TRANSMISOR == "F" && this.E_NOMBRE_TRANSMISOR.Length < 5)) throw new CustomException("Falta especificar el nombre del transmisor");

                if (!String.IsNullOrEmpty(this.E_RFC_TRANSMISOR))
                {
                    if (this.CID_TIPO_PERSONA_TRANSMISOR == "F")
                        if (this.E_RFC_TRANSMISOR.Length != 13)
                            throw new CustomException("El RFC del transmisor no tiene 13 caracteres");
                        else
                        { }
                    else
                        if (this.E_RFC_TRANSMISOR.Length != 12)
                        throw new CustomException("El RFC del transmisor no tiene 12 caracteres");
                }


            }

            if (this.V_TIPO_MONEDA.Length < 2) throw new CustomException("Falta el tipo de moneda");
            if (this.E_REGISTRO_PUBLICO_PROPIEDAD.Length < 4) throw new CustomException("Falta el dato del registro  público de la propiedad");

            if (N_PORCENTAJE_DECLARANTE < 0 || N_PORCENTAJE_DECLARANTE > 100) throw new CustomException("El valor del porcentaje debe estar entre 0 y 100");

            List<blld_ALTA_INMUEBLE_TITULAR> listAux = new List<blld_ALTA_INMUEBLE_TITULAR>();
            foreach (blld_ALTA_INMUEBLE_TITULAR o in ALTA_INMUEBLE_TITULARs)
            {
                listAux.Add(o);
            }

            foreach (blld_ALTA_INMUEBLE_TITULAR select in listAux)
            {
                if (!ListDependientes.Contains(select.NID_DEPENDIENTE))
                    ALTA_INMUEBLE_TITULARs.Remove(select);
            }

            foreach (Int32 nid_Dependiente in ListDependientes)
            {
                Add_ALTA_INMUEBLE_TITULARs(nid_Dependiente);
            }



            datos_ALTA_INMUEBLE.update();

            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            {
                _ALTA_INMUEBLE_COPROPIETARIO = new blld_ALTA_INMUEBLE_COPROPIETARIO(
                                                                                    this.VID_NOMBRE
                                                                                    , this.VID_FECHA
                                                                                    , this.VID_HOMOCLAVE
                                                                                    , this.NID_DECLARACION
                                                                                    , this.NID_INMUEBLE
                                                                                    , 1
                                                                                    , CID_TIPO_PERSONA
                                                                                    , V_NOMBRE
                                                                                    , V_RFC);
            }
            else
                _ALTA_INMUEBLE_COPROPIETARIO.update();


            //if (String.IsNullOrEmpty(_ALTA_INMUEBLE_COPROPIETARIO.VID_NOMBRE))
            //{
            //    _ALTA_INMUEBLE_COPROPIETARIO.update(this.VID_NOMBRE,
            //                                        this.VID_FECHA,
            //                                        this.VID_HOMOCLAVE,
            //                                        this.NID_DECLARACION,
            //                                        this.NID_INMUEBLE,
            //                                        1);
            //}
            //_ALTA_INMUEBLE_COPROPIETARIO.update();
        }

        new public void delete()
        {
            Reload_ALTA_INMUEBLE_ADEUDOs();
            if (ALTA_ADEUDOs.Any())
                throw new CustomException("El inmueble tiene adeudos asociados, eliminelos antes de eliminar el inmueble");
            //int val = ALTA_INMUEBLE_TITULARs.Count - 1;
            //for (int i = val; i >= 0; i--)
            //{
            //    try { ALTA_INMUEBLE_TITULARs.RemoveAt(i); } catch { };
            //}

            datos_ALTA_INMUEBLE.delete();
        }


        #endregion

    }
}
