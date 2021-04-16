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
    public  class bll_CAT_TIPO_VEHICULO : _bllSistema
    {

        internal dald_CAT_TIPO_VEHICULO datos_CAT_TIPO_VEHICULO;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo I D_ T I P O_ V E H I C U L O es requerido ")]
        [DisplayName("I D_ T I P O_ V E H I C U L O")]
        public Int32 NID_TIPO_VEHICULO => datos_CAT_TIPO_VEHICULO.NID_TIPO_VEHICULO;

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo T I P O_ V E H I C U L O es requerido ")]
        [DisplayName("T I P O_ V E H I C U L O")]
        public String V_TIPO_VEHICULO
        {
          get => datos_CAT_TIPO_VEHICULO.V_TIPO_VEHICULO;
          set => datos_CAT_TIPO_VEHICULO.V_TIPO_VEHICULO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_TIPO_VEHICULO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_TIPO_VEHICULO() => datos_CAT_TIPO_VEHICULO = new dald_CAT_TIPO_VEHICULO();

        public bll_CAT_TIPO_VEHICULO(MODELDeclara_V2.CAT_TIPO_VEHICULO CAT_TIPO_VEHICULO) => datos_CAT_TIPO_VEHICULO = new dald_CAT_TIPO_VEHICULO(CAT_TIPO_VEHICULO);

        public bll_CAT_TIPO_VEHICULO(Int32 NID_TIPO_VEHICULO) => datos_CAT_TIPO_VEHICULO = new dald_CAT_TIPO_VEHICULO(NID_TIPO_VEHICULO);

        public bll_CAT_TIPO_VEHICULO(Int32 NID_TIPO_VEHICULO, String V_TIPO_VEHICULO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_TIPO_VEHICULO = new dald_CAT_TIPO_VEHICULO(NID_TIPO_VEHICULO, V_TIPO_VEHICULO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_TIPO_VEHICULO.update();
        }

        public void delete()
        {
            datos_CAT_TIPO_VEHICULO.delete();
        }

        public void reload()
        {
            datos_CAT_TIPO_VEHICULO.reload();
        }

     #endregion

    }
}
