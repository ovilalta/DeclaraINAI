using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_PATRIMONIO_FLUJO : _bllSistema
    {

        internal dald__l_PATRIMONIO_FLUJO datos_PATRIMONIO_FLUJO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.PATRIMONIO_FLUJO> lista_PATRIMONIO_FLUJO => datos_PATRIMONIO_FLUJO.lista_PATRIMONIO_FLUJOs;

        protected List<MODELDeclara_V2.PATRIMONIO_FLUJO>  base_PATRIMONIO_FLUJOs => datos_PATRIMONIO_FLUJO.base_PATRIMONIO_FLUJOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_PATRIMONIO_FLUJO.VID_NOMBRE;
          set => datos_PATRIMONIO_FLUJO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_PATRIMONIO_FLUJO.VID_NOMBREs;
          set => datos_PATRIMONIO_FLUJO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_PATRIMONIO_FLUJO.VID_FECHA;
          set => datos_PATRIMONIO_FLUJO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_PATRIMONIO_FLUJO.VID_FECHAs;
          set => datos_PATRIMONIO_FLUJO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_PATRIMONIO_FLUJO.VID_HOMOCLAVE;
          set => datos_PATRIMONIO_FLUJO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_PATRIMONIO_FLUJO.VID_HOMOCLAVEs;
          set => datos_PATRIMONIO_FLUJO.VID_HOMOCLAVEs = value;
        }

        public DecimalFilter M_INGRESOS
        {
          get => datos_PATRIMONIO_FLUJO.M_INGRESOS;
          set => datos_PATRIMONIO_FLUJO.M_INGRESOS = value;
        }
        public ListFilter<Decimal> M_INGRESOSs
        {
          get => datos_PATRIMONIO_FLUJO.M_INGRESOSs;
          set => datos_PATRIMONIO_FLUJO.M_INGRESOSs = value;
        }

        public DecimalFilter M_EGRESOS
        {
          get => datos_PATRIMONIO_FLUJO.M_EGRESOS;
          set => datos_PATRIMONIO_FLUJO.M_EGRESOS = value;
        }
        public ListFilter<Decimal> M_EGRESOSs
        {
          get => datos_PATRIMONIO_FLUJO.M_EGRESOSs;
          set => datos_PATRIMONIO_FLUJO.M_EGRESOSs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_PATRIMONIO_FLUJO.OrderByCriterios; 
            set => datos_PATRIMONIO_FLUJO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_PATRIMONIO_FLUJO() => datos_PATRIMONIO_FLUJO = new dald__l_PATRIMONIO_FLUJO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_PATRIMONIO_FLUJO.select();
        }

        public void clearOrderBy()
        {
            datos_PATRIMONIO_FLUJO.clearOrderBy();
        }

        public void Select()
        {
            datos_PATRIMONIO_FLUJO.single_select();
        }

     #endregion

    }
}
