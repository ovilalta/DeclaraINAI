using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_DECLARACION_INGRESOS : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.DECLARACION_INGRESOS> lista_DECLARACION_INGRESOSs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_INGRESOS> base_DECLARACION_INGRESOSs { get; set; }

        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_INGRESO { get; set; }
        internal ListFilter<Int32> NID_INGRESOs { get; set; }

        internal StringFilter V_CONCEPTO { get; set; }
        internal ListFilter<String> V_CONCEPTOs { get; set; }

        internal DecimalFilter M_DECLARANTE { get; set; }

        internal DecimalFilter M_DEPENDIENTE { get; set; }

        internal DecimalFilter M_SUMA { get; set; }

        internal IntegerFilter N_NIVEL { get; set; }
        internal ListFilter<Int32> N_NIVELs { get; set; }

        private List<Order> _OrderByCriterios;
        internal List<Order> OrderByCriterios
        {
            get
            {
                if (_OrderByCriterios == null) _OrderByCriterios = new List<Order>();
                return _OrderByCriterios;
            }
            set { _OrderByCriterios = value; }
        }
        protected IQueryable<Declara_V2.MODELextended.DECLARACION_INGRESOS> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_INGRESOS> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_DECLARACION_INGRESOS()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_INGRESOs = new ListFilter<Int32>();
            V_CONCEPTOs = new ListFilter<String>();
            N_NIVELs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.DECLARACION_INGRESOS
                           select p;
        }
        protected void Select()
        {
            query = from qDECLARACION_INGRESOS in db.DECLARACION_INGRESOS
                    select new Declara_V2.MODELextended.DECLARACION_INGRESOS
                    {
                        VID_NOMBRE = qDECLARACION_INGRESOS.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_INGRESOS.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_INGRESOS.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_INGRESOS.NID_DECLARACION,
                        NID_INGRESO = qDECLARACION_INGRESOS.NID_INGRESO,
                        V_CONCEPTO = qDECLARACION_INGRESOS.V_CONCEPTO,
                        M_DECLARANTE = qDECLARACION_INGRESOS.M_DECLARANTE,
                        M_DEPENDIENTE = qDECLARACION_INGRESOS.M_DEPENDIENTE,
                        M_SUMA = qDECLARACION_INGRESOS.M_SUMA,
                        N_NIVEL = qDECLARACION_INGRESOS.N_NIVEL,
                    };
        }
        protected void Single_Where()
        {
            if (VID_NOMBREs.Values.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_INGRESOS>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.VID_NOMBRE, single_query);

            if (VID_FECHAs.Values.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_INGRESOS>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.VID_FECHA, single_query);

            if (VID_HOMOCLAVEs.Values.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_INGRESOS>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.VID_HOMOCLAVE, single_query);

            if (NID_DECLARACIONs.Values.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_INGRESOS>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.NID_DECLARACION, single_query);

            if (NID_INGRESOs.Values.Count > 0) single_query = (NID_INGRESOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INGRESOs.Values.Contains(p.NID_INGRESO)) : single_query.Where(p => !NID_INGRESOs.Values.Contains(p.NID_INGRESO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_INGRESOS>(NID_INGRESO, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.NID_INGRESO, single_query);

            if (V_CONCEPTOs.Values.Count > 0) single_query = (V_CONCEPTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_CONCEPTOs.Values.Contains(p.V_CONCEPTO)) : single_query.Where(p => !V_CONCEPTOs.Values.Contains(p.V_CONCEPTO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_INGRESOS>(V_CONCEPTO, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.V_CONCEPTO, single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.DECLARACION_INGRESOS>(M_DECLARANTE, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.M_DECLARANTE, single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.DECLARACION_INGRESOS>(M_DEPENDIENTE, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.M_DEPENDIENTE, single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.DECLARACION_INGRESOS>(M_SUMA, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.M_SUMA, single_query);

            if (N_NIVELs.Values.Count > 0) single_query = (N_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => N_NIVELs.Values.Contains(p.N_NIVEL)) : single_query.Where(p => !N_NIVELs.Values.Contains(p.N_NIVEL));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_INGRESOS>(N_NIVEL, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.N_NIVEL, single_query);

        }
        protected void Where()
        {
            if (VID_NOMBREs.Values.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_INGRESOS>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.VID_NOMBRE, query);

            if (VID_FECHAs.Values.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_INGRESOS>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.VID_FECHA, query);

            if (VID_HOMOCLAVEs.Values.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_INGRESOS>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.VID_HOMOCLAVE, query);

            if (NID_DECLARACIONs.Values.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_INGRESOS>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.NID_DECLARACION, query);

            if (NID_INGRESOs.Values.Count > 0) query = (NID_INGRESOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INGRESOs.Values.Contains(p.NID_INGRESO)) : query.Where(p => !NID_INGRESOs.Values.Contains(p.NID_INGRESO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_INGRESOS>(NID_INGRESO, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.NID_INGRESO, query);

            if (V_CONCEPTOs.Values.Count > 0) query = (V_CONCEPTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_CONCEPTOs.Values.Contains(p.V_CONCEPTO)) : query.Where(p => !V_CONCEPTOs.Values.Contains(p.V_CONCEPTO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_INGRESOS>(V_CONCEPTO, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.V_CONCEPTO, query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.DECLARACION_INGRESOS>(M_DECLARANTE, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.M_DECLARANTE, query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.DECLARACION_INGRESOS>(M_DEPENDIENTE, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.M_DEPENDIENTE, query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.DECLARACION_INGRESOS>(M_SUMA, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.M_SUMA, query);

            if (N_NIVELs.Values.Count > 0) query = (N_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => N_NIVELs.Values.Contains(p.N_NIVEL)) : query.Where(p => !N_NIVELs.Values.Contains(p.N_NIVEL));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_INGRESOS>(N_NIVEL, Declara_V2.MODELextended.DECLARACION_INGRESOS.Properties.N_NIVEL, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_DECLARACION_INGRESOSs = single_query.AsNoTracking().ToList();
            else
                base_DECLARACION_INGRESOSs = new List<MODELDeclara_V2.DECLARACION_INGRESOS>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_DECLARACION_INGRESOSs = query.AsNoTracking().ToList();
            else
                lista_DECLARACION_INGRESOSs = new List<Declara_V2.MODELextended.DECLARACION_INGRESOS>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_INGRESOS> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x < OrderByCriterios.Count(); x++)
                {
                    if (OrderByCriterios[x].OrderDirection == Order.OrderDirections.asc)
                        r.ThenBy(OrderByCriterios[x].Field.ToString());
                    else
                        r.ThenByDescending(OrderByCriterios[x].Field.ToString());
                }
                single_query = r;
            }
        }
        internal void orderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_INGRESOS> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x < OrderByCriterios.Count(); x++)
                {
                    if (OrderByCriterios[x].OrderDirection == Order.OrderDirections.asc)
                        r.ThenBy(OrderByCriterios[x].Field.ToString());
                    else
                        r.ThenByDescending(OrderByCriterios[x].Field.ToString());
                }
                query = r;
            }
        }
        internal void clearOrderBy()
        {
            _OrderByCriterios = null;
        }

        #endregion

    }
}
