using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_INSTRUMENTO_RENDIMIENTO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_INSTRUMENTO_RENDIMIENTO datos_CAT_INSTRUMENTO_RENDIMIENTO { get; set; }
        public Int32 NID_INSTRUMENTO_RENDIMIENTO => datos_CAT_INSTRUMENTO_RENDIMIENTO.NID_INSTRUMENTO_RENDIMIENTO;
        public String V_INSTRUMENTO_RENDIMIENTO
        {
            get => datos_CAT_INSTRUMENTO_RENDIMIENTO.V_INSTRUMENTO_RENDIMIENTO;
            set => datos_CAT_INSTRUMENTO_RENDIMIENTO.V_INSTRUMENTO_RENDIMIENTO = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_INSTRUMENTO_RENDIMIENTO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_INSTRUMENTO_RENDIMIENTO() => datos_CAT_INSTRUMENTO_RENDIMIENTO = new dald_CAT_INSTRUMENTO_RENDIMIENTO();
        public bll_CAT_INSTRUMENTO_RENDIMIENTO(MODELDeclara_V2.CAT_INSTRUMENTO_RENDIMIENTO CAT_INSTRUMENTO_RENDIMIENTO) => datos_CAT_INSTRUMENTO_RENDIMIENTO = new dald_CAT_INSTRUMENTO_RENDIMIENTO(CAT_INSTRUMENTO_RENDIMIENTO);
        public bll_CAT_INSTRUMENTO_RENDIMIENTO(Int32 NID_INSTRUMENTO_RENDIMIENTO) => datos_CAT_INSTRUMENTO_RENDIMIENTO = new dald_CAT_INSTRUMENTO_RENDIMIENTO(NID_INSTRUMENTO_RENDIMIENTO);

//        public bll_CAT_INSTRUMENTO_RENDIMIENTO(Int32 NID_INSTRUMENTO_RENDIMIENTO, String V_INSTRUMENTO_RENDIMIENTO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_INSTRUMENTO_RENDIMIENTO = new dald_CAT_INSTRUMENTO_RENDIMIENTO();
//            Int32 _NID_INSTRUMENTO_RENDIMIENTO = NID_INSTRUMENTO_RENDIMIENTO; 
//            this.V_INSTRUMENTO_RENDIMIENTO = V_INSTRUMENTO_RENDIMIENTO;
//            datos_CAT_INSTRUMENTO_RENDIMIENTO = new dald_CAT_INSTRUMENTO_RENDIMIENTO(_NID_INSTRUMENTO_RENDIMIENTO, this.NID_INSTRUMENTO_RENDIMIENTO, this.V_INSTRUMENTO_RENDIMIENTO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_INSTRUMENTO_RENDIMIENTO.update();
        }
        public void delete()
        {
            datos_CAT_INSTRUMENTO_RENDIMIENTO.delete();
        }
        public void reload()
        {
            datos_CAT_INSTRUMENTO_RENDIMIENTO.reload();
        }

        #endregion

    }
}
