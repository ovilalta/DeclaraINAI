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
    public partial class blld_ALTA_ADEUDO : bll_ALTA_ADEUDO
    {

        #region *** Atributos ***

        private Lista<blld_ALTA_ADEUDO_TITULAR> _ALTA_ADEUDO_TITULARs;
        public Lista<blld_ALTA_ADEUDO_TITULAR> ALTA_ADEUDO_TITULARs
        {
            get
            {
                if (_ALTA_ADEUDO_TITULARs == null)
                {
                    _ALTA_ADEUDO_TITULARs = new Lista<blld_ALTA_ADEUDO_TITULAR>();
                    Reload_ALTA_ADEUDO_TITULARs();
                }
                return _ALTA_ADEUDO_TITULARs;
            }
        }

        #region * CAT_ENTIDAD_FEDERATIVA *


        //[StringLength(511)]
        //[DataType(DataType.MultilineText)]
        //[Required(ErrorMessage = "El campo  es requerido ")]
        //[DisplayName("")]
        //public String V_ENTIDAD_FEDERATIVA => datos_ALTA_ADEUDO.V_ENTIDAD_FEDERATIVA;

        #endregion * CAT_ENTIDAD_FEDERATIVA *


        #region * CAT_TIPO_ADEUDO *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO_ADEUDO => datos_ALTA_ADEUDO.V_TIPO_ADEUDO;

        #endregion * CAT_TIPO_ADEUDO *


        #region * CAT_INST_FINANCIERA *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_INSTITUCION => datos_ALTA_ADEUDO.V_INSTITUCION;

        #endregion * CAT_INST_FINANCIERA *



     #endregion


     #region *** Constructores ***

        private blld_ALTA_ADEUDO()
        : base()
        {
        }

        public blld_ALTA_ADEUDO(MODELDeclara_V2.ALTA_ADEUDO ALTA_ADEUDO)
        : base(ALTA_ADEUDO)
        {
        }

        public  blld_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO)
        {
        }

        public blld_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO,DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, String V_TIPO_MONEDA, String E_RFC, String E_OBSERVACIONES, String CID_TIPO_PERSONA_OTORGANTE, Boolean L_AUTOGENERADO, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO,F_ADEUDO , M_ORIGINAL, M_SALDO, E_CUENTA, V_TIPO_MONEDA, E_RFC, E_OBSERVACIONES, CID_TIPO_PERSONA_OTORGANTE, L_AUTOGENERADO, NID_PATRIMONIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


        #endregion


        #region *** Metodos ***

        private void _Reload_ALTA_ADEUDO_TITULARs()
        {
            _ALTA_ADEUDO_TITULARs = new Lista<blld_ALTA_ADEUDO_TITULAR>();
            foreach (MODELDeclara_V2.ALTA_ADEUDO_TITULAR o in datos_ALTA_ADEUDO._ALTA_ADEUDO_TITULARs)
            {
                _ALTA_ADEUDO_TITULARs.Add(new blld_ALTA_ADEUDO_TITULAR(o));
            }
        }

        private void _Add_ALTA_ADEUDO_TITULARs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
            blld_ALTA_ADEUDO_TITULAR oALTA_ADEUDO_TITULAR = new blld_ALTA_ADEUDO_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO, NID_DEPENDIENTE, L_DIF);
            if (oALTA_ADEUDO_TITULAR.lEsNuevoRegistro.Value) ALTA_ADEUDO_TITULARs.Add(oALTA_ADEUDO_TITULAR);
            _ALTA_ADEUDO_TITULARs[FindIndex_ALTA_ADEUDO_TITULARs(NID_DEPENDIENTE)] = oALTA_ADEUDO_TITULAR;
        }

        public Int32 FindIndex_ALTA_ADEUDO_TITULARs(Int32 NID_DEPENDIENTE)
        {
            return ALTA_ADEUDO_TITULARs.FindIndex(p =>
                              p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }

        #endregion

    }
}
