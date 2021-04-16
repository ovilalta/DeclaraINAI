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
    public  class bll_CAT_PUESTO : _bllSistema
    {

        internal dald_CAT_PUESTO datos_CAT_PUESTO;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PUESTO => datos_CAT_PUESTO.NID_PUESTO;

        [StringLength(10)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_PUESTO
        {
          get => datos_CAT_PUESTO.VID_PUESTO;
          set => datos_CAT_PUESTO.VID_PUESTO = value;
        }

        [StringLength(10)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NIVEL
        {
          get => datos_CAT_PUESTO.VID_NIVEL;
          set => datos_CAT_PUESTO.VID_NIVEL = value;
        }

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_PUESTO
        {
          get => datos_CAT_PUESTO.V_PUESTO;
          set => datos_CAT_PUESTO.V_PUESTO = value;
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_ACTIVO
        {
          get => datos_CAT_PUESTO.L_ACTIVO;
          set => datos_CAT_PUESTO.L_ACTIVO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_PUESTO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_PUESTO() => datos_CAT_PUESTO = new dald_CAT_PUESTO();

        public bll_CAT_PUESTO(MODELDeclara_V2.CAT_PUESTO CAT_PUESTO) => datos_CAT_PUESTO = new dald_CAT_PUESTO(CAT_PUESTO);

        public bll_CAT_PUESTO(Int32 NID_PUESTO) => datos_CAT_PUESTO = new dald_CAT_PUESTO(NID_PUESTO);

        public bll_CAT_PUESTO(Int32 NID_PUESTO, String VID_PUESTO, String VID_NIVEL, String V_PUESTO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_PUESTO = new dald_CAT_PUESTO(NID_PUESTO, VID_PUESTO, VID_NIVEL, V_PUESTO, L_ACTIVO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_PUESTO.update();
        }

        public void delete()
        {
            datos_CAT_PUESTO.delete();
        }

        public void reload()
        {
            datos_CAT_PUESTO.reload();
        }

     #endregion

    }
}
