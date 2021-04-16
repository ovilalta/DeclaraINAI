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
    public partial class blld_H_PATRIMONIO_VEHICULO : bll_H_PATRIMONIO_VEHICULO
    {

     #region *** Atributos ***


        #region * CAT_USO_VEHICULO *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_USO => datos_H_PATRIMONIO_VEHICULO.V_USO;

        #endregion * CAT_USO_VEHICULO *


        #region * CAT_MARCA_VEHICULO *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_MARCA => datos_H_PATRIMONIO_VEHICULO.V_MARCA;

        #endregion * CAT_MARCA_VEHICULO *



     #endregion


     #region *** Constructores ***

        private blld_H_PATRIMONIO_VEHICULO()
        : base()
        {
        }

        public blld_H_PATRIMONIO_VEHICULO(MODELDeclara_V2.H_PATRIMONIO_VEHICULO H_PATRIMONIO_VEHICULO)
        : base(H_PATRIMONIO_VEHICULO)
        {
        }

        public  blld_H_PATRIMONIO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO)
        {
        }

        public blld_H_PATRIMONIO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_USO, M_VALOR_VEHICULO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
