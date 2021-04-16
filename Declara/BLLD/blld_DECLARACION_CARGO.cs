using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_CARGO : bll_DECLARACION_CARGO
    {

     #region *** Atributos ***


        #region * CAT_PUESTO *


        [StringLength(10)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I D_ P U E S T O es requerido ")]
        [DisplayName("I D_ P U E S T O")]
        public String VID_PUESTO => datos_DECLARACION_CARGO.VID_PUESTO;


        [StringLength(10)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I D_ N I V E L es requerido ")]
        [DisplayName("I D_ N I V E L")]
        public String VID_NIVEL => datos_DECLARACION_CARGO.VID_NIVEL;


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo P U E S T O es requerido ")]
        [DisplayName("P U E S T O")]
        public String V_PUESTO => datos_DECLARACION_CARGO.V_PUESTO;


        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO => datos_DECLARACION_CARGO.L_ACTIVO;

        #endregion * CAT_PUESTO *


        #region * CAT_SEGUNDO_NIVEL *


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo S E G U N D O_ N I V E L es requerido ")]
        [DisplayName("S E G U N D O_ N I V E L")]
        public String V_SEGUNDO_NIVEL => datos_DECLARACION_CARGO.V_SEGUNDO_NIVEL;


        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I N I C I O es requerido ")]
        [DisplayName("I N I C I O")]
        public String C_INICIO => datos_DECLARACION_CARGO.C_INICIO;


        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo F I N es requerido ")]
        [DisplayName("F I N")]
        public String C_FIN => datos_DECLARACION_CARGO.C_FIN;

        #endregion * CAT_SEGUNDO_NIVEL *



     #endregion


     #region *** Constructores ***

        private blld_DECLARACION_CARGO()
        : base()
        {
        }

        public blld_DECLARACION_CARGO(MODELDeclara_V2.DECLARACION_CARGO DECLARACION_CARGO)
        : base(DECLARACION_CARGO)
        {
        }

        public  blld_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION)
        {
        }

        //public blld_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PUESTO, String V_DENOMINACION, DateTime F_POSESION, DateTime F_INICIO, String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL)
        //: base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PUESTO, V_DENOMINACION, F_POSESION, F_INICIO, VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        //{
        //}


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
