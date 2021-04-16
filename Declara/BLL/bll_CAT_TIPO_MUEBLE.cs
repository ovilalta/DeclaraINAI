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
    public  class bll_CAT_TIPO_MUEBLE : _bllSistema
    {

        internal dald_CAT_TIPO_MUEBLE datos_CAT_TIPO_MUEBLE;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo I D_ T I P O es requerido ")]
        [DisplayName("I D_ T I P O")]
        public Int32 NID_TIPO => datos_CAT_TIPO_MUEBLE.NID_TIPO;

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo T I P O es requerido ")]
        [DisplayName("T I P O")]
        public String V_TIPO
        {
          get => datos_CAT_TIPO_MUEBLE.V_TIPO;
          set => datos_CAT_TIPO_MUEBLE.V_TIPO = value;
        }

        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO
        {
          get => datos_CAT_TIPO_MUEBLE.L_ACTIVO;
          set => datos_CAT_TIPO_MUEBLE.L_ACTIVO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_TIPO_MUEBLE.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_TIPO_MUEBLE() => datos_CAT_TIPO_MUEBLE = new dald_CAT_TIPO_MUEBLE();

        public bll_CAT_TIPO_MUEBLE(MODELDeclara_V2.CAT_TIPO_MUEBLE CAT_TIPO_MUEBLE) => datos_CAT_TIPO_MUEBLE = new dald_CAT_TIPO_MUEBLE(CAT_TIPO_MUEBLE);

        public bll_CAT_TIPO_MUEBLE(Int32 NID_TIPO) => datos_CAT_TIPO_MUEBLE = new dald_CAT_TIPO_MUEBLE(NID_TIPO);

        public bll_CAT_TIPO_MUEBLE(Int32 NID_TIPO, String V_TIPO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_TIPO_MUEBLE = new dald_CAT_TIPO_MUEBLE(NID_TIPO, V_TIPO, L_ACTIVO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_TIPO_MUEBLE.update();
        }

        public void delete()
        {
            datos_CAT_TIPO_MUEBLE.delete();
        }

        public void reload()
        {
            datos_CAT_TIPO_MUEBLE.reload();
        }

     #endregion

    }
}
