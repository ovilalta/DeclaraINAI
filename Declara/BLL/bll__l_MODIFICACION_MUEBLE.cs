using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_MUEBLE : _bllSistema
    {

        internal dald__l_MODIFICACION_MUEBLE datos_MODIFICACION_MUEBLE;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_MUEBLE> lista_MODIFICACION_MUEBLE => datos_MODIFICACION_MUEBLE.lista_MODIFICACION_MUEBLEs;

        protected List<MODELDeclara_V2.MODIFICACION_MUEBLE>  base_MODIFICACION_MUEBLEs => datos_MODIFICACION_MUEBLE.base_MODIFICACION_MUEBLEs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_MUEBLE.VID_NOMBRE;
          set => datos_MODIFICACION_MUEBLE.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_MUEBLE.VID_NOMBREs;
          set => datos_MODIFICACION_MUEBLE.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_MUEBLE.VID_FECHA;
          set => datos_MODIFICACION_MUEBLE.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_MUEBLE.VID_FECHAs;
          set => datos_MODIFICACION_MUEBLE.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_MUEBLE.VID_HOMOCLAVE;
          set => datos_MODIFICACION_MUEBLE.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_MUEBLE.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_MUEBLE.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_MUEBLE.NID_DECLARACION;
          set => datos_MODIFICACION_MUEBLE.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_MUEBLE.NID_DECLARACIONs;
          set => datos_MODIFICACION_MUEBLE.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_MODIFICACION_MUEBLE.NID_PATRIMONIO;
          set => datos_MODIFICACION_MUEBLE.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_MODIFICACION_MUEBLE.NID_PATRIMONIOs;
          set => datos_MODIFICACION_MUEBLE.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_TIPO
        {
          get => datos_MODIFICACION_MUEBLE.NID_TIPO;
          set => datos_MODIFICACION_MUEBLE.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
          get => datos_MODIFICACION_MUEBLE.NID_TIPOs;
          set => datos_MODIFICACION_MUEBLE.NID_TIPOs = value;
        }

        public StringFilter E_ESPECIFICACION
        {
          get => datos_MODIFICACION_MUEBLE.E_ESPECIFICACION;
          set => datos_MODIFICACION_MUEBLE.E_ESPECIFICACION = value;
        }
        public ListFilter<String> E_ESPECIFICACIONs
        {
          get => datos_MODIFICACION_MUEBLE.E_ESPECIFICACIONs;
          set => datos_MODIFICACION_MUEBLE.E_ESPECIFICACIONs = value;
        }

        public DecimalFilter M_VALOR
        {
          get => datos_MODIFICACION_MUEBLE.M_VALOR;
          set => datos_MODIFICACION_MUEBLE.M_VALOR = value;
        }
        public ListFilter<Decimal> M_VALORs
        {
          get => datos_MODIFICACION_MUEBLE.M_VALORs;
          set => datos_MODIFICACION_MUEBLE.M_VALORs = value;
        }

        public System.Nullable<Boolean> L_MODIFICADO
        {
          get => datos_MODIFICACION_MUEBLE.L_MODIFICADO;
          set => datos_MODIFICACION_MUEBLE.L_MODIFICADO = value;
        }
        public ListFilter<Boolean> L_MODIFICADOs
        {
          get => datos_MODIFICACION_MUEBLE.L_MODIFICADOs;
          set => datos_MODIFICACION_MUEBLE.L_MODIFICADOs = value;
        }

        public DateTimeFilter F_ADQUISICION
        {
          get => datos_MODIFICACION_MUEBLE.F_ADQUISICION;
          set => datos_MODIFICACION_MUEBLE.F_ADQUISICION = value;
        }
        public ListFilter<DateTime> F_ADQUISICIONs
        {
          get => datos_MODIFICACION_MUEBLE.F_ADQUISICIONs;
          set => datos_MODIFICACION_MUEBLE.F_ADQUISICIONs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_MUEBLE.OrderByCriterios; 
            set => datos_MODIFICACION_MUEBLE.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_MUEBLE() => datos_MODIFICACION_MUEBLE = new dald__l_MODIFICACION_MUEBLE();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_MUEBLE.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_MUEBLE.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_MUEBLE.single_select();
        }

     #endregion

    }
}
