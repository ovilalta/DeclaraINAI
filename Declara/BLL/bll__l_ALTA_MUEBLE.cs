using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_ALTA_MUEBLE : _bllSistema
    {

        internal dald__l_ALTA_MUEBLE datos_ALTA_MUEBLE;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.ALTA_MUEBLE> lista_ALTA_MUEBLE => datos_ALTA_MUEBLE.lista_ALTA_MUEBLEs;

        protected List<MODELDeclara_V2.ALTA_MUEBLE>  base_ALTA_MUEBLEs => datos_ALTA_MUEBLE.base_ALTA_MUEBLEs;

        public StringFilter VID_NOMBRE
        {
          get => datos_ALTA_MUEBLE.VID_NOMBRE;
          set => datos_ALTA_MUEBLE.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_ALTA_MUEBLE.VID_NOMBREs;
          set => datos_ALTA_MUEBLE.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_ALTA_MUEBLE.VID_FECHA;
          set => datos_ALTA_MUEBLE.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_ALTA_MUEBLE.VID_FECHAs;
          set => datos_ALTA_MUEBLE.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_ALTA_MUEBLE.VID_HOMOCLAVE;
          set => datos_ALTA_MUEBLE.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_ALTA_MUEBLE.VID_HOMOCLAVEs;
          set => datos_ALTA_MUEBLE.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_ALTA_MUEBLE.NID_DECLARACION;
          set => datos_ALTA_MUEBLE.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_ALTA_MUEBLE.NID_DECLARACIONs;
          set => datos_ALTA_MUEBLE.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_MUEBLE
        {
          get => datos_ALTA_MUEBLE.NID_MUEBLE;
          set => datos_ALTA_MUEBLE.NID_MUEBLE = value;
        }
        public ListFilter<Int32> NID_MUEBLEs
        {
          get => datos_ALTA_MUEBLE.NID_MUEBLEs;
          set => datos_ALTA_MUEBLE.NID_MUEBLEs = value;
        }

        public IntegerFilter NID_TIPO
        {
          get => datos_ALTA_MUEBLE.NID_TIPO;
          set => datos_ALTA_MUEBLE.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
          get => datos_ALTA_MUEBLE.NID_TIPOs;
          set => datos_ALTA_MUEBLE.NID_TIPOs = value;
        }

        public StringFilter E_ESPECIFICACION
        {
          get => datos_ALTA_MUEBLE.E_ESPECIFICACION;
          set => datos_ALTA_MUEBLE.E_ESPECIFICACION = value;
        }
        public ListFilter<String> E_ESPECIFICACIONs
        {
          get => datos_ALTA_MUEBLE.E_ESPECIFICACIONs;
          set => datos_ALTA_MUEBLE.E_ESPECIFICACIONs = value;
        }

        public DecimalFilter M_VALOR
        {
          get => datos_ALTA_MUEBLE.M_VALOR;
          set => datos_ALTA_MUEBLE.M_VALOR = value;
        }
        public ListFilter<Decimal> M_VALORs
        {
          get => datos_ALTA_MUEBLE.M_VALORs;
          set => datos_ALTA_MUEBLE.M_VALORs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_ALTA_MUEBLE.NID_PATRIMONIO;
          set => datos_ALTA_MUEBLE.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_ALTA_MUEBLE.NID_PATRIMONIOs;
          set => datos_ALTA_MUEBLE.NID_PATRIMONIOs = value;
        }

        public System.Nullable<Boolean> L_CREDITO
        {
          get => datos_ALTA_MUEBLE.L_CREDITO;
          set => datos_ALTA_MUEBLE.L_CREDITO = value;
        }
        public ListFilter<Boolean> L_CREDITOs
        {
          get => datos_ALTA_MUEBLE.L_CREDITOs;
          set => datos_ALTA_MUEBLE.L_CREDITOs = value;
        }

        public DateTimeFilter F_ADQUISICION
        {
          get => datos_ALTA_MUEBLE.F_ADQUISICION;
          set => datos_ALTA_MUEBLE.F_ADQUISICION = value;
        }
        public ListFilter<DateTime> F_ADQUISICIONs
        {
          get => datos_ALTA_MUEBLE.F_ADQUISICIONs;
          set => datos_ALTA_MUEBLE.F_ADQUISICIONs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_ALTA_MUEBLE.OrderByCriterios; 
            set => datos_ALTA_MUEBLE.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_ALTA_MUEBLE() => datos_ALTA_MUEBLE = new dald__l_ALTA_MUEBLE();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_ALTA_MUEBLE.select();
        }

        public void clearOrderBy()
        {
            datos_ALTA_MUEBLE.clearOrderBy();
        }

        public void Select()
        {
            datos_ALTA_MUEBLE.single_select();
        }

     #endregion

    }
}
