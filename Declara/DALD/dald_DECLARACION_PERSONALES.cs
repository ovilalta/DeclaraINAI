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
    internal partial class dald_DECLARACION_PERSONALES : dal_DECLARACION_PERSONALES
    {

     #region *** Atributos ***

        #region * CAT_ESTADO_CIVIL *

        dald_CAT_ESTADO_CIVIL _oCAT_ESTADO_CIVIL;
        dald_CAT_ESTADO_CIVIL oCAT_ESTADO_CIVIL
        {
            get
            {
                if(_oCAT_ESTADO_CIVIL == null) _oCAT_ESTADO_CIVIL= new dald_CAT_ESTADO_CIVIL(NID_ESTADO_CIVIL);
                return _oCAT_ESTADO_CIVIL;
            }
        }

        internal String V_ESTADO_CIVIL => oCAT_ESTADO_CIVIL.V_ESTADO_CIVIL;

        internal void Reload_CAT_ESTADO_CIVIL() => _oCAT_ESTADO_CIVIL = null;


        #endregion * CAT_ESTADO_CIVIL *



     #endregion


     #region *** Constructores ***

        internal dald_DECLARACION_PERSONALES()
        : base() { }

        internal dald_DECLARACION_PERSONALES(DECLARACION_PERSONALES DECLARACION_PERSONALES)
        : base(DECLARACION_PERSONALES) { }

        internal dald_DECLARACION_PERSONALES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION) { }
        //: base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_GENERO, C_CURP, NID_PAIS, CID_ENTIDAD_FEDERATIVA, NID_NACIONALIDAD, NID_ESTADO_CIVIL, lOpcionesRegistroExistente)  { }
        // SME-NF-I
        public dald_DECLARACION_PERSONALES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_GENERO, String C_CURP, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, Int32 NID_NACIONALIDAD, Int32 NID_ESTADO_CIVIL, System.Nullable<Boolean> L_SERVIDOR_ANTERIOR, System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_INICIO, System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_FIN, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO,ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE,VID_FECHA,VID_HOMOCLAVE,NID_DECLARACION,C_GENERO,C_CURP,NID_PAIS,CID_ENTIDAD_FEDERATIVA, NID_NACIONALIDAD, NID_ESTADO_CIVIL, L_SERVIDOR_ANTERIOR, F_SERVIDOR_ANTERIOR_INICIO,F_SERVIDOR_ANTERIOR_FIN,E_OBSERVACIONES,E_OBSERVACIONES_MARCADO,V_OBSERVACIONES_TESTADO,NID_ESTADO_TESTADO,lOpcionesRegistroExistente ) { }
        // SME-NF-F



        #endregion


        #region *** Metodos ***


        #endregion

    }
}
