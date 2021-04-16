using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_RELACION_TRANSMISOR : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_RELACION_TRANSMISOR datos_CAT_RELACION_TRANSMISOR { get; set; }
        public Int32 NID_RELACION_TRANSMISOR => datos_CAT_RELACION_TRANSMISOR.NID_RELACION_TRANSMISOR;
        public String V_RELACION_TRANSMISOR
        {
            get => datos_CAT_RELACION_TRANSMISOR.V_RELACION_TRANSMISOR;
            set => datos_CAT_RELACION_TRANSMISOR.V_RELACION_TRANSMISOR = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_RELACION_TRANSMISOR.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_RELACION_TRANSMISOR() => datos_CAT_RELACION_TRANSMISOR = new dald_CAT_RELACION_TRANSMISOR();
        public bll_CAT_RELACION_TRANSMISOR(MODELDeclara_V2.CAT_RELACION_TRANSMISOR CAT_RELACION_TRANSMISOR) => datos_CAT_RELACION_TRANSMISOR = new dald_CAT_RELACION_TRANSMISOR(CAT_RELACION_TRANSMISOR);
        public bll_CAT_RELACION_TRANSMISOR(Int32 NID_RELACION_TRANSMISOR) => datos_CAT_RELACION_TRANSMISOR = new dald_CAT_RELACION_TRANSMISOR(NID_RELACION_TRANSMISOR);

//        public bll_CAT_RELACION_TRANSMISOR(Int32 NID_RELACION_TRANSMISOR, String V_RELACION_TRANSMISOR)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_RELACION_TRANSMISOR = new dald_CAT_RELACION_TRANSMISOR();
//            Int32 _NID_RELACION_TRANSMISOR = NID_RELACION_TRANSMISOR; 
//            this.V_RELACION_TRANSMISOR = V_RELACION_TRANSMISOR;
//            datos_CAT_RELACION_TRANSMISOR = new dald_CAT_RELACION_TRANSMISOR(_NID_RELACION_TRANSMISOR, this.NID_RELACION_TRANSMISOR, this.V_RELACION_TRANSMISOR, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_RELACION_TRANSMISOR.update();
        }
        public void delete()
        {
            datos_CAT_RELACION_TRANSMISOR.delete();
        }
        public void reload()
        {
            datos_CAT_RELACION_TRANSMISOR.reload();
        }

        #endregion

    }
}
