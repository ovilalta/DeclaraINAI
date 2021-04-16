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
    public partial class blld_ALTA_INMUEBLE : bll_ALTA_INMUEBLE
    {

     #region *** Atributos ***


        private Lista<blld_ALTA_INMUEBLE_ADEUDO> _ALTA_INMUEBLE_ADEUDOs;
        public Lista<blld_ALTA_INMUEBLE_ADEUDO> ALTA_INMUEBLE_ADEUDOs
        {
          get
          {
              if(_ALTA_INMUEBLE_ADEUDOs == null)
              {
                  _ALTA_INMUEBLE_ADEUDOs = new Lista<blld_ALTA_INMUEBLE_ADEUDO>();
                  Reload_ALTA_INMUEBLE_ADEUDOs();
              }
              return _ALTA_INMUEBLE_ADEUDOs;
          }
        }

        private Lista<blld_ALTA_INMUEBLE_TITULAR> _ALTA_INMUEBLE_TITULARs;
        public Lista<blld_ALTA_INMUEBLE_TITULAR> ALTA_INMUEBLE_TITULARs
        {
          get
          {
              if(_ALTA_INMUEBLE_TITULARs == null)
              {
                  _ALTA_INMUEBLE_TITULARs = new Lista<blld_ALTA_INMUEBLE_TITULAR>();
                  Reload_ALTA_INMUEBLE_TITULARs();
              }
              return _ALTA_INMUEBLE_TITULARs;
          }
        }

        #region * CAT_TIPO_INMUEBLE *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo T I P O es requerido ")]
        [DisplayName("T I P O")]
        public String V_TIPO => datos_ALTA_INMUEBLE.V_TIPO;



        #endregion * CAT_TIPO_INMUEBLE *


        #region * CAT_USO_INMUEBLE *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo U S O es requerido ")]
        [DisplayName("U S O")]
        public String V_USO => datos_ALTA_INMUEBLE.V_USO;


        #endregion * CAT_USO_INMUEBLE *



     #endregion


     #region *** Constructores ***

        private blld_ALTA_INMUEBLE()
        : base()
        {
            _ALTA_INMUEBLE_ADEUDOs = null;
            _ALTA_INMUEBLE_TITULARs = null;
        }

        public blld_ALTA_INMUEBLE(MODELDeclara_V2.ALTA_INMUEBLE ALTA_INMUEBLE)
        : base(ALTA_INMUEBLE)
        {
        }

        public  blld_ALTA_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE)
        {
        }

        public blld_ALTA_INMUEBLE(
                                      String VID_NOMBRE
                                    , String VID_FECHA
                                    , String VID_HOMOCLAVE
                                    , Int32 NID_DECLARACION
                                    , Int32 NID_INMUEBLE
                                    , Int32 NID_TIPO
                                    , DateTime F_ADQUISICION
                                    , Int32 NID_USO
                                    , String E_UBICACION
                                    , Decimal N_TERRENO
                                    , Decimal N_CONSTRUCCION
                                    , Decimal M_VALOR_INMUEBLE
                                    , Int32 NID_PATRIMONIO
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
                                    )
        : base(
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
              )
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_ALTA_INMUEBLE_ADEUDOs()
        {
            _ALTA_INMUEBLE_ADEUDOs = new Lista<blld_ALTA_INMUEBLE_ADEUDO>();
            foreach (MODELDeclara_V2.ALTA_INMUEBLE_ADEUDO o in datos_ALTA_INMUEBLE._ALTA_INMUEBLE_ADEUDOs)
            {
                _ALTA_INMUEBLE_ADEUDOs.Add(new blld_ALTA_INMUEBLE_ADEUDO(o));
            }
        }

        private void _Add_ALTA_INMUEBLE_ADEUDOs(Int32 NID_ADEUDO, Boolean L_DIF)
        {
                blld_ALTA_INMUEBLE_ADEUDO oALTA_INMUEBLE_ADEUDO = new blld_ALTA_INMUEBLE_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_ADEUDO, L_DIF);
                if (oALTA_INMUEBLE_ADEUDO.lEsNuevoRegistro.Value) ALTA_INMUEBLE_ADEUDOs.Add(oALTA_INMUEBLE_ADEUDO);
                _ALTA_INMUEBLE_ADEUDOs[FindIndex_ALTA_INMUEBLE_ADEUDOs(NID_ADEUDO)] = oALTA_INMUEBLE_ADEUDO;
        }

        public Int32 FindIndex_ALTA_INMUEBLE_ADEUDOs(Int32 NID_ADEUDO)
        {
            return  ALTA_INMUEBLE_ADEUDOs.FindIndex(p =>
                               p.NID_ADEUDO == NID_ADEUDO
                                                   );
        }


        private void _Reload_ALTA_INMUEBLE_TITULARs()
        {
            _ALTA_INMUEBLE_TITULARs = new Lista<blld_ALTA_INMUEBLE_TITULAR>();
            foreach (MODELDeclara_V2.ALTA_INMUEBLE_TITULAR o in datos_ALTA_INMUEBLE._ALTA_INMUEBLE_TITULARs)
            {
                _ALTA_INMUEBLE_TITULARs.Add(new blld_ALTA_INMUEBLE_TITULAR(o));
            }
        }

        private void _Add_ALTA_INMUEBLE_TITULARs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_ALTA_INMUEBLE_TITULAR oALTA_INMUEBLE_TITULAR = new blld_ALTA_INMUEBLE_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_DEPENDIENTE, L_DIF);
                if (oALTA_INMUEBLE_TITULAR.lEsNuevoRegistro.Value) ALTA_INMUEBLE_TITULARs.Add(oALTA_INMUEBLE_TITULAR);
                _ALTA_INMUEBLE_TITULARs[FindIndex_ALTA_INMUEBLE_TITULARs(NID_DEPENDIENTE)] = oALTA_INMUEBLE_TITULAR;
        }

        public Int32 FindIndex_ALTA_INMUEBLE_TITULARs(Int32 NID_DEPENDIENTE)
        {
            return  ALTA_INMUEBLE_TITULARs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }



     #endregion

    }
}
