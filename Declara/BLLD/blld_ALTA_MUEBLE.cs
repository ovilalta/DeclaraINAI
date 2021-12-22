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
    public partial class blld_ALTA_MUEBLE : bll_ALTA_MUEBLE
    {

     #region *** Atributos ***


        private Lista<blld_ALTA_MUEBLE_TITULAR> _ALTA_MUEBLE_TITULARs;
        public Lista<blld_ALTA_MUEBLE_TITULAR> ALTA_MUEBLE_TITULARs
        {
          get
          {
              if(_ALTA_MUEBLE_TITULARs == null)
              {
                  _ALTA_MUEBLE_TITULARs = new Lista<blld_ALTA_MUEBLE_TITULAR>();
                  Reload_ALTA_MUEBLE_TITULARs();
              }
              return _ALTA_MUEBLE_TITULARs;
          }
        }

        #region * CAT_TIPO_MUEBLE *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo T I P O es requerido ")]
        [DisplayName("T I P O")]
        public String V_TIPO => datos_ALTA_MUEBLE.V_TIPO;


        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO => datos_ALTA_MUEBLE.L_ACTIVO;

        #endregion * CAT_TIPO_MUEBLE *



     #endregion


     #region *** Constructores ***

        private blld_ALTA_MUEBLE()
        : base()
        {
            _ALTA_MUEBLE_TITULARs = null;
        }

        public blld_ALTA_MUEBLE(MODELDeclara_V2.ALTA_MUEBLE ALTA_MUEBLE)
        : base(ALTA_MUEBLE)
        {
        }

        public  blld_ALTA_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE)
        {
        }

        public blld_ALTA_MUEBLE(String VID_NOMBRE
                                , String VID_FECHA
                                , String VID_HOMOCLAVE
                                , Int32 NID_DECLARACION
                                , Int32 NID_MUEBLE
                                , Int32 NID_TIPO
                                , String E_ESPECIFICACION
                                , Decimal M_VALOR
                                , Int32 NID_PATRIMONIO
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
                                , String D_ESPECIFICACION
                                )
        : base(VID_NOMBRE
                , VID_FECHA
                , VID_HOMOCLAVE
                , NID_DECLARACION
                , NID_MUEBLE
                , NID_TIPO
                , E_ESPECIFICACION
                , M_VALOR
                , NID_PATRIMONIO
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
                , D_ESPECIFICACION
                , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException
                )
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_ALTA_MUEBLE_TITULARs()
        {
            _ALTA_MUEBLE_TITULARs = new Lista<blld_ALTA_MUEBLE_TITULAR>();
            foreach (MODELDeclara_V2.ALTA_MUEBLE_TITULAR o in datos_ALTA_MUEBLE._ALTA_MUEBLE_TITULARs)
            {
                _ALTA_MUEBLE_TITULARs.Add(new blld_ALTA_MUEBLE_TITULAR(o));
            }
        }

        private void _Add_ALTA_MUEBLE_TITULARs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_ALTA_MUEBLE_TITULAR oALTA_MUEBLE_TITULAR = new blld_ALTA_MUEBLE_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE, NID_DEPENDIENTE, L_DIF);
                if (oALTA_MUEBLE_TITULAR.lEsNuevoRegistro.Value) ALTA_MUEBLE_TITULARs.Add(oALTA_MUEBLE_TITULAR);
                _ALTA_MUEBLE_TITULARs[FindIndex_ALTA_MUEBLE_TITULARs(NID_DEPENDIENTE)] = oALTA_MUEBLE_TITULAR;
        }

        public Int32 FindIndex_ALTA_MUEBLE_TITULARs(Int32 NID_DEPENDIENTE)
        {
            return  ALTA_MUEBLE_TITULARs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }



     #endregion

    }
}
