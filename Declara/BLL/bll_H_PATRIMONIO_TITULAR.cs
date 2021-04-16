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
    public  class bll_H_PATRIMONIO_TITULAR : _bllSistema
    {

        internal dald_H_PATRIMONIO_TITULAR datos_H_PATRIMONIO_TITULAR;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_H_PATRIMONIO_TITULAR.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_H_PATRIMONIO_TITULAR.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_H_PATRIMONIO_TITULAR.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_H_PATRIMONIO_TITULAR.NID_PATRIMONIO;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DEPENDIENTE => datos_H_PATRIMONIO_TITULAR.NID_DEPENDIENTE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_HISTORICO => datos_H_PATRIMONIO_TITULAR.NID_HISTORICO;



        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_H_PATRIMONIO_TITULAR.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_H_PATRIMONIO_TITULAR() => datos_H_PATRIMONIO_TITULAR = new dald_H_PATRIMONIO_TITULAR();

        public bll_H_PATRIMONIO_TITULAR(MODELDeclara_V2.H_PATRIMONIO_TITULAR H_PATRIMONIO_TITULAR) => datos_H_PATRIMONIO_TITULAR = new dald_H_PATRIMONIO_TITULAR(H_PATRIMONIO_TITULAR);

        public bll_H_PATRIMONIO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Int32 NID_HISTORICO) => datos_H_PATRIMONIO_TITULAR = new dald_H_PATRIMONIO_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE, NID_HISTORICO);

        public bll_H_PATRIMONIO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Int32 NID_HISTORICO, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_H_PATRIMONIO_TITULAR = new dald_H_PATRIMONIO_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE, NID_HISTORICO, L_DIF, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_H_PATRIMONIO_TITULAR.update();
        }

        public void delete()
        {
            datos_H_PATRIMONIO_TITULAR.delete();
        }

        public void reload()
        {
            datos_H_PATRIMONIO_TITULAR.reload();
        }

     #endregion

    }
}
