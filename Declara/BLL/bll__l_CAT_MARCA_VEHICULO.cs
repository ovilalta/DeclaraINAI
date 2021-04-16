using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_MARCA_VEHICULO : _bllSistema
    {

        internal dald__l_CAT_MARCA_VEHICULO datos_CAT_MARCA_VEHICULO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_MARCA_VEHICULO> lista_CAT_MARCA_VEHICULO => datos_CAT_MARCA_VEHICULO.lista_CAT_MARCA_VEHICULOs;

        protected List<MODELDeclara_V2.CAT_MARCA_VEHICULO>  base_CAT_MARCA_VEHICULOs => datos_CAT_MARCA_VEHICULO.base_CAT_MARCA_VEHICULOs;

        public IntegerFilter NID_MARCA
        {
          get => datos_CAT_MARCA_VEHICULO.NID_MARCA;
          set => datos_CAT_MARCA_VEHICULO.NID_MARCA = value;
        }
        public ListFilter<Int32> NID_MARCAs
        {
          get => datos_CAT_MARCA_VEHICULO.NID_MARCAs;
          set => datos_CAT_MARCA_VEHICULO.NID_MARCAs = value;
        }

        public StringFilter V_MARCA
        {
          get => datos_CAT_MARCA_VEHICULO.V_MARCA;
          set => datos_CAT_MARCA_VEHICULO.V_MARCA = value;
        }
        public ListFilter<String> V_MARCAs
        {
          get => datos_CAT_MARCA_VEHICULO.V_MARCAs;
          set => datos_CAT_MARCA_VEHICULO.V_MARCAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_MARCA_VEHICULO.OrderByCriterios; 
            set => datos_CAT_MARCA_VEHICULO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_MARCA_VEHICULO() => datos_CAT_MARCA_VEHICULO = new dald__l_CAT_MARCA_VEHICULO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_MARCA_VEHICULO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_MARCA_VEHICULO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_MARCA_VEHICULO.single_select();
        }

     #endregion

    }
}
