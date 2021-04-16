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
    public  class bll_CAT_TIPO_DECLARACION : _bllSistema
    {

        internal dald_CAT_TIPO_DECLARACION datos_CAT_TIPO_DECLARACION;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_DECLARACION => datos_CAT_TIPO_DECLARACION.NID_TIPO_DECLARACION;

        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO_DECLARACION
        {
          get => datos_CAT_TIPO_DECLARACION.V_TIPO_DECLARACION;
          set => datos_CAT_TIPO_DECLARACION.V_TIPO_DECLARACION = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_TIPO_DECLARACION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_TIPO_DECLARACION() => datos_CAT_TIPO_DECLARACION = new dald_CAT_TIPO_DECLARACION();

        public bll_CAT_TIPO_DECLARACION(MODELDeclara_V2.CAT_TIPO_DECLARACION CAT_TIPO_DECLARACION) => datos_CAT_TIPO_DECLARACION = new dald_CAT_TIPO_DECLARACION(CAT_TIPO_DECLARACION);

        public bll_CAT_TIPO_DECLARACION(Int32 NID_TIPO_DECLARACION) => datos_CAT_TIPO_DECLARACION = new dald_CAT_TIPO_DECLARACION(NID_TIPO_DECLARACION);

        public bll_CAT_TIPO_DECLARACION(Int32 NID_TIPO_DECLARACION, String V_TIPO_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_TIPO_DECLARACION = new dald_CAT_TIPO_DECLARACION(NID_TIPO_DECLARACION, V_TIPO_DECLARACION, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_TIPO_DECLARACION.update();
        }

        public void delete()
        {
            datos_CAT_TIPO_DECLARACION.delete();
        }

        public void reload()
        {
            datos_CAT_TIPO_DECLARACION.reload();
        }

     #endregion

    }
}
