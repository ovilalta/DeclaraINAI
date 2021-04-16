using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_MUNICIPIO : _bllSistema
    {

        internal dald__l_CAT_MUNICIPIO datos_CAT_MUNICIPIO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_MUNICIPIO> lista_CAT_MUNICIPIO => datos_CAT_MUNICIPIO.lista_CAT_MUNICIPIOs;

        protected List<MODELDeclara_V2.CAT_MUNICIPIO>  base_CAT_MUNICIPIOs => datos_CAT_MUNICIPIO.base_CAT_MUNICIPIOs;

        public IntegerFilter NID_PAIS
        {
          get => datos_CAT_MUNICIPIO.NID_PAIS;
          set => datos_CAT_MUNICIPIO.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
          get => datos_CAT_MUNICIPIO.NID_PAISs;
          set => datos_CAT_MUNICIPIO.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
          get => datos_CAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVA;
          set => datos_CAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
          get => datos_CAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVAs;
          set => datos_CAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public StringFilter CID_MUNICIPIO
        {
          get => datos_CAT_MUNICIPIO.CID_MUNICIPIO;
          set => datos_CAT_MUNICIPIO.CID_MUNICIPIO = value;
        }
        public ListFilter<String> CID_MUNICIPIOs
        {
          get => datos_CAT_MUNICIPIO.CID_MUNICIPIOs;
          set => datos_CAT_MUNICIPIO.CID_MUNICIPIOs = value;
        }

        public StringFilter V_MUNICIPIO
        {
          get => datos_CAT_MUNICIPIO.V_MUNICIPIO;
          set => datos_CAT_MUNICIPIO.V_MUNICIPIO = value;
        }
        public ListFilter<String> V_MUNICIPIOs
        {
          get => datos_CAT_MUNICIPIO.V_MUNICIPIOs;
          set => datos_CAT_MUNICIPIO.V_MUNICIPIOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_MUNICIPIO.OrderByCriterios; 
            set => datos_CAT_MUNICIPIO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_MUNICIPIO() => datos_CAT_MUNICIPIO = new dald__l_CAT_MUNICIPIO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_MUNICIPIO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_MUNICIPIO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_MUNICIPIO.single_select();
        }

     #endregion

    }
}
