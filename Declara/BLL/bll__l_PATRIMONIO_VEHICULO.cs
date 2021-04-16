using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_PATRIMONIO_VEHICULO : _bllSistema
    {

        internal dald__l_PATRIMONIO_VEHICULO datos_PATRIMONIO_VEHICULO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.PATRIMONIO_VEHICULO> lista_PATRIMONIO_VEHICULO => datos_PATRIMONIO_VEHICULO.lista_PATRIMONIO_VEHICULOs;

        protected List<MODELDeclara_V2.PATRIMONIO_VEHICULO>  base_PATRIMONIO_VEHICULOs => datos_PATRIMONIO_VEHICULO.base_PATRIMONIO_VEHICULOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_PATRIMONIO_VEHICULO.VID_NOMBRE;
          set => datos_PATRIMONIO_VEHICULO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_PATRIMONIO_VEHICULO.VID_NOMBREs;
          set => datos_PATRIMONIO_VEHICULO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_PATRIMONIO_VEHICULO.VID_FECHA;
          set => datos_PATRIMONIO_VEHICULO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_PATRIMONIO_VEHICULO.VID_FECHAs;
          set => datos_PATRIMONIO_VEHICULO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_PATRIMONIO_VEHICULO.VID_HOMOCLAVE;
          set => datos_PATRIMONIO_VEHICULO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_PATRIMONIO_VEHICULO.VID_HOMOCLAVEs;
          set => datos_PATRIMONIO_VEHICULO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_PATRIMONIO_VEHICULO.NID_PATRIMONIO;
          set => datos_PATRIMONIO_VEHICULO.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_PATRIMONIO_VEHICULO.NID_PATRIMONIOs;
          set => datos_PATRIMONIO_VEHICULO.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_MARCA
        {
          get => datos_PATRIMONIO_VEHICULO.NID_MARCA;
          set => datos_PATRIMONIO_VEHICULO.NID_MARCA = value;
        }
        public ListFilter<Int32> NID_MARCAs
        {
          get => datos_PATRIMONIO_VEHICULO.NID_MARCAs;
          set => datos_PATRIMONIO_VEHICULO.NID_MARCAs = value;
        }

        public StringFilter C_MODELO
        {
          get => datos_PATRIMONIO_VEHICULO.C_MODELO;
          set => datos_PATRIMONIO_VEHICULO.C_MODELO = value;
        }
        public ListFilter<String> C_MODELOs
        {
          get => datos_PATRIMONIO_VEHICULO.C_MODELOs;
          set => datos_PATRIMONIO_VEHICULO.C_MODELOs = value;
        }

        public StringFilter V_DESCRIPCION
        {
          get => datos_PATRIMONIO_VEHICULO.V_DESCRIPCION;
          set => datos_PATRIMONIO_VEHICULO.V_DESCRIPCION = value;
        }
        public ListFilter<String> V_DESCRIPCIONs
        {
          get => datos_PATRIMONIO_VEHICULO.V_DESCRIPCIONs;
          set => datos_PATRIMONIO_VEHICULO.V_DESCRIPCIONs = value;
        }

        public DateTimeFilter F_ADQUISICION
        {
          get => datos_PATRIMONIO_VEHICULO.F_ADQUISICION;
          set => datos_PATRIMONIO_VEHICULO.F_ADQUISICION = value;
        }
        public ListFilter<DateTime> F_ADQUISICIONs
        {
          get => datos_PATRIMONIO_VEHICULO.F_ADQUISICIONs;
          set => datos_PATRIMONIO_VEHICULO.F_ADQUISICIONs = value;
        }

        public IntegerFilter NID_USO
        {
          get => datos_PATRIMONIO_VEHICULO.NID_USO;
          set => datos_PATRIMONIO_VEHICULO.NID_USO = value;
        }
        public ListFilter<Int32> NID_USOs
        {
          get => datos_PATRIMONIO_VEHICULO.NID_USOs;
          set => datos_PATRIMONIO_VEHICULO.NID_USOs = value;
        }

        public DecimalFilter M_VALOR_VEHICULO
        {
          get => datos_PATRIMONIO_VEHICULO.M_VALOR_VEHICULO;
          set => datos_PATRIMONIO_VEHICULO.M_VALOR_VEHICULO = value;
        }
        public ListFilter<Decimal> M_VALOR_VEHICULOs
        {
          get => datos_PATRIMONIO_VEHICULO.M_VALOR_VEHICULOs;
          set => datos_PATRIMONIO_VEHICULO.M_VALOR_VEHICULOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_PATRIMONIO_VEHICULO.OrderByCriterios; 
            set => datos_PATRIMONIO_VEHICULO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_PATRIMONIO_VEHICULO() => datos_PATRIMONIO_VEHICULO = new dald__l_PATRIMONIO_VEHICULO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_PATRIMONIO_VEHICULO.select();
        }

        public void clearOrderBy()
        {
            datos_PATRIMONIO_VEHICULO.clearOrderBy();
        }

        public void Select()
        {
            datos_PATRIMONIO_VEHICULO.single_select();
        }

     #endregion

    }
}
