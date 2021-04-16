using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_DOCUMENTO_OBTENIDO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_DOCUMENTO_OBTENIDO datos_CAT_DOCUMENTO_OBTENIDO { get; set; }
        public Int32 NID_DOCUMENTO_OBTENIDO => datos_CAT_DOCUMENTO_OBTENIDO.NID_DOCUMENTO_OBTENIDO;
        public String V_DOCUMENTO_OBTENIDO
        {
            get => datos_CAT_DOCUMENTO_OBTENIDO.V_DOCUMENTO_OBTENIDO;
            set => datos_CAT_DOCUMENTO_OBTENIDO.V_DOCUMENTO_OBTENIDO = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_DOCUMENTO_OBTENIDO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_DOCUMENTO_OBTENIDO() => datos_CAT_DOCUMENTO_OBTENIDO = new dald_CAT_DOCUMENTO_OBTENIDO();
        public bll_CAT_DOCUMENTO_OBTENIDO(MODELDeclara_V2.CAT_DOCUMENTO_OBTENIDO CAT_DOCUMENTO_OBTENIDO) => datos_CAT_DOCUMENTO_OBTENIDO = new dald_CAT_DOCUMENTO_OBTENIDO(CAT_DOCUMENTO_OBTENIDO);
        public bll_CAT_DOCUMENTO_OBTENIDO(Int32 NID_DOCUMENTO_OBTENIDO) => datos_CAT_DOCUMENTO_OBTENIDO = new dald_CAT_DOCUMENTO_OBTENIDO(NID_DOCUMENTO_OBTENIDO);

//        public bll_CAT_DOCUMENTO_OBTENIDO(Int32 NID_DOCUMENTO_OBTENIDO, String V_DOCUMENTO_OBTENIDO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_DOCUMENTO_OBTENIDO = new dald_CAT_DOCUMENTO_OBTENIDO();
//            Int32 _NID_DOCUMENTO_OBTENIDO = NID_DOCUMENTO_OBTENIDO; 
//            this.V_DOCUMENTO_OBTENIDO = V_DOCUMENTO_OBTENIDO;
//            datos_CAT_DOCUMENTO_OBTENIDO = new dald_CAT_DOCUMENTO_OBTENIDO(_NID_DOCUMENTO_OBTENIDO, this.NID_DOCUMENTO_OBTENIDO, this.V_DOCUMENTO_OBTENIDO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_DOCUMENTO_OBTENIDO.update();
        }
        public void delete()
        {
            datos_CAT_DOCUMENTO_OBTENIDO.delete();
        }
        public void reload()
        {
            datos_CAT_DOCUMENTO_OBTENIDO.reload();
        }

        #endregion

    }
}
