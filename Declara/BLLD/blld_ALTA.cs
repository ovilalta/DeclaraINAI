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
    public partial class blld_ALTA : bll_ALTA
    {

     #region *** Atributos ***


        private Lista<blld_ALTA_ADEUDO> _ALTA_ADEUDOs;
        public Lista<blld_ALTA_ADEUDO> ALTA_ADEUDOs
        {
          get
          {
              if(_ALTA_ADEUDOs == null)
              {
                  _ALTA_ADEUDOs = new Lista<blld_ALTA_ADEUDO>();
                  Reload_ALTA_ADEUDOs();
              }
              return _ALTA_ADEUDOs;
          }
        }

        private Lista<blld_ALTA_INVERSION> _ALTA_INVERSIONs;
        public Lista<blld_ALTA_INVERSION> ALTA_INVERSIONs
        {
          get
          {
              if(_ALTA_INVERSIONs == null)
              {
                  _ALTA_INVERSIONs = new Lista<blld_ALTA_INVERSION>();
                  Reload_ALTA_INVERSIONs();
              }
              return _ALTA_INVERSIONs;
          }
        }

        private Lista<blld_ALTA_MUEBLE> _ALTA_MUEBLEs;
        public Lista<blld_ALTA_MUEBLE> ALTA_MUEBLEs
        {
          get
          {
              if(_ALTA_MUEBLEs == null)
              {
                  _ALTA_MUEBLEs = new Lista<blld_ALTA_MUEBLE>();
                  Reload_ALTA_MUEBLEs();
              }
              return _ALTA_MUEBLEs;
          }
        }

        private Lista<blld_ALTA_VEHICULO> _ALTA_VEHICULOs;
        public Lista<blld_ALTA_VEHICULO> ALTA_VEHICULOs
        {
          get
          {
              if(_ALTA_VEHICULOs == null)
              {
                  _ALTA_VEHICULOs = new Lista<blld_ALTA_VEHICULO>();
                  Reload_ALTA_VEHICULOs();
              }
              return _ALTA_VEHICULOs;
          }
        }

        private Lista<blld_ALTA_TARJETA> _ALTA_TARJETAs;
        public Lista<blld_ALTA_TARJETA> ALTA_TARJETAs
        {
          get
          {
              if(_ALTA_TARJETAs == null)
              {
                  _ALTA_TARJETAs = new Lista<blld_ALTA_TARJETA>();
                  Reload_ALTA_TARJETAs();
              }
              return _ALTA_TARJETAs;
          }
        }

        private Lista<blld_ALTA_INMUEBLE> _ALTA_INMUEBLEs;
        public Lista<blld_ALTA_INMUEBLE> ALTA_INMUEBLEs
        {
          get
          {
              if(_ALTA_INMUEBLEs == null)
              {
                  _ALTA_INMUEBLEs = new Lista<blld_ALTA_INMUEBLE>();
                  Reload_ALTA_INMUEBLEs();
              }
              return _ALTA_INMUEBLEs;
          }
        }


     #endregion


     #region *** Constructores ***

        private blld_ALTA()
        : base()
        {
            _ALTA_ADEUDOs = null;
            _ALTA_INVERSIONs = null;
            _ALTA_MUEBLEs = null;
            _ALTA_VEHICULOs = null;
            _ALTA_TARJETAs = null;
            _ALTA_INMUEBLEs = null;
        }

        public blld_ALTA(MODELDeclara_V2.ALTA ALTA)
        : base(ALTA)
        {
        }

        public  blld_ALTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION)
        {
        }

        public blld_ALTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION,bool lDif)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_ALTA_ADEUDOs()
        {
            _ALTA_ADEUDOs = new Lista<blld_ALTA_ADEUDO>();
            foreach (MODELDeclara_V2.ALTA_ADEUDO o in datos_ALTA._ALTA_ADEUDOs)
            {
                _ALTA_ADEUDOs.Add(new blld_ALTA_ADEUDO(o));
            }
        }

        private void _Add_ALTA_ADEUDOs( Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA,String V_LUGAR, Int32 NID_INSTITUCION,String V_OTRA, Int32 NID_TIPO_ADEUDO,DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, String V_TIPO_MONEDA, String E_RFC, String E_OBSERVACIONES, String CID_TIPO_PERSONA_OTORGANTE, List<Int32> ListaTitulares)
        {
                blld_ALTA_ADEUDO oALTA_ADEUDO = new blld_ALTA_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PAIS, CID_ENTIDAD_FEDERATIVA,V_LUGAR, NID_INSTITUCION,V_OTRA, NID_TIPO_ADEUDO, F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, V_TIPO_MONEDA, E_RFC, E_OBSERVACIONES, CID_TIPO_PERSONA_OTORGANTE, ListaTitulares);
                if (oALTA_ADEUDO.lEsNuevoRegistro.Value) ALTA_ADEUDOs.Add(oALTA_ADEUDO);
        }

        public Int32 FindIndex_ALTA_ADEUDOs(Int32 NID_ADEUDO)
        {
            return  ALTA_ADEUDOs.FindIndex(p =>
                               p.NID_ADEUDO == NID_ADEUDO
                                                   );
        }


        private void _Reload_ALTA_INVERSIONs()
        {
            _ALTA_INVERSIONs = new Lista<blld_ALTA_INVERSION>();
            foreach (MODELDeclara_V2.ALTA_INVERSION o in datos_ALTA._ALTA_INVERSIONs)
            {
                _ALTA_INVERSIONs.Add(new blld_ALTA_INVERSION(o));
            }
        }

        private void _Add_ALTA_INVERSIONs(Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR,DateTime F_APERTURA, String V_RFC_INVERSION, String V_TIPO_MONEDA, String V_TERCERO_TIPO, String V_TERCERO_NOMBRE, String V_TERCERO_RFC, String E_OBSERVACIONES, List<Int32> ListaTitulares)
        {
                blld_ALTA_INVERSION oALTA_INVERSION = new blld_ALTA_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION,NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, NID_INSTITUCION, E_CUENTA, V_OTRO, M_SALDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR,F_APERTURA, V_RFC_INVERSION, V_TIPO_MONEDA, V_TERCERO_TIPO, V_TERCERO_NOMBRE, V_TERCERO_RFC, E_OBSERVACIONES, ListaTitulares);
            ALTA_INVERSIONs.Add(oALTA_INVERSION);
        }

        public Int32 FindIndex_ALTA_INVERSIONs(Int32 NID_INVERSION)
        {
            return  ALTA_INVERSIONs.FindIndex(p =>
                               p.NID_INVERSION == NID_INVERSION
                                                   );
        }


        private void _Reload_ALTA_MUEBLEs()
        {
            _ALTA_MUEBLEs = new Lista<blld_ALTA_MUEBLE>();
            foreach (MODELDeclara_V2.ALTA_MUEBLE o in datos_ALTA._ALTA_MUEBLEs)
            {
                _ALTA_MUEBLEs.Add(new blld_ALTA_MUEBLE(o));
            }
        }

        private void _Add_ALTA_MUEBLEs(   Int32 NID_TIPO
                                        , String E_ESPECIFICACION
                                        , Decimal M_VALOR
                                        , Boolean L_CREDITO
                                        , DateTime F_ADQUISICION
                                        , String CID_TIPO_PERSONA_TRANSMISOR
                                        , String E_NOMBRE_TRANSMISOR
                                        , String E_RFC_TRANSMISOR
                                        , Int32 NID_RELACION_TRANSMISOR
                                        , String V_TIPO_MONEDA
                                        , Int32 NID_FORMA_ADQUISICION
                                        , Int32 NID_FORMA_PAGO
                                        , String E_OBSERVACIONES
                                        , String CID_TIPO_PERSONA
                                        , String V_NOMBRE
                                        , String V_RFC
                                        , List<Int32> ListDependientes
                                        )
        {

            blld_ALTA_MUEBLE oALTA_MUEBLE = new blld_ALTA_MUEBLE( VID_NOMBRE
                                                                , VID_FECHA
                                                                , VID_HOMOCLAVE
                                                                , NID_DECLARACION
                                                                , NID_TIPO
                                                                , E_ESPECIFICACION
                                                                , M_VALOR
                                                                , L_CREDITO
                                                                , F_ADQUISICION
                                                                , CID_TIPO_PERSONA_TRANSMISOR
                                                                , E_NOMBRE_TRANSMISOR
                                                                , E_RFC_TRANSMISOR
                                                                , NID_RELACION_TRANSMISOR
                                                                , V_TIPO_MONEDA
                                                                , NID_FORMA_ADQUISICION
                                                                , NID_FORMA_PAGO
                                                                , E_OBSERVACIONES
                                                                , CID_TIPO_PERSONA
                                                                , V_NOMBRE
                                                                , V_RFC
                                                                , ListDependientes
                                                                );
            ALTA_MUEBLEs.Add(oALTA_MUEBLE);

            //if (oALTA_MUEBLE.lEsNuevoRegistro.Value) ALTA_MUEBLEs.Add(oALTA_MUEBLE);
            //ALTA_MUEBLEs[FindIndex_ALTA_MUEBLEs(NID_MUEBLE)] = oALTA_MUEBLE;
        }


        public Int32 FindIndex_ALTA_MUEBLEs(Int32 NID_MUEBLE)
        {
            return  ALTA_MUEBLEs.FindIndex(p =>
                               p.NID_MUEBLE == NID_MUEBLE
                                                   );
        }


        private void _Reload_ALTA_VEHICULOs()
        {
            _ALTA_VEHICULOs = new Lista<blld_ALTA_VEHICULO>();
            foreach (MODELDeclara_V2.ALTA_VEHICULO o in datos_ALTA._ALTA_VEHICULOs)
            {
                _ALTA_VEHICULOs.Add(new blld_ALTA_VEHICULO(o));
            }
        }

        private void _Add_ALTA_VEHICULOs(Int32 NID_TIPO_VECHICULO
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
        {
            blld_ALTA_VEHICULO oALTA_VEHICULO = new blld_ALTA_VEHICULO(VID_NOMBRE
                                                                        , VID_FECHA
                                                                        , VID_HOMOCLAVE
                                                                        , NID_DECLARACION
                                                                        , NID_TIPO_VECHICULO
                                                                        , NID_MARCA, C_MODELO
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
                                                                        , ListDependientes
                                                                        );
            ALTA_VEHICULOs.Add(oALTA_VEHICULO);
            //if (oALTA_VEHICULO.lEsNuevoRegistro.Value) ALTA_VEHICULOs.Add(oALTA_VEHICULO);
            //    _ALTA_VEHICULOs[FindIndex_ALTA_VEHICULOs(NID_VEHICULO)] = oALTA_VEHICULO;
        }

        public Int32 FindIndex_ALTA_VEHICULOs(Int32 NID_VEHICULO)
        {
            return  ALTA_VEHICULOs.FindIndex(p =>
                               p.NID_VEHICULO == NID_VEHICULO
                                                   );
        }


        private void _Reload_ALTA_TARJETAs()
        {
            _ALTA_TARJETAs = new Lista<blld_ALTA_TARJETA>();
            foreach (MODELDeclara_V2.ALTA_TARJETA o in datos_ALTA._ALTA_TARJETAs)
            {
                _ALTA_TARJETAs.Add(new blld_ALTA_TARJETA(o));
            }
        }

        private void _Add_ALTA_TARJETAs(String E_NUMERO, String V_NUMERO_CORTO, Decimal M_SALDO, Int32 NID_TITULAR)
        {
                blld_ALTA_TARJETA oALTA_TARJETA = new blld_ALTA_TARJETA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, V_NUMERO_CORTO, M_SALDO, NID_TITULAR);
                if (oALTA_TARJETA.lEsNuevoRegistro.Value) ALTA_TARJETAs.Add(oALTA_TARJETA);
                _ALTA_TARJETAs[FindIndex_ALTA_TARJETAs(E_NUMERO)] = oALTA_TARJETA;
        }

        public Int32 FindIndex_ALTA_TARJETAs(String E_NUMERO)
        {
            return  ALTA_TARJETAs.FindIndex(p =>
                               p.E_NUMERO == E_NUMERO
                                                   );
        }


        private void _Reload_ALTA_INMUEBLEs()
        {
            _ALTA_INMUEBLEs = new Lista<blld_ALTA_INMUEBLE>();
            foreach (MODELDeclara_V2.ALTA_INMUEBLE o in datos_ALTA._ALTA_INMUEBLEs)
            {
                _ALTA_INMUEBLEs.Add(new blld_ALTA_INMUEBLE(o));
            }
        }

        private void _Add_ALTA_INMUEBLEs( Int32 NID_TIPO
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
            blld_ALTA_INMUEBLE oALTA_INMUEBLE = new blld_ALTA_INMUEBLE(
                                                                          VID_NOMBRE
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
            ALTA_INMUEBLEs.Add(oALTA_INMUEBLE);
        }

        public Int32 FindIndex_ALTA_INMUEBLEs(Int32 NID_INMUEBLE)
        {
            return  ALTA_INMUEBLEs.FindIndex(p =>
                               p.NID_INMUEBLE == NID_INMUEBLE
                                                   );
        }      
        #endregion
    }
}
