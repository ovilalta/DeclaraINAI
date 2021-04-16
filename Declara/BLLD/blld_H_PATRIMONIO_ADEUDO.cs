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
    public partial class blld_H_PATRIMONIO_ADEUDO : bll_H_PATRIMONIO_ADEUDO
    {

     #region *** Atributos ***


        #region * CAT_ENTIDAD_FEDERATIVA *


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_ENTIDAD_FEDERATIVA => datos_H_PATRIMONIO_ADEUDO.V_ENTIDAD_FEDERATIVA;

        #endregion * CAT_ENTIDAD_FEDERATIVA *


        #region * CAT_TIPO_ADEUDO *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO_ADEUDO => datos_H_PATRIMONIO_ADEUDO.V_TIPO_ADEUDO;

        #endregion * CAT_TIPO_ADEUDO *


        #region * CAT_INST_FINANCIERA *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_INSTITUCION => datos_H_PATRIMONIO_ADEUDO.V_INSTITUCION;

        #endregion * CAT_INST_FINANCIERA *



     #endregion


     #region *** Constructores ***

        private blld_H_PATRIMONIO_ADEUDO()
        : base()
        {
        }

        public blld_H_PATRIMONIO_ADEUDO(MODELDeclara_V2.H_PATRIMONIO_ADEUDO H_PATRIMONIO_ADEUDO)
        : base(H_PATRIMONIO_ADEUDO)
        {
        }

        public  blld_H_PATRIMONIO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO)
        {
        }

        public blld_H_PATRIMONIO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, Int32 NID_INSTITUCION, Int32 NID_TIPO_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, NID_INSTITUCION, NID_TIPO_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
