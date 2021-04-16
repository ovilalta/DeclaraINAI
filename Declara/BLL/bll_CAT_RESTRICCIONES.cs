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
    public  class bll_CAT_RESTRICCIONES : _bllSistema
    {

        internal dald_CAT_RESTRICCIONES datos_CAT_RESTRICCIONES;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_RESTRICCION => datos_CAT_RESTRICCIONES.NID_RESTRICCION;

        [StringLength(255)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_RESTRICCION
        {
          get => datos_CAT_RESTRICCIONES.V_RESTRICCION;
          set => datos_CAT_RESTRICCIONES.V_RESTRICCION = value;
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_VIGENTE
        {
          get => datos_CAT_RESTRICCIONES.L_VIGENTE;
          set => datos_CAT_RESTRICCIONES.L_VIGENTE = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_RESTRICCIONES.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_RESTRICCIONES() => datos_CAT_RESTRICCIONES = new dald_CAT_RESTRICCIONES();

        public bll_CAT_RESTRICCIONES(MODELDeclara_V2.CAT_RESTRICCIONES CAT_RESTRICCIONES) => datos_CAT_RESTRICCIONES = new dald_CAT_RESTRICCIONES(CAT_RESTRICCIONES);

        public bll_CAT_RESTRICCIONES(Int32 NID_RESTRICCION) => datos_CAT_RESTRICCIONES = new dald_CAT_RESTRICCIONES(NID_RESTRICCION);

        public bll_CAT_RESTRICCIONES(Int32 NID_RESTRICCION, String V_RESTRICCION, Boolean L_VIGENTE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_RESTRICCIONES = new dald_CAT_RESTRICCIONES(NID_RESTRICCION, V_RESTRICCION, L_VIGENTE, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_RESTRICCIONES.update();
        }

        public void delete()
        {
            datos_CAT_RESTRICCIONES.delete();
        }

        public void reload()
        {
            datos_CAT_RESTRICCIONES.reload();
        }

     #endregion

    }
}
