using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_ENTIDAD_FEDERATIVA : _bllSistema
    {

        internal dald__l_CAT_ENTIDAD_FEDERATIVA datos_CAT_ENTIDAD_FEDERATIVA;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA> lista_CAT_ENTIDAD_FEDERATIVA => datos_CAT_ENTIDAD_FEDERATIVA.lista_CAT_ENTIDAD_FEDERATIVAs;

        protected List<MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA>  base_CAT_ENTIDAD_FEDERATIVAs => datos_CAT_ENTIDAD_FEDERATIVA.base_CAT_ENTIDAD_FEDERATIVAs;

        public IntegerFilter NID_PAIS
        {
          get => datos_CAT_ENTIDAD_FEDERATIVA.NID_PAIS;
          set => datos_CAT_ENTIDAD_FEDERATIVA.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
          get => datos_CAT_ENTIDAD_FEDERATIVA.NID_PAISs;
          set => datos_CAT_ENTIDAD_FEDERATIVA.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
          get => datos_CAT_ENTIDAD_FEDERATIVA.CID_ENTIDAD_FEDERATIVA;
          set => datos_CAT_ENTIDAD_FEDERATIVA.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
          get => datos_CAT_ENTIDAD_FEDERATIVA.CID_ENTIDAD_FEDERATIVAs;
          set => datos_CAT_ENTIDAD_FEDERATIVA.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public StringFilter V_ENTIDAD_FEDERATIVA
        {
          get => datos_CAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA;
          set => datos_CAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> V_ENTIDAD_FEDERATIVAs
        {
          get => datos_CAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVAs;
          set => datos_CAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_ENTIDAD_FEDERATIVA.OrderByCriterios; 
            set => datos_CAT_ENTIDAD_FEDERATIVA.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_ENTIDAD_FEDERATIVA() => datos_CAT_ENTIDAD_FEDERATIVA = new dald__l_CAT_ENTIDAD_FEDERATIVA();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_ENTIDAD_FEDERATIVA.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_ENTIDAD_FEDERATIVA.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_ENTIDAD_FEDERATIVA.single_select();
        }

     #endregion

    }
}
