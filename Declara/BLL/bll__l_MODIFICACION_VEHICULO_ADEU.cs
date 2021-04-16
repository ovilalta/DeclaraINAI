using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_VEHICULO_ADEU : _bllSistema
    {

        internal dald__l_MODIFICACION_VEHICULO_ADEU datos_MODIFICACION_VEHICULO_ADEU;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU> lista_MODIFICACION_VEHICULO_ADEU => datos_MODIFICACION_VEHICULO_ADEU.lista_MODIFICACION_VEHICULO_ADEUs;

        protected List<MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU>  base_MODIFICACION_VEHICULO_ADEUs => datos_MODIFICACION_VEHICULO_ADEU.base_MODIFICACION_VEHICULO_ADEUs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.VID_NOMBRE;
          set => datos_MODIFICACION_VEHICULO_ADEU.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.VID_NOMBREs;
          set => datos_MODIFICACION_VEHICULO_ADEU.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.VID_FECHA;
          set => datos_MODIFICACION_VEHICULO_ADEU.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.VID_FECHAs;
          set => datos_MODIFICACION_VEHICULO_ADEU.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.VID_HOMOCLAVE;
          set => datos_MODIFICACION_VEHICULO_ADEU.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_VEHICULO_ADEU.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.NID_DECLARACION;
          set => datos_MODIFICACION_VEHICULO_ADEU.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.NID_DECLARACIONs;
          set => datos_MODIFICACION_VEHICULO_ADEU.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.NID_PATRIMONIO;
          set => datos_MODIFICACION_VEHICULO_ADEU.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.NID_PATRIMONIOs;
          set => datos_MODIFICACION_VEHICULO_ADEU.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_PATRIMONIO_ADEUDO
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.NID_PATRIMONIO_ADEUDO;
          set => datos_MODIFICACION_VEHICULO_ADEU.NID_PATRIMONIO_ADEUDO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIO_ADEUDOs
        {
          get => datos_MODIFICACION_VEHICULO_ADEU.NID_PATRIMONIO_ADEUDOs;
          set => datos_MODIFICACION_VEHICULO_ADEU.NID_PATRIMONIO_ADEUDOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_VEHICULO_ADEU.OrderByCriterios; 
            set => datos_MODIFICACION_VEHICULO_ADEU.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_VEHICULO_ADEU() => datos_MODIFICACION_VEHICULO_ADEU = new dald__l_MODIFICACION_VEHICULO_ADEU();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_VEHICULO_ADEU.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_VEHICULO_ADEU.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_VEHICULO_ADEU.single_select();
        }

     #endregion

    }
}
