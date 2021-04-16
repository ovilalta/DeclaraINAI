using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll_CAT_SUBTIPO_INVERSION : _bllSistema
    {

        internal dald_CAT_SUBTIPO_INVERSION datos_CAT_SUBTIPO_INVERSION;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo I D_ T I P O_ I N V E R S I O N es requerido ")]
        [DisplayName("I D_ T I P O_ I N V E R S I O N")]
        public Int32 NID_TIPO_INVERSION => datos_CAT_SUBTIPO_INVERSION.NID_TIPO_INVERSION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ S U B T I P O_ I N V E R S I O N es requerido ")]
        [DisplayName("I D_ S U B T I P O_ I N V E R S I O N")]
        public Int32 NID_SUBTIPO_INVERSION => datos_CAT_SUBTIPO_INVERSION.NID_SUBTIPO_INVERSION;

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo S U B T I P O_ I N V E R S I O N es requerido ")]
        [DisplayName("S U B T I P O_ I N V E R S I O N")]
        public String V_SUBTIPO_INVERSION
        {
          get => datos_CAT_SUBTIPO_INVERSION.V_SUBTIPO_INVERSION;
          set => datos_CAT_SUBTIPO_INVERSION.V_SUBTIPO_INVERSION = value;
        }

        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO
        {
          get => datos_CAT_SUBTIPO_INVERSION.L_ACTIVO;
          set => datos_CAT_SUBTIPO_INVERSION.L_ACTIVO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_SUBTIPO_INVERSION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_SUBTIPO_INVERSION() => datos_CAT_SUBTIPO_INVERSION = new dald_CAT_SUBTIPO_INVERSION();

        public bll_CAT_SUBTIPO_INVERSION(MODELDeclara_V2.CAT_SUBTIPO_INVERSION CAT_SUBTIPO_INVERSION) => datos_CAT_SUBTIPO_INVERSION = new dald_CAT_SUBTIPO_INVERSION(CAT_SUBTIPO_INVERSION);

        public bll_CAT_SUBTIPO_INVERSION(Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION) => datos_CAT_SUBTIPO_INVERSION = new dald_CAT_SUBTIPO_INVERSION(NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION);

        public bll_CAT_SUBTIPO_INVERSION(Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, String V_SUBTIPO_INVERSION, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_SUBTIPO_INVERSION = new dald_CAT_SUBTIPO_INVERSION(NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, V_SUBTIPO_INVERSION, L_ACTIVO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_SUBTIPO_INVERSION.update();
        }

        public void delete()
        {
            datos_CAT_SUBTIPO_INVERSION.delete();
        }

        public void reload()
        {
            datos_CAT_SUBTIPO_INVERSION.reload();
        }

     #endregion

    }
}
