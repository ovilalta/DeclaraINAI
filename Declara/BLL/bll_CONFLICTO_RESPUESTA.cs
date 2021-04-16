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
    public  class bll_CONFLICTO_RESPUESTA : _bllSistema
    {

        internal dald_CONFLICTO_RESPUESTA datos_CONFLICTO_RESPUESTA;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_CONFLICTO_RESPUESTA.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_CONFLICTO_RESPUESTA.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_CONFLICTO_RESPUESTA.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ C O N F L I C T O es requerido ")]
        [DisplayName("I D_ C O N F L I C T O")]
        public Int32 NID_CONFLICTO => datos_CONFLICTO_RESPUESTA.NID_CONFLICTO;

        [Key]
        [Required(ErrorMessage = "El campo I D_ R U B R O es requerido ")]
        [DisplayName("I D_ R U B R O")]
        public Int32 NID_RUBRO => datos_CONFLICTO_RESPUESTA.NID_RUBRO;

        [Key]
        [Required(ErrorMessage = "El campo I D_ E N C A B E Z A D O es requerido ")]
        [DisplayName("I D_ E N C A B E Z A D O")]
        public Int32 NID_ENCABEZADO => datos_CONFLICTO_RESPUESTA.NID_ENCABEZADO;

        [Key]
        [Required(ErrorMessage = "El campo I D_ P R E G U N T A es requerido ")]
        [DisplayName("I D_ P R E G U N T A")]
        public Int32 NID_PREGUNTA => datos_CONFLICTO_RESPUESTA.NID_PREGUNTA;

        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("R E S P U E S T A")]
        public String V_RESPUESTA
        {
          get => datos_CONFLICTO_RESPUESTA.V_RESPUESTA;
          set => datos_CONFLICTO_RESPUESTA.V_RESPUESTA = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CONFLICTO_RESPUESTA.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CONFLICTO_RESPUESTA() => datos_CONFLICTO_RESPUESTA = new dald_CONFLICTO_RESPUESTA();

        public bll_CONFLICTO_RESPUESTA(MODELDeclara_V2.CONFLICTO_RESPUESTA CONFLICTO_RESPUESTA) => datos_CONFLICTO_RESPUESTA = new dald_CONFLICTO_RESPUESTA(CONFLICTO_RESPUESTA);

        public bll_CONFLICTO_RESPUESTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO, Int32 NID_PREGUNTA) => datos_CONFLICTO_RESPUESTA = new dald_CONFLICTO_RESPUESTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, NID_PREGUNTA);

        public bll_CONFLICTO_RESPUESTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO, Int32 NID_PREGUNTA, String V_RESPUESTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CONFLICTO_RESPUESTA = new dald_CONFLICTO_RESPUESTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, NID_PREGUNTA, V_RESPUESTA, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CONFLICTO_RESPUESTA.update();
        }

        public void delete()
        {
            datos_CONFLICTO_RESPUESTA.delete();
        }

        public void reload()
        {
            datos_CONFLICTO_RESPUESTA.reload();
        }

     #endregion

    }
}
