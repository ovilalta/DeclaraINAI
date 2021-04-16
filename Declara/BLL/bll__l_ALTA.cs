using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_ALTA : _bllSistema
    {

        internal dald__l_ALTA datos_ALTA;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.ALTA> lista_ALTA => datos_ALTA.lista_ALTAs;

        protected List<MODELDeclara_V2.ALTA>  base_ALTAs => datos_ALTA.base_ALTAs;

        public StringFilter VID_NOMBRE
        {
          get => datos_ALTA.VID_NOMBRE;
          set => datos_ALTA.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_ALTA.VID_NOMBREs;
          set => datos_ALTA.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_ALTA.VID_FECHA;
          set => datos_ALTA.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_ALTA.VID_FECHAs;
          set => datos_ALTA.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_ALTA.VID_HOMOCLAVE;
          set => datos_ALTA.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_ALTA.VID_HOMOCLAVEs;
          set => datos_ALTA.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_ALTA.NID_DECLARACION;
          set => datos_ALTA.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_ALTA.NID_DECLARACIONs;
          set => datos_ALTA.NID_DECLARACIONs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_ALTA.OrderByCriterios; 
            set => datos_ALTA.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_ALTA() => datos_ALTA = new dald__l_ALTA();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_ALTA.select();
        }

        public void clearOrderBy()
        {
            datos_ALTA.clearOrderBy();
        }

        public void Select()
        {
            datos_ALTA.single_select();
        }

     #endregion

    }
}
