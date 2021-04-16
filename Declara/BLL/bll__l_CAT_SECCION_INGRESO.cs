using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_SECCION_INGRESO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_SECCION_INGRESO datos_CAT_SECCION_INGRESO { get; set; }
        public List<Declara_V2.MODELextended.CAT_SECCION_INGRESO> lista_CAT_SECCION_INGRESO => datos_CAT_SECCION_INGRESO.lista_CAT_SECCION_INGRESOs;
        protected List<MODELDeclara_V2.CAT_SECCION_INGRESO> base_CAT_SECCION_INGRESOs => datos_CAT_SECCION_INGRESO.base_CAT_SECCION_INGRESOs;

        public IntegerFilter NID_SECCION
        {
            get => datos_CAT_SECCION_INGRESO.NID_SECCION;
            set => datos_CAT_SECCION_INGRESO.NID_SECCION = value;
        }
        public ListFilter<Int32> NID_SECCIONs
        {
            get => datos_CAT_SECCION_INGRESO.NID_SECCIONs;
            set => datos_CAT_SECCION_INGRESO.NID_SECCIONs = value;
        }

        public IntegerFilter NID_RUBRO
        {
            get => datos_CAT_SECCION_INGRESO.NID_RUBRO;
            set => datos_CAT_SECCION_INGRESO.NID_RUBRO = value;
        }
        public ListFilter<Int32> NID_RUBROs
        {
            get => datos_CAT_SECCION_INGRESO.NID_RUBROs;
            set => datos_CAT_SECCION_INGRESO.NID_RUBROs = value;
        }

        public StringFilter V_RUBRO
        {
            get => datos_CAT_SECCION_INGRESO.V_RUBRO;
            set => datos_CAT_SECCION_INGRESO.V_RUBRO = value;
        }
        public ListFilter<String> V_RUBROs
        {
            get => datos_CAT_SECCION_INGRESO.V_RUBROs;
            set => datos_CAT_SECCION_INGRESO.V_RUBROs = value;
        }

        public System.Nullable<Boolean> L_VIGENTE
        {
            get => datos_CAT_SECCION_INGRESO.L_VIGENTE;
            set => datos_CAT_SECCION_INGRESO.L_VIGENTE = value;
        }

        public StringFilter CID_TIPO
        {
            get => datos_CAT_SECCION_INGRESO.CID_TIPO;
            set => datos_CAT_SECCION_INGRESO.CID_TIPO = value;
        }
        public ListFilter<String> CID_TIPOs
        {
            get => datos_CAT_SECCION_INGRESO.CID_TIPOs;
            set => datos_CAT_SECCION_INGRESO.CID_TIPOs = value;
        }

        public IntegerFilter NID_RUBRO_SUMA
        {
            get => datos_CAT_SECCION_INGRESO.NID_RUBRO_SUMA;
            set => datos_CAT_SECCION_INGRESO.NID_RUBRO_SUMA = value;
        }
        public ListFilter<Int32> NID_RUBRO_SUMAs
        {
            get => datos_CAT_SECCION_INGRESO.NID_RUBRO_SUMAs;
            set => datos_CAT_SECCION_INGRESO.NID_RUBRO_SUMAs = value;
        }

        public StringFilter C_TITULAR
        {
            get => datos_CAT_SECCION_INGRESO.C_TITULAR;
            set => datos_CAT_SECCION_INGRESO.C_TITULAR = value;
        }
        public ListFilter<String> C_TITULARs
        {
            get => datos_CAT_SECCION_INGRESO.C_TITULARs;
            set => datos_CAT_SECCION_INGRESO.C_TITULARs = value;
        }

        public StringFilter V_CATALOGO
        {
            get => datos_CAT_SECCION_INGRESO.V_CATALOGO;
            set => datos_CAT_SECCION_INGRESO.V_CATALOGO = value;
        }
        public ListFilter<String> V_CATALOGOs
        {
            get => datos_CAT_SECCION_INGRESO.V_CATALOGOs;
            set => datos_CAT_SECCION_INGRESO.V_CATALOGOs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_SECCION_INGRESO.OrderByCriterios;
            set => datos_CAT_SECCION_INGRESO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_SECCION_INGRESO() => datos_CAT_SECCION_INGRESO = new dald__l_CAT_SECCION_INGRESO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_SECCION_INGRESO.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_SECCION_INGRESO.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_SECCION_INGRESO.single_select();
        }

        #endregion

    }
}
