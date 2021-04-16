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
    public partial class blld_ALTA_VEHICULO : bll_ALTA_VEHICULO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_ALTA_VEHICULO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_ALTA_VEHICULO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_ALTA_VEHICULO.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_ALTA_VEHICULO.NID_DECLARACION; }
        //        }

        //        public Int32 NID_VEHICULO
        //        {
        //          get { return datos_ALTA_VEHICULO.NID_VEHICULO; }
        //        }


        //        public Int32 NID_MARCA
        //        {
        //          get { return datos_ALTA_VEHICULO.NID_MARCA; }
        //          set { datos_ALTA_VEHICULO.NID_MARCA = value; }
        //        }


        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo M O D E L O es requerido ")]
        [DisplayName("M O D E L O")]
        new public String C_MODELO
        {
            get => datos_ALTA_VEHICULO.C_MODELO;
            set
            {
                if (Convert.ToInt32(value) > F_ADQUISICION.Year + 2)
                    throw new CustomException("El año del modelo no puede ser mayor que el año de adquisición");
                datos_ALTA_VEHICULO.C_MODELO = value;
            }
        }


        //        public String V_DESCRIPCION
        //        {
        //          get { return datos_ALTA_VEHICULO.V_DESCRIPCION; }
        //          set { datos_ALTA_VEHICULO.V_DESCRIPCION = value; }
        //        }

        new public Int32 NID_TIPO_VEHICULO
        {
            get => datos_ALTA_VEHICULO.NID_TIPO_VEHICULO;
            set
            {
                if (!datos_ALTA_VEHICULO.NID_TIPO_VEHICULO.Equals(value))
                    oCAT_TIPO_VEHICULO = null;
                datos_ALTA_VEHICULO.NID_TIPO_VEHICULO = value;
            }
        }

        private blld_CAT_TIPO_VEHICULO oCAT_TIPO_VEHICULO;

        public String V_TIPO_VEHICULO
        {
            get
            {
                if (oCAT_TIPO_VEHICULO == null)
                    oCAT_TIPO_VEHICULO = new blld_CAT_TIPO_VEHICULO(NID_TIPO_VEHICULO);
                return oCAT_TIPO_VEHICULO.V_TIPO_VEHICULO;
            }
        }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public DateTime F_ADQUISICION
        {
            get => datos_ALTA_VEHICULO.F_ADQUISICION;
            set
            {
                if (value >= DateTime.Today) throw new CustomException("La fecha de adquisición del vehiculo no puede ser mayor que la fecha actual");
                datos_ALTA_VEHICULO.F_ADQUISICION = value;
            }
        }

        private List<blld_ALTA_ADEUDO> _ALTA_ADEUDOs;

        public List<blld_ALTA_ADEUDO> ALTA_ADEUDOs
        {
            get
            {
                if (_ALTA_ADEUDOs == null)
                    Reload_ALTA_VEHICULO_ADEUDOs();
                return _ALTA_ADEUDOs;
            }
        }



        //        public Int32 NID_TIPO_COMPRA
        //        {
        //          get { return datos_ALTA_VEHICULO.NID_TIPO_COMPRA; }
        //          set { datos_ALTA_VEHICULO.NID_TIPO_COMPRA = value; }
        //        }


        //        public Int32 NID_USO
        //        {
        //          get { return datos_ALTA_VEHICULO.NID_USO; }
        //          set { datos_ALTA_VEHICULO.NID_USO = value; }
        //        }


        //        public Decimal M_VALOR_VEHICULO
        //        {
        //          get { return datos_ALTA_VEHICULO.M_VALOR_VEHICULO; }
        //          set { datos_ALTA_VEHICULO.M_VALOR_VEHICULO = value; }
        //        }


        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_ALTA_VEHICULO.NID_PATRIMONIO; }
        //          set { datos_ALTA_VEHICULO.NID_PATRIMONIO = value; }
        //        }

        public Boolean L_DONACION
        {
            get
            {
                if (datos_ALTA_VEHICULO.NID_FORMA_ADQUISICION == 1)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    datos_ALTA_VEHICULO.NID_FORMA_ADQUISICION = 1;
                else
                    datos_ALTA_VEHICULO.NID_FORMA_ADQUISICION = -1;
            }
        }

        public Decimal M_PAGO_INICIAL
        {
            get => datos_ALTA_VEHICULO.M_PAGO_INICIAL;
            set => datos_ALTA_VEHICULO.M_PAGO_INICIAL = value;
        }

        // sme

        //private String _V_PAIS { get; set; }
        //public String V_PAIS
        //{
        //    get
        //    {
        //             return _V_PAIS;
        //    }
        //    set
        //    {
        //        if (value == null)
        //        {
        //            _V_PAIS = String.Empty;
        //        }
        //        else
        //        {
        //            _V_PAIS = value;

        //        }
        //    }
        //}


        // sme
        new public String E_NOMBRE_TRANSMISOR
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_VEHICULO.E_NOMBRE_TRANSMISOR))
                    return String.Empty;

                if (datos_ALTA_VEHICULO.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    return datos_ALTA_VEHICULO.E_NOMBRE_TRANSMISOR;
                else
                    return DesEncripta(datos_ALTA_VEHICULO.E_NOMBRE_TRANSMISOR);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_VEHICULO.E_NOMBRE_TRANSMISOR = String.Empty;
                else
                    if (datos_ALTA_VEHICULO.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    datos_ALTA_VEHICULO.E_NOMBRE_TRANSMISOR = value;
                else
                    datos_ALTA_VEHICULO.E_NOMBRE_TRANSMISOR = Encripta(value);
            }
        }
        new public String E_NUMERO_SERIE
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_VEHICULO.E_NUMERO_SERIE))
                    return String.Empty;
                return DesEncripta(datos_ALTA_VEHICULO.E_NUMERO_SERIE);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_VEHICULO.E_NUMERO_SERIE = String.Empty;
                else
                    datos_ALTA_VEHICULO.E_NUMERO_SERIE = Encripta(value);
            }
        }

        new public String E_RFC_TRANSMISOR
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_VEHICULO.E_RFC_TRANSMISOR))
                    return String.Empty;

                if (datos_ALTA_VEHICULO.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    return datos_ALTA_VEHICULO.E_RFC_TRANSMISOR;
                else
                    return DesEncripta(datos_ALTA_VEHICULO.E_RFC_TRANSMISOR);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_VEHICULO.E_RFC_TRANSMISOR = String.Empty;
                else
                    if (datos_ALTA_VEHICULO.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    datos_ALTA_VEHICULO.E_RFC_TRANSMISOR = value;
                else
                    datos_ALTA_VEHICULO.E_RFC_TRANSMISOR = Encripta(value);
            }
        }
        new public String E_OBSERVACIONES
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_VEHICULO.E_OBSERVACIONES))
                    return String.Empty;
                return DesEncripta(datos_ALTA_VEHICULO.E_OBSERVACIONES);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_VEHICULO.E_OBSERVACIONES = String.Empty;
                else
                    datos_ALTA_VEHICULO.E_OBSERVACIONES = Encripta(value);
            }
        }


        // sme 

        public String V_FORMA_PAGO => datos_ALTA_VEHICULO.oFormaPago.V_FORMA_PAGO;
        new public System.Nullable<Int32> NID_FORMA_PAGO
        {
            get => datos_ALTA_VEHICULO.NID_FORMA_PAGO;
            set
            {
                if (!value.Equals(datos_ALTA_VEHICULO.NID_FORMA_PAGO))
                {
                    datos_ALTA_VEHICULO._oFormaPago = null;
                }
                datos_ALTA_VEHICULO.NID_FORMA_PAGO = value;
            }
        }

        public String V_FORMA_ADQUISICION => datos_ALTA_VEHICULO.oFormaAdquisicion.V_FORMA_ADQUISICION;
        new public System.Nullable<Int32> NID_FORMA_ADQUISICION
        {
            get => datos_ALTA_VEHICULO.NID_FORMA_ADQUISICION;
            set
            {
                if (!value.Equals(datos_ALTA_VEHICULO.NID_FORMA_ADQUISICION))
                {
                    datos_ALTA_VEHICULO._oFormaAdquisicion = null;
                }
                datos_ALTA_VEHICULO.NID_FORMA_ADQUISICION = value;
            }
        }

        public String V_RELACION_TRANSMISOR => datos_ALTA_VEHICULO.oRelacionTransmisor.V_RELACION_TRANSMISOR;
        new public Int32 NID_RELACION_TRANSMISOR
        {
            get => datos_ALTA_VEHICULO.NID_RELACION_TRANSMISOR;
            set
            {
                if (!value.Equals(datos_ALTA_VEHICULO.NID_RELACION_TRANSMISOR))
                {
                    datos_ALTA_VEHICULO._oRelacionTransmisor = null;
                }
                datos_ALTA_VEHICULO.NID_RELACION_TRANSMISOR = value;
            }
        }

        new public System.Nullable<Int32> NID_PAIS
        {
            get => datos_ALTA_VEHICULO.NID_PAIS;
            set
            {
                if (!value.Equals(datos_ALTA_VEHICULO.NID_PAIS))
                {
                    datos_ALTA_VEHICULO._oPais = null;
                    datos_ALTA_VEHICULO._oEntidad = null;
                }
                datos_ALTA_VEHICULO.NID_PAIS = value;
            }
        }


        new public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_ALTA_VEHICULO.CID_ENTIDAD_FEDERATIVA;
            set
            {
                if (!value.Equals(datos_ALTA_VEHICULO.CID_ENTIDAD_FEDERATIVA))
                {
                    datos_ALTA_VEHICULO._oEntidad = null;
                }
                datos_ALTA_VEHICULO.CID_ENTIDAD_FEDERATIVA = value;
            }
        }

        public String V_PAIS => datos_ALTA_VEHICULO.oPais.V_PAIS;
        public String V_ENTIDAD_FEDERATIVA => datos_ALTA_VEHICULO.oEntidad.V_ENTIDAD_FEDERATIVA;
        //sme
        blld_ALTA_VEHICULO_COPROPIETARIO _ALTA_VEHICULO_COPROPIETARIO { get; set; }

        public blld_ALTA_VEHICULO_COPROPIETARIO ALTA_VEHICULO_COPROPIETARIO
        {
            get
            {
                try
                {
                    if (_ALTA_VEHICULO_COPROPIETARIO == null)
                        _ALTA_VEHICULO_COPROPIETARIO = new blld_ALTA_VEHICULO_COPROPIETARIO(this.VID_NOMBRE
                                                                                            , this.VID_FECHA
                                                                                            , this.VID_HOMOCLAVE
                                                                                            , this.NID_DECLARACION
                                                                                            , this.NID_VEHICULO
                                                                                            , 1);
                }
                catch (Exception ex)
                {
                    if (ex is RowNotFoundException)
                        _ALTA_VEHICULO_COPROPIETARIO = new blld_ALTA_VEHICULO_COPROPIETARIO();
                }
                return _ALTA_VEHICULO_COPROPIETARIO;
            }
            set => _ALTA_VEHICULO_COPROPIETARIO = value;
        }
        #endregion


        #region *** Constructores (Extended) ***

        public blld_ALTA_VEHICULO(String VID_NOMBRE
                                , String VID_FECHA
                                , String VID_HOMOCLAVE
                                , Int32 NID_DECLARACION
                                , Int32 NID_TIPO_VECHICULO
                                , Int32 NID_MARCA
                                , String C_MODELO
                                , String V_DESCRIPCION
                                , DateTime F_ADQUISICION
                                , Int32 NID_USO
                                , Decimal M_VALOR_VEHICULO
                                , Int32 NID_PAIS
                                , String CID_ENTIDAD_FEDERATIVA
                                , String CID_TIPO_PERSONA_TRANSMISOR
                                , String E_NOMBRE_TRANSMISOR
                                , String E_RFC_TRANSMISOR
                                , Int32 NID_RELACION_TRANSMISOR
                                , String V_TIPO_MONEDA
                                , String E_NUMERO_SERIE
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
            if (F_ADQUISICION >= DateTime.Today) throw new CustomException("La fecha de adquisición del vehiculo no puede ser mayor que la fecha actual");
            if (Convert.ToInt32(C_MODELO) > F_ADQUISICION.Year + 2)
                throw new CustomException("El año del modelo no puede ser mayor que el año de adquisición");


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
            //if (!String.IsNullOrEmpty(CID_TIPO_PERSONA_TRANSMISOR))
            //{
            //    if (CID_TIPO_PERSONA_TRANSMISOR != "F" && CID_TIPO_PERSONA_TRANSMISOR != "M") throw new CustomException("Falta el tipo de persona del transmisor");

            //    if (String.IsNullOrEmpty(E_NOMBRE_TRANSMISOR)) throw new CustomException("Falta especificar el nombre del transmisor");

            //    if ((CID_TIPO_PERSONA_TRANSMISOR == "F" && E_NOMBRE_TRANSMISOR.Length < 5)) throw new CustomException("Falta especificar el nombre del transmisor");

            //    if (!String.IsNullOrEmpty(E_RFC_TRANSMISOR))
            //    {
            //        if (CID_TIPO_PERSONA_TRANSMISOR == "F")
            //            if (E_RFC_TRANSMISOR.Length != 13)
            //                throw new CustomException("El RFC del transmisor no tiene 13 caracteres");
            //            else
            //            { }
            //        else
            //            if (E_RFC_TRANSMISOR.Length != 12)
            //            throw new CustomException("El RFC del transmisor no tiene 12 caracteres");
            //    }


            //}


            Int32 NID_PATRIMONIO = dald_PATRIMONIO.nNuevo_NID_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            Int32 NID_VEHICULO = dald_ALTA_VEHICULO.nNuevo_NID_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);

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
            E_NUMERO_SERIE = Encripta(E_NUMERO_SERIE);
            E_OBSERVACIONES = Encripta(E_OBSERVACIONES);

            datos_ALTA_VEHICULO = new dald_ALTA_VEHICULO(VID_NOMBRE
                                                        , VID_FECHA
                                                        , VID_HOMOCLAVE
                                                        , NID_DECLARACION
                                                        , NID_VEHICULO
                                                        , NID_MARCA
                                                        , C_MODELO
                                                        , V_DESCRIPCION
                                                        , F_ADQUISICION
                                                        , NID_TIPO_VECHICULO
                                                        , NID_USO
                                                        , M_VALOR_VEHICULO
                                                        , NID_PATRIMONIO
                                                        , NID_PAIS
                                                        , CID_ENTIDAD_FEDERATIVA
                                                        , CID_TIPO_PERSONA_TRANSMISOR
                                                        , E_NOMBRE_TRANSMISOR
                                                        , E_RFC_TRANSMISOR
                                                        , NID_RELACION_TRANSMISOR
                                                        , V_TIPO_MONEDA
                                                        , E_NUMERO_SERIE
                                                        , NID_FORMA_ADQUISICION
                                                        , NID_FORMA_PAGO
                                                        , E_OBSERVACIONES
                                                        , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException
                                                        );


            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            {
                _ALTA_VEHICULO_COPROPIETARIO = new blld_ALTA_VEHICULO_COPROPIETARIO(VID_NOMBRE
                , VID_FECHA
                , VID_HOMOCLAVE
                , NID_DECLARACION
                , NID_VEHICULO
                , 1
                , CID_TIPO_PERSONA
                , V_NOMBRE
                , V_RFC
               );
            }
            if (ListDependientes != null)
            {
                foreach (Int32 nid_dependiente in ListDependientes)
                {
                    Add_ALTA_VEHICULO_TITULARs(nid_dependiente);
                }
            }
        }

        public blld_ALTA_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_TIPO_VECHICULO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO, Decimal M_PAGO_INICIAL, Boolean L_DONACION, List<Int32> ListDependientes)
      : base()
        {
            //if (ListDependientes == null) throw new CustomException("Debe haber al menos un titular");
            //if (ListDependientes.Count == 0) throw new CustomException("Debe haber al menos un titular");
            if (F_ADQUISICION >= DateTime.Today) throw new CustomException("La fecha de adquisición del vehiculo no puede ser mayor que la fecha actual");
            if (Convert.ToInt32(C_MODELO) > F_ADQUISICION.Year + 2)
                throw new CustomException("El año del modelo no puede ser mayor que el año de adquisición");

            Int32 NID_FORMA_ADQUISICION;
            if (L_DONACION)
                NID_FORMA_ADQUISICION = 1;
            else
                NID_FORMA_ADQUISICION = -1;

            Int32 NID_PATRIMONIO = dald_PATRIMONIO.nNuevo_NID_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            Int32 NID_VEHICULO = dald_ALTA_VEHICULO.nNuevo_NID_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            datos_ALTA_VEHICULO = new dald_ALTA_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_TIPO_VECHICULO, NID_USO, M_VALOR_VEHICULO, NID_PATRIMONIO, M_PAGO_INICIAL, NID_FORMA_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);

            if (ListDependientes != null)
            {
                foreach (Int32 nid_dependiente in ListDependientes)
                {
                    Add_ALTA_VEHICULO_TITULARs(nid_dependiente);
                }
            }
        }


        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_ALTA_VEHICULO_ADEUDOs()
        {
            _ALTA_ADEUDOs = new List<blld_ALTA_ADEUDO>();
            foreach (MODELDeclara_V2.ALTA_VEHICULO_ADEUDO o in datos_ALTA_VEHICULO._ALTA_VEHICULO_ADEUDOs)
            {
                try
                {
                    blld_ALTA_ADEUDO oAdeudo = new blld_ALTA_ADEUDO(this.VID_NOMBRE
                                                                    , this.VID_FECHA
                                                                    , this.VID_HOMOCLAVE
                                                                    , this.NID_DECLARACION
                                                                    , o.NID_ADEUDO

                         );
                    //if (oAdeudo.NID_TIPO_ADEUDO != 2)
                    //    throw new RowNotFoundException();
                    _ALTA_ADEUDOs.Add(oAdeudo);
                }
                catch (Exception ex)
                {
                    if (ex is RowNotFoundException)
                    {
                        blld_ALTA_VEHICULO_ADEUDO ade = new blld_ALTA_VEHICULO_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO, o.NID_ADEUDO);
                        ade.delete();
                    }
                    else
                    {
                        throw ex;
                    }

                }

            }
        }

        public void Add_ALTA_VEHICULO_ADEUDO(Int32 NID_ADEUDO)
        {
            try
            {
                _Add_ALTA_VEHICULO_ADEUDO(NID_ADEUDO);
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

        public void Reload_ALTA_VEHICULO_TITULARs()
        {
            _Reload_ALTA_VEHICULO_TITULARs();
        }

        public void Add_ALTA_VEHICULO_TITULARs(Int32 NID_DEPENDIENTE)
        {
            try
            {
                _Add_ALTA_VEHICULO_TITULARs(NID_DEPENDIENTE, true);
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




        public void update(List<Int32> ListDependientesVehiculos, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC)
        {
            //if (ListDependientesVehiculos == null) throw new CustomException("Debe haber al menos un titular");
            //if (ListDependientesVehiculos.Count == 0) throw new CustomException("Debe haber al menos un titular");

            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            {
                if (CID_TIPO_PERSONA != "F" && CID_TIPO_PERSONA != "M") throw new CustomException("Falta el tipo de persona del tercero");
                if (String.IsNullOrEmpty(V_NOMBRE) || V_NOMBRE.Length < 5) throw new CustomException("Falta especificar el nombre del tercero");
                if (!String.IsNullOrEmpty(V_RFC) && ((CID_TIPO_PERSONA == "F" && V_RFC.Length != 13) || (CID_TIPO_PERSONA == "M" && V_RFC.Length != 12))) throw new CustomException("El RFC del tercero es incorrecto");

            }

            if (!String.IsNullOrEmpty(this.CID_TIPO_PERSONA_TRANSMISOR))
            {
                if (this.CID_TIPO_PERSONA_TRANSMISOR != "F" && this.CID_TIPO_PERSONA_TRANSMISOR != "M") throw new CustomException("Falta el tipo de persona del transmisor");
                if (String.IsNullOrEmpty(this.E_NOMBRE_TRANSMISOR) || this.E_NOMBRE_TRANSMISOR.Length < 5) throw new CustomException("Falta especificar el nombre del transmisor");
                if (!String.IsNullOrEmpty(this.E_RFC_TRANSMISOR) && ((this.CID_TIPO_PERSONA_TRANSMISOR == "F" && this.E_RFC_TRANSMISOR.Length != 13) || (this.CID_TIPO_PERSONA_TRANSMISOR == "M" && this.E_RFC_TRANSMISOR.Length != 12))) throw new CustomException("El RFC del transmisor es incorrecto");

            }
            List<blld_ALTA_VEHICULO_TITULAR> ListAux = new List<blld_ALTA_VEHICULO_TITULAR>();
            foreach (blld_ALTA_VEHICULO_TITULAR o in ALTA_VEHICULO_TITULARs)
            {
                ListAux.Add(o);
            }

            foreach (blld_ALTA_VEHICULO_TITULAR select in ListAux)
            {
                if (!ListDependientesVehiculos.Contains(select.NID_DEPENDIENTE))
                    ALTA_VEHICULO_TITULARs.Remove(select);
            }
            if (ListDependientesVehiculos != null)
            {
                foreach (Int32 nid_Dependiente in ListDependientesVehiculos)
                {
                    Add_ALTA_VEHICULO_TITULARs(nid_Dependiente);
                }
            }
            datos_ALTA_VEHICULO.update();

            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            {
                _ALTA_VEHICULO_COPROPIETARIO = new blld_ALTA_VEHICULO_COPROPIETARIO(
                                                                                      this.VID_NOMBRE
                                                                                    , this.VID_FECHA
                                                                                    , this.VID_HOMOCLAVE
                                                                                    , this.NID_DECLARACION
                                                                                    , this.NID_VEHICULO
                                                                                    , 1
                                                                                    , CID_TIPO_PERSONA
                                                                                    , V_NOMBRE
                                                                                    , V_RFC);
            }
            else
                _ALTA_VEHICULO_COPROPIETARIO.update();
        }


        new public void delete()
        {
            Reload_ALTA_VEHICULO_ADEUDOs();
            if (ALTA_ADEUDOs.Any())
                throw new CustomException("El vehículo tiene adeudos asociados, eliminelos antes de eliminar el vehículo");
            //int val = ALTA_VEHICULO_TITULARs.Count - 1;
            //for (int i = val; i >= 0; i--)
            //{
            //    try { ALTA_VEHICULO_TITULARs.RemoveAt(i); } catch { };
            //}
            datos_ALTA_VEHICULO.delete();
        }

        new public void update()
        {
            if (Convert.ToInt32(C_MODELO) > F_ADQUISICION.Year + 2)
                throw new CustomException("El año del modelo no puede ser mayor que el año de adquisición");
            base.update();
        }

        public void Add_ALTA_VEHICULO_ADEUDO(int NID_PAIS, string CID_ENTIDAD_FEDERATIVA, string V_LUGAR, int NID_INSTITUCION, string V_OTRA, int NID_TIPO_ADEUDO, DateTime F_ADEUDO, decimal M_ORIGINAL, decimal M_SALDO, string E_CUENTA, List<int> NID_TITULARs)
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
                                            , NID_TITULARs
                                            , NID_VEHICULO
                                            , Convert.ToInt16(2)
                        ));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Add_ALTA_VEHICULO_ADEUDO(int NID_PAIS, string CID_ENTIDAD_FEDERATIVA, string V_LUGAR, int NID_INSTITUCION, string V_OTRA, int NID_TIPO_ADEUDO, DateTime F_ADEUDO, decimal M_ORIGINAL, decimal M_SALDO, string E_CUENTA, Decimal M_PAGOS, List<int> NID_TITULARs)
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
                                            , NID_TITULARs
                                            , NID_VEHICULO
                                            , Convert.ToInt16(2)
                        ));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

    }
}
