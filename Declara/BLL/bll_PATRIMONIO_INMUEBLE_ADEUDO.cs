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
    public  class bll_PATRIMONIO_INMUEBLE_ADEUDO : _bllSistema
    {

        internal dald_PATRIMONIO_INMUEBLE_ADEUDO datos_PATRIMONIO_INMUEBLE_ADEUDO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_PATRIMONIO_INMUEBLE_ADEUDO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_PATRIMONIO_INMUEBLE_ADEUDO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_PATRIMONIO_INMUEBLE_ADEUDO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_PATRIMONIO_INMUEBLE_ADEUDO.NID_PATRIMONIO;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO_ADEUDO => datos_PATRIMONIO_INMUEBLE_ADEUDO.NID_PATRIMONIO_ADEUDO;



        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_PATRIMONIO_INMUEBLE_ADEUDO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_PATRIMONIO_INMUEBLE_ADEUDO() => datos_PATRIMONIO_INMUEBLE_ADEUDO = new dald_PATRIMONIO_INMUEBLE_ADEUDO();

        public bll_PATRIMONIO_INMUEBLE_ADEUDO(MODELDeclara_V2.PATRIMONIO_INMUEBLE_ADEUDO PATRIMONIO_INMUEBLE_ADEUDO) => datos_PATRIMONIO_INMUEBLE_ADEUDO = new dald_PATRIMONIO_INMUEBLE_ADEUDO(PATRIMONIO_INMUEBLE_ADEUDO);

        public bll_PATRIMONIO_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO) => datos_PATRIMONIO_INMUEBLE_ADEUDO = new dald_PATRIMONIO_INMUEBLE_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO);

        public bll_PATRIMONIO_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_PATRIMONIO_INMUEBLE_ADEUDO = new dald_PATRIMONIO_INMUEBLE_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO, L_DIF, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_PATRIMONIO_INMUEBLE_ADEUDO.update();
        }

        public void delete()
        {
            datos_PATRIMONIO_INMUEBLE_ADEUDO.delete();
        }

        public void reload()
        {
            datos_PATRIMONIO_INMUEBLE_ADEUDO.reload();
        }

     #endregion

    }
}
