using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_DECLARACION_REGIMEN_MATRIMONIAL : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_DECLARACION_REGIMEN_MATRIMONIAL datos_DECLARACION_REGIMEN_MATRIMONIAL { get; set; }
        public List<Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL> lista_DECLARACION_REGIMEN_MATRIMONIAL => datos_DECLARACION_REGIMEN_MATRIMONIAL.lista_DECLARACION_REGIMEN_MATRIMONIALs;
        protected List<MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL> base_DECLARACION_REGIMEN_MATRIMONIALs => datos_DECLARACION_REGIMEN_MATRIMONIAL.base_DECLARACION_REGIMEN_MATRIMONIALs;

        public StringFilter VID_NOMBRE
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_NOMBRE;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_NOMBREs;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_FECHA;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_FECHAs;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_HOMOCLAVE;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_HOMOCLAVEs;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_DECLARACION;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_DECLARACIONs;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_REGIMEN
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN = value;
        }
        public ListFilter<Int32> NID_REGIMENs
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMENs;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMENs = value;
        }

        public IntegerFilter NID_REGIMEN_MATRIMONIAL
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL = value;
        }
        public ListFilter<Int32> NID_REGIMEN_MATRIMONIALs
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIALs;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIALs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.OrderByCriterios;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_DECLARACION_REGIMEN_MATRIMONIAL() => datos_DECLARACION_REGIMEN_MATRIMONIAL = new dald__l_DECLARACION_REGIMEN_MATRIMONIAL();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_DECLARACION_REGIMEN_MATRIMONIAL.select();
        }
        public void clearOrderBy()
        {
            datos_DECLARACION_REGIMEN_MATRIMONIAL.clearOrderBy();
        }
        public void single_select()
        {
            datos_DECLARACION_REGIMEN_MATRIMONIAL.single_select();
        }

        #endregion

    }
}
