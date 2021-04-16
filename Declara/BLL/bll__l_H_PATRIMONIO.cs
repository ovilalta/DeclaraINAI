using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_H_PATRIMONIO : _bllSistema
    {

        internal dald__l_H_PATRIMONIO datos_H_PATRIMONIO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.H_PATRIMONIO> lista_H_PATRIMONIO => datos_H_PATRIMONIO.lista_H_PATRIMONIOs;

        protected List<MODELDeclara_V2.H_PATRIMONIO>  base_H_PATRIMONIOs => datos_H_PATRIMONIO.base_H_PATRIMONIOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_H_PATRIMONIO.VID_NOMBRE;
          set => datos_H_PATRIMONIO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_H_PATRIMONIO.VID_NOMBREs;
          set => datos_H_PATRIMONIO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_H_PATRIMONIO.VID_FECHA;
          set => datos_H_PATRIMONIO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_H_PATRIMONIO.VID_FECHAs;
          set => datos_H_PATRIMONIO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_H_PATRIMONIO.VID_HOMOCLAVE;
          set => datos_H_PATRIMONIO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_H_PATRIMONIO.VID_HOMOCLAVEs;
          set => datos_H_PATRIMONIO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_H_PATRIMONIO.NID_PATRIMONIO;
          set => datos_H_PATRIMONIO.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_H_PATRIMONIO.NID_PATRIMONIOs;
          set => datos_H_PATRIMONIO.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_HISTORICO
        {
          get => datos_H_PATRIMONIO.NID_HISTORICO;
          set => datos_H_PATRIMONIO.NID_HISTORICO = value;
        }
        public ListFilter<Int32> NID_HISTORICOs
        {
          get => datos_H_PATRIMONIO.NID_HISTORICOs;
          set => datos_H_PATRIMONIO.NID_HISTORICOs = value;
        }

        public IntegerFilter NID_TIPO
        {
          get => datos_H_PATRIMONIO.NID_TIPO;
          set => datos_H_PATRIMONIO.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
          get => datos_H_PATRIMONIO.NID_TIPOs;
          set => datos_H_PATRIMONIO.NID_TIPOs = value;
        }

        public DecimalFilter M_VALOR
        {
          get => datos_H_PATRIMONIO.M_VALOR;
          set => datos_H_PATRIMONIO.M_VALOR = value;
        }
        public ListFilter<Decimal> M_VALORs
        {
          get => datos_H_PATRIMONIO.M_VALORs;
          set => datos_H_PATRIMONIO.M_VALORs = value;
        }

        public IntegerFilter NID_DEC_INCOR
        {
          get => datos_H_PATRIMONIO.NID_DEC_INCOR;
          set => datos_H_PATRIMONIO.NID_DEC_INCOR = value;
        }
        public ListFilter<Int32> NID_DEC_INCORs
        {
          get => datos_H_PATRIMONIO.NID_DEC_INCORs;
          set => datos_H_PATRIMONIO.NID_DEC_INCORs = value;
        }

        public DateTimeFilter F_INCORPORACION
        {
          get => datos_H_PATRIMONIO.F_INCORPORACION;
          set => datos_H_PATRIMONIO.F_INCORPORACION = value;
        }
        public ListFilter<DateTime> F_INCORPORACIONs
        {
          get => datos_H_PATRIMONIO.F_INCORPORACIONs;
          set => datos_H_PATRIMONIO.F_INCORPORACIONs = value;
        }

        public IntegerFilter NID_DEC_ULT_MOD
        {
          get => datos_H_PATRIMONIO.NID_DEC_ULT_MOD;
          set => datos_H_PATRIMONIO.NID_DEC_ULT_MOD = value;
        }
        public ListFilter<Int32> NID_DEC_ULT_MODs
        {
          get => datos_H_PATRIMONIO.NID_DEC_ULT_MODs;
          set => datos_H_PATRIMONIO.NID_DEC_ULT_MODs = value;
        }

        public DateTimeFilter F_MODIFICACION
        {
          get => datos_H_PATRIMONIO.F_MODIFICACION;
          set => datos_H_PATRIMONIO.F_MODIFICACION = value;
        }
        public ListFilter<DateTime> F_MODIFICACIONs
        {
          get => datos_H_PATRIMONIO.F_MODIFICACIONs;
          set => datos_H_PATRIMONIO.F_MODIFICACIONs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_H_PATRIMONIO.L_ACTIVO;
          set => datos_H_PATRIMONIO.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_H_PATRIMONIO.L_ACTIVOs;
          set => datos_H_PATRIMONIO.L_ACTIVOs = value;
        }

        public DateTimeFilter F_REGISTRO
        {
          get => datos_H_PATRIMONIO.F_REGISTRO;
          set => datos_H_PATRIMONIO.F_REGISTRO = value;
        }
        public ListFilter<DateTime> F_REGISTROs
        {
          get => datos_H_PATRIMONIO.F_REGISTROs;
          set => datos_H_PATRIMONIO.F_REGISTROs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_H_PATRIMONIO.OrderByCriterios; 
            set => datos_H_PATRIMONIO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_H_PATRIMONIO() => datos_H_PATRIMONIO = new dald__l_H_PATRIMONIO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_H_PATRIMONIO.select();
        }

        public void clearOrderBy()
        {
            datos_H_PATRIMONIO.clearOrderBy();
        }

        public void Select()
        {
            datos_H_PATRIMONIO.single_select();
        }

     #endregion

    }
}
