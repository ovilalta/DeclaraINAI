using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_TIPO_VEHICULO : _bllSistema
    {

        internal dald__l_CAT_TIPO_VEHICULO datos_CAT_TIPO_VEHICULO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_TIPO_VEHICULO> lista_CAT_TIPO_VEHICULO => datos_CAT_TIPO_VEHICULO.lista_CAT_TIPO_VEHICULOs;

        protected List<MODELDeclara_V2.CAT_TIPO_VEHICULO>  base_CAT_TIPO_VEHICULOs => datos_CAT_TIPO_VEHICULO.base_CAT_TIPO_VEHICULOs;

        public IntegerFilter NID_TIPO_VEHICULO
        {
          get => datos_CAT_TIPO_VEHICULO.NID_TIPO_VEHICULO;
          set => datos_CAT_TIPO_VEHICULO.NID_TIPO_VEHICULO = value;
        }
        public ListFilter<Int32> NID_TIPO_VEHICULOs
        {
          get => datos_CAT_TIPO_VEHICULO.NID_TIPO_VEHICULOs;
          set => datos_CAT_TIPO_VEHICULO.NID_TIPO_VEHICULOs = value;
        }

        public StringFilter V_TIPO_VEHICULO
        {
          get => datos_CAT_TIPO_VEHICULO.V_TIPO_VEHICULO;
          set => datos_CAT_TIPO_VEHICULO.V_TIPO_VEHICULO = value;
        }
        public ListFilter<String> V_TIPO_VEHICULOs
        {
          get => datos_CAT_TIPO_VEHICULO.V_TIPO_VEHICULOs;
          set => datos_CAT_TIPO_VEHICULO.V_TIPO_VEHICULOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TIPO_VEHICULO.OrderByCriterios; 
            set => datos_CAT_TIPO_VEHICULO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_TIPO_VEHICULO() => datos_CAT_TIPO_VEHICULO = new dald__l_CAT_TIPO_VEHICULO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_TIPO_VEHICULO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_TIPO_VEHICULO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_TIPO_VEHICULO.single_select();
        }

     #endregion

    }
}
