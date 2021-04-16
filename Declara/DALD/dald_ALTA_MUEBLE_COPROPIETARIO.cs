using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_ALTA_MUEBLE_COPROPIETARIO : dal_ALTA_MUEBLE_COPROPIETARIO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_ALTA_MUEBLE_COPROPIETARIO() : base() { }
        internal dald_ALTA_MUEBLE_COPROPIETARIO(ALTA_MUEBLE_COPROPIETARIO ALTA_MUEBLE_COPROPIETARIO) : base(ALTA_MUEBLE_COPROPIETARIO) { }
        internal dald_ALTA_MUEBLE_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE, Int32 NID_COPROPIETARIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE, NID_COPROPIETARIO) { }
        internal dald_ALTA_MUEBLE_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE, Int32 NID_COPROPIETARIO, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE, NID_COPROPIETARIO, CID_TIPO_PERSONA, V_NOMBRE, V_RFC, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***

        internal void update(string vID_NOMBRE, string vID_FECHA, string vID_HOMOCLAVE, int nID_DECLARACION, int nID_MUEBLE, int nID_COPROPIETARIO)
        {
            registro.VID_NOMBRE = vID_NOMBRE;
            registro.VID_FECHA = vID_FECHA;
            registro.VID_HOMOCLAVE = vID_HOMOCLAVE;
            registro.NID_DECLARACION = nID_DECLARACION;
            registro.NID_MUEBLE = nID_MUEBLE;
            registro.NID_COPROPIETARIO = nID_COPROPIETARIO;

            db.SaveChanges();
        }
        #endregion

    }
}
