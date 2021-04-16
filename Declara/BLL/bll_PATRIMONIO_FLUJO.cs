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
    public  class bll_PATRIMONIO_FLUJO : _bllSistema
    {

        internal dald_PATRIMONIO_FLUJO datos_PATRIMONIO_FLUJO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_PATRIMONIO_FLUJO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_PATRIMONIO_FLUJO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_PATRIMONIO_FLUJO.VID_HOMOCLAVE;

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo I N G R E S O S es requerido ")]
        [DisplayName("I N G R E S O S")]
        public Decimal M_INGRESOS
        {
          get => datos_PATRIMONIO_FLUJO.M_INGRESOS;
          set => datos_PATRIMONIO_FLUJO.M_INGRESOS = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo E G R E S O S es requerido ")]
        [DisplayName("E G R E S O S")]
        public Decimal M_EGRESOS
        {
          get => datos_PATRIMONIO_FLUJO.M_EGRESOS;
          set => datos_PATRIMONIO_FLUJO.M_EGRESOS = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_PATRIMONIO_FLUJO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_PATRIMONIO_FLUJO() => datos_PATRIMONIO_FLUJO = new dald_PATRIMONIO_FLUJO();

        public bll_PATRIMONIO_FLUJO(MODELDeclara_V2.PATRIMONIO_FLUJO PATRIMONIO_FLUJO) => datos_PATRIMONIO_FLUJO = new dald_PATRIMONIO_FLUJO(PATRIMONIO_FLUJO);

        public bll_PATRIMONIO_FLUJO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE) => datos_PATRIMONIO_FLUJO = new dald_PATRIMONIO_FLUJO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);

        public bll_PATRIMONIO_FLUJO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Decimal M_INGRESOS, Decimal M_EGRESOS, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_PATRIMONIO_FLUJO = new dald_PATRIMONIO_FLUJO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, M_INGRESOS, M_EGRESOS, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_PATRIMONIO_FLUJO.update();
        }

        public void delete()
        {
            datos_PATRIMONIO_FLUJO.delete();
        }

        public void reload()
        {
            datos_PATRIMONIO_FLUJO.reload();
        }

     #endregion

    }
}
