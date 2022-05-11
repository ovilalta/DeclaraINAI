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
    public  class bll_ALTA : _bllSistema
    {

        internal dald_ALTA datos_ALTA;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_ALTA.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_ALTA.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_ALTA.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_ALTA.NID_DECLARACION;


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_ALTA() => datos_ALTA = new dald_ALTA();

        public bll_ALTA(MODELDeclara_V2.ALTA ALTA) => datos_ALTA = new dald_ALTA(ALTA);

        public bll_ALTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) => datos_ALTA = new dald_ALTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);

        //OEVM - 20220510
        public bll_ALTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_ALTA = new dald_ALTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION,  lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_ALTA.update();
        }

        public void delete()
        {
            datos_ALTA.delete();
        }

        public void reload()
        {
            datos_ALTA.reload();
        }

     #endregion

    }
}
