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
    public  class bll_CAT_TIPO_INVERSION : _bllSistema
    {

        internal dald_CAT_TIPO_INVERSION datos_CAT_TIPO_INVERSION;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo I D_ T I P O_ I N V E R S I O N es requerido ")]
        [DisplayName("I D_ T I P O_ I N V E R S I O N")]
        public Int32 NID_TIPO_INVERSION => datos_CAT_TIPO_INVERSION.NID_TIPO_INVERSION;

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo T I P O_ I N V E R S I O N es requerido ")]
        [DisplayName("T I P O_ I N V E R S I O N")]
        public String V_TIPO_INVERSION
        {
          get => datos_CAT_TIPO_INVERSION.V_TIPO_INVERSION;
          set => datos_CAT_TIPO_INVERSION.V_TIPO_INVERSION = value;
        }

        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO
        {
          get => datos_CAT_TIPO_INVERSION.L_ACTIVO;
          set => datos_CAT_TIPO_INVERSION.L_ACTIVO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_TIPO_INVERSION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_TIPO_INVERSION() => datos_CAT_TIPO_INVERSION = new dald_CAT_TIPO_INVERSION();

        public bll_CAT_TIPO_INVERSION(MODELDeclara_V2.CAT_TIPO_INVERSION CAT_TIPO_INVERSION) => datos_CAT_TIPO_INVERSION = new dald_CAT_TIPO_INVERSION(CAT_TIPO_INVERSION);

        public bll_CAT_TIPO_INVERSION(Int32 NID_TIPO_INVERSION) => datos_CAT_TIPO_INVERSION = new dald_CAT_TIPO_INVERSION(NID_TIPO_INVERSION);

        public bll_CAT_TIPO_INVERSION(Int32 NID_TIPO_INVERSION, String V_TIPO_INVERSION, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_TIPO_INVERSION = new dald_CAT_TIPO_INVERSION(NID_TIPO_INVERSION, V_TIPO_INVERSION, L_ACTIVO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_TIPO_INVERSION.update();
        }

        public void delete()
        {
            datos_CAT_TIPO_INVERSION.delete();
        }

        public void reload()
        {
            datos_CAT_TIPO_INVERSION.reload();
        }

     #endregion

    }
}
