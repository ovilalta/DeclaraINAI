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
    public partial class blld_H_PATRIMONIO_INVERSION : bll_H_PATRIMONIO_INVERSION
    {

     #region *** Atributos ***


        #region * CAT_ENTIDAD_FEDERATIVA *


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_ENTIDAD_FEDERATIVA => datos_H_PATRIMONIO_INVERSION.V_ENTIDAD_FEDERATIVA;

        #endregion * CAT_ENTIDAD_FEDERATIVA *


        #region * CAT_SUBTIPO_INVERSION *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_SUBTIPO_INVERSION => datos_H_PATRIMONIO_INVERSION.V_SUBTIPO_INVERSION;

        #endregion * CAT_SUBTIPO_INVERSION *


        #region * CAT_INST_FINANCIERA *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_INSTITUCION => datos_H_PATRIMONIO_INVERSION.V_INSTITUCION;

        #endregion * CAT_INST_FINANCIERA *



     #endregion


     #region *** Constructores ***

        private blld_H_PATRIMONIO_INVERSION()
        : base()
        {
        }

        public blld_H_PATRIMONIO_INVERSION(MODELDeclara_V2.H_PATRIMONIO_INVERSION H_PATRIMONIO_INVERSION)
        : base(H_PATRIMONIO_INVERSION)
        {
        }

        public  blld_H_PATRIMONIO_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO)
        {
        }

        public blld_H_PATRIMONIO_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_CUENTA_CORTO, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, NID_INSTITUCION, E_CUENTA, V_CUENTA_CORTO, V_OTRO, M_SALDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
