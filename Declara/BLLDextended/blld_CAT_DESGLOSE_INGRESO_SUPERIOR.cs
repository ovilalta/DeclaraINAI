using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_DESGLOSE_INGRESO_SUPERIOR : bll_CAT_DESGLOSE_INGRESO_SUPERIOR
    {

        #region *** Propiedades ***
//    new public Int32 NID_INGRESO_SUPERIOR => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.NID_INGRESO_SUPERIOR;
//    new public String V_INGRESO_SUPERIOR
//        {
//            get => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.V_INGRESO_SUPERIOR;
//            set => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.V_INGRESO_SUPERIOR = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_DESGLOSE_INGRESO_SUPERIOR(Int32 NID_INGRESO_SUPERIOR, String V_INGRESO_SUPERIOR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_INGRESO_SUPERIOR = NID_INGRESO_SUPERIOR; 
            this.V_INGRESO_SUPERIOR = V_INGRESO_SUPERIOR;
            datos_CAT_DESGLOSE_INGRESO_SUPERIOR = new dald_CAT_DESGLOSE_INGRESO_SUPERIOR(_NID_INGRESO_SUPERIOR, this.V_INGRESO_SUPERIOR, lOpcionesRegistroExistente);
        }
        public blld_CAT_DESGLOSE_INGRESO_SUPERIOR(String V_INGRESO_SUPERIOR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_INGRESO_SUPERIOR = dald_CAT_DESGLOSE_INGRESO_SUPERIOR.nNuevo_NID_INGRESO_SUPERIOR();
            this.V_INGRESO_SUPERIOR = V_INGRESO_SUPERIOR;
            datos_CAT_DESGLOSE_INGRESO_SUPERIOR = new dald_CAT_DESGLOSE_INGRESO_SUPERIOR(_NID_INGRESO_SUPERIOR, this.V_INGRESO_SUPERIOR, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        public void Reload_CAT_DESGLOSE_INGRESOs()
        {
            _Reload_CAT_DESGLOSE_INGRESOs();
        }
        public void Add_CAT_DESGLOSE_INGRESOs(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO, String V_INGRESO, Boolean L_VIGENTE)
        {
            _Add_CAT_DESGLOSE_INGRESOs(NID_INGRESO_SUPERIOR, NID_INGRESO, V_INGRESO, L_VIGENTE);
        }



        #endregion

    }
}
