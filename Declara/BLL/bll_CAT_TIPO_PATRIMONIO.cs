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
    public  class bll_CAT_TIPO_PATRIMONIO : _bllSistema
    {

        internal dald_CAT_TIPO_PATRIMONIO datos_CAT_TIPO_PATRIMONIO;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO => datos_CAT_TIPO_PATRIMONIO.NID_TIPO;

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO
        {
          get => datos_CAT_TIPO_PATRIMONIO.V_TIPO;
          set => datos_CAT_TIPO_PATRIMONIO.V_TIPO = value;
        }

        public Int32 C_NATURALEZA
        {
          get => datos_CAT_TIPO_PATRIMONIO.C_NATURALEZA;
          set => datos_CAT_TIPO_PATRIMONIO.C_NATURALEZA = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_TIPO_PATRIMONIO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_TIPO_PATRIMONIO() => datos_CAT_TIPO_PATRIMONIO = new dald_CAT_TIPO_PATRIMONIO();

        public bll_CAT_TIPO_PATRIMONIO(MODELDeclara_V2.CAT_TIPO_PATRIMONIO CAT_TIPO_PATRIMONIO) => datos_CAT_TIPO_PATRIMONIO = new dald_CAT_TIPO_PATRIMONIO(CAT_TIPO_PATRIMONIO);

        public bll_CAT_TIPO_PATRIMONIO(Int32 NID_TIPO) => datos_CAT_TIPO_PATRIMONIO = new dald_CAT_TIPO_PATRIMONIO(NID_TIPO);

        public bll_CAT_TIPO_PATRIMONIO(Int32 NID_TIPO, String V_TIPO, Int32 C_NATURALEZA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_TIPO_PATRIMONIO = new dald_CAT_TIPO_PATRIMONIO(NID_TIPO, V_TIPO, C_NATURALEZA, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_TIPO_PATRIMONIO.update();
        }

        public void delete()
        {
            datos_CAT_TIPO_PATRIMONIO.delete();
        }

        public void reload()
        {
            datos_CAT_TIPO_PATRIMONIO.reload();
        }

     #endregion

    }
}
