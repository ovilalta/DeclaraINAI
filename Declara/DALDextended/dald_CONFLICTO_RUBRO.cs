using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2;
using Declara_V2.DAL;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using System.Data.Entity.Core.Objects;

namespace Declara_V2.DALD
{
// Extended
    internal partial class dald_CONFLICTO_RUBRO : dal_CONFLICTO_RUBRO
    {

        #region *** Atributos (Extended) ***


        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***

        internal Int32 SI(System.Nullable<Int32> NID_DECLARACION)
        {
            ObjectParameter NID_ENCABEZADO = new ObjectParameter("NID_ENCABEZADO",-1);
            db.paCONFLICTO_CREAR_ENCABEZADO(VID_NOMBRE
                                          ,VID_FECHA
                                          ,VID_HOMOCLAVE
                                          ,NID_CONFLICTO
                                          ,NID_RUBRO
                                          ,NID_DECLARACION
                                          ,NID_ENCABEZADO);
            return Convert.ToInt32(NID_ENCABEZADO.Value);
        }


        internal void NO(System.Nullable<Int32> NID_DECLARACION)
        {
            db.paCONFLICTO_BORRA_ENCABEZADOS(VID_NOMBRE
                                          , VID_FECHA
                                          , VID_HOMOCLAVE
                                          , NID_CONFLICTO
                                          , NID_RUBRO
                                          , NID_DECLARACION);
        }

        #endregion

    }
}
