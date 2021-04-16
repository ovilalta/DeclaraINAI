using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CONFLICTO_ENCABEZADO : _bllSistema
    {

        internal dald__l_CONFLICTO_ENCABEZADO datos_CONFLICTO_ENCABEZADO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CONFLICTO_ENCABEZADO> lista_CONFLICTO_ENCABEZADO => datos_CONFLICTO_ENCABEZADO.lista_CONFLICTO_ENCABEZADOs;

        protected List<MODELDeclara_V2.CONFLICTO_ENCABEZADO>  base_CONFLICTO_ENCABEZADOs => datos_CONFLICTO_ENCABEZADO.base_CONFLICTO_ENCABEZADOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_CONFLICTO_ENCABEZADO.VID_NOMBRE;
          set => datos_CONFLICTO_ENCABEZADO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_CONFLICTO_ENCABEZADO.VID_NOMBREs;
          set => datos_CONFLICTO_ENCABEZADO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_CONFLICTO_ENCABEZADO.VID_FECHA;
          set => datos_CONFLICTO_ENCABEZADO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_CONFLICTO_ENCABEZADO.VID_FECHAs;
          set => datos_CONFLICTO_ENCABEZADO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_CONFLICTO_ENCABEZADO.VID_HOMOCLAVE;
          set => datos_CONFLICTO_ENCABEZADO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_CONFLICTO_ENCABEZADO.VID_HOMOCLAVEs;
          set => datos_CONFLICTO_ENCABEZADO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_CONFLICTO
        {
          get => datos_CONFLICTO_ENCABEZADO.NID_CONFLICTO;
          set => datos_CONFLICTO_ENCABEZADO.NID_CONFLICTO = value;
        }
        public ListFilter<Int32> NID_CONFLICTOs
        {
          get => datos_CONFLICTO_ENCABEZADO.NID_CONFLICTOs;
          set => datos_CONFLICTO_ENCABEZADO.NID_CONFLICTOs = value;
        }

        public IntegerFilter NID_RUBRO
        {
          get => datos_CONFLICTO_ENCABEZADO.NID_RUBRO;
          set => datos_CONFLICTO_ENCABEZADO.NID_RUBRO = value;
        }
        public ListFilter<Int32> NID_RUBROs
        {
          get => datos_CONFLICTO_ENCABEZADO.NID_RUBROs;
          set => datos_CONFLICTO_ENCABEZADO.NID_RUBROs = value;
        }

        public IntegerFilter NID_ENCABEZADO
        {
          get => datos_CONFLICTO_ENCABEZADO.NID_ENCABEZADO;
          set => datos_CONFLICTO_ENCABEZADO.NID_ENCABEZADO = value;
        }
        public ListFilter<Int32> NID_ENCABEZADOs
        {
          get => datos_CONFLICTO_ENCABEZADO.NID_ENCABEZADOs;
          set => datos_CONFLICTO_ENCABEZADO.NID_ENCABEZADOs = value;
        }

        public System.Nullable<Boolean> L_CONFLICTO
        {
          get => datos_CONFLICTO_ENCABEZADO.L_CONFLICTO;
          set => datos_CONFLICTO_ENCABEZADO.L_CONFLICTO = value;
        }
        public ListFilter<Boolean> L_CONFLICTOs
        {
          get => datos_CONFLICTO_ENCABEZADO.L_CONFLICTOs;
          set => datos_CONFLICTO_ENCABEZADO.L_CONFLICTOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CONFLICTO_ENCABEZADO.OrderByCriterios; 
            set => datos_CONFLICTO_ENCABEZADO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CONFLICTO_ENCABEZADO() => datos_CONFLICTO_ENCABEZADO = new dald__l_CONFLICTO_ENCABEZADO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CONFLICTO_ENCABEZADO.select();
        }

        public void clearOrderBy()
        {
            datos_CONFLICTO_ENCABEZADO.clearOrderBy();
        }

        public void Select()
        {
            datos_CONFLICTO_ENCABEZADO.single_select();
        }

     #endregion

    }
}
