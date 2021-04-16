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
    public  class bll_ALTA_VEHICULO_ADEUDO : _bllSistema
    {

        internal dald_ALTA_VEHICULO_ADEUDO datos_ALTA_VEHICULO_ADEUDO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_ALTA_VEHICULO_ADEUDO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_ALTA_VEHICULO_ADEUDO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_ALTA_VEHICULO_ADEUDO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_ALTA_VEHICULO_ADEUDO.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ V E H I C U L O es requerido ")]
        [DisplayName("I D_ V E H I C U L O")]
        public Int32 NID_VEHICULO => datos_ALTA_VEHICULO_ADEUDO.NID_VEHICULO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ A D E U D O es requerido ")]
        [DisplayName("I D_ A D E U D O")]
        public Int32 NID_ADEUDO
        {
          get => datos_ALTA_VEHICULO_ADEUDO.NID_ADEUDO;
          set => datos_ALTA_VEHICULO_ADEUDO.NID_ADEUDO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_VEHICULO_ADEUDO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_ALTA_VEHICULO_ADEUDO() => datos_ALTA_VEHICULO_ADEUDO = new dald_ALTA_VEHICULO_ADEUDO();

        public bll_ALTA_VEHICULO_ADEUDO(MODELDeclara_V2.ALTA_VEHICULO_ADEUDO ALTA_VEHICULO_ADEUDO) => datos_ALTA_VEHICULO_ADEUDO = new dald_ALTA_VEHICULO_ADEUDO(ALTA_VEHICULO_ADEUDO);

        public bll_ALTA_VEHICULO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO) => datos_ALTA_VEHICULO_ADEUDO = new dald_ALTA_VEHICULO_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO);

        public bll_ALTA_VEHICULO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO, Int32 NID_ADEUDO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_ALTA_VEHICULO_ADEUDO = new dald_ALTA_VEHICULO_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO, NID_ADEUDO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_ALTA_VEHICULO_ADEUDO.update();
        }

        public void delete()
        {
            datos_ALTA_VEHICULO_ADEUDO.delete();
        }

        public void reload()
        {
            datos_ALTA_VEHICULO_ADEUDO.reload();
        }

     #endregion

    }
}
