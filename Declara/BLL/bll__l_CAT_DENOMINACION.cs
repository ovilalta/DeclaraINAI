using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_DENOMINACION : _bllSistema
    {

        internal dald__l_CAT_DENOMINACION datos_CAT_DENOMINACION;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_DENOMINACION> lista_CAT_DENOMINACION => datos_CAT_DENOMINACION.lista_CAT_DENOMINACIONs;

        protected List<MODELDeclara_V2.CAT_DENOMINACION>  base_CAT_DENOMINACIONs => datos_CAT_DENOMINACION.base_CAT_DENOMINACIONs;

        public IntegerFilter NID_DENOMINACION
        {
          get => datos_CAT_DENOMINACION.NID_DENOMINACION;
          set => datos_CAT_DENOMINACION.NID_DENOMINACION = value;
        }
        public ListFilter<Int32> NID_DENOMINACIONs
        {
          get => datos_CAT_DENOMINACION.NID_DENOMINACIONs;
          set => datos_CAT_DENOMINACION.NID_DENOMINACIONs = value;
        }

        public StringFilter V_DENOMINACION
        {
          get => datos_CAT_DENOMINACION.V_DENOMINACION;
          set => datos_CAT_DENOMINACION.V_DENOMINACION = value;
        }
        public ListFilter<String> V_DENOMINACIONs
        {
          get => datos_CAT_DENOMINACION.V_DENOMINACIONs;
          set => datos_CAT_DENOMINACION.V_DENOMINACIONs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_DENOMINACION.OrderByCriterios; 
            set => datos_CAT_DENOMINACION.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_DENOMINACION() => datos_CAT_DENOMINACION = new dald__l_CAT_DENOMINACION();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_DENOMINACION.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_DENOMINACION.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_DENOMINACION.single_select();
        }

     #endregion

    }
}
