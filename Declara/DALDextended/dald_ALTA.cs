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

namespace Declara_V2.DALD
{
// Extended
    internal partial class dald_ALTA : dal_ALTA
    {

        #region *** Atributos (Extended) ***

        internal List<ALTA_COMODATO_INMUEBLE> _ALTA_COMODATO_INMUEBLEs
        {
            get
            {
                db.Entry(registro).Collection(p => p.ALTA_COMODATO_INMUEBLE).Load();
                return registro.ALTA_COMODATO_INMUEBLE.ToList();
            }
        }
        internal Int32 ALTA_COMODATO_INMUEBLE_Count() => db.Entry(registro).Collection(b => b.ALTA_COMODATO_INMUEBLE).Query().Count();
        internal void ALTA_COMODATO_INMUEBLE_Clear() => db.Entry(registro).Collection(p => p.ALTA_COMODATO_INMUEBLE).CurrentValue.Clear();
        internal List<ALTA_COMODATO_VEHICULO> _ALTA_COMODATO_VEHICULOs
        {
            get
            {
                db.Entry(registro).Collection(p => p.ALTA_COMODATO_VEHICULO).Load();
                return registro.ALTA_COMODATO_VEHICULO.ToList();
            }
        }

        internal Int32 ALTA_COMODATO_VEHICULO_Count() => db.Entry(registro).Collection(b => b.ALTA_COMODATO_VEHICULO).Query().Count();
        internal void ALTA_COMODATO_VEHICULO_Clear() => db.Entry(registro).Collection(p => p.ALTA_COMODATO_VEHICULO).CurrentValue.Clear();

        internal List<ALTA_COMODATO> _ALTA_COMODATOs
        {
            get
            {
                db.Entry(registro).Collection(p => p.ALTA_COMODATO).Load();
                return registro.ALTA_COMODATO.ToList();
            }
        }


        internal Int32 ALTA_COMODATO_Count() => db.Entry(registro).Collection(b => b.ALTA_COMODATO).Query().Count();
        internal void ALTA_COMODATO_Clear() => db.Entry(registro).Collection(p => p.ALTA_COMODATO).CurrentValue.Clear();

        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
