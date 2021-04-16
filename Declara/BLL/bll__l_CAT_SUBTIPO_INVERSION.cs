using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_SUBTIPO_INVERSION : _bllSistema
    {

        internal dald__l_CAT_SUBTIPO_INVERSION datos_CAT_SUBTIPO_INVERSION;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_SUBTIPO_INVERSION> lista_CAT_SUBTIPO_INVERSION => datos_CAT_SUBTIPO_INVERSION.lista_CAT_SUBTIPO_INVERSIONs;

        protected List<MODELDeclara_V2.CAT_SUBTIPO_INVERSION>  base_CAT_SUBTIPO_INVERSIONs => datos_CAT_SUBTIPO_INVERSION.base_CAT_SUBTIPO_INVERSIONs;

        public IntegerFilter NID_TIPO_INVERSION
        {
          get => datos_CAT_SUBTIPO_INVERSION.NID_TIPO_INVERSION;
          set => datos_CAT_SUBTIPO_INVERSION.NID_TIPO_INVERSION = value;
        }
        public ListFilter<Int32> NID_TIPO_INVERSIONs
        {
          get => datos_CAT_SUBTIPO_INVERSION.NID_TIPO_INVERSIONs;
          set => datos_CAT_SUBTIPO_INVERSION.NID_TIPO_INVERSIONs = value;
        }

        public IntegerFilter NID_SUBTIPO_INVERSION
        {
          get => datos_CAT_SUBTIPO_INVERSION.NID_SUBTIPO_INVERSION;
          set => datos_CAT_SUBTIPO_INVERSION.NID_SUBTIPO_INVERSION = value;
        }
        public ListFilter<Int32> NID_SUBTIPO_INVERSIONs
        {
          get => datos_CAT_SUBTIPO_INVERSION.NID_SUBTIPO_INVERSIONs;
          set => datos_CAT_SUBTIPO_INVERSION.NID_SUBTIPO_INVERSIONs = value;
        }

        public StringFilter V_SUBTIPO_INVERSION
        {
          get => datos_CAT_SUBTIPO_INVERSION.V_SUBTIPO_INVERSION;
          set => datos_CAT_SUBTIPO_INVERSION.V_SUBTIPO_INVERSION = value;
        }
        public ListFilter<String> V_SUBTIPO_INVERSIONs
        {
          get => datos_CAT_SUBTIPO_INVERSION.V_SUBTIPO_INVERSIONs;
          set => datos_CAT_SUBTIPO_INVERSION.V_SUBTIPO_INVERSIONs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_CAT_SUBTIPO_INVERSION.L_ACTIVO;
          set => datos_CAT_SUBTIPO_INVERSION.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_CAT_SUBTIPO_INVERSION.L_ACTIVOs;
          set => datos_CAT_SUBTIPO_INVERSION.L_ACTIVOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_SUBTIPO_INVERSION.OrderByCriterios; 
            set => datos_CAT_SUBTIPO_INVERSION.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_SUBTIPO_INVERSION() => datos_CAT_SUBTIPO_INVERSION = new dald__l_CAT_SUBTIPO_INVERSION();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_SUBTIPO_INVERSION.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_SUBTIPO_INVERSION.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_SUBTIPO_INVERSION.single_select();
        }

     #endregion

    }
}
