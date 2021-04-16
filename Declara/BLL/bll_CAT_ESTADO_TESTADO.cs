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
    public  class bll_CAT_ESTADO_TESTADO : _bllSistema
    {

        internal dald_CAT_ESTADO_TESTADO datos_CAT_ESTADO_TESTADO;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_ESTADO_TESTADO => datos_CAT_ESTADO_TESTADO.NID_ESTADO_TESTADO;

        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_ESTADO_TESTADO
        {
          get => datos_CAT_ESTADO_TESTADO.V_ESTADO_TESTADO;
          set => datos_CAT_ESTADO_TESTADO.V_ESTADO_TESTADO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_ESTADO_TESTADO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_ESTADO_TESTADO() => datos_CAT_ESTADO_TESTADO = new dald_CAT_ESTADO_TESTADO();

        public bll_CAT_ESTADO_TESTADO(MODELDeclara_V2.CAT_ESTADO_TESTADO CAT_ESTADO_TESTADO) => datos_CAT_ESTADO_TESTADO = new dald_CAT_ESTADO_TESTADO(CAT_ESTADO_TESTADO);

        public bll_CAT_ESTADO_TESTADO(Int32 NID_ESTADO_TESTADO) => datos_CAT_ESTADO_TESTADO = new dald_CAT_ESTADO_TESTADO(NID_ESTADO_TESTADO);

        public bll_CAT_ESTADO_TESTADO(Int32 NID_ESTADO_TESTADO, String V_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_ESTADO_TESTADO = new dald_CAT_ESTADO_TESTADO(NID_ESTADO_TESTADO, V_ESTADO_TESTADO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_ESTADO_TESTADO.update();
        }

        public void delete()
        {
            datos_CAT_ESTADO_TESTADO.delete();
        }

        public void reload()
        {
            datos_CAT_ESTADO_TESTADO.reload();
        }

     #endregion

    }
}
