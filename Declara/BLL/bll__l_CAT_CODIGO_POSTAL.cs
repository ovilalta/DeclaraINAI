using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_CODIGO_POSTAL : _bllSistema
    {

        internal dald__l_CAT_CODIGO_POSTAL datos_CAT_CODIGO_POSTAL;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_CODIGO_POSTAL> lista_CAT_CODIGO_POSTAL => datos_CAT_CODIGO_POSTAL.lista_CAT_CODIGO_POSTALs;

        protected List<MODELDeclara_V2.CAT_CODIGO_POSTAL>  base_CAT_CODIGO_POSTALs => datos_CAT_CODIGO_POSTAL.base_CAT_CODIGO_POSTALs;

        public IntegerFilter NID_PAIS
        {
          get => datos_CAT_CODIGO_POSTAL.NID_PAIS;
          set => datos_CAT_CODIGO_POSTAL.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
          get => datos_CAT_CODIGO_POSTAL.NID_PAISs;
          set => datos_CAT_CODIGO_POSTAL.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
          get => datos_CAT_CODIGO_POSTAL.CID_ENTIDAD_FEDERATIVA;
          set => datos_CAT_CODIGO_POSTAL.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
          get => datos_CAT_CODIGO_POSTAL.CID_ENTIDAD_FEDERATIVAs;
          set => datos_CAT_CODIGO_POSTAL.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public StringFilter CID_MUNICIPIO
        {
          get => datos_CAT_CODIGO_POSTAL.CID_MUNICIPIO;
          set => datos_CAT_CODIGO_POSTAL.CID_MUNICIPIO = value;
        }
        public ListFilter<String> CID_MUNICIPIOs
        {
          get => datos_CAT_CODIGO_POSTAL.CID_MUNICIPIOs;
          set => datos_CAT_CODIGO_POSTAL.CID_MUNICIPIOs = value;
        }

        public StringFilter CID_CODIGO_POSTAL
        {
          get => datos_CAT_CODIGO_POSTAL.CID_CODIGO_POSTAL;
          set => datos_CAT_CODIGO_POSTAL.CID_CODIGO_POSTAL = value;
        }
        public ListFilter<String> CID_CODIGO_POSTALs
        {
          get => datos_CAT_CODIGO_POSTAL.CID_CODIGO_POSTALs;
          set => datos_CAT_CODIGO_POSTAL.CID_CODIGO_POSTALs = value;
        }

        public IntegerFilter NID_COLONIA
        {
          get => datos_CAT_CODIGO_POSTAL.NID_COLONIA;
          set => datos_CAT_CODIGO_POSTAL.NID_COLONIA = value;
        }
        public ListFilter<Int32> NID_COLONIAs
        {
          get => datos_CAT_CODIGO_POSTAL.NID_COLONIAs;
          set => datos_CAT_CODIGO_POSTAL.NID_COLONIAs = value;
        }

        public StringFilter V_COLONIA
        {
          get => datos_CAT_CODIGO_POSTAL.V_COLONIA;
          set => datos_CAT_CODIGO_POSTAL.V_COLONIA = value;
        }
        public ListFilter<String> V_COLONIAs
        {
          get => datos_CAT_CODIGO_POSTAL.V_COLONIAs;
          set => datos_CAT_CODIGO_POSTAL.V_COLONIAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_CODIGO_POSTAL.OrderByCriterios; 
            set => datos_CAT_CODIGO_POSTAL.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_CODIGO_POSTAL() => datos_CAT_CODIGO_POSTAL = new dald__l_CAT_CODIGO_POSTAL();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_CODIGO_POSTAL.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_CODIGO_POSTAL.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_CODIGO_POSTAL.single_select();
        }

     #endregion

    }
}
