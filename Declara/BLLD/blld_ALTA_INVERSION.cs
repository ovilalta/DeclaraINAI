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
    public partial class blld_ALTA_INVERSION : bll_ALTA_INVERSION
    {

     #region *** Atributos ***


        private Lista<blld_ALTA_INVERSION_TITULAR> _ALTA_INVERSION_TITULARs;
        public Lista<blld_ALTA_INVERSION_TITULAR> ALTA_INVERSION_TITULARs
        {
          get
          {
              if(_ALTA_INVERSION_TITULARs == null)
              {
                  _ALTA_INVERSION_TITULARs = new Lista<blld_ALTA_INVERSION_TITULAR>();
                  Reload_ALTA_INVERSION_TITULARs();
              }
              return _ALTA_INVERSION_TITULARs;
          }
        }

        #region * CAT_ENTIDAD_FEDERATIVA *


        //[StringLength(511)]
        //[DataType(DataType.MultilineText)]
        //[Required(ErrorMessage = "El campo  es requerido ")]
        //[DisplayName("")]
        //public String V_ENTIDAD_FEDERATIVA => datos_ALTA_INVERSION.V_ENTIDAD_FEDERATIVA;

        #endregion * CAT_ENTIDAD_FEDERATIVA *


        #region * CAT_SUBTIPO_INVERSION *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_SUBTIPO_INVERSION => datos_ALTA_INVERSION.V_SUBTIPO_INVERSION;
        public String V_TIPO_INVERSION => datos_ALTA_INVERSION.V_TIPO_INVERSION;


        #endregion * CAT_SUBTIPO_INVERSION *


        #region * CAT_INST_FINANCIERA *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_INSTITUCION => datos_ALTA_INVERSION.V_INSTITUCION;

        #endregion * CAT_INST_FINANCIERA *



     #endregion


     #region *** Constructores ***

        private blld_ALTA_INVERSION()
        : base()
        {
            _ALTA_INVERSION_TITULARs = null;
        }

        public blld_ALTA_INVERSION(MODELDeclara_V2.ALTA_INVERSION ALTA_INVERSION)
        : base(ALTA_INVERSION)
        {
        }

        public  blld_ALTA_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION)
        {
        }

        public blld_ALTA_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION, Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_CUENTA_CORTO, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, DateTime F_APERTURA, Int32 NID_PATRIMONIO, String V_RFC, String V_TIPOMONEDA, String V_TERCEROTIPO, String V_TERCERONOMBRE, String V_TERCERORFC, String E_OBSERBACIONES)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, NID_INSTITUCION, E_CUENTA, V_CUENTA_CORTO, V_OTRO, M_SALDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, F_APERTURA, NID_PATRIMONIO, V_RFC, V_TIPOMONEDA, V_TERCEROTIPO, V_TERCERONOMBRE, V_TERCERORFC, E_OBSERBACIONES, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }



        #endregion


        #region *** Metodos ***

        private void _Reload_ALTA_INVERSION_TITULARs()
        {
            _ALTA_INVERSION_TITULARs = new Lista<blld_ALTA_INVERSION_TITULAR>();
            foreach (MODELDeclara_V2.ALTA_INVERSION_TITULAR o in datos_ALTA_INVERSION._ALTA_INVERSION_TITULARs)
            {
                _ALTA_INVERSION_TITULARs.Add(new blld_ALTA_INVERSION_TITULAR(o));
            }
        }

        private void _Add_ALTA_INVERSION_TITULARs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_ALTA_INVERSION_TITULAR oALTA_INVERSION_TITULAR = new blld_ALTA_INVERSION_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, NID_DEPENDIENTE, L_DIF);
                if (oALTA_INVERSION_TITULAR.lEsNuevoRegistro.Value) ALTA_INVERSION_TITULARs.Add(oALTA_INVERSION_TITULAR);
                _ALTA_INVERSION_TITULARs[FindIndex_ALTA_INVERSION_TITULARs(NID_DEPENDIENTE)] = oALTA_INVERSION_TITULAR;
        }

        public Int32 FindIndex_ALTA_INVERSION_TITULARs(Int32 NID_DEPENDIENTE)
        {
            return  ALTA_INVERSION_TITULARs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }



     #endregion

    }
}
