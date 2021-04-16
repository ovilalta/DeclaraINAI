using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_PATRIMONIO : _bllSistema
    {

        internal dald__l_PATRIMONIO datos_PATRIMONIO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.PATRIMONIO> lista_PATRIMONIO => datos_PATRIMONIO.lista_PATRIMONIOs;

        protected List<MODELDeclara_V2.PATRIMONIO>  base_PATRIMONIOs => datos_PATRIMONIO.base_PATRIMONIOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_PATRIMONIO.VID_NOMBRE;
          set => datos_PATRIMONIO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_PATRIMONIO.VID_NOMBREs;
          set => datos_PATRIMONIO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_PATRIMONIO.VID_FECHA;
          set => datos_PATRIMONIO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_PATRIMONIO.VID_FECHAs;
          set => datos_PATRIMONIO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_PATRIMONIO.VID_HOMOCLAVE;
          set => datos_PATRIMONIO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_PATRIMONIO.VID_HOMOCLAVEs;
          set => datos_PATRIMONIO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_PATRIMONIO.NID_PATRIMONIO;
          set => datos_PATRIMONIO.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_PATRIMONIO.NID_PATRIMONIOs;
          set => datos_PATRIMONIO.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_TIPO
        {
          get => datos_PATRIMONIO.NID_TIPO;
          set => datos_PATRIMONIO.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
          get => datos_PATRIMONIO.NID_TIPOs;
          set => datos_PATRIMONIO.NID_TIPOs = value;
        }

        public DecimalFilter M_VALOR
        {
          get => datos_PATRIMONIO.M_VALOR;
          set => datos_PATRIMONIO.M_VALOR = value;
        }
        public ListFilter<Decimal> M_VALORs
        {
          get => datos_PATRIMONIO.M_VALORs;
          set => datos_PATRIMONIO.M_VALORs = value;
        }

        public IntegerFilter NID_DEC_INCOR
        {
          get => datos_PATRIMONIO.NID_DEC_INCOR;
          set => datos_PATRIMONIO.NID_DEC_INCOR = value;
        }
        public ListFilter<Int32> NID_DEC_INCORs
        {
          get => datos_PATRIMONIO.NID_DEC_INCORs;
          set => datos_PATRIMONIO.NID_DEC_INCORs = value;
        }

        public DateTimeFilter F_INCORPORACION
        {
          get => datos_PATRIMONIO.F_INCORPORACION;
          set => datos_PATRIMONIO.F_INCORPORACION = value;
        }
        public ListFilter<DateTime> F_INCORPORACIONs
        {
          get => datos_PATRIMONIO.F_INCORPORACIONs;
          set => datos_PATRIMONIO.F_INCORPORACIONs = value;
        }

        public IntegerFilter NID_DEC_ULT_MOD
        {
          get => datos_PATRIMONIO.NID_DEC_ULT_MOD;
          set => datos_PATRIMONIO.NID_DEC_ULT_MOD = value;
        }
        public ListFilter<Int32> NID_DEC_ULT_MODs
        {
          get => datos_PATRIMONIO.NID_DEC_ULT_MODs;
          set => datos_PATRIMONIO.NID_DEC_ULT_MODs = value;
        }

        public DateTimeFilter F_MODIFICACION
        {
          get => datos_PATRIMONIO.F_MODIFICACION;
          set => datos_PATRIMONIO.F_MODIFICACION = value;
        }
        public ListFilter<DateTime> F_MODIFICACIONs
        {
          get => datos_PATRIMONIO.F_MODIFICACIONs;
          set => datos_PATRIMONIO.F_MODIFICACIONs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_PATRIMONIO.L_ACTIVO;
          set => datos_PATRIMONIO.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_PATRIMONIO.L_ACTIVOs;
          set => datos_PATRIMONIO.L_ACTIVOs = value;
        }

        public DateTimeFilter F_REGISTRO
        {
          get => datos_PATRIMONIO.F_REGISTRO;
          set => datos_PATRIMONIO.F_REGISTRO = value;
        }
        public ListFilter<DateTime> F_REGISTROs
        {
          get => datos_PATRIMONIO.F_REGISTROs;
          set => datos_PATRIMONIO.F_REGISTROs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_PATRIMONIO.OrderByCriterios; 
            set => datos_PATRIMONIO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_PATRIMONIO() => datos_PATRIMONIO = new dald__l_PATRIMONIO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_PATRIMONIO.select();
        }

        public void clearOrderBy()
        {
            datos_PATRIMONIO.clearOrderBy();
        }

        public void Select()
        {
            datos_PATRIMONIO.single_select();
        }

     #endregion

    }
}
