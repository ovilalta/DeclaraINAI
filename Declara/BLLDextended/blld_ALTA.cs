using Declara_V2.BLL;
using System;
using System.Collections.Generic;

namespace Declara_V2.BLLD
{
    // Extended
    public partial class blld_ALTA : bll_ALTA
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_ALTA.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_ALTA.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_ALTA.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_ALTA.NID_DECLARACION; }
        //        }

        private Lista<blld_ALTA_COMODATO_INMUEBLE> _ALTA_COMODATO_INMUEBLEs { get; set; }
        private Lista<blld_ALTA_COMODATO_VEHICULO> _ALTA_COMODATO_VEHICULOs { get; set; }

        public Lista<blld_ALTA_COMODATO_INMUEBLE> ALTA_COMODATO_INMUEBLEs
        {
            get
            {
                if (_ALTA_COMODATO_INMUEBLEs == null)
                {
                    _ALTA_COMODATO_INMUEBLEs = new Lista<blld_ALTA_COMODATO_INMUEBLE>();
                    Reload_ALTA_COMODATO_INMUEBLEs();
                }
                return _ALTA_COMODATO_INMUEBLEs;
            }
        }
        public Lista<blld_ALTA_COMODATO_VEHICULO> ALTA_COMODATO_VEHICULOs
        {
            get
            {
                if (_ALTA_COMODATO_VEHICULOs == null)
                {
                    _ALTA_COMODATO_VEHICULOs = new Lista<blld_ALTA_COMODATO_VEHICULO>();
                    Reload_ALTA_COMODATO_VEHICULOs();
                }
                return _ALTA_COMODATO_VEHICULOs;
            }
        }

        private Lista<blld_ALTA_COMODATO> _ALTA_COMODATOs { get; set; }
        public Lista<blld_ALTA_COMODATO> ALTA_COMODATOs
        {
            get
            {
                if (_ALTA_COMODATOs == null)
                {
                    _ALTA_COMODATOs = new Lista<blld_ALTA_COMODATO>();
                    Reload_ALTA_COMODATOs();
                }
                return _ALTA_COMODATOs;
            }
        }
        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_ALTA_ADEUDOs()
        {
            _Reload_ALTA_ADEUDOs();
        }

        public void Add_ALTA_ADEUDOs(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, String V_TIPO_MONEDA, String E_RFC, String E_OBSERVACIONES, String CID_TIPO_PERSONA_OTORGANTE, List<Int32> ListaTitulares)
        {
            try
            {

                _Add_ALTA_ADEUDOs(NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO, F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, V_TIPO_MONEDA, E_RFC, E_OBSERVACIONES, CID_TIPO_PERSONA_OTORGANTE, ListaTitulares);
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

        public void Add_ALTA_ADEUDOs(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, Decimal M_PAGOS, List<Int32> ListaTitulares)
        {
            try
            {

                _Add_ALTA_ADEUDOs(NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO, F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, M_PAGOS, ListaTitulares);
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

        private void _Add_ALTA_ADEUDOs(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, Decimal M_PAGOS, List<Int32> ListaTitulares)
        {
            blld_ALTA_ADEUDO oALTA_ADEUDO = new blld_ALTA_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO, F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, M_PAGOS, ListaTitulares);
            if (oALTA_ADEUDO.lEsNuevoRegistro.Value) ALTA_ADEUDOs.Add(oALTA_ADEUDO);
        }

        public void Reload_ALTA_INVERSIONs()
        {
            _Reload_ALTA_INVERSIONs();
        }

        public void Add_ALTA_INVERSIONs(Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, DateTime F_APERTURA, String V_RFC_INVERSION, String V_TIPO_MONEDA, String V_TERCERO_TIPO, String V_TERCERO_NOMBRE, String V_TERCERO_RFC, String E_OBSERVACIONES, List<Int32> ListaTitulares)
        {
            try
            {
                _Add_ALTA_INVERSIONs(NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, NID_INSTITUCION, E_CUENTA, V_OTRO, M_SALDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, F_APERTURA, V_RFC_INVERSION, V_TIPO_MONEDA, V_TERCERO_TIPO, V_TERCERO_NOMBRE, V_TERCERO_RFC, E_OBSERVACIONES, ListaTitulares);
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

        public void Reload_ALTA_MUEBLEs()
        {
            _Reload_ALTA_MUEBLEs();
        }

        public void Add_ALTA_MUEBLEs(Int32 NID_TIPO
                                    , String E_ESPECIFICACION
                                    , Decimal M_VALOR
                                    , Boolean L_CREDITO
                                    , DateTime F_ADQUISICION
                                    , String CID_TIPO_PERSONA_TRANSMISOR
                                    , String E_NOMBRE_TRANSMISOR
                                    , String E_RFC_TRANSMISOR
                                    , Int32 NID_RELACION_TRANSMISOR
                                    , String V_TIPO_MONEDA
                                    , Int32 V_FORMA_ADQUISICION
                                    , Int32 V_FORMA_PAGO
                                    , String E_OBSERVACIONES
                                    , String CID_TIPO_PERSONA
                                    , String V_NOMBRE
                                    , String V_RFC
                                    , List<Int32> ListaDependietesMuebles
                                    )
        {
            try
            {
                _Add_ALTA_MUEBLEs(NID_TIPO
                                , E_ESPECIFICACION
                                , M_VALOR
                                , L_CREDITO
                                , F_ADQUISICION
                                , CID_TIPO_PERSONA_TRANSMISOR
                                , E_NOMBRE_TRANSMISOR
                                , E_RFC_TRANSMISOR
                                , NID_RELACION_TRANSMISOR
                                , V_TIPO_MONEDA
                                , V_FORMA_ADQUISICION
                                , V_FORMA_PAGO
                                , E_OBSERVACIONES
                                , CID_TIPO_PERSONA
                                , V_NOMBRE
                                , V_RFC
                                , ListaDependietesMuebles
                                );
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

        public void Add_ALTA_MUEBLEs(Int32 NID_TIPO, String E_ESPECIFICACION, Decimal M_VALOR, Boolean L_CREDITO, DateTime F_ADQUISICION, Boolean L_DONACION, List<Int32> ListaDependietesMuebles)
        {
            try
            {
                _Add_ALTA_MUEBLEs(NID_TIPO, E_ESPECIFICACION, M_VALOR, L_CREDITO, F_ADQUISICION, L_DONACION, ListaDependietesMuebles);
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

        private void _Add_ALTA_MUEBLEs(Int32 NID_TIPO, String E_ESPECIFICACION, Decimal M_VALOR, Boolean L_CREDITO, DateTime F_ADQUISICION, Boolean L_DONACION, List<Int32> ListDependientes)
        {

            blld_ALTA_MUEBLE oALTA_MUEBLE = new blld_ALTA_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_TIPO, E_ESPECIFICACION, M_VALOR, L_CREDITO, F_ADQUISICION, L_DONACION, ListDependientes);
            ALTA_MUEBLEs.Add(oALTA_MUEBLE);

            //if (oALTA_MUEBLE.lEsNuevoRegistro.Value) ALTA_MUEBLEs.Add(oALTA_MUEBLE);
            //ALTA_MUEBLEs[FindIndex_ALTA_MUEBLEs(NID_MUEBLE)] = oALTA_MUEBLE;
        }

        public void Reload_ALTA_VEHICULOs()
        {
            _Reload_ALTA_VEHICULOs();
        }

        public void Add_ALTA_VEHICULOs(Int32 NID_TIPO_VEHICULO
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
                                        , List<Int32> ListaDependietesVehiculo
                                        )
        {
            try
            {
                _Add_ALTA_VEHICULOs(NID_TIPO_VEHICULO
                                    , NID_MARCA
                                    , C_MODELO
                                    , V_DESCRIPCION
                                    , F_ADQUISICION
                                    , NID_USO
                                    , M_VALOR_VEHICULO
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
                                    , CID_TIPO_PERSONA
                                    , V_NOMBRE
                                    , V_RFC
                                    , ListaDependietesVehiculo
                                    );
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

        public void Add_ALTA_VEHICULOs(Int32 NID_TIPO_VEHICULO
                                    , Int32 NID_MARCA
                                    , String C_MODELO
                                    , String V_DESCRIPCION
                                    , DateTime F_ADQUISICION
                                    , Int32 NID_USO
                                    , Decimal M_VALOR_VEHICULO
                                    , Decimal M_PAGO_INICIAL
                                    , Boolean L_DONACION
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
                                    , List<Int32> ListaDependietesVehiculo
                                    )
        {
            try
            {
                _Add_ALTA_VEHICULOs(NID_TIPO_VEHICULO
                                    , NID_MARCA
                                    , C_MODELO
                                    , V_DESCRIPCION
                                    , F_ADQUISICION
                                    , NID_USO
                                    , M_VALOR_VEHICULO
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
                                    , CID_TIPO_PERSONA
                                    , V_NOMBRE
                                    , V_RFC
                                    , ListaDependietesVehiculo
                                    );
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

        private void _Add_ALTA_VEHICULOs(Int32 NID_TIPO_VECHICULO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO, Decimal M_PAGO_INICIAL, Boolean L_DONACION, List<Int32> ListDependientes)
        {
            blld_ALTA_VEHICULO oALTA_VEHICULO = new blld_ALTA_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_TIPO_VECHICULO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_USO, M_VALOR_VEHICULO, M_PAGO_INICIAL, L_DONACION, ListDependientes);
            ALTA_VEHICULOs.Add(oALTA_VEHICULO);
            //if (oALTA_VEHICULO.lEsNuevoRegistro.Value) ALTA_VEHICULOs.Add(oALTA_VEHICULO);
            //    _ALTA_VEHICULOs[FindIndex_ALTA_VEHICULOs(NID_VEHICULO)] = oALTA_VEHICULO;
        }

        public void Reload_ALTA_TARJETAs()
        {
            _Reload_ALTA_TARJETAs();
        }

        public void Add_ALTA_TARJETAs(String E_NUMERO, String V_NUMERO_CORTO, Decimal M_SALDO, Int32 NID_TITULAR)
        {
            try
            {
                _Add_ALTA_TARJETAs(E_NUMERO, V_NUMERO_CORTO, M_SALDO, NID_TITULAR);
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

        public void Reload_ALTA_INMUEBLEs()
        {
            _Reload_ALTA_INMUEBLEs();
        }

        public void Add_ALTA_INMUEBLEs(Int32 NID_TIPO
                                        , DateTime F_ADQUISICION
                                        , Int32 NID_TIPO_COMPRA
                                        , Int32 NID_USO
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
        {
            try
            {
                _Add_ALTA_INMUEBLEs(NID_TIPO
                                    , F_ADQUISICION
                                    , NID_TIPO_COMPRA
                                    , NID_USO
                                    , E_UBICACION
                                    , N_TERRENO
                                    , N_CONSTRUCCION
                                    , M_VALOR_INMUEBLE
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
                                    , CID_TIPO_PERSONA
                                    , V_NOMBRE
                                    , V_RFC
                                    , ListDependientes
                                   );
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

        public void Add_ALTA_INMUEBLEs(Int32 NID_TIPO
                                        , DateTime F_ADQUISICION
                                        , Int32 NID_TIPO_COMPRA
                                        , Int32 NID_USO
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
        {
            try
            {
                _Add_ALTA_INMUEBLEs(NID_TIPO
                                    , F_ADQUISICION
                                    , NID_TIPO_COMPRA
                                    , NID_USO
                                    , E_UBICACION
                                    , N_TERRENO
                                    , N_CONSTRUCCION
                                    , M_VALOR_INMUEBLE
                                    , M_PAGO_INICIAL
                                    , L_DONACION
                                    , N_PORCENTAJE_DECLARANTE
                                    , CID_TIPO_PERSONA_TRANSMISOR
                                    , E_NOMBRE_TRANSMISOR
                                    , E_RFC_TRANSMISOR
                                    , NID_RELACION_TRANSMISOR
                                    , V_TIPO_MONEDA
                                    , E_REGISTRO_PUBLICO_PROPIEDAD
                                    , NID_VALOR_ADQUISICION
                                    , E_OBSERVACIONES
                                    , CID_TIPO_PERSONA
                                    , V_NOMBRE
                                    , V_RFC
                                    , ListDependientes
                                    );
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

        private void _Add_ALTA_INMUEBLEs(
                                              Int32 NID_TIPO
                                            , DateTime F_ADQUISICION
                                            , Int32 NID_TIPO_COMPRA
                                            , Int32 NID_USO
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
        {
            blld_ALTA_INMUEBLE oALTA_INMUEBLE = new blld_ALTA_INMUEBLE(VID_NOMBRE
                                                                        , VID_FECHA
                                                                        , VID_HOMOCLAVE
                                                                        , NID_DECLARACION
                                                                        , F_ADQUISICION
                                                                        , NID_USO
                                                                        , NID_TIPO
                                                                        , E_UBICACION
                                                                        , N_TERRENO
                                                                        , N_CONSTRUCCION
                                                                        , M_VALOR_INMUEBLE
                                                                        , M_PAGO_INICIAL
                                                                        , L_DONACION
                                                                        , N_PORCENTAJE_DECLARANTE
                                                                        , CID_TIPO_PERSONA_TRANSMISOR
                                                                        , E_NOMBRE_TRANSMISOR
                                                                        , E_RFC_TRANSMISOR
                                                                        , NID_RELACION_TRANSMISOR
                                                                        , V_TIPO_MONEDA
                                                                        , E_REGISTRO_PUBLICO_PROPIEDAD
                                                                        , NID_VALOR_ADQUISICION
                                                                        , E_OBSERVACIONES
                                                                        , CID_TIPO_PERSONA
                                                                        , V_NOMBRE
                                                                        , V_RFC
                                                                        , ListDependientes);
            ALTA_INMUEBLEs.Add(oALTA_INMUEBLE);
        }

        private void _Reload_ALTA_COMODATO()
        {
            _ALTA_COMODATOs = new Lista<blld_ALTA_COMODATO>();
            foreach (MODELDeclara_V2.ALTA_COMODATO o in datos_ALTA._ALTA_COMODATOs)
                _ALTA_COMODATOs.Add(new blld_ALTA_COMODATO(o));
        }
        private void _Add_ALTA_COMODATOs(String VID_NOMBRE
                                        , String VID_FECHA
                                        , String VID_HOMOCLAVE
                                        , Int32 NID_DECLARACION
                                        , String CID_TIPO_PERSONA
                                        , String E_TITULAR
                                        , String E_RFC
                                        , Int32 NID_TIPO_RELACION
                                        , String E_OBSERVACIONES)
        {
            blld_ALTA_COMODATO oALTA_COMODATO = new blld_ALTA_COMODATO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, CID_TIPO_PERSONA, E_TITULAR, E_RFC, NID_TIPO_RELACION, E_OBSERVACIONES);
            //if(oALTA_COMODATO.lEsNuevoRegistro.Value) ALTA_COMODATOs.Add(oALTA_COMODATO);
            //ALTA_COMODATOs[FindIndex_ALTA_COMODATOs(cIdEjercicio, nIdSolicitud, vIdDato)] = oALTA_COMODATO;
            ALTA_COMODATOs.Add(oALTA_COMODATO);
        }

        private void _Reload_ALTA_COMODATOs()
        {
            _ALTA_COMODATOs = new Lista<blld_ALTA_COMODATO>();
            foreach (MODELDeclara_V2.ALTA_COMODATO o in datos_ALTA._ALTA_COMODATOs)
                _ALTA_COMODATOs.Add(new blld_ALTA_COMODATO(o));
        }

        public void Reload_ALTA_COMODATOs()
        {
            _Reload_ALTA_COMODATOs();
        }
        public void Add_ALTA_COMODATOs(String CID_TIPO_PERSONA
                                    , String E_TITULAR
                                    , String E_RFC
                                    , Int32 NID_TIPO_RELACION
                                    , String E_OBSERVACIONES)
        {
            _Add_ALTA_COMODATOs(VID_NOMBRE
                                , VID_FECHA
                                , VID_HOMOCLAVE
                                , NID_DECLARACION
                                , CID_TIPO_PERSONA
                                , E_TITULAR
                                , E_RFC
                                , NID_TIPO_RELACION
                                , E_OBSERVACIONES);
        }

        private void _Reload_ALTA_COMODATO_VEHICULO()
        {
            _ALTA_COMODATO_VEHICULOs = new Lista<blld_ALTA_COMODATO_VEHICULO>();
            foreach (MODELDeclara_V2.ALTA_COMODATO_VEHICULO o in datos_ALTA._ALTA_COMODATO_VEHICULOs)
                _ALTA_COMODATO_VEHICULOs.Add(new blld_ALTA_COMODATO_VEHICULO(o));
        }
        private void _Add_ALTA_COMODATO_VEHICULOs(String VID_NOMBRE
                                                    , String VID_FECHA
                                                    , String VID_HOMOCLAVE
                                                    , Int32 NID_DECLARACION
                                                    , Int32 NID_TIPO_VEHICULO
                                                    , Int32 NID_MARCA
                                                    , String C_MODELO
                                                    , String V_DESCRIPCION
                                                    , String E_NUMERO_SERIE
                                                    , Int32 NID_PAIS
                                                    , String CID_ENTIDAD_FEDERATIVA
                                                    )
        {
            blld_ALTA_COMODATO_VEHICULO oALTA_COMODATO_VEHICULO = new blld_ALTA_COMODATO_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_TIPO_VEHICULO, NID_MARCA, C_MODELO, V_DESCRIPCION, E_NUMERO_SERIE, NID_PAIS, CID_ENTIDAD_FEDERATIVA);
            ALTA_COMODATO_VEHICULOs.Add(oALTA_COMODATO_VEHICULO);
        }
        private void _Reload_ALTA_COMODATO_INMUEBLE()
        {
            _ALTA_COMODATO_INMUEBLEs = new Lista<blld_ALTA_COMODATO_INMUEBLE>();
            foreach (MODELDeclara_V2.ALTA_COMODATO_INMUEBLE o in datos_ALTA._ALTA_COMODATO_INMUEBLEs)
                _ALTA_COMODATO_INMUEBLEs.Add(new blld_ALTA_COMODATO_INMUEBLE(o));
        }
        private void _Add_ALTA_COMODATO_INMUEBLEs(
                                                String VID_NOMBRE
                                                , String VID_FECHA
                                                , String VID_HOMOCLAVE
                                                , Int32 NID_DECLARACION
                                                , Int32 NID_TIPO
                                                , String C_CODIGO_POSTAL
                                                , Int32 NID_PAIS
                                                , String CID_ENTIDAD_FEDERATIVA
                                                , String CID_MUNICIPIO
                                                , String V_COLONIA
                                                , String V_DOMICILIO)

        {
            blld_ALTA_COMODATO_INMUEBLE oALTA_COMODATO_INMUEBLE = new blld_ALTA_COMODATO_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_TIPO, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO);
            ALTA_COMODATO_INMUEBLEs.Add(oALTA_COMODATO_INMUEBLE);
        }


        private void _Reload_ALTA_COMODATO_INMUEBLEs()
        {
            _ALTA_COMODATO_INMUEBLEs = new Lista<blld_ALTA_COMODATO_INMUEBLE>();
            foreach (MODELDeclara_V2.ALTA_COMODATO_INMUEBLE o in datos_ALTA._ALTA_COMODATO_INMUEBLEs)
                _ALTA_COMODATO_INMUEBLEs.Add(new blld_ALTA_COMODATO_INMUEBLE(o));
        }
        public void Reload_ALTA_COMODATO_INMUEBLEs()
        {
            _Reload_ALTA_COMODATO_INMUEBLEs();
        }

        private void _Reload_ALTA_COMODATO_VEHICULOs()
        {
            _ALTA_COMODATO_VEHICULOs = new Lista<blld_ALTA_COMODATO_VEHICULO>();
            foreach (MODELDeclara_V2.ALTA_COMODATO_VEHICULO o in datos_ALTA._ALTA_COMODATO_VEHICULOs)
                _ALTA_COMODATO_VEHICULOs.Add(new blld_ALTA_COMODATO_VEHICULO(o));
        }
        public void Reload_ALTA_COMODATO_VEHICULOs()
        {
            _Reload_ALTA_COMODATO_VEHICULOs();
        }



        public void Add_ALTA_COMODATO_INMUEBLEs(
                                                Int32 NID_TIPO
                                                , String C_CODIGO_POSTAL
                                                , Int32 NID_PAIS
                                                , String CID_ENTIDAD_FEDERATIVA
                                                , String CID_MUNICIPIO
                                                , String V_COLONIA
                                                , String V_DOMICILIO)
        {
            _Add_ALTA_COMODATO_INMUEBLEs(
                                VID_NOMBRE
                                , VID_FECHA
                                , VID_HOMOCLAVE
                                , NID_DECLARACION
                                , NID_TIPO
                                , C_CODIGO_POSTAL
                                , NID_PAIS
                                , CID_ENTIDAD_FEDERATIVA
                                , CID_MUNICIPIO
                                , V_COLONIA
                                , V_DOMICILIO
                                 );
        }
        public void Add_ALTA_COMODATO_VEHICULOs(
                                                 Int32 NID_TIPO_VEHICULO
                                                , Int32 NID_MARCA
                                                , String C_MODELO
                                                , String V_DESCRIPCION
                                                , String E_NUMERO_SERIE
                                                , Int32 NID_PAIS
                                                , String CID_ENTIDAD_FEDERATIVA)
        {
            _Add_ALTA_COMODATO_VEHICULOs(
                                VID_NOMBRE
                                , VID_FECHA
                                , VID_HOMOCLAVE
                                , NID_DECLARACION
                                , NID_TIPO_VEHICULO
                                , NID_MARCA
                                , C_MODELO
                                , V_DESCRIPCION
                                , E_NUMERO_SERIE
                                , NID_PAIS
                                , CID_ENTIDAD_FEDERATIVA
                                );
        }

        #endregion

    }
}
