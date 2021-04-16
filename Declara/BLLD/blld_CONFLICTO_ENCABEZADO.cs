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
    public partial class blld_CONFLICTO_ENCABEZADO : bll_CONFLICTO_ENCABEZADO
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
                  Reload_CONFLICTO_RESPUESTAs();
              }
              return _CONFLICTO_RESPUESTAs;
          }
        }


     #endregion


     #region *** Constructores ***

        private blld_CONFLICTO_ENCABEZADO()
        : base()
        {
            _CONFLICTO_RESPUESTAs = null;
        }

        public blld_CONFLICTO_ENCABEZADO(MODELDeclara_V2.CONFLICTO_ENCABEZADO CONFLICTO_ENCABEZADO)
        : base(CONFLICTO_ENCABEZADO)
        {
        }

        public  blld_CONFLICTO_ENCABEZADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO)
        {
        }

        public blld_CONFLICTO_ENCABEZADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO, System.Nullable<Boolean> L_CONFLICTO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_CONFLICTO_RESPUESTAs()
        {
            _CONFLICTO_RESPUESTAs = new Lista<blld_CONFLICTO_RESPUESTA>();
            foreach (MODELDeclara_V2.CONFLICTO_RESPUESTA o in datos_CONFLICTO_ENCABEZADO._CONFLICTO_RESPUESTAs)
            {
                _CONFLICTO_RESPUESTAs.Add(new blld_CONFLICTO_RESPUESTA(o));
            }
        }

        private void _Add_CONFLICTO_RESPUESTAs(Int32 NID_PREGUNTA, String V_RESPUESTA)
        {
                blld_CONFLICTO_RESPUESTA oCONFLICTO_RESPUESTA = new blld_CONFLICTO_RESPUESTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, NID_PREGUNTA, V_RESPUESTA);
                if (oCONFLICTO_RESPUESTA.lEsNuevoRegistro.Value) CONFLICTO_RESPUESTAs.Add(oCONFLICTO_RESPUESTA);
                _CONFLICTO_RESPUESTAs[FindIndex_CONFLICTO_RESPUESTAs(NID_PREGUNTA)] = oCONFLICTO_RESPUESTA;
        }

        public Int32 FindIndex_CONFLICTO_RESPUESTAs(Int32 NID_PREGUNTA)
        {
            return  CONFLICTO_RESPUESTAs.FindIndex(p =>
                               p.NID_PREGUNTA == NID_PREGUNTA
                                                   );
        }



     #endregion

    }
}
