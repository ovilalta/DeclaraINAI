using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_DOCUMENTO_OBTENIDO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_DOCUMENTO_OBTENIDO datos_CAT_DOCUMENTO_OBTENIDO { get; set; }
        public List<Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO> lista_CAT_DOCUMENTO_OBTENIDO => datos_CAT_DOCUMENTO_OBTENIDO.lista_CAT_DOCUMENTO_OBTENIDOs;
        protected List<MODELDeclara_V2.CAT_DOCUMENTO_OBTENIDO> base_CAT_DOCUMENTO_OBTENIDOs => datos_CAT_DOCUMENTO_OBTENIDO.base_CAT_DOCUMENTO_OBTENIDOs;

        public IntegerFilter NID_DOCUMENTO_OBTENIDO
        {
            get => datos_CAT_DOCUMENTO_OBTENIDO.NID_DOCUMENTO_OBTENIDO;
            set => datos_CAT_DOCUMENTO_OBTENIDO.NID_DOCUMENTO_OBTENIDO = value;
        }
        public ListFilter<Int32> NID_DOCUMENTO_OBTENIDOs
        {
            get => datos_CAT_DOCUMENTO_OBTENIDO.NID_DOCUMENTO_OBTENIDOs;
            set => datos_CAT_DOCUMENTO_OBTENIDO.NID_DOCUMENTO_OBTENIDOs = value;
        }

        public StringFilter V_DOCUMENTO_OBTENIDO
        {
            get => datos_CAT_DOCUMENTO_OBTENIDO.V_DOCUMENTO_OBTENIDO;
            set => datos_CAT_DOCUMENTO_OBTENIDO.V_DOCUMENTO_OBTENIDO = value;
        }
        public ListFilter<String> V_DOCUMENTO_OBTENIDOs
        {
            get => datos_CAT_DOCUMENTO_OBTENIDO.V_DOCUMENTO_OBTENIDOs;
            set => datos_CAT_DOCUMENTO_OBTENIDO.V_DOCUMENTO_OBTENIDOs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_DOCUMENTO_OBTENIDO.OrderByCriterios;
            set => datos_CAT_DOCUMENTO_OBTENIDO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_DOCUMENTO_OBTENIDO() => datos_CAT_DOCUMENTO_OBTENIDO = new dald__l_CAT_DOCUMENTO_OBTENIDO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_DOCUMENTO_OBTENIDO.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_DOCUMENTO_OBTENIDO.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_DOCUMENTO_OBTENIDO.single_select();
        }

        #endregion

    }
}
