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
    public  class bll_MODIFICACION_BAJA_SINIESTRO : _bllSistema
    {

        internal dald_MODIFICACION_BAJA_SINIESTRO datos_MODIFICACION_BAJA_SINIESTRO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_MODIFICACION_BAJA_SINIESTRO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_MODIFICACION_BAJA_SINIESTRO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_BAJA_SINIESTRO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_BAJA_SINIESTRO.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO => datos_MODIFICACION_BAJA_SINIESTRO.NID_PATRIMONIO;

        [Required(ErrorMessage = "El campo P O L I Z A es requerido ")]
        [DisplayName("P O L I Z A")]
        public Boolean L_POLIZA
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.L_POLIZA;
          set => datos_MODIFICACION_BAJA_SINIESTRO.L_POLIZA = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo R E C U P E R A D O es requerido ")]
        [DisplayName("R E C U P E R A D O")]
        public Decimal M_RECUPERADO
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.M_RECUPERADO;
          set => datos_MODIFICACION_BAJA_SINIESTRO.M_RECUPERADO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_BAJA_SINIESTRO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_BAJA_SINIESTRO() => datos_MODIFICACION_BAJA_SINIESTRO = new dald_MODIFICACION_BAJA_SINIESTRO();

        public bll_MODIFICACION_BAJA_SINIESTRO(MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO MODIFICACION_BAJA_SINIESTRO) => datos_MODIFICACION_BAJA_SINIESTRO = new dald_MODIFICACION_BAJA_SINIESTRO(MODIFICACION_BAJA_SINIESTRO);

        public bll_MODIFICACION_BAJA_SINIESTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) => datos_MODIFICACION_BAJA_SINIESTRO = new dald_MODIFICACION_BAJA_SINIESTRO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);

        public bll_MODIFICACION_BAJA_SINIESTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Boolean L_POLIZA, Decimal M_RECUPERADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_BAJA_SINIESTRO = new dald_MODIFICACION_BAJA_SINIESTRO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, L_POLIZA, M_RECUPERADO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_BAJA_SINIESTRO.update();
        }

        public void delete()
        {
            datos_MODIFICACION_BAJA_SINIESTRO.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_BAJA_SINIESTRO.reload();
        }

     #endregion

    }
}
