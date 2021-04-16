using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_DESGLOSE_INGRESO_SUPERIOR : bll_CAT_DESGLOSE_INGRESO_SUPERIOR
    {

        #region *** Propiedades ***
        private Lista<blld_CAT_DESGLOSE_INGRESO> _CAT_DESGLOSE_INGRESOs { get; set; }
        public Lista<blld_CAT_DESGLOSE_INGRESO> CAT_DESGLOSE_INGRESOs
        {
            get
            {
                if (_CAT_DESGLOSE_INGRESOs == null)
                {
                    _CAT_DESGLOSE_INGRESOs = new Lista<blld_CAT_DESGLOSE_INGRESO>();
                    Reload_CAT_DESGLOSE_INGRESOs();
                }
                return _CAT_DESGLOSE_INGRESOs;
            }
        }


        #endregion


        #region *** Constructores ***
        private blld_CAT_DESGLOSE_INGRESO_SUPERIOR() : base()
        {
            _CAT_DESGLOSE_INGRESOs = null;
        }
        public blld_CAT_DESGLOSE_INGRESO_SUPERIOR(MODELDeclara_V2.CAT_DESGLOSE_INGRESO_SUPERIOR CAT_DESGLOSE_INGRESO_SUPERIOR) : base(CAT_DESGLOSE_INGRESO_SUPERIOR) { }
        public blld_CAT_DESGLOSE_INGRESO_SUPERIOR(Int32 NID_INGRESO_SUPERIOR) : base(NID_INGRESO_SUPERIOR) { }

//        public blld_CAT_DESGLOSE_INGRESO_SUPERIOR(Int32 NID_INGRESO_SUPERIOR, String V_INGRESO_SUPERIOR)
//        : base(NID_INGRESO_SUPERIOR, V_INGRESO_SUPERIOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***
        private void _Reload_CAT_DESGLOSE_INGRESOs()
        {
            _CAT_DESGLOSE_INGRESOs = new Lista<blld_CAT_DESGLOSE_INGRESO>();
            foreach (MODELDeclara_V2.CAT_DESGLOSE_INGRESO o in datos_CAT_DESGLOSE_INGRESO_SUPERIOR._CAT_DESGLOSE_INGRESOs)
                _CAT_DESGLOSE_INGRESOs.Add(new blld_CAT_DESGLOSE_INGRESO(o));
        }
        private void _Add_CAT_DESGLOSE_INGRESOs(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO, String V_INGRESO, Boolean L_VIGENTE)
        {
            blld_CAT_DESGLOSE_INGRESO oCAT_DESGLOSE_INGRESO = new blld_CAT_DESGLOSE_INGRESO(NID_INGRESO_SUPERIOR, NID_INGRESO, V_INGRESO, L_VIGENTE);
            if (oCAT_DESGLOSE_INGRESO.lEsNuevoRegistro.Value) CAT_DESGLOSE_INGRESOs.Add(oCAT_DESGLOSE_INGRESO);
            CAT_DESGLOSE_INGRESOs[FindIndex_CAT_DESGLOSE_INGRESOs(NID_INGRESO_SUPERIOR, NID_INGRESO)] = oCAT_DESGLOSE_INGRESO;
        }
        public Int32 FindIndex_CAT_DESGLOSE_INGRESOs(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO) => CAT_DESGLOSE_INGRESOs.FindIndex(p => p.NID_INGRESO_SUPERIOR == NID_INGRESO_SUPERIOR && p.NID_INGRESO == NID_INGRESO);



        #endregion

    }
}
