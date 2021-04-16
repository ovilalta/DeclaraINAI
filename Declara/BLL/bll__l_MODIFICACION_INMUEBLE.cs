using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_INMUEBLE : _bllSistema
    {

        internal dald__l_MODIFICACION_INMUEBLE datos_MODIFICACION_INMUEBLE;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_INMUEBLE> lista_MODIFICACION_INMUEBLE => datos_MODIFICACION_INMUEBLE.lista_MODIFICACION_INMUEBLEs;

        protected List<MODELDeclara_V2.MODIFICACION_INMUEBLE>  base_MODIFICACION_INMUEBLEs => datos_MODIFICACION_INMUEBLE.base_MODIFICACION_INMUEBLEs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_INMUEBLE.VID_NOMBRE;
          set => datos_MODIFICACION_INMUEBLE.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_INMUEBLE.VID_NOMBREs;
          set => datos_MODIFICACION_INMUEBLE.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_INMUEBLE.VID_FECHA;
          set => datos_MODIFICACION_INMUEBLE.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_INMUEBLE.VID_FECHAs;
          set => datos_MODIFICACION_INMUEBLE.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_INMUEBLE.VID_HOMOCLAVE;
          set => datos_MODIFICACION_INMUEBLE.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_INMUEBLE.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_INMUEBLE.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_INMUEBLE.NID_DECLARACION;
          set => datos_MODIFICACION_INMUEBLE.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_INMUEBLE.NID_DECLARACIONs;
          set => datos_MODIFICACION_INMUEBLE.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_MODIFICACION_INMUEBLE.NID_PATRIMONIO;
          set => datos_MODIFICACION_INMUEBLE.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_MODIFICACION_INMUEBLE.NID_PATRIMONIOs;
          set => datos_MODIFICACION_INMUEBLE.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_TIPO
        {
          get => datos_MODIFICACION_INMUEBLE.NID_TIPO;
          set => datos_MODIFICACION_INMUEBLE.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
          get => datos_MODIFICACION_INMUEBLE.NID_TIPOs;
          set => datos_MODIFICACION_INMUEBLE.NID_TIPOs = value;
        }

        public DateTimeFilter F_ADQUISICION
        {
          get => datos_MODIFICACION_INMUEBLE.F_ADQUISICION;
          set => datos_MODIFICACION_INMUEBLE.F_ADQUISICION = value;
        }
        public ListFilter<DateTime> F_ADQUISICIONs
        {
          get => datos_MODIFICACION_INMUEBLE.F_ADQUISICIONs;
          set => datos_MODIFICACION_INMUEBLE.F_ADQUISICIONs = value;
        }

        public IntegerFilter NID_USO
        {
          get => datos_MODIFICACION_INMUEBLE.NID_USO;
          set => datos_MODIFICACION_INMUEBLE.NID_USO = value;
        }
        public ListFilter<Int32> NID_USOs
        {
          get => datos_MODIFICACION_INMUEBLE.NID_USOs;
          set => datos_MODIFICACION_INMUEBLE.NID_USOs = value;
        }

        public StringFilter E_UBICACION
        {
          get => datos_MODIFICACION_INMUEBLE.E_UBICACION;
          set => datos_MODIFICACION_INMUEBLE.E_UBICACION = value;
        }
        public ListFilter<String> E_UBICACIONs
        {
          get => datos_MODIFICACION_INMUEBLE.E_UBICACIONs;
          set => datos_MODIFICACION_INMUEBLE.E_UBICACIONs = value;
        }

        public DecimalFilter N_TERRENO
        {
          get => datos_MODIFICACION_INMUEBLE.N_TERRENO;
          set => datos_MODIFICACION_INMUEBLE.N_TERRENO = value;
        }
        public ListFilter<Decimal> N_TERRENOs
        {
          get => datos_MODIFICACION_INMUEBLE.N_TERRENOs;
          set => datos_MODIFICACION_INMUEBLE.N_TERRENOs = value;
        }

        public DecimalFilter N_CONSTRUCCION
        {
          get => datos_MODIFICACION_INMUEBLE.N_CONSTRUCCION;
          set => datos_MODIFICACION_INMUEBLE.N_CONSTRUCCION = value;
        }
        public ListFilter<Decimal> N_CONSTRUCCIONs
        {
          get => datos_MODIFICACION_INMUEBLE.N_CONSTRUCCIONs;
          set => datos_MODIFICACION_INMUEBLE.N_CONSTRUCCIONs = value;
        }

        public DecimalFilter M_VALOR_INMUEBLE
        {
          get => datos_MODIFICACION_INMUEBLE.M_VALOR_INMUEBLE;
          set => datos_MODIFICACION_INMUEBLE.M_VALOR_INMUEBLE = value;
        }
        public ListFilter<Decimal> M_VALOR_INMUEBLEs
        {
          get => datos_MODIFICACION_INMUEBLE.M_VALOR_INMUEBLEs;
          set => datos_MODIFICACION_INMUEBLE.M_VALOR_INMUEBLEs = value;
        }

        public System.Nullable<Boolean> L_MODIFICADO
        {
          get => datos_MODIFICACION_INMUEBLE.L_MODIFICADO;
          set => datos_MODIFICACION_INMUEBLE.L_MODIFICADO = value;
        }
        public ListFilter<Boolean> L_MODIFICADOs
        {
          get => datos_MODIFICACION_INMUEBLE.L_MODIFICADOs;
          set => datos_MODIFICACION_INMUEBLE.L_MODIFICADOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_INMUEBLE.OrderByCriterios; 
            set => datos_MODIFICACION_INMUEBLE.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_INMUEBLE() => datos_MODIFICACION_INMUEBLE = new dald__l_MODIFICACION_INMUEBLE();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_INMUEBLE.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_INMUEBLE.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_INMUEBLE.single_select();
        }

     #endregion

    }
}
