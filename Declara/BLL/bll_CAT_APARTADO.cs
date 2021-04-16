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
    public  class bll_CAT_APARTADO : _bllSistema
    {

        internal dald_CAT_APARTADO datos_CAT_APARTADO;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_APARTADO => datos_CAT_APARTADO.NID_APARTADO;

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_APARTADO
        {
          get => datos_CAT_APARTADO.V_APARTADO;
          set => datos_CAT_APARTADO.V_APARTADO = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [DisplayName("")]
        public System.Nullable<Int32> NID_APARTADO_SUPERIOR
        {
          get => datos_CAT_APARTADO.NID_APARTADO_SUPERIOR;
          set => datos_CAT_APARTADO.NID_APARTADO_SUPERIOR = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [DisplayName("")]
        public System.Nullable<Int32> N_APARTADO
        {
          get => datos_CAT_APARTADO.N_APARTADO;
          set => datos_CAT_APARTADO.N_APARTADO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_APARTADO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_APARTADO() => datos_CAT_APARTADO = new dald_CAT_APARTADO();

        public bll_CAT_APARTADO(MODELDeclara_V2.CAT_APARTADO CAT_APARTADO) => datos_CAT_APARTADO = new dald_CAT_APARTADO(CAT_APARTADO);

        public bll_CAT_APARTADO(Int32 NID_APARTADO) => datos_CAT_APARTADO = new dald_CAT_APARTADO(NID_APARTADO);

        //public bll_CAT_APARTADO(Int32 NID_APARTADO, String V_APARTADO, System.Nullable<Int32> NID_APARTADO_SUPERIOR, System.Nullable<Int32> N_APARTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_APARTADO = new dald_CAT_APARTADO(NID_APARTADO, V_APARTADO, NID_APARTADO_SUPERIOR, N_APARTADO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_APARTADO.update();
        }

        public void delete()
        {
            datos_CAT_APARTADO.delete();
        }

        public void reload()
        {
            datos_CAT_APARTADO.reload();
        }

     #endregion

    }
}
