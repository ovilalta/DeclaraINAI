using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_ESTADO_DECLARACION : _bllSistema
    {

        internal dald__l_CAT_ESTADO_DECLARACION datos_CAT_ESTADO_DECLARACION;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_ESTADO_DECLARACION> lista_CAT_ESTADO_DECLARACION => datos_CAT_ESTADO_DECLARACION.lista_CAT_ESTADO_DECLARACIONs;

        protected List<MODELDeclara_V2.CAT_ESTADO_DECLARACION>  base_CAT_ESTADO_DECLARACIONs => datos_CAT_ESTADO_DECLARACION.base_CAT_ESTADO_DECLARACIONs;

        public IntegerFilter NID_ESTADO
        {
          get => datos_CAT_ESTADO_DECLARACION.NID_ESTADO;
          set => datos_CAT_ESTADO_DECLARACION.NID_ESTADO = value;
        }
        public ListFilter<Int32> NID_ESTADOs
        {
          get => datos_CAT_ESTADO_DECLARACION.NID_ESTADOs;
          set => datos_CAT_ESTADO_DECLARACION.NID_ESTADOs = value;
        }

        public StringFilter V_ESTADO
        {
          get => datos_CAT_ESTADO_DECLARACION.V_ESTADO;
          set => datos_CAT_ESTADO_DECLARACION.V_ESTADO = value;
        }
        public ListFilter<String> V_ESTADOs
        {
          get => datos_CAT_ESTADO_DECLARACION.V_ESTADOs;
          set => datos_CAT_ESTADO_DECLARACION.V_ESTADOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_ESTADO_DECLARACION.OrderByCriterios; 
            set => datos_CAT_ESTADO_DECLARACION.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_ESTADO_DECLARACION() => datos_CAT_ESTADO_DECLARACION = new dald__l_CAT_ESTADO_DECLARACION();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_ESTADO_DECLARACION.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_ESTADO_DECLARACION.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_ESTADO_DECLARACION.single_select();
        }

     #endregion

    }
}
