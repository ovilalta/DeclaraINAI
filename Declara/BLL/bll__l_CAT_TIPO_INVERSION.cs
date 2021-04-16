using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_TIPO_INVERSION : _bllSistema
    {

        internal dald__l_CAT_TIPO_INVERSION datos_CAT_TIPO_INVERSION;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_TIPO_INVERSION> lista_CAT_TIPO_INVERSION => datos_CAT_TIPO_INVERSION.lista_CAT_TIPO_INVERSIONs;

        protected List<MODELDeclara_V2.CAT_TIPO_INVERSION>  base_CAT_TIPO_INVERSIONs => datos_CAT_TIPO_INVERSION.base_CAT_TIPO_INVERSIONs;

        public IntegerFilter NID_TIPO_INVERSION
        {
          get => datos_CAT_TIPO_INVERSION.NID_TIPO_INVERSION;
          set => datos_CAT_TIPO_INVERSION.NID_TIPO_INVERSION = value;
        }
        public ListFilter<Int32> NID_TIPO_INVERSIONs
        {
          get => datos_CAT_TIPO_INVERSION.NID_TIPO_INVERSIONs;
          set => datos_CAT_TIPO_INVERSION.NID_TIPO_INVERSIONs = value;
        }

        public StringFilter V_TIPO_INVERSION
        {
          get => datos_CAT_TIPO_INVERSION.V_TIPO_INVERSION;
          set => datos_CAT_TIPO_INVERSION.V_TIPO_INVERSION = value;
        }
        public ListFilter<String> V_TIPO_INVERSIONs
        {
          get => datos_CAT_TIPO_INVERSION.V_TIPO_INVERSIONs;
          set => datos_CAT_TIPO_INVERSION.V_TIPO_INVERSIONs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_CAT_TIPO_INVERSION.L_ACTIVO;
          set => datos_CAT_TIPO_INVERSION.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_CAT_TIPO_INVERSION.L_ACTIVOs;
          set => datos_CAT_TIPO_INVERSION.L_ACTIVOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TIPO_INVERSION.OrderByCriterios; 
            set => datos_CAT_TIPO_INVERSION.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_TIPO_INVERSION() => datos_CAT_TIPO_INVERSION = new dald__l_CAT_TIPO_INVERSION();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_TIPO_INVERSION.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_TIPO_INVERSION.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_TIPO_INVERSION.single_select();
        }

     #endregion

    }
}
