using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_INSTRUMENTO_RENDIMIENTO : bll_CAT_INSTRUMENTO_RENDIMIENTO
    {

        #region *** Propiedades ***
//    new public Int32 NID_INSTRUMENTO_RENDIMIENTO => datos_CAT_INSTRUMENTO_RENDIMIENTO.NID_INSTRUMENTO_RENDIMIENTO;
//    new public String V_INSTRUMENTO_RENDIMIENTO
//        {
//            get => datos_CAT_INSTRUMENTO_RENDIMIENTO.V_INSTRUMENTO_RENDIMIENTO;
//            set => datos_CAT_INSTRUMENTO_RENDIMIENTO.V_INSTRUMENTO_RENDIMIENTO = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_INSTRUMENTO_RENDIMIENTO(Int32 NID_INSTRUMENTO_RENDIMIENTO, String V_INSTRUMENTO_RENDIMIENTO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_INSTRUMENTO_RENDIMIENTO = NID_INSTRUMENTO_RENDIMIENTO; 
            this.V_INSTRUMENTO_RENDIMIENTO = V_INSTRUMENTO_RENDIMIENTO;
            datos_CAT_INSTRUMENTO_RENDIMIENTO = new dald_CAT_INSTRUMENTO_RENDIMIENTO(_NID_INSTRUMENTO_RENDIMIENTO, this.V_INSTRUMENTO_RENDIMIENTO, lOpcionesRegistroExistente);
        }
        public blld_CAT_INSTRUMENTO_RENDIMIENTO(String V_INSTRUMENTO_RENDIMIENTO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_INSTRUMENTO_RENDIMIENTO = dald_CAT_INSTRUMENTO_RENDIMIENTO.nNuevo_NID_INSTRUMENTO_RENDIMIENTO();
            this.V_INSTRUMENTO_RENDIMIENTO = V_INSTRUMENTO_RENDIMIENTO;
            datos_CAT_INSTRUMENTO_RENDIMIENTO = new dald_CAT_INSTRUMENTO_RENDIMIENTO(_NID_INSTRUMENTO_RENDIMIENTO, this.V_INSTRUMENTO_RENDIMIENTO, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
