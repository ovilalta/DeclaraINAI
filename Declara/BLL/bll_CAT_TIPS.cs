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
    public  class bll_CAT_TIPS : _bllSistema
    {

        internal dald_CAT_TIPS datos_CAT_TIPS;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIP => datos_CAT_TIPS.NID_TIP;

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIP
        {
          get => datos_CAT_TIPS.V_TIP;
          set => datos_CAT_TIPS.V_TIP = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_TIPS.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_TIPS() => datos_CAT_TIPS = new dald_CAT_TIPS();

        public bll_CAT_TIPS(MODELDeclara_V2.CAT_TIPS CAT_TIPS) => datos_CAT_TIPS = new dald_CAT_TIPS(CAT_TIPS);

        public bll_CAT_TIPS(Int32 NID_TIP) => datos_CAT_TIPS = new dald_CAT_TIPS(NID_TIP);

        public bll_CAT_TIPS(Int32 NID_TIP, String V_TIP, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_TIPS = new dald_CAT_TIPS(NID_TIP, V_TIP, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_TIPS.update();
        }

        public void delete()
        {
            datos_CAT_TIPS.delete();
        }

        public void reload()
        {
            datos_CAT_TIPS.reload();
        }

     #endregion

    }
}
