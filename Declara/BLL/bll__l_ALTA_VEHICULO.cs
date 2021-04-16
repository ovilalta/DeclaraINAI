using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_ALTA_VEHICULO : _bllSistema
    {

        internal dald__l_ALTA_VEHICULO datos_ALTA_VEHICULO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.ALTA_VEHICULO> lista_ALTA_VEHICULO => datos_ALTA_VEHICULO.lista_ALTA_VEHICULOs;

        protected List<MODELDeclara_V2.ALTA_VEHICULO>  base_ALTA_VEHICULOs => datos_ALTA_VEHICULO.base_ALTA_VEHICULOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_ALTA_VEHICULO.VID_NOMBRE;
          set => datos_ALTA_VEHICULO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_ALTA_VEHICULO.VID_NOMBREs;
          set => datos_ALTA_VEHICULO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_ALTA_VEHICULO.VID_FECHA;
          set => datos_ALTA_VEHICULO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_ALTA_VEHICULO.VID_FECHAs;
          set => datos_ALTA_VEHICULO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_ALTA_VEHICULO.VID_HOMOCLAVE;
          set => datos_ALTA_VEHICULO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_ALTA_VEHICULO.VID_HOMOCLAVEs;
          set => datos_ALTA_VEHICULO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_ALTA_VEHICULO.NID_DECLARACION;
          set => datos_ALTA_VEHICULO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_ALTA_VEHICULO.NID_DECLARACIONs;
          set => datos_ALTA_VEHICULO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_VEHICULO
        {
          get => datos_ALTA_VEHICULO.NID_VEHICULO;
          set => datos_ALTA_VEHICULO.NID_VEHICULO = value;
        }
        public ListFilter<Int32> NID_VEHICULOs
        {
          get => datos_ALTA_VEHICULO.NID_VEHICULOs;
          set => datos_ALTA_VEHICULO.NID_VEHICULOs = value;
        }

        public IntegerFilter NID_MARCA
        {
          get => datos_ALTA_VEHICULO.NID_MARCA;
          set => datos_ALTA_VEHICULO.NID_MARCA = value;
        }
        public ListFilter<Int32> NID_MARCAs
        {
          get => datos_ALTA_VEHICULO.NID_MARCAs;
          set => datos_ALTA_VEHICULO.NID_MARCAs = value;
        }

        public StringFilter C_MODELO
        {
          get => datos_ALTA_VEHICULO.C_MODELO;
          set => datos_ALTA_VEHICULO.C_MODELO = value;
        }
        public ListFilter<String> C_MODELOs
        {
          get => datos_ALTA_VEHICULO.C_MODELOs;
          set => datos_ALTA_VEHICULO.C_MODELOs = value;
        }

        public StringFilter V_DESCRIPCION
        {
          get => datos_ALTA_VEHICULO.V_DESCRIPCION;
          set => datos_ALTA_VEHICULO.V_DESCRIPCION = value;
        }
        public ListFilter<String> V_DESCRIPCIONs
        {
          get => datos_ALTA_VEHICULO.V_DESCRIPCIONs;
          set => datos_ALTA_VEHICULO.V_DESCRIPCIONs = value;
        }

        public DateTimeFilter F_ADQUISICION
        {
          get => datos_ALTA_VEHICULO.F_ADQUISICION;
          set => datos_ALTA_VEHICULO.F_ADQUISICION = value;
        }
        public ListFilter<DateTime> F_ADQUISICIONs
        {
          get => datos_ALTA_VEHICULO.F_ADQUISICIONs;
          set => datos_ALTA_VEHICULO.F_ADQUISICIONs = value;
        }

        public IntegerFilter NID_TIPO_VEHICULO
        {
          get => datos_ALTA_VEHICULO.NID_TIPO_VEHICULO;
          set => datos_ALTA_VEHICULO.NID_TIPO_VEHICULO = value;
        }
        public ListFilter<Int32> NID_TIPO_VEHICULOs
        {
          get => datos_ALTA_VEHICULO.NID_TIPO_VEHICULOs;
          set => datos_ALTA_VEHICULO.NID_TIPO_VEHICULOs = value;
        }

        public IntegerFilter NID_USO
        {
          get => datos_ALTA_VEHICULO.NID_USO;
          set => datos_ALTA_VEHICULO.NID_USO = value;
        }
        public ListFilter<Int32> NID_USOs
        {
          get => datos_ALTA_VEHICULO.NID_USOs;
          set => datos_ALTA_VEHICULO.NID_USOs = value;
        }

        public DecimalFilter M_VALOR_VEHICULO
        {
          get => datos_ALTA_VEHICULO.M_VALOR_VEHICULO;
          set => datos_ALTA_VEHICULO.M_VALOR_VEHICULO = value;
        }
        public ListFilter<Decimal> M_VALOR_VEHICULOs
        {
          get => datos_ALTA_VEHICULO.M_VALOR_VEHICULOs;
          set => datos_ALTA_VEHICULO.M_VALOR_VEHICULOs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_ALTA_VEHICULO.NID_PATRIMONIO;
          set => datos_ALTA_VEHICULO.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_ALTA_VEHICULO.NID_PATRIMONIOs;
          set => datos_ALTA_VEHICULO.NID_PATRIMONIOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_ALTA_VEHICULO.OrderByCriterios; 
            set => datos_ALTA_VEHICULO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_ALTA_VEHICULO() => datos_ALTA_VEHICULO = new dald__l_ALTA_VEHICULO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_ALTA_VEHICULO.select();
        }

        public void clearOrderBy()
        {
            datos_ALTA_VEHICULO.clearOrderBy();
        }

        public void Select()
        {
            datos_ALTA_VEHICULO.single_select();
        }

     #endregion

    }
}
