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
    public  class bll_ALTA_INMUEBLE_ADEUDO : _bllSistema
    {

        internal dald_ALTA_INMUEBLE_ADEUDO datos_ALTA_INMUEBLE_ADEUDO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_ALTA_INMUEBLE_ADEUDO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_ALTA_INMUEBLE_ADEUDO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_ALTA_INMUEBLE_ADEUDO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_ALTA_INMUEBLE_ADEUDO.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_INMUEBLE => datos_ALTA_INMUEBLE_ADEUDO.NID_INMUEBLE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_ADEUDO => datos_ALTA_INMUEBLE_ADEUDO.NID_ADEUDO;



        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_INMUEBLE_ADEUDO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_ALTA_INMUEBLE_ADEUDO() => datos_ALTA_INMUEBLE_ADEUDO = new dald_ALTA_INMUEBLE_ADEUDO();

        public bll_ALTA_INMUEBLE_ADEUDO(MODELDeclara_V2.ALTA_INMUEBLE_ADEUDO ALTA_INMUEBLE_ADEUDO) => datos_ALTA_INMUEBLE_ADEUDO = new dald_ALTA_INMUEBLE_ADEUDO(ALTA_INMUEBLE_ADEUDO);

        public bll_ALTA_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_ADEUDO) => datos_ALTA_INMUEBLE_ADEUDO = new dald_ALTA_INMUEBLE_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_ADEUDO);

        public bll_ALTA_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_ADEUDO, System.Nullable<Boolean> L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_ALTA_INMUEBLE_ADEUDO = new dald_ALTA_INMUEBLE_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_ADEUDO, L_DIF, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_ALTA_INMUEBLE_ADEUDO.update();
        }

        public void delete()
        {
            datos_ALTA_INMUEBLE_ADEUDO.delete();
        }

        public void reload()
        {
            datos_ALTA_INMUEBLE_ADEUDO.reload();
        }

     #endregion

    }
}
