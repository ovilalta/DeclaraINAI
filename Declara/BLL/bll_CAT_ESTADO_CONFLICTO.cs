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
    public  class bll_CAT_ESTADO_CONFLICTO : _bllSistema
    {

        internal dald_CAT_ESTADO_CONFLICTO datos_CAT_ESTADO_CONFLICTO;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo I D_ E S T A D O_ C O N F L I C T O es requerido ")]
        [DisplayName("I D_ E S T A D O_ C O N F L I C T O")]
        public Int32 NID_ESTADO_CONFLICTO => datos_CAT_ESTADO_CONFLICTO.NID_ESTADO_CONFLICTO;

        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo E S T A D O_ C O N F L I C T O es requerido ")]
        [DisplayName("E S T A D O_ C O N F L I C T O")]
        public String V_ESTADO_CONFLICTO
        {
          get => datos_CAT_ESTADO_CONFLICTO.V_ESTADO_CONFLICTO;
          set => datos_CAT_ESTADO_CONFLICTO.V_ESTADO_CONFLICTO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_ESTADO_CONFLICTO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_ESTADO_CONFLICTO() => datos_CAT_ESTADO_CONFLICTO = new dald_CAT_ESTADO_CONFLICTO();

        public bll_CAT_ESTADO_CONFLICTO(MODELDeclara_V2.CAT_ESTADO_CONFLICTO CAT_ESTADO_CONFLICTO) => datos_CAT_ESTADO_CONFLICTO = new dald_CAT_ESTADO_CONFLICTO(CAT_ESTADO_CONFLICTO);

        public bll_CAT_ESTADO_CONFLICTO(Int32 NID_ESTADO_CONFLICTO) => datos_CAT_ESTADO_CONFLICTO = new dald_CAT_ESTADO_CONFLICTO(NID_ESTADO_CONFLICTO);

        public bll_CAT_ESTADO_CONFLICTO(Int32 NID_ESTADO_CONFLICTO, String V_ESTADO_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_ESTADO_CONFLICTO = new dald_CAT_ESTADO_CONFLICTO(NID_ESTADO_CONFLICTO, V_ESTADO_CONFLICTO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_ESTADO_CONFLICTO.update();
        }

        public void delete()
        {
            datos_CAT_ESTADO_CONFLICTO.delete();
        }

        public void reload()
        {
            datos_CAT_ESTADO_CONFLICTO.reload();
        }

     #endregion

    }
}
