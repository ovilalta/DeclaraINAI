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
    public  class bll_CAT_ESTADO_CIVIL : _bllSistema
    {

        internal dald_CAT_ESTADO_CIVIL datos_CAT_ESTADO_CIVIL;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_ESTADO_CIVIL => datos_CAT_ESTADO_CIVIL.NID_ESTADO_CIVIL;

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_ESTADO_CIVIL
        {
          get => datos_CAT_ESTADO_CIVIL.V_ESTADO_CIVIL;
          set => datos_CAT_ESTADO_CIVIL.V_ESTADO_CIVIL = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_ESTADO_CIVIL.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_ESTADO_CIVIL() => datos_CAT_ESTADO_CIVIL = new dald_CAT_ESTADO_CIVIL();

        public bll_CAT_ESTADO_CIVIL(MODELDeclara_V2.CAT_ESTADO_CIVIL CAT_ESTADO_CIVIL) => datos_CAT_ESTADO_CIVIL = new dald_CAT_ESTADO_CIVIL(CAT_ESTADO_CIVIL);

        public bll_CAT_ESTADO_CIVIL(Int32 NID_ESTADO_CIVIL) => datos_CAT_ESTADO_CIVIL = new dald_CAT_ESTADO_CIVIL(NID_ESTADO_CIVIL);

        public bll_CAT_ESTADO_CIVIL(Int32 NID_ESTADO_CIVIL, String V_ESTADO_CIVIL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_ESTADO_CIVIL = new dald_CAT_ESTADO_CIVIL(NID_ESTADO_CIVIL, V_ESTADO_CIVIL, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_ESTADO_CIVIL.update();
        }

        public void delete()
        {
            datos_CAT_ESTADO_CIVIL.delete();
        }

        public void reload()
        {
            datos_CAT_ESTADO_CIVIL.reload();
        }

     #endregion

    }
}
