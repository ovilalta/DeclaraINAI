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
    public  class bll_CAT_MARCA_VEHICULO : _bllSistema
    {

        internal dald_CAT_MARCA_VEHICULO datos_CAT_MARCA_VEHICULO;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_MARCA => datos_CAT_MARCA_VEHICULO.NID_MARCA;

        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_MARCA
        {
          get => datos_CAT_MARCA_VEHICULO.V_MARCA;
          set => datos_CAT_MARCA_VEHICULO.V_MARCA = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_MARCA_VEHICULO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_MARCA_VEHICULO() => datos_CAT_MARCA_VEHICULO = new dald_CAT_MARCA_VEHICULO();

        public bll_CAT_MARCA_VEHICULO(MODELDeclara_V2.CAT_MARCA_VEHICULO CAT_MARCA_VEHICULO) => datos_CAT_MARCA_VEHICULO = new dald_CAT_MARCA_VEHICULO(CAT_MARCA_VEHICULO);

        public bll_CAT_MARCA_VEHICULO(Int32 NID_MARCA) => datos_CAT_MARCA_VEHICULO = new dald_CAT_MARCA_VEHICULO(NID_MARCA);

        public bll_CAT_MARCA_VEHICULO(Int32 NID_MARCA, String V_MARCA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_MARCA_VEHICULO = new dald_CAT_MARCA_VEHICULO(NID_MARCA, V_MARCA, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_MARCA_VEHICULO.update();
        }

        public void delete()
        {
            datos_CAT_MARCA_VEHICULO.delete();
        }

        public void reload()
        {
            datos_CAT_MARCA_VEHICULO.reload();
        }

     #endregion

    }
}
