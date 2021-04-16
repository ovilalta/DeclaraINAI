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
    public  class bll_CAT_CONFLICTO_PREGUNTA : _bllSistema
    {

        internal dald_CAT_CONFLICTO_PREGUNTA datos_CAT_CONFLICTO_PREGUNTA;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo I D_ R U B R O es requerido ")]
        [DisplayName("I D_ R U B R O")]
        public Int32 NID_RUBRO => datos_CAT_CONFLICTO_PREGUNTA.NID_RUBRO;

        [Key]
        [Required(ErrorMessage = "El campo I D_ P R E G U N T A es requerido ")]
        [DisplayName("I D_ P R E G U N T A")]
        public Int32 NID_PREGUNTA => datos_CAT_CONFLICTO_PREGUNTA.NID_PREGUNTA;

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo R U B R O es requerido ")]
        [DisplayName("R U B R O")]
        public String V_RUBRO
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.V_RUBRO;
          set => datos_CAT_CONFLICTO_PREGUNTA.V_RUBRO = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("O P C I O N E S")]
        public String V_OPCIONES
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.V_OPCIONES;
          set => datos_CAT_CONFLICTO_PREGUNTA.V_OPCIONES = value;
        }

        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I N I C I O es requerido ")]
        [DisplayName("I N I C I O")]
        public String C_INICIO
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.C_INICIO;
          set => datos_CAT_CONFLICTO_PREGUNTA.C_INICIO = value;
        }

        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo F I N es requerido ")]
        [DisplayName("F I N")]
        public String C_FIN
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.C_FIN;
          set => datos_CAT_CONFLICTO_PREGUNTA.C_FIN = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_CONFLICTO_PREGUNTA.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_CONFLICTO_PREGUNTA() => datos_CAT_CONFLICTO_PREGUNTA = new dald_CAT_CONFLICTO_PREGUNTA();

        public bll_CAT_CONFLICTO_PREGUNTA(MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA CAT_CONFLICTO_PREGUNTA) => datos_CAT_CONFLICTO_PREGUNTA = new dald_CAT_CONFLICTO_PREGUNTA(CAT_CONFLICTO_PREGUNTA);

        public bll_CAT_CONFLICTO_PREGUNTA(Int32 NID_RUBRO, Int32 NID_PREGUNTA) => datos_CAT_CONFLICTO_PREGUNTA = new dald_CAT_CONFLICTO_PREGUNTA(NID_RUBRO, NID_PREGUNTA);

        public bll_CAT_CONFLICTO_PREGUNTA(Int32 NID_RUBRO, Int32 NID_PREGUNTA, String V_RUBRO, String V_OPCIONES, String C_INICIO, String C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_CONFLICTO_PREGUNTA = new dald_CAT_CONFLICTO_PREGUNTA(NID_RUBRO, NID_PREGUNTA, V_RUBRO, V_OPCIONES, C_INICIO, C_FIN, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_CONFLICTO_PREGUNTA.update();
        }

        public void delete()
        {
            datos_CAT_CONFLICTO_PREGUNTA.delete();
        }

        public void reload()
        {
            datos_CAT_CONFLICTO_PREGUNTA.reload();
        }

     #endregion

    }
}
