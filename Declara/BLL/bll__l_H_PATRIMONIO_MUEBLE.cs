using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_H_PATRIMONIO_MUEBLE : _bllSistema
    {

        internal dald__l_H_PATRIMONIO_MUEBLE datos_H_PATRIMONIO_MUEBLE;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE> lista_H_PATRIMONIO_MUEBLE => datos_H_PATRIMONIO_MUEBLE.lista_H_PATRIMONIO_MUEBLEs;

        protected List<MODELDeclara_V2.H_PATRIMONIO_MUEBLE>  base_H_PATRIMONIO_MUEBLEs => datos_H_PATRIMONIO_MUEBLE.base_H_PATRIMONIO_MUEBLEs;

        public StringFilter VID_NOMBRE
        {
          get => datos_H_PATRIMONIO_MUEBLE.VID_NOMBRE;
          set => datos_H_PATRIMONIO_MUEBLE.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_H_PATRIMONIO_MUEBLE.VID_NOMBREs;
          set => datos_H_PATRIMONIO_MUEBLE.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_H_PATRIMONIO_MUEBLE.VID_FECHA;
          set => datos_H_PATRIMONIO_MUEBLE.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_H_PATRIMONIO_MUEBLE.VID_FECHAs;
          set => datos_H_PATRIMONIO_MUEBLE.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_H_PATRIMONIO_MUEBLE.VID_HOMOCLAVE;
          set => datos_H_PATRIMONIO_MUEBLE.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_H_PATRIMONIO_MUEBLE.VID_HOMOCLAVEs;
          set => datos_H_PATRIMONIO_MUEBLE.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_H_PATRIMONIO_MUEBLE.NID_PATRIMONIO;
          set => datos_H_PATRIMONIO_MUEBLE.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_H_PATRIMONIO_MUEBLE.NID_PATRIMONIOs;
          set => datos_H_PATRIMONIO_MUEBLE.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_HISTORICO
        {
          get => datos_H_PATRIMONIO_MUEBLE.NID_HISTORICO;
          set => datos_H_PATRIMONIO_MUEBLE.NID_HISTORICO = value;
        }
        public ListFilter<Int32> NID_HISTORICOs
        {
          get => datos_H_PATRIMONIO_MUEBLE.NID_HISTORICOs;
          set => datos_H_PATRIMONIO_MUEBLE.NID_HISTORICOs = value;
        }

        public IntegerFilter NID_TIPO
        {
          get => datos_H_PATRIMONIO_MUEBLE.NID_TIPO;
          set => datos_H_PATRIMONIO_MUEBLE.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
          get => datos_H_PATRIMONIO_MUEBLE.NID_TIPOs;
          set => datos_H_PATRIMONIO_MUEBLE.NID_TIPOs = value;
        }

        public StringFilter E_ESPECIFICACION
        {
          get => datos_H_PATRIMONIO_MUEBLE.E_ESPECIFICACION;
          set => datos_H_PATRIMONIO_MUEBLE.E_ESPECIFICACION = value;
        }
        public ListFilter<String> E_ESPECIFICACIONs
        {
          get => datos_H_PATRIMONIO_MUEBLE.E_ESPECIFICACIONs;
          set => datos_H_PATRIMONIO_MUEBLE.E_ESPECIFICACIONs = value;
        }

        public System.Nullable<Decimal> M_VALOR
        {
          get => datos_H_PATRIMONIO_MUEBLE.M_VALOR;
          set => datos_H_PATRIMONIO_MUEBLE.M_VALOR = value;
        }
        public ListFilter<Decimal> M_VALORs
        {
          get => datos_H_PATRIMONIO_MUEBLE.M_VALORs;
          set => datos_H_PATRIMONIO_MUEBLE.M_VALORs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_H_PATRIMONIO_MUEBLE.OrderByCriterios; 
            set => datos_H_PATRIMONIO_MUEBLE.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_H_PATRIMONIO_MUEBLE() => datos_H_PATRIMONIO_MUEBLE = new dald__l_H_PATRIMONIO_MUEBLE();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_H_PATRIMONIO_MUEBLE.select();
        }

        public void clearOrderBy()
        {
            datos_H_PATRIMONIO_MUEBLE.clearOrderBy();
        }

        public void Select()
        {
            datos_H_PATRIMONIO_MUEBLE.single_select();
        }

     #endregion

    }
}
