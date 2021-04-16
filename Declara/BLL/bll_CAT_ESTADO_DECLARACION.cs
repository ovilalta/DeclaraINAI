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
    public  class bll_CAT_ESTADO_DECLARACION : _bllSistema
    {

        internal dald_CAT_ESTADO_DECLARACION datos_CAT_ESTADO_DECLARACION;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_ESTADO => datos_CAT_ESTADO_DECLARACION.NID_ESTADO;

        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_ESTADO
        {
          get => datos_CAT_ESTADO_DECLARACION.V_ESTADO;
          set => datos_CAT_ESTADO_DECLARACION.V_ESTADO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_ESTADO_DECLARACION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_ESTADO_DECLARACION() => datos_CAT_ESTADO_DECLARACION = new dald_CAT_ESTADO_DECLARACION();

        public bll_CAT_ESTADO_DECLARACION(MODELDeclara_V2.CAT_ESTADO_DECLARACION CAT_ESTADO_DECLARACION) => datos_CAT_ESTADO_DECLARACION = new dald_CAT_ESTADO_DECLARACION(CAT_ESTADO_DECLARACION);

        public bll_CAT_ESTADO_DECLARACION(Int32 NID_ESTADO) => datos_CAT_ESTADO_DECLARACION = new dald_CAT_ESTADO_DECLARACION(NID_ESTADO);

        public bll_CAT_ESTADO_DECLARACION(Int32 NID_ESTADO, String V_ESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_ESTADO_DECLARACION = new dald_CAT_ESTADO_DECLARACION(NID_ESTADO, V_ESTADO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_ESTADO_DECLARACION.update();
        }

        public void delete()
        {
            datos_CAT_ESTADO_DECLARACION.delete();
        }

        public void reload()
        {
            datos_CAT_ESTADO_DECLARACION.reload();
        }

     #endregion

    }
}
