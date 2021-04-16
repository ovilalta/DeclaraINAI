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
    public  class bll_CONFLICTO : _bllSistema
    {

        internal dald_CONFLICTO datos_CONFLICTO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_CONFLICTO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_CONFLICTO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_CONFLICTO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ C O N F L I C T O es requerido ")]
        [DisplayName("I D_ C O N F L I C T O")]
        public Int32 NID_CONFLICTO => datos_CONFLICTO.NID_CONFLICTO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [DisplayName("I D_ D E C_ A S O S")]
        public System.Nullable<Int32> NID_DEC_ASOS
        {
          get => datos_CONFLICTO.NID_DEC_ASOS;
          set => datos_CONFLICTO.NID_DEC_ASOS = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ E S T A D O_ C O N F L I C T O es requerido ")]
        [DisplayName("I D_ E S T A D O_ C O N F L I C T O")]
        public Int32 NID_ESTADO_CONFLICTO => datos_CONFLICTO.NID_ESTADO_CONFLICTO;


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CONFLICTO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CONFLICTO() => datos_CONFLICTO = new dald_CONFLICTO();

        public bll_CONFLICTO(MODELDeclara_V2.CONFLICTO CONFLICTO) => datos_CONFLICTO = new dald_CONFLICTO(CONFLICTO);

        public bll_CONFLICTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO) => datos_CONFLICTO = new dald_CONFLICTO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO);

        public bll_CONFLICTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, System.Nullable<Int32> NID_DEC_ASOS, Int32 NID_ESTADO_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CONFLICTO = new dald_CONFLICTO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_DEC_ASOS, NID_ESTADO_CONFLICTO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CONFLICTO.update();
        }

        public void delete()
        {
            datos_CONFLICTO.delete();
        }

        public void reload()
        {
            datos_CONFLICTO.reload();
        }

     #endregion

    }
}
