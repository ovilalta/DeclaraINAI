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
    public  class bll_CAT_INST_FINANCIERA : _bllSistema
    {

        internal dald_CAT_INST_FINANCIERA datos_CAT_INST_FINANCIERA;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo I D_ I N S T I T U C I O N es requerido ")]
        [DisplayName("I D_ I N S T I T U C I O N")]
        public Int32 NID_INSTITUCION => datos_CAT_INST_FINANCIERA.NID_INSTITUCION;

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I N S T I T U C I O N es requerido ")]
        [DisplayName("I N S T I T U C I O N")]
        public String V_INSTITUCION
        {
          get => datos_CAT_INST_FINANCIERA.V_INSTITUCION;
          set => datos_CAT_INST_FINANCIERA.V_INSTITUCION = value;
        }

        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO
        {
          get => datos_CAT_INST_FINANCIERA.L_ACTIVO;
          set => datos_CAT_INST_FINANCIERA.L_ACTIVO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_INST_FINANCIERA.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_INST_FINANCIERA() => datos_CAT_INST_FINANCIERA = new dald_CAT_INST_FINANCIERA();

        public bll_CAT_INST_FINANCIERA(MODELDeclara_V2.CAT_INST_FINANCIERA CAT_INST_FINANCIERA) => datos_CAT_INST_FINANCIERA = new dald_CAT_INST_FINANCIERA(CAT_INST_FINANCIERA);

        public bll_CAT_INST_FINANCIERA(Int32 NID_INSTITUCION) => datos_CAT_INST_FINANCIERA = new dald_CAT_INST_FINANCIERA(NID_INSTITUCION);

        public bll_CAT_INST_FINANCIERA(Int32 NID_INSTITUCION, String V_INSTITUCION, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_INST_FINANCIERA = new dald_CAT_INST_FINANCIERA(NID_INSTITUCION, V_INSTITUCION, L_ACTIVO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_INST_FINANCIERA.update();
        }

        public void delete()
        {
            datos_CAT_INST_FINANCIERA.delete();
        }

        public void reload()
        {
            datos_CAT_INST_FINANCIERA.reload();
        }

     #endregion

    }
}
