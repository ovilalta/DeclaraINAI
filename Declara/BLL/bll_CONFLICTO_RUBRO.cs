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
    public  class bll_CONFLICTO_RUBRO : _bllSistema
    {

        internal dald_CONFLICTO_RUBRO datos_CONFLICTO_RUBRO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_CONFLICTO_RUBRO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_CONFLICTO_RUBRO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_CONFLICTO_RUBRO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ C O N F L I C T O es requerido ")]
        [DisplayName("I D_ C O N F L I C T O")]
        public Int32 NID_CONFLICTO => datos_CONFLICTO_RUBRO.NID_CONFLICTO;

        [Key]
        [Required(ErrorMessage = "El campo I D_ R U B R O es requerido ")]
        [DisplayName("I D_ R U B R O")]
        public Int32 NID_RUBRO => datos_CONFLICTO_RUBRO.NID_RUBRO;

        [DisplayName("R E S P U E S T A")]
        public System.Nullable<Boolean> L_RESPUESTA
        {
          get => datos_CONFLICTO_RUBRO.L_RESPUESTA;
          set => datos_CONFLICTO_RUBRO.L_RESPUESTA = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CONFLICTO_RUBRO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CONFLICTO_RUBRO() => datos_CONFLICTO_RUBRO = new dald_CONFLICTO_RUBRO();

        public bll_CONFLICTO_RUBRO(MODELDeclara_V2.CONFLICTO_RUBRO CONFLICTO_RUBRO) => datos_CONFLICTO_RUBRO = new dald_CONFLICTO_RUBRO(CONFLICTO_RUBRO);

        public bll_CONFLICTO_RUBRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO) => datos_CONFLICTO_RUBRO = new dald_CONFLICTO_RUBRO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO);

        public bll_CONFLICTO_RUBRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, System.Nullable<Boolean> L_RESPUESTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CONFLICTO_RUBRO = new dald_CONFLICTO_RUBRO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, L_RESPUESTA, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CONFLICTO_RUBRO.update();
        }

        public void delete()
        {
            datos_CONFLICTO_RUBRO.delete();
        }

        public void reload()
        {
            datos_CONFLICTO_RUBRO.reload();
        }

     #endregion

    }
}
