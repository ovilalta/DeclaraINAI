using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_DESGLOSE_INGRESO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_DESGLOSE_INGRESO datos_CAT_DESGLOSE_INGRESO { get; set; }
        public Int32 NID_INGRESO_SUPERIOR => datos_CAT_DESGLOSE_INGRESO.NID_INGRESO_SUPERIOR;
        public Int32 NID_INGRESO => datos_CAT_DESGLOSE_INGRESO.NID_INGRESO;
        public String V_INGRESO
        {
            get => datos_CAT_DESGLOSE_INGRESO.V_INGRESO;
            set => datos_CAT_DESGLOSE_INGRESO.V_INGRESO = value;
        }
        public Boolean L_VIGENTE
        {
            get => datos_CAT_DESGLOSE_INGRESO.L_VIGENTE;
            set => datos_CAT_DESGLOSE_INGRESO.L_VIGENTE = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_DESGLOSE_INGRESO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_DESGLOSE_INGRESO() => datos_CAT_DESGLOSE_INGRESO = new dald_CAT_DESGLOSE_INGRESO();
        public bll_CAT_DESGLOSE_INGRESO(MODELDeclara_V2.CAT_DESGLOSE_INGRESO CAT_DESGLOSE_INGRESO) => datos_CAT_DESGLOSE_INGRESO = new dald_CAT_DESGLOSE_INGRESO(CAT_DESGLOSE_INGRESO);
        public bll_CAT_DESGLOSE_INGRESO(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO) => datos_CAT_DESGLOSE_INGRESO = new dald_CAT_DESGLOSE_INGRESO(NID_INGRESO_SUPERIOR, NID_INGRESO);

//        public bll_CAT_DESGLOSE_INGRESO(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO, String V_INGRESO, Boolean L_VIGENTE)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_DESGLOSE_INGRESO = new dald_CAT_DESGLOSE_INGRESO();
//            Int32 _NID_INGRESO_SUPERIOR = NID_INGRESO_SUPERIOR; 
//            Int32 _NID_INGRESO = NID_INGRESO; 
//            this.V_INGRESO = V_INGRESO;
//            this.L_VIGENTE = L_VIGENTE;
//            datos_CAT_DESGLOSE_INGRESO = new dald_CAT_DESGLOSE_INGRESO(_NID_INGRESO_SUPERIOR, _NID_INGRESO, this.NID_INGRESO_SUPERIOR, this.NID_INGRESO, this.V_INGRESO, this.L_VIGENTE, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_DESGLOSE_INGRESO.update();
        }
        public void delete()
        {
            datos_CAT_DESGLOSE_INGRESO.delete();
        }
        public void reload()
        {
            datos_CAT_DESGLOSE_INGRESO.reload();
        }

        #endregion

    }
}
