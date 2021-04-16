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
    public  class bll_CAT_SEGUNDO_NIVEL : _bllSistema
    {

        internal dald_CAT_SEGUNDO_NIVEL datos_CAT_SEGUNDO_NIVEL;

     #region *** Atributos ***

        [Key]
        [StringLength(8)]
        [Required(ErrorMessage = "El campo I D_ P R I M E R_ N I V E L es requerido ")]
        [DisplayName("I D_ P R I M E R_ N I V E L")]
        public String VID_PRIMER_NIVEL => datos_CAT_SEGUNDO_NIVEL.VID_PRIMER_NIVEL;

        [Key]
        [StringLength(8)]
        [Required(ErrorMessage = "El campo I D_ S E G U N D O_ N I V E L es requerido ")]
        [DisplayName("I D_ S E G U N D O_ N I V E L")]
        public String VID_SEGUNDO_NIVEL => datos_CAT_SEGUNDO_NIVEL.VID_SEGUNDO_NIVEL;

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo S E G U N D O_ N I V E L es requerido ")]
        [DisplayName("S E G U N D O_ N I V E L")]
        public String V_SEGUNDO_NIVEL
        {
          get => datos_CAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVEL;
          set => datos_CAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVEL = value;
        }

        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I N I C I O es requerido ")]
        [DisplayName("I N I C I O")]
        public String C_INICIO
        {
          get => datos_CAT_SEGUNDO_NIVEL.C_INICIO;
          set => datos_CAT_SEGUNDO_NIVEL.C_INICIO = value;
        }

        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo F I N es requerido ")]
        [DisplayName("F I N")]
        public String C_FIN
        {
          get => datos_CAT_SEGUNDO_NIVEL.C_FIN;
          set => datos_CAT_SEGUNDO_NIVEL.C_FIN = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_SEGUNDO_NIVEL.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_SEGUNDO_NIVEL() => datos_CAT_SEGUNDO_NIVEL = new dald_CAT_SEGUNDO_NIVEL();

        public bll_CAT_SEGUNDO_NIVEL(MODELDeclara_V2.CAT_SEGUNDO_NIVEL CAT_SEGUNDO_NIVEL) => datos_CAT_SEGUNDO_NIVEL = new dald_CAT_SEGUNDO_NIVEL(CAT_SEGUNDO_NIVEL);

        public bll_CAT_SEGUNDO_NIVEL(String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL) => datos_CAT_SEGUNDO_NIVEL = new dald_CAT_SEGUNDO_NIVEL(VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL);

        public bll_CAT_SEGUNDO_NIVEL(String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL, String V_SEGUNDO_NIVEL, String C_INICIO, String C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_SEGUNDO_NIVEL = new dald_CAT_SEGUNDO_NIVEL(VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL, V_SEGUNDO_NIVEL, C_INICIO, C_FIN, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_SEGUNDO_NIVEL.update();
        }

        public void delete()
        {
            datos_CAT_SEGUNDO_NIVEL.delete();
        }

        public void reload()
        {
            datos_CAT_SEGUNDO_NIVEL.reload();
        }

     #endregion

    }
}
