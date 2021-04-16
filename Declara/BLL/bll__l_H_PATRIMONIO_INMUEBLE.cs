using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_H_PATRIMONIO_INMUEBLE : _bllSistema
    {

        internal dald__l_H_PATRIMONIO_INMUEBLE datos_H_PATRIMONIO_INMUEBLE;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.H_PATRIMONIO_INMUEBLE> lista_H_PATRIMONIO_INMUEBLE => datos_H_PATRIMONIO_INMUEBLE.lista_H_PATRIMONIO_INMUEBLEs;

        protected List<MODELDeclara_V2.H_PATRIMONIO_INMUEBLE>  base_H_PATRIMONIO_INMUEBLEs => datos_H_PATRIMONIO_INMUEBLE.base_H_PATRIMONIO_INMUEBLEs;

        public StringFilter VID_NOMBRE
        {
          get => datos_H_PATRIMONIO_INMUEBLE.VID_NOMBRE;
          set => datos_H_PATRIMONIO_INMUEBLE.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.VID_NOMBREs;
          set => datos_H_PATRIMONIO_INMUEBLE.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_H_PATRIMONIO_INMUEBLE.VID_FECHA;
          set => datos_H_PATRIMONIO_INMUEBLE.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.VID_FECHAs;
          set => datos_H_PATRIMONIO_INMUEBLE.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_H_PATRIMONIO_INMUEBLE.VID_HOMOCLAVE;
          set => datos_H_PATRIMONIO_INMUEBLE.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.VID_HOMOCLAVEs;
          set => datos_H_PATRIMONIO_INMUEBLE.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_H_PATRIMONIO_INMUEBLE.NID_PATRIMONIO;
          set => datos_H_PATRIMONIO_INMUEBLE.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.NID_PATRIMONIOs;
          set => datos_H_PATRIMONIO_INMUEBLE.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_HISTORICO
        {
          get => datos_H_PATRIMONIO_INMUEBLE.NID_HISTORICO;
          set => datos_H_PATRIMONIO_INMUEBLE.NID_HISTORICO = value;
        }
        public ListFilter<Int32> NID_HISTORICOs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.NID_HISTORICOs;
          set => datos_H_PATRIMONIO_INMUEBLE.NID_HISTORICOs = value;
        }

        public IntegerFilter NID_TIPO
        {
          get => datos_H_PATRIMONIO_INMUEBLE.NID_TIPO;
          set => datos_H_PATRIMONIO_INMUEBLE.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.NID_TIPOs;
          set => datos_H_PATRIMONIO_INMUEBLE.NID_TIPOs = value;
        }

        public DateTimeFilter F_ADQUISICION
        {
          get => datos_H_PATRIMONIO_INMUEBLE.F_ADQUISICION;
          set => datos_H_PATRIMONIO_INMUEBLE.F_ADQUISICION = value;
        }
        public ListFilter<DateTime> F_ADQUISICIONs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.F_ADQUISICIONs;
          set => datos_H_PATRIMONIO_INMUEBLE.F_ADQUISICIONs = value;
        }

        public IntegerFilter NID_USO
        {
          get => datos_H_PATRIMONIO_INMUEBLE.NID_USO;
          set => datos_H_PATRIMONIO_INMUEBLE.NID_USO = value;
        }
        public ListFilter<Int32> NID_USOs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.NID_USOs;
          set => datos_H_PATRIMONIO_INMUEBLE.NID_USOs = value;
        }

        public StringFilter E_UBICACION
        {
          get => datos_H_PATRIMONIO_INMUEBLE.E_UBICACION;
          set => datos_H_PATRIMONIO_INMUEBLE.E_UBICACION = value;
        }
        public ListFilter<String> E_UBICACIONs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.E_UBICACIONs;
          set => datos_H_PATRIMONIO_INMUEBLE.E_UBICACIONs = value;
        }

        public DecimalFilter N_TERRENO
        {
          get => datos_H_PATRIMONIO_INMUEBLE.N_TERRENO;
          set => datos_H_PATRIMONIO_INMUEBLE.N_TERRENO = value;
        }
        public ListFilter<Decimal> N_TERRENOs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.N_TERRENOs;
          set => datos_H_PATRIMONIO_INMUEBLE.N_TERRENOs = value;
        }

        public DecimalFilter N_CONSTRUCCION
        {
          get => datos_H_PATRIMONIO_INMUEBLE.N_CONSTRUCCION;
          set => datos_H_PATRIMONIO_INMUEBLE.N_CONSTRUCCION = value;
        }
        public ListFilter<Decimal> N_CONSTRUCCIONs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.N_CONSTRUCCIONs;
          set => datos_H_PATRIMONIO_INMUEBLE.N_CONSTRUCCIONs = value;
        }

        public DecimalFilter M_VALOR_INMUEBLE
        {
          get => datos_H_PATRIMONIO_INMUEBLE.M_VALOR_INMUEBLE;
          set => datos_H_PATRIMONIO_INMUEBLE.M_VALOR_INMUEBLE = value;
        }
        public ListFilter<Decimal> M_VALOR_INMUEBLEs
        {
          get => datos_H_PATRIMONIO_INMUEBLE.M_VALOR_INMUEBLEs;
          set => datos_H_PATRIMONIO_INMUEBLE.M_VALOR_INMUEBLEs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_H_PATRIMONIO_INMUEBLE.OrderByCriterios; 
            set => datos_H_PATRIMONIO_INMUEBLE.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_H_PATRIMONIO_INMUEBLE() => datos_H_PATRIMONIO_INMUEBLE = new dald__l_H_PATRIMONIO_INMUEBLE();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_H_PATRIMONIO_INMUEBLE.select();
        }

        public void clearOrderBy()
        {
            datos_H_PATRIMONIO_INMUEBLE.clearOrderBy();
        }

        public void Select()
        {
            datos_H_PATRIMONIO_INMUEBLE.single_select();
        }

     #endregion

    }
}
