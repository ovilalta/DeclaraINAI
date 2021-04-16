using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_ESTADO_CONFLICTO : _bllSistema
    {

        internal dald__l_CAT_ESTADO_CONFLICTO datos_CAT_ESTADO_CONFLICTO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO> lista_CAT_ESTADO_CONFLICTO => datos_CAT_ESTADO_CONFLICTO.lista_CAT_ESTADO_CONFLICTOs;

        protected List<MODELDeclara_V2.CAT_ESTADO_CONFLICTO>  base_CAT_ESTADO_CONFLICTOs => datos_CAT_ESTADO_CONFLICTO.base_CAT_ESTADO_CONFLICTOs;

        public IntegerFilter NID_ESTADO_CONFLICTO
        {
          get => datos_CAT_ESTADO_CONFLICTO.NID_ESTADO_CONFLICTO;
          set => datos_CAT_ESTADO_CONFLICTO.NID_ESTADO_CONFLICTO = value;
        }
        public ListFilter<Int32> NID_ESTADO_CONFLICTOs
        {
          get => datos_CAT_ESTADO_CONFLICTO.NID_ESTADO_CONFLICTOs;
          set => datos_CAT_ESTADO_CONFLICTO.NID_ESTADO_CONFLICTOs = value;
        }

        public StringFilter V_ESTADO_CONFLICTO
        {
          get => datos_CAT_ESTADO_CONFLICTO.V_ESTADO_CONFLICTO;
          set => datos_CAT_ESTADO_CONFLICTO.V_ESTADO_CONFLICTO = value;
        }
        public ListFilter<String> V_ESTADO_CONFLICTOs
        {
          get => datos_CAT_ESTADO_CONFLICTO.V_ESTADO_CONFLICTOs;
          set => datos_CAT_ESTADO_CONFLICTO.V_ESTADO_CONFLICTOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_ESTADO_CONFLICTO.OrderByCriterios; 
            set => datos_CAT_ESTADO_CONFLICTO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_ESTADO_CONFLICTO() => datos_CAT_ESTADO_CONFLICTO = new dald__l_CAT_ESTADO_CONFLICTO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_ESTADO_CONFLICTO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_ESTADO_CONFLICTO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_ESTADO_CONFLICTO.single_select();
        }

     #endregion

    }
}
