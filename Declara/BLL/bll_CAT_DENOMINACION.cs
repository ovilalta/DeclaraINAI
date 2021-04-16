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
    public  class bll_CAT_DENOMINACION : _bllSistema
    {

        internal dald_CAT_DENOMINACION datos_CAT_DENOMINACION;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DENOMINACION => datos_CAT_DENOMINACION.NID_DENOMINACION;

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_DENOMINACION
        {
          get => datos_CAT_DENOMINACION.V_DENOMINACION;
          set => datos_CAT_DENOMINACION.V_DENOMINACION = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_DENOMINACION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_DENOMINACION() => datos_CAT_DENOMINACION = new dald_CAT_DENOMINACION();

        public bll_CAT_DENOMINACION(MODELDeclara_V2.CAT_DENOMINACION CAT_DENOMINACION) => datos_CAT_DENOMINACION = new dald_CAT_DENOMINACION(CAT_DENOMINACION);

        public bll_CAT_DENOMINACION(Int32 NID_DENOMINACION) => datos_CAT_DENOMINACION = new dald_CAT_DENOMINACION(NID_DENOMINACION);

        public bll_CAT_DENOMINACION(Int32 NID_DENOMINACION, String V_DENOMINACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_DENOMINACION = new dald_CAT_DENOMINACION(NID_DENOMINACION, V_DENOMINACION, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_DENOMINACION.update();
        }

        public void delete()
        {
            datos_CAT_DENOMINACION.delete();
        }

        public void reload()
        {
            datos_CAT_DENOMINACION.reload();
        }

     #endregion

    }
}
