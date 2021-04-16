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
    public  class bll_CAT_TIPO_DEPENDIENTES : _bllSistema
    {

        internal dald_CAT_TIPO_DEPENDIENTES datos_CAT_TIPO_DEPENDIENTES;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_DEPENDIENTE => datos_CAT_TIPO_DEPENDIENTES.NID_TIPO_DEPENDIENTE;

        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO_DEPENDIENTE
        {
          get => datos_CAT_TIPO_DEPENDIENTES.V_TIPO_DEPENDIENTE;
          set => datos_CAT_TIPO_DEPENDIENTES.V_TIPO_DEPENDIENTE = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_TIPO_DEPENDIENTES.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_TIPO_DEPENDIENTES() => datos_CAT_TIPO_DEPENDIENTES = new dald_CAT_TIPO_DEPENDIENTES();

        public bll_CAT_TIPO_DEPENDIENTES(MODELDeclara_V2.CAT_TIPO_DEPENDIENTES CAT_TIPO_DEPENDIENTES) => datos_CAT_TIPO_DEPENDIENTES = new dald_CAT_TIPO_DEPENDIENTES(CAT_TIPO_DEPENDIENTES);

        public bll_CAT_TIPO_DEPENDIENTES(Int32 NID_TIPO_DEPENDIENTE) => datos_CAT_TIPO_DEPENDIENTES = new dald_CAT_TIPO_DEPENDIENTES(NID_TIPO_DEPENDIENTE);

        public bll_CAT_TIPO_DEPENDIENTES(Int32 NID_TIPO_DEPENDIENTE, String V_TIPO_DEPENDIENTE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_TIPO_DEPENDIENTES = new dald_CAT_TIPO_DEPENDIENTES(NID_TIPO_DEPENDIENTE, V_TIPO_DEPENDIENTE, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_TIPO_DEPENDIENTES.update();
        }

        public void delete()
        {
            datos_CAT_TIPO_DEPENDIENTES.delete();
        }

        public void reload()
        {
            datos_CAT_TIPO_DEPENDIENTES.reload();
        }

     #endregion

    }
}
