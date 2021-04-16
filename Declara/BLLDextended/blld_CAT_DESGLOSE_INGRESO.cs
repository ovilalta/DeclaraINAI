using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_DESGLOSE_INGRESO : bll_CAT_DESGLOSE_INGRESO
    {

        #region *** Propiedades ***
//    new public Int32 NID_INGRESO_SUPERIOR => datos_CAT_DESGLOSE_INGRESO.NID_INGRESO_SUPERIOR;
//    new public Int32 NID_INGRESO => datos_CAT_DESGLOSE_INGRESO.NID_INGRESO;
//    new public String V_INGRESO
//        {
//            get => datos_CAT_DESGLOSE_INGRESO.V_INGRESO;
//            set => datos_CAT_DESGLOSE_INGRESO.V_INGRESO = value;
//        }
//    new public Boolean L_VIGENTE
//        {
//            get => datos_CAT_DESGLOSE_INGRESO.L_VIGENTE;
//            set => datos_CAT_DESGLOSE_INGRESO.L_VIGENTE = value;
//        }
        public String V_INGRESO_SUPERIOR => datos_CAT_DESGLOSE_INGRESO.oCAT_DESGLOSE_INGRESO_SUPERIOR.V_INGRESO_SUPERIOR;

        #endregion


        #region *** Constructores ***
        public blld_CAT_DESGLOSE_INGRESO(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO, String V_INGRESO, Boolean L_VIGENTE)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_INGRESO_SUPERIOR = NID_INGRESO_SUPERIOR; 
            Int32 _NID_INGRESO = NID_INGRESO; 
            this.V_INGRESO = V_INGRESO;
            this.L_VIGENTE = L_VIGENTE;
            datos_CAT_DESGLOSE_INGRESO = new dald_CAT_DESGLOSE_INGRESO(_NID_INGRESO_SUPERIOR, _NID_INGRESO, this.V_INGRESO, this.L_VIGENTE, lOpcionesRegistroExistente);
        }
        public blld_CAT_DESGLOSE_INGRESO(Int32 NID_INGRESO_SUPERIOR, String V_INGRESO, Boolean L_VIGENTE)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_INGRESO_SUPERIOR = NID_INGRESO_SUPERIOR; 
            Int32 _NID_INGRESO = dald_CAT_DESGLOSE_INGRESO.nNuevo_NID_INGRESO(NID_INGRESO_SUPERIOR);
            this.V_INGRESO = V_INGRESO;
            this.L_VIGENTE = L_VIGENTE;
            datos_CAT_DESGLOSE_INGRESO = new dald_CAT_DESGLOSE_INGRESO(_NID_INGRESO_SUPERIOR, _NID_INGRESO, this.V_INGRESO, this.L_VIGENTE, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
