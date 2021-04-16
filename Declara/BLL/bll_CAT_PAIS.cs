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
    public  class bll_CAT_PAIS : _bllSistema
    {

        internal dald_CAT_PAIS datos_CAT_PAIS;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PAIS => datos_CAT_PAIS.NID_PAIS;

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_PAIS
        {
          get => datos_CAT_PAIS.V_PAIS;
          set => datos_CAT_PAIS.V_PAIS = value;
        }

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_NACIONALIDAD_M
        {
          get => datos_CAT_PAIS.V_NACIONALIDAD_M;
          set => datos_CAT_PAIS.V_NACIONALIDAD_M = value;
        }

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_NACIONALIDAD_F
        {
          get => datos_CAT_PAIS.V_NACIONALIDAD_F;
          set => datos_CAT_PAIS.V_NACIONALIDAD_F = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_PAIS.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_PAIS() => datos_CAT_PAIS = new dald_CAT_PAIS();

        public bll_CAT_PAIS(MODELDeclara_V2.CAT_PAIS CAT_PAIS) => datos_CAT_PAIS = new dald_CAT_PAIS(CAT_PAIS);

        public bll_CAT_PAIS(Int32 NID_PAIS) => datos_CAT_PAIS = new dald_CAT_PAIS(NID_PAIS);

        public bll_CAT_PAIS(Int32 NID_PAIS, String V_PAIS, String V_NACIONALIDAD_M, String V_NACIONALIDAD_F, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_PAIS = new dald_CAT_PAIS(NID_PAIS, V_PAIS, V_NACIONALIDAD_M, V_NACIONALIDAD_F, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_PAIS.update();
        }

        public void delete()
        {
            datos_CAT_PAIS.delete();
        }

        public void reload()
        {
            datos_CAT_PAIS.reload();
        }

     #endregion

    }
}
