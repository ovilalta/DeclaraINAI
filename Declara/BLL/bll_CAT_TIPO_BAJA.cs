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
    public  class bll_CAT_TIPO_BAJA : _bllSistema
    {

        internal dald_CAT_TIPO_BAJA datos_CAT_TIPO_BAJA;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_BAJA => datos_CAT_TIPO_BAJA.NID_TIPO_BAJA;

        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO_BAJA
        {
          get => datos_CAT_TIPO_BAJA.V_TIPO_BAJA;
          set => datos_CAT_TIPO_BAJA.V_TIPO_BAJA = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_TIPO_BAJA.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_TIPO_BAJA() => datos_CAT_TIPO_BAJA = new dald_CAT_TIPO_BAJA();

        public bll_CAT_TIPO_BAJA(MODELDeclara_V2.CAT_TIPO_BAJA CAT_TIPO_BAJA) => datos_CAT_TIPO_BAJA = new dald_CAT_TIPO_BAJA(CAT_TIPO_BAJA);

        public bll_CAT_TIPO_BAJA(Int32 NID_TIPO_BAJA) => datos_CAT_TIPO_BAJA = new dald_CAT_TIPO_BAJA(NID_TIPO_BAJA);

        public bll_CAT_TIPO_BAJA(Int32 NID_TIPO_BAJA, String V_TIPO_BAJA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_TIPO_BAJA = new dald_CAT_TIPO_BAJA(NID_TIPO_BAJA, V_TIPO_BAJA, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_TIPO_BAJA.update();
        }

        public void delete()
        {
            datos_CAT_TIPO_BAJA.delete();
        }

        public void reload()
        {
            datos_CAT_TIPO_BAJA.reload();
        }

     #endregion

    }
}
