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
    public  class bll_CAT_ENTIDAD_FEDERATIVA : _bllSistema
    {

        internal dald_CAT_ENTIDAD_FEDERATIVA datos_CAT_ENTIDAD_FEDERATIVA;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PAIS => datos_CAT_ENTIDAD_FEDERATIVA.NID_PAIS;

        [Key]
        [StringLength(2)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_ENTIDAD_FEDERATIVA => datos_CAT_ENTIDAD_FEDERATIVA.CID_ENTIDAD_FEDERATIVA;

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_ENTIDAD_FEDERATIVA
        {
          get => datos_CAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA;
          set => datos_CAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_ENTIDAD_FEDERATIVA.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        //public bll_CAT_ENTIDAD_FEDERATIVA() => datos_CAT_ENTIDAD_FEDERATIVA = new dald_CAT_ENTIDAD_FEDERATIVA();

        public bll_CAT_ENTIDAD_FEDERATIVA(MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA CAT_ENTIDAD_FEDERATIVA) => datos_CAT_ENTIDAD_FEDERATIVA = new dald_CAT_ENTIDAD_FEDERATIVA(CAT_ENTIDAD_FEDERATIVA);

        public bll_CAT_ENTIDAD_FEDERATIVA(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA) => datos_CAT_ENTIDAD_FEDERATIVA = new dald_CAT_ENTIDAD_FEDERATIVA(NID_PAIS, CID_ENTIDAD_FEDERATIVA);

        public bll_CAT_ENTIDAD_FEDERATIVA(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_ENTIDAD_FEDERATIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_ENTIDAD_FEDERATIVA = new dald_CAT_ENTIDAD_FEDERATIVA(NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_ENTIDAD_FEDERATIVA, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_ENTIDAD_FEDERATIVA.update();
        }

        public void delete()
        {
            datos_CAT_ENTIDAD_FEDERATIVA.delete();
        }

        public void reload()
        {
            datos_CAT_ENTIDAD_FEDERATIVA.reload();
        }

     #endregion

    }
}
