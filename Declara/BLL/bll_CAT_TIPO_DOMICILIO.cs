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
    public  class bll_CAT_TIPO_DOMICILIO : _bllSistema
    {

        internal dald_CAT_TIPO_DOMICILIO datos_CAT_TIPO_DOMICILIO;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_DOMICILIO => datos_CAT_TIPO_DOMICILIO.NID_TIPO_DOMICILIO;

        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO_DOMICILIO
        {
          get => datos_CAT_TIPO_DOMICILIO.V_TIPO_DOMICILIO;
          set => datos_CAT_TIPO_DOMICILIO.V_TIPO_DOMICILIO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_TIPO_DOMICILIO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_TIPO_DOMICILIO() => datos_CAT_TIPO_DOMICILIO = new dald_CAT_TIPO_DOMICILIO();

        public bll_CAT_TIPO_DOMICILIO(MODELDeclara_V2.CAT_TIPO_DOMICILIO CAT_TIPO_DOMICILIO) => datos_CAT_TIPO_DOMICILIO = new dald_CAT_TIPO_DOMICILIO(CAT_TIPO_DOMICILIO);

        public bll_CAT_TIPO_DOMICILIO(Int32 NID_TIPO_DOMICILIO) => datos_CAT_TIPO_DOMICILIO = new dald_CAT_TIPO_DOMICILIO(NID_TIPO_DOMICILIO);

        public bll_CAT_TIPO_DOMICILIO(Int32 NID_TIPO_DOMICILIO, String V_TIPO_DOMICILIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_TIPO_DOMICILIO = new dald_CAT_TIPO_DOMICILIO(NID_TIPO_DOMICILIO, V_TIPO_DOMICILIO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_TIPO_DOMICILIO.update();
        }

        public void delete()
        {
            datos_CAT_TIPO_DOMICILIO.delete();
        }

        public void reload()
        {
            datos_CAT_TIPO_DOMICILIO.reload();
        }

     #endregion

    }
}
