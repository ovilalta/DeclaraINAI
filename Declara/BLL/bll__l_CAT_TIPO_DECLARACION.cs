using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_TIPO_DECLARACION : _bllSistema
    {

        internal dald__l_CAT_TIPO_DECLARACION datos_CAT_TIPO_DECLARACION;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_TIPO_DECLARACION> lista_CAT_TIPO_DECLARACION => datos_CAT_TIPO_DECLARACION.lista_CAT_TIPO_DECLARACIONs;

        protected List<MODELDeclara_V2.CAT_TIPO_DECLARACION>  base_CAT_TIPO_DECLARACIONs => datos_CAT_TIPO_DECLARACION.base_CAT_TIPO_DECLARACIONs;

        public IntegerFilter NID_TIPO_DECLARACION
        {
          get => datos_CAT_TIPO_DECLARACION.NID_TIPO_DECLARACION;
          set => datos_CAT_TIPO_DECLARACION.NID_TIPO_DECLARACION = value;
        }
        public ListFilter<Int32> NID_TIPO_DECLARACIONs
        {
          get => datos_CAT_TIPO_DECLARACION.NID_TIPO_DECLARACIONs;
          set => datos_CAT_TIPO_DECLARACION.NID_TIPO_DECLARACIONs = value;
        }

        public StringFilter V_TIPO_DECLARACION
        {
          get => datos_CAT_TIPO_DECLARACION.V_TIPO_DECLARACION;
          set => datos_CAT_TIPO_DECLARACION.V_TIPO_DECLARACION = value;
        }
        public ListFilter<String> V_TIPO_DECLARACIONs
        {
          get => datos_CAT_TIPO_DECLARACION.V_TIPO_DECLARACIONs;
          set => datos_CAT_TIPO_DECLARACION.V_TIPO_DECLARACIONs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TIPO_DECLARACION.OrderByCriterios; 
            set => datos_CAT_TIPO_DECLARACION.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_TIPO_DECLARACION() => datos_CAT_TIPO_DECLARACION = new dald__l_CAT_TIPO_DECLARACION();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_TIPO_DECLARACION.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_TIPO_DECLARACION.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_TIPO_DECLARACION.single_select();
        }

     #endregion

    }
}
