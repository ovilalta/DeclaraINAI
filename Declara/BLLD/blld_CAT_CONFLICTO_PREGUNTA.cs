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
    public partial class blld_CAT_CONFLICTO_PREGUNTA : bll_CAT_CONFLICTO_PREGUNTA
    {

     #region *** Atributos ***


        private Lista<blld_CONFLICTO_RESPUESTA> _CONFLICTO_RESPUESTAs;
        public Lista<blld_CONFLICTO_RESPUESTA> CONFLICTO_RESPUESTAs
        {
          get
          {
              if(_CONFLICTO_RESPUESTAs == null)
              {
                  _CONFLICTO_RESPUESTAs = new Lista<blld_CONFLICTO_RESPUESTA>();
                  _Reload_CONFLICTO_RESPUESTAs();
              }
              return _CONFLICTO_RESPUESTAs;
          }
        }

        #region * CAT_CONFLICTO_RUBRO *


        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo R U B R O es requerido ")]
        [DisplayName("R U B R O")]
        public String V_RUBRO_CAT_CONFLICTO_RUBRO => datos_CAT_CONFLICTO_PREGUNTA.V_RUBRO;


        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I N I C I O es requerido ")]
        [DisplayName("I N I C I O")]
        public String C_INICIO_CAT_CONFLICTO_RUBRO => datos_CAT_CONFLICTO_PREGUNTA.C_INICIO;


        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo F I N es requerido ")]
        [DisplayName("F I N")]
        public String C_FIN_CAT_CONFLICTO_RUBRO => datos_CAT_CONFLICTO_PREGUNTA.C_FIN;

        #endregion * CAT_CONFLICTO_RUBRO *



     #endregion


     #region *** Constructores ***

        private blld_CAT_CONFLICTO_PREGUNTA()
        : base()
        {
            _CONFLICTO_RESPUESTAs = null;
        }

        public blld_CAT_CONFLICTO_PREGUNTA(MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA CAT_CONFLICTO_PREGUNTA)
        : base(CAT_CONFLICTO_PREGUNTA)
        {
        }

        public  blld_CAT_CONFLICTO_PREGUNTA(Int32 NID_RUBRO, Int32 NID_PREGUNTA)
        : base(NID_RUBRO, NID_PREGUNTA)
        {
        }

        public blld_CAT_CONFLICTO_PREGUNTA(Int32 NID_RUBRO, Int32 NID_PREGUNTA, String V_RUBRO, String V_OPCIONES, String C_INICIO, String C_FIN)
        : base(NID_RUBRO, NID_PREGUNTA, V_RUBRO, V_OPCIONES, C_INICIO, C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_CONFLICTO_RESPUESTAs()
        {
            _CONFLICTO_RESPUESTAs = new Lista<blld_CONFLICTO_RESPUESTA>();
            foreach (MODELDeclara_V2.CONFLICTO_RESPUESTA o in datos_CAT_CONFLICTO_PREGUNTA._CONFLICTO_RESPUESTAs)
            {
                _CONFLICTO_RESPUESTAs.Add(new blld_CONFLICTO_RESPUESTA(o));
            }
        }

        private void _Add_CONFLICTO_RESPUESTAs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_ENCABEZADO, String V_RESPUESTA)
        {
                blld_CONFLICTO_RESPUESTA oCONFLICTO_RESPUESTA = new blld_CONFLICTO_RESPUESTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, NID_PREGUNTA, V_RESPUESTA);
                if (oCONFLICTO_RESPUESTA.lEsNuevoRegistro.Value) CONFLICTO_RESPUESTAs.Add(oCONFLICTO_RESPUESTA);
                _CONFLICTO_RESPUESTAs[FindIndex_CONFLICTO_RESPUESTAs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_ENCABEZADO)] = oCONFLICTO_RESPUESTA;
        }

        public Int32 FindIndex_CONFLICTO_RESPUESTAs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_ENCABEZADO)
        {
            return  CONFLICTO_RESPUESTAs.FindIndex(p =>
                               p.VID_NOMBRE == VID_NOMBRE && 
                               p.VID_FECHA == VID_FECHA && 
                               p.VID_HOMOCLAVE == VID_HOMOCLAVE && 
                               p.NID_CONFLICTO == NID_CONFLICTO && 
                               p.NID_ENCABEZADO == NID_ENCABEZADO
                                                   );
        }



     #endregion

    }
}
