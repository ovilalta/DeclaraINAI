using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_ALTA_INMUEBLE_COPROPIETARIO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO> lista_ALTA_INMUEBLE_COPROPIETARIOs { get; set; }
        internal List<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO> base_ALTA_INMUEBLE_COPROPIETARIOs { get; set; }

        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_INMUEBLE { get; set; }
        internal ListFilter<Int32> NID_INMUEBLEs { get; set; }

        internal IntegerFilter NID_COPROPIETARIO { get; set; }
        internal ListFilter<Int32> NID_COPROPIETARIOs { get; set; }

        internal StringFilter CID_TIPO_PERSONA { get; set; }
        internal ListFilter<String> CID_TIPO_PERSONAs { get; set; }

        internal StringFilter V_NOMBRE { get; set; }
        internal ListFilter<String> V_NOMBREs { get; set; }

        internal StringFilter V_RFC { get; set; }
        internal ListFilter<String> V_RFCs { get; set; }

        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

        internal StringFilter CID_ENTIDAD_FEDERATIVA { get; set; }
        internal ListFilter<String> CID_ENTIDAD_FEDERATIVAs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_ALTA_INMUEBLE_COPROPIETARIO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_INMUEBLEs = new ListFilter<Int32>();
            NID_COPROPIETARIOs = new ListFilter<Int32>();
            CID_TIPO_PERSONAs = new ListFilter<String>();
            V_NOMBREs = new ListFilter<String>();
            V_RFCs = new ListFilter<String>();
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.ALTA_INMUEBLE_COPROPIETARIO
                           select p;
        }
        protected void Select()
        {
            query = from qALTA_INMUEBLE_COPROPIETARIO in db.ALTA_INMUEBLE_COPROPIETARIO
                    select new Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO
                    {
                        VID_NOMBRE = qALTA_INMUEBLE_COPROPIETARIO.VID_NOMBRE,
                        VID_FECHA = qALTA_INMUEBLE_COPROPIETARIO.VID_FECHA,
                        VID_HOMOCLAVE = qALTA_INMUEBLE_COPROPIETARIO.VID_HOMOCLAVE,
                        NID_DECLARACION = qALTA_INMUEBLE_COPROPIETARIO.NID_DECLARACION,
                        NID_INMUEBLE = qALTA_INMUEBLE_COPROPIETARIO.NID_INMUEBLE,
                        NID_COPROPIETARIO = qALTA_INMUEBLE_COPROPIETARIO.NID_COPROPIETARIO,
                        CID_TIPO_PERSONA = qALTA_INMUEBLE_COPROPIETARIO.CID_TIPO_PERSONA,
                        V_NOMBRE = qALTA_INMUEBLE_COPROPIETARIO.V_NOMBRE,
                        V_RFC = qALTA_INMUEBLE_COPROPIETARIO.V_RFC,
                    };
        }
        protected void Single_Where()
        {
            if (VID_NOMBREs.Values.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.VID_NOMBRE, single_query);

            if (VID_FECHAs.Values.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO>(VID_FECHA, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.VID_FECHA, single_query);

            if (VID_HOMOCLAVEs.Values.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.VID_HOMOCLAVE, single_query);

            if (NID_DECLARACIONs.Values.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.NID_DECLARACION, single_query);

            if (NID_INMUEBLEs.Values.Count > 0) single_query = (NID_INMUEBLEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INMUEBLEs.Values.Contains(p.NID_INMUEBLE)) : single_query.Where(p => !NID_INMUEBLEs.Values.Contains(p.NID_INMUEBLE));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO>(NID_INMUEBLE, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.NID_INMUEBLE, single_query);

            if (NID_COPROPIETARIOs.Values.Count > 0) single_query = (NID_COPROPIETARIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_COPROPIETARIOs.Values.Contains(p.NID_COPROPIETARIO)) : single_query.Where(p => !NID_COPROPIETARIOs.Values.Contains(p.NID_COPROPIETARIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO>(NID_COPROPIETARIO, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.NID_COPROPIETARIO, single_query);

            if (CID_TIPO_PERSONAs.Values.Count > 0) single_query = (CID_TIPO_PERSONAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_TIPO_PERSONAs.Values.Contains(p.CID_TIPO_PERSONA)) : single_query.Where(p => !CID_TIPO_PERSONAs.Values.Contains(p.CID_TIPO_PERSONA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO>(CID_TIPO_PERSONA, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.CID_TIPO_PERSONA, single_query);

            if (V_NOMBREs.Values.Count > 0) single_query = (V_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_NOMBREs.Values.Contains(p.V_NOMBRE)) : single_query.Where(p => !V_NOMBREs.Values.Contains(p.V_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO>(V_NOMBRE, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.V_NOMBRE, single_query);

            if (V_RFCs.Values.Count > 0) single_query = (V_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_RFCs.Values.Contains(p.V_RFC)) : single_query.Where(p => !V_RFCs.Values.Contains(p.V_RFC));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO>(V_RFC, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.V_RFC, single_query);

        }
        protected void Where()
        {
            if (VID_NOMBREs.Values.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.VID_NOMBRE, query);

            if (VID_FECHAs.Values.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO>(VID_FECHA, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.VID_FECHA, query);

            if (VID_HOMOCLAVEs.Values.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.VID_HOMOCLAVE, query);

            if (NID_DECLARACIONs.Values.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.NID_DECLARACION, query);

            if (NID_INMUEBLEs.Values.Count > 0) query = (NID_INMUEBLEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INMUEBLEs.Values.Contains(p.NID_INMUEBLE)) : query.Where(p => !NID_INMUEBLEs.Values.Contains(p.NID_INMUEBLE));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO>(NID_INMUEBLE, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.NID_INMUEBLE, query);

            if (NID_COPROPIETARIOs.Values.Count > 0) query = (NID_COPROPIETARIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_COPROPIETARIOs.Values.Contains(p.NID_COPROPIETARIO)) : query.Where(p => !NID_COPROPIETARIOs.Values.Contains(p.NID_COPROPIETARIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO>(NID_COPROPIETARIO, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.NID_COPROPIETARIO, query);

            if (CID_TIPO_PERSONAs.Values.Count > 0) query = (CID_TIPO_PERSONAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_TIPO_PERSONAs.Values.Contains(p.CID_TIPO_PERSONA)) : query.Where(p => !CID_TIPO_PERSONAs.Values.Contains(p.CID_TIPO_PERSONA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO>(CID_TIPO_PERSONA, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.CID_TIPO_PERSONA, query);

            if (V_NOMBREs.Values.Count > 0) query = (V_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_NOMBREs.Values.Contains(p.V_NOMBRE)) : query.Where(p => !V_NOMBREs.Values.Contains(p.V_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO>(V_NOMBRE, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.V_NOMBRE, query);

            if (V_RFCs.Values.Count > 0) query = (V_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_RFCs.Values.Contains(p.V_RFC)) : query.Where(p => !V_RFCs.Values.Contains(p.V_RFC));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO>(V_RFC, Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO.Properties.V_RFC, query);
        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_ALTA_INMUEBLE_COPROPIETARIOs = single_query.AsNoTracking().ToList();
            else
                base_ALTA_INMUEBLE_COPROPIETARIOs = new List<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_ALTA_INMUEBLE_COPROPIETARIOs = query.AsNoTracking().ToList();
            else
                lista_ALTA_INMUEBLE_COPROPIETARIOs = new List<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO> r;
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
