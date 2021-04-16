using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_AMBITO_PUBLICO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_AMBITO_PUBLICO datos_CAT_AMBITO_PUBLICO { get; set; }
        public Int32 NID_AMBITO_PUBLICO => datos_CAT_AMBITO_PUBLICO.NID_AMBITO_PUBLICO;
        public String V_AMBITO_PUBLICO
        {
            get => datos_CAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO;
            set => datos_CAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_AMBITO_PUBLICO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_AMBITO_PUBLICO() => datos_CAT_AMBITO_PUBLICO = new dald_CAT_AMBITO_PUBLICO();
        public bll_CAT_AMBITO_PUBLICO(MODELDeclara_V2.CAT_AMBITO_PUBLICO CAT_AMBITO_PUBLICO) => datos_CAT_AMBITO_PUBLICO = new dald_CAT_AMBITO_PUBLICO(CAT_AMBITO_PUBLICO);
        public bll_CAT_AMBITO_PUBLICO(Int32 NID_AMBITO_PUBLICO) => datos_CAT_AMBITO_PUBLICO = new dald_CAT_AMBITO_PUBLICO(NID_AMBITO_PUBLICO);

//        public bll_CAT_AMBITO_PUBLICO(Int32 NID_AMBITO_PUBLICO, String V_AMBITO_PUBLICO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_AMBITO_PUBLICO = new dald_CAT_AMBITO_PUBLICO();
//            Int32 _NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO; 
//            this.V_AMBITO_PUBLICO = V_AMBITO_PUBLICO;
//            datos_CAT_AMBITO_PUBLICO = new dald_CAT_AMBITO_PUBLICO(_NID_AMBITO_PUBLICO, this.NID_AMBITO_PUBLICO, this.V_AMBITO_PUBLICO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_AMBITO_PUBLICO.update();
        }
        public void delete()
        {
            datos_CAT_AMBITO_PUBLICO.delete();
        }
        public void reload()
        {
            datos_CAT_AMBITO_PUBLICO.reload();
        }

        #endregion

    }
}
