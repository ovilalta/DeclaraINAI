using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_ALTA_INMUEBLE : _bllSistema
    {

        internal dald__l_ALTA_INMUEBLE datos_ALTA_INMUEBLE;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.ALTA_INMUEBLE> lista_ALTA_INMUEBLE => datos_ALTA_INMUEBLE.lista_ALTA_INMUEBLEs;

        protected List<MODELDeclara_V2.ALTA_INMUEBLE>  base_ALTA_INMUEBLEs => datos_ALTA_INMUEBLE.base_ALTA_INMUEBLEs;

        public StringFilter VID_NOMBRE
        {
          get => datos_ALTA_INMUEBLE.VID_NOMBRE;
          set => datos_ALTA_INMUEBLE.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_ALTA_INMUEBLE.VID_NOMBREs;
          set => datos_ALTA_INMUEBLE.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_ALTA_INMUEBLE.VID_FECHA;
          set => datos_ALTA_INMUEBLE.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_ALTA_INMUEBLE.VID_FECHAs;
          set => datos_ALTA_INMUEBLE.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_ALTA_INMUEBLE.VID_HOMOCLAVE;
          set => datos_ALTA_INMUEBLE.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_ALTA_INMUEBLE.VID_HOMOCLAVEs;
          set => datos_ALTA_INMUEBLE.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_ALTA_INMUEBLE.NID_DECLARACION;
          set => datos_ALTA_INMUEBLE.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_ALTA_INMUEBLE.NID_DECLARACIONs;
          set => datos_ALTA_INMUEBLE.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_INMUEBLE
        {
          get => datos_ALTA_INMUEBLE.NID_INMUEBLE;
          set => datos_ALTA_INMUEBLE.NID_INMUEBLE = value;
        }
        public ListFilter<Int32> NID_INMUEBLEs
        {
          get => datos_ALTA_INMUEBLE.NID_INMUEBLEs;
          set => datos_ALTA_INMUEBLE.NID_INMUEBLEs = value;
        }

        public IntegerFilter NID_TIPO
        {
          get => datos_ALTA_INMUEBLE.NID_TIPO;
          set => datos_ALTA_INMUEBLE.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
          get => datos_ALTA_INMUEBLE.NID_TIPOs;
          set => datos_ALTA_INMUEBLE.NID_TIPOs = value;
        }

        public DateTimeFilter F_ADQUISICION
        {
          get => datos_ALTA_INMUEBLE.F_ADQUISICION;
          set => datos_ALTA_INMUEBLE.F_ADQUISICION = value;
        }
        public ListFilter<DateTime> F_ADQUISICIONs
        {
          get => datos_ALTA_INMUEBLE.F_ADQUISICIONs;
          set => datos_ALTA_INMUEBLE.F_ADQUISICIONs = value;
        }

        public IntegerFilter NID_USO
        {
          get => datos_ALTA_INMUEBLE.NID_USO;
          set => datos_ALTA_INMUEBLE.NID_USO = value;
        }
        public ListFilter<Int32> NID_USOs
        {
          get => datos_ALTA_INMUEBLE.NID_USOs;
          set => datos_ALTA_INMUEBLE.NID_USOs = value;
        }

        public StringFilter E_UBICACION
        {
          get => datos_ALTA_INMUEBLE.E_UBICACION;
          set => datos_ALTA_INMUEBLE.E_UBICACION = value;
        }
        public ListFilter<String> E_UBICACIONs
        {
          get => datos_ALTA_INMUEBLE.E_UBICACIONs;
          set => datos_ALTA_INMUEBLE.E_UBICACIONs = value;
        }

        public DecimalFilter N_TERRENO
        {
          get => datos_ALTA_INMUEBLE.N_TERRENO;
          set => datos_ALTA_INMUEBLE.N_TERRENO = value;
        }
        public ListFilter<Decimal> N_TERRENOs
        {
          get => datos_ALTA_INMUEBLE.N_TERRENOs;
          set => datos_ALTA_INMUEBLE.N_TERRENOs = value;
        }

        public DecimalFilter N_CONSTRUCCION
        {
          get => datos_ALTA_INMUEBLE.N_CONSTRUCCION;
          set => datos_ALTA_INMUEBLE.N_CONSTRUCCION = value;
        }
        public ListFilter<Decimal> N_CONSTRUCCIONs
        {
          get => datos_ALTA_INMUEBLE.N_CONSTRUCCIONs;
          set => datos_ALTA_INMUEBLE.N_CONSTRUCCIONs = value;
        }

        public DecimalFilter M_VALOR_INMUEBLE
        {
          get => datos_ALTA_INMUEBLE.M_VALOR_INMUEBLE;
          set => datos_ALTA_INMUEBLE.M_VALOR_INMUEBLE = value;
        }
        public ListFilter<Decimal> M_VALOR_INMUEBLEs
        {
          get => datos_ALTA_INMUEBLE.M_VALOR_INMUEBLEs;
          set => datos_ALTA_INMUEBLE.M_VALOR_INMUEBLEs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_ALTA_INMUEBLE.NID_PATRIMONIO;
          set => datos_ALTA_INMUEBLE.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_ALTA_INMUEBLE.NID_PATRIMONIOs;
          set => datos_ALTA_INMUEBLE.NID_PATRIMONIOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_ALTA_INMUEBLE.OrderByCriterios; 
            set => datos_ALTA_INMUEBLE.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_ALTA_INMUEBLE() => datos_ALTA_INMUEBLE = new dald__l_ALTA_INMUEBLE();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_ALTA_INMUEBLE.select();
        }

        public void clearOrderBy()
        {
            datos_ALTA_INMUEBLE.clearOrderBy();
        }

        public void Select()
        {
            datos_ALTA_INMUEBLE.single_select();
        }

     #endregion

    }
}
