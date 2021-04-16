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
    public  class bll_CAT_TIPO_ADEUDO : _bllSistema
    {

        internal dald_CAT_TIPO_ADEUDO datos_CAT_TIPO_ADEUDO;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_ADEUDO => datos_CAT_TIPO_ADEUDO.NID_TIPO_ADEUDO;

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO_ADEUDO
        {
          get => datos_CAT_TIPO_ADEUDO.V_TIPO_ADEUDO;
          set => datos_CAT_TIPO_ADEUDO.V_TIPO_ADEUDO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_TIPO_ADEUDO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_TIPO_ADEUDO() => datos_CAT_TIPO_ADEUDO = new dald_CAT_TIPO_ADEUDO();

        public bll_CAT_TIPO_ADEUDO(MODELDeclara_V2.CAT_TIPO_ADEUDO CAT_TIPO_ADEUDO) => datos_CAT_TIPO_ADEUDO = new dald_CAT_TIPO_ADEUDO(CAT_TIPO_ADEUDO);

        public bll_CAT_TIPO_ADEUDO(Int32 NID_TIPO_ADEUDO) => datos_CAT_TIPO_ADEUDO = new dald_CAT_TIPO_ADEUDO(NID_TIPO_ADEUDO);

        public bll_CAT_TIPO_ADEUDO(Int32 NID_TIPO_ADEUDO, String V_TIPO_ADEUDO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_TIPO_ADEUDO = new dald_CAT_TIPO_ADEUDO(NID_TIPO_ADEUDO, V_TIPO_ADEUDO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_TIPO_ADEUDO.update();
        }

        public void delete()
        {
            datos_CAT_TIPO_ADEUDO.delete();
        }

        public void reload()
        {
            datos_CAT_TIPO_ADEUDO.reload();
        }

     #endregion

    }
}
