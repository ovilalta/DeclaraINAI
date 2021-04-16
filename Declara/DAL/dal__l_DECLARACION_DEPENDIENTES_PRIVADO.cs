using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_DECLARACION_DEPENDIENTES_PRIVADO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO> lista_DECLARACION_DEPENDIENTES_PRIVADOs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO> base_DECLARACION_DEPENDIENTES_PRIVADOs { get; set; }

        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_DEPENDIENTE { get; set; }
        internal ListFilter<Int32> NID_DEPENDIENTEs { get; set; }

        internal StringFilter V_NOMBRE { get; set; }
        internal ListFilter<String> V_NOMBREs { get; set; }

        internal StringFilter V_CARGO { get; set; }
        internal ListFilter<String> V_CARGOs { get; set; }

        internal StringFilter V_RFC { get; set; }
        internal ListFilter<String> V_RFCs { get; set; }

        internal DateTimeFilter F_INGRESO { get; set; }

        internal IntegerFilter NID_SECTOR { get; set; }
        internal ListFilter<Int32> NID_SECTORs { get; set; }

        internal DecimalFilter M_SALARIO_MENSUAL { get; set; }

        internal System.Nullable<Boolean> L_PROVEEDOR { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_DECLARACION_DEPENDIENTES_PRIVADO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_DEPENDIENTEs = new ListFilter<Int32>();
            V_NOMBREs = new ListFilter<String>();
            V_CARGOs = new ListFilter<String>();
            V_RFCs = new ListFilter<String>();
            NID_SECTORs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.DECLARACION_DEPENDIENTES_PRIVADO
                           select p;
        }
        protected void Select()
        {
            query = from qDECLARACION_DEPENDIENTES_PRIVADO in db.DECLARACION_DEPENDIENTES_PRIVADO
                    join qCAT_SECTOR in db.CAT_SECTOR on qDECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR equals qCAT_SECTOR.NID_SECTOR
                    select new Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO
                    {
                        VID_NOMBRE = qDECLARACION_DEPENDIENTES_PRIVADO.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_DEPENDIENTES_PRIVADO.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_DEPENDIENTES_PRIVADO.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_DEPENDIENTES_PRIVADO.NID_DECLARACION,
                        NID_DEPENDIENTE = qDECLARACION_DEPENDIENTES_PRIVADO.NID_DEPENDIENTE,
                        V_NOMBRE = qDECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE,
                        V_CARGO = qDECLARACION_DEPENDIENTES_PRIVADO.V_CARGO,
                        V_RFC = qDECLARACION_DEPENDIENTES_PRIVADO.V_RFC,
                        F_INGRESO = qDECLARACION_DEPENDIENTES_PRIVADO.F_INGRESO,
                        NID_SECTOR = qDECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR,
                        M_SALARIO_MENSUAL = qDECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL,
                        L_PROVEEDOR = qDECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR,
                        V_SECTOR = qCAT_SECTOR.V_SECTOR,
                    };
        }
        protected void Single_Where()
        {
            if (VID_NOMBREs.Values.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.VID_NOMBRE, single_query);

            if (VID_FECHAs.Values.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.VID_FECHA, single_query);

            if (VID_HOMOCLAVEs.Values.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.VID_HOMOCLAVE, single_query);

            if (NID_DECLARACIONs.Values.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.NID_DECLARACION, single_query);

            if (NID_DEPENDIENTEs.Values.Count > 0) single_query = (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DEPENDIENTEs.Values.Contains(p.NID_DEPENDIENTE)) : single_query.Where(p => !NID_DEPENDIENTEs.Values.Contains(p.NID_DEPENDIENTE));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(NID_DEPENDIENTE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.NID_DEPENDIENTE, single_query);

            if (V_NOMBREs.Values.Count > 0) single_query = (V_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_NOMBREs.Values.Contains(p.V_NOMBRE)) : single_query.Where(p => !V_NOMBREs.Values.Contains(p.V_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(V_NOMBRE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.V_NOMBRE, single_query);

            if (V_CARGOs.Values.Count > 0) single_query = (V_CARGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_CARGOs.Values.Contains(p.V_CARGO)) : single_query.Where(p => !V_CARGOs.Values.Contains(p.V_CARGO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(V_CARGO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.V_CARGO, single_query);

            if (V_RFCs.Values.Count > 0) single_query = (V_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_RFCs.Values.Contains(p.V_RFC)) : single_query.Where(p => !V_RFCs.Values.Contains(p.V_RFC));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(V_RFC, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.V_RFC, single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(F_INGRESO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.F_INGRESO, single_query);

            if (NID_SECTORs.Values.Count > 0) single_query = (NID_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_SECTORs.Values.Contains(p.NID_SECTOR)) : single_query.Where(p => !NID_SECTORs.Values.Contains(p.NID_SECTOR));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(NID_SECTOR, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.NID_SECTOR, single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(M_SALARIO_MENSUAL, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.M_SALARIO_MENSUAL, single_query);

            if (L_PROVEEDOR.HasValue) single_query = single_query.Where<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>(p => p.L_PROVEEDOR == L_PROVEEDOR);

        }
        protected void Where()
        {
            if (VID_NOMBREs.Values.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.VID_NOMBRE, query);

            if (VID_FECHAs.Values.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.VID_FECHA, query);

            if (VID_HOMOCLAVEs.Values.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.VID_HOMOCLAVE, query);

            if (NID_DECLARACIONs.Values.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.NID_DECLARACION, query);

            if (NID_DEPENDIENTEs.Values.Count > 0) query = (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DEPENDIENTEs.Values.Contains(p.NID_DEPENDIENTE)) : query.Where(p => !NID_DEPENDIENTEs.Values.Contains(p.NID_DEPENDIENTE));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(NID_DEPENDIENTE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.NID_DEPENDIENTE, query);

            if (V_NOMBREs.Values.Count > 0) query = (V_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_NOMBREs.Values.Contains(p.V_NOMBRE)) : query.Where(p => !V_NOMBREs.Values.Contains(p.V_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(V_NOMBRE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.V_NOMBRE, query);

            if (V_CARGOs.Values.Count > 0) query = (V_CARGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_CARGOs.Values.Contains(p.V_CARGO)) : query.Where(p => !V_CARGOs.Values.Contains(p.V_CARGO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(V_CARGO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.V_CARGO, query);

            if (V_RFCs.Values.Count > 0) query = (V_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_RFCs.Values.Contains(p.V_RFC)) : query.Where(p => !V_RFCs.Values.Contains(p.V_RFC));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(V_RFC, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.V_RFC, query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(F_INGRESO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.F_INGRESO, query);

            if (NID_SECTORs.Values.Count > 0) query = (NID_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_SECTORs.Values.Contains(p.NID_SECTOR)) : query.Where(p => !NID_SECTORs.Values.Contains(p.NID_SECTOR));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(NID_SECTOR, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.NID_SECTOR, query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(M_SALARIO_MENSUAL, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO.Properties.M_SALARIO_MENSUAL, query);

            if (L_PROVEEDOR.HasValue) query = query.Where<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>(p => p.L_PROVEEDOR == L_PROVEEDOR);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_DECLARACION_DEPENDIENTES_PRIVADOs = single_query.AsNoTracking().ToList();
            else
                base_DECLARACION_DEPENDIENTES_PRIVADOs = new List<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_DECLARACION_DEPENDIENTES_PRIVADOs = query.AsNoTracking().ToList();
            else
                lista_DECLARACION_DEPENDIENTES_PRIVADOs = new List<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO> r;
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
