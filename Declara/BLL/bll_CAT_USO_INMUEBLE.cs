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
    public  class bll_CAT_USO_INMUEBLE : _bllSistema
    {

        internal dald_CAT_USO_INMUEBLE datos_CAT_USO_INMUEBLE;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo I D_ U S O es requerido ")]
        [DisplayName("I D_ U S O")]
        public Int32 NID_USO => datos_CAT_USO_INMUEBLE.NID_USO;

        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo U S O es requerido ")]
        [DisplayName("U S O")]
        public String V_USO
        {
          get => datos_CAT_USO_INMUEBLE.V_USO;
          set => datos_CAT_USO_INMUEBLE.V_USO = value;
        }

        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO
        {
          get => datos_CAT_USO_INMUEBLE.L_ACTIVO;
          set => datos_CAT_USO_INMUEBLE.L_ACTIVO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_USO_INMUEBLE.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_USO_INMUEBLE() => datos_CAT_USO_INMUEBLE = new dald_CAT_USO_INMUEBLE();

        public bll_CAT_USO_INMUEBLE(MODELDeclara_V2.CAT_USO_INMUEBLE CAT_USO_INMUEBLE) => datos_CAT_USO_INMUEBLE = new dald_CAT_USO_INMUEBLE(CAT_USO_INMUEBLE);

        public bll_CAT_USO_INMUEBLE(Int32 NID_USO) => datos_CAT_USO_INMUEBLE = new dald_CAT_USO_INMUEBLE(NID_USO);

        public bll_CAT_USO_INMUEBLE(Int32 NID_USO, String V_USO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_USO_INMUEBLE = new dald_CAT_USO_INMUEBLE(NID_USO, V_USO, L_ACTIVO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_USO_INMUEBLE.update();
        }

        public void delete()
        {
            datos_CAT_USO_INMUEBLE.delete();
        }

        public void reload()
        {
            datos_CAT_USO_INMUEBLE.reload();
        }

     #endregion

    }
}
