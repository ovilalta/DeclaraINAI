using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_TIPO_PATRIMONIO : _bllSistema
    {

        internal dald__l_CAT_TIPO_PATRIMONIO datos_CAT_TIPO_PATRIMONIO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO> lista_CAT_TIPO_PATRIMONIO => datos_CAT_TIPO_PATRIMONIO.lista_CAT_TIPO_PATRIMONIOs;

        protected List<MODELDeclara_V2.CAT_TIPO_PATRIMONIO>  base_CAT_TIPO_PATRIMONIOs => datos_CAT_TIPO_PATRIMONIO.base_CAT_TIPO_PATRIMONIOs;

        public IntegerFilter NID_TIPO
        {
          get => datos_CAT_TIPO_PATRIMONIO.NID_TIPO;
          set => datos_CAT_TIPO_PATRIMONIO.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
          get => datos_CAT_TIPO_PATRIMONIO.NID_TIPOs;
          set => datos_CAT_TIPO_PATRIMONIO.NID_TIPOs = value;
        }

        public StringFilter V_TIPO
        {
          get => datos_CAT_TIPO_PATRIMONIO.V_TIPO;
          set => datos_CAT_TIPO_PATRIMONIO.V_TIPO = value;
        }
        public ListFilter<String> V_TIPOs
        {
          get => datos_CAT_TIPO_PATRIMONIO.V_TIPOs;
          set => datos_CAT_TIPO_PATRIMONIO.V_TIPOs = value;
        }

        public IntegerFilter C_NATURALEZA
        {
          get => datos_CAT_TIPO_PATRIMONIO.C_NATURALEZA;
          set => datos_CAT_TIPO_PATRIMONIO.C_NATURALEZA = value;
        }
        public ListFilter<Int32> C_NATURALEZAs
        {
          get => datos_CAT_TIPO_PATRIMONIO.C_NATURALEZAs;
          set => datos_CAT_TIPO_PATRIMONIO.C_NATURALEZAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TIPO_PATRIMONIO.OrderByCriterios; 
            set => datos_CAT_TIPO_PATRIMONIO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_TIPO_PATRIMONIO() => datos_CAT_TIPO_PATRIMONIO = new dald__l_CAT_TIPO_PATRIMONIO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_TIPO_PATRIMONIO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_TIPO_PATRIMONIO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_TIPO_PATRIMONIO.single_select();
        }

     #endregion

    }
}
