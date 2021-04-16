using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_BIEN_ENAJENADO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_BIEN_ENAJENADO datos_CAT_BIEN_ENAJENADO { get; set; }
        public Int32 NID_BIEN_ENAJENADO => datos_CAT_BIEN_ENAJENADO.NID_BIEN_ENAJENADO;
        public String V_BIEN_ENAJENADO
        {
            get => datos_CAT_BIEN_ENAJENADO.V_BIEN_ENAJENADO;
            set => datos_CAT_BIEN_ENAJENADO.V_BIEN_ENAJENADO = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_BIEN_ENAJENADO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_BIEN_ENAJENADO() => datos_CAT_BIEN_ENAJENADO = new dald_CAT_BIEN_ENAJENADO();
        public bll_CAT_BIEN_ENAJENADO(MODELDeclara_V2.CAT_BIEN_ENAJENADO CAT_BIEN_ENAJENADO) => datos_CAT_BIEN_ENAJENADO = new dald_CAT_BIEN_ENAJENADO(CAT_BIEN_ENAJENADO);
        public bll_CAT_BIEN_ENAJENADO(Int32 NID_BIEN_ENAJENADO) => datos_CAT_BIEN_ENAJENADO = new dald_CAT_BIEN_ENAJENADO(NID_BIEN_ENAJENADO);

//        public bll_CAT_BIEN_ENAJENADO(Int32 NID_BIEN_ENAJENADO, String V_BIEN_ENAJENADO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_BIEN_ENAJENADO = new dald_CAT_BIEN_ENAJENADO();
//            Int32 _NID_BIEN_ENAJENADO = NID_BIEN_ENAJENADO; 
//            this.V_BIEN_ENAJENADO = V_BIEN_ENAJENADO;
//            datos_CAT_BIEN_ENAJENADO = new dald_CAT_BIEN_ENAJENADO(_NID_BIEN_ENAJENADO, this.NID_BIEN_ENAJENADO, this.V_BIEN_ENAJENADO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_BIEN_ENAJENADO.update();
        }
        public void delete()
        {
            datos_CAT_BIEN_ENAJENADO.delete();
        }
        public void reload()
        {
            datos_CAT_BIEN_ENAJENADO.reload();
        }

        #endregion

    }
}
