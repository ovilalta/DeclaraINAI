using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_DECLARACION_REGIMEN_MATRIMONIAL : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL> lista_DECLARACION_REGIMEN_MATRIMONIALs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL> base_DECLARACION_REGIMEN_MATRIMONIALs { get; set; }

        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_REGIMEN { get; set; }
        internal ListFilter<Int32> NID_REGIMENs { get; set; }

        internal IntegerFilter NID_REGIMEN_MATRIMONIAL { get; set; }
        internal ListFilter<Int32> NID_REGIMEN_MATRIMONIALs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_DECLARACION_REGIMEN_MATRIMONIAL()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_REGIMENs = new ListFilter<Int32>();
            NID_REGIMEN_MATRIMONIALs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.DECLARACION_REGIMEN_MATRIMONIAL
                           select p;
        }
        protected void Select()
        {
            query = from qDECLARACION_REGIMEN_MATRIMONIAL in db.DECLARACION_REGIMEN_MATRIMONIAL
                    join qCAT_REGIMEN_MATRIMONIAL in db.CAT_REGIMEN_MATRIMONIAL on qDECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL equals qCAT_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL
                    select new Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL
                    {
                        VID_NOMBRE = qDECLARACION_REGIMEN_MATRIMONIAL.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_REGIMEN_MATRIMONIAL.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_REGIMEN_MATRIMONIAL.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_REGIMEN_MATRIMONIAL.NID_DECLARACION,
                        NID_REGIMEN = qDECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN,
                        NID_REGIMEN_MATRIMONIAL = qDECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL,
                        V_REGIMEN_MATRIMONIAL = qCAT_REGIMEN_MATRIMONIAL.V_REGIMEN_MATRIMONIAL,
                    };
        }
        protected void Single_Where()
        {
            if (VID_NOMBREs.Values.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.VID_NOMBRE, single_query);

            if (VID_FECHAs.Values.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.VID_FECHA, single_query);

            if (VID_HOMOCLAVEs.Values.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.VID_HOMOCLAVE, single_query);

            if (NID_DECLARACIONs.Values.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.NID_DECLARACION, single_query);

            //if (NID_REGIMENs.Values.Count > 0) single_query = (NID_REGIMENs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_REGIMENs.Values.Contains(p.NID_REGIMEN)) : single_query.Where(p => !NID_REGIMENs.Values.Contains(p.NID_REGIMEN));
            //single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL>(NID_REGIMEN, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.NID_REGIMEN, single_query);

            if (NID_REGIMEN_MATRIMONIALs.Values.Count > 0) single_query = (NID_REGIMEN_MATRIMONIALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_REGIMEN_MATRIMONIALs.Values.Contains(p.NID_REGIMEN_MATRIMONIAL)) : single_query.Where(p => !NID_REGIMEN_MATRIMONIALs.Values.Contains(p.NID_REGIMEN_MATRIMONIAL));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL>(NID_REGIMEN_MATRIMONIAL, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.NID_REGIMEN_MATRIMONIAL, single_query);

        }
        protected void Where()
        {
            if (VID_NOMBREs.Values.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.VID_NOMBRE, query);

            if (VID_FECHAs.Values.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.VID_FECHA, query);

            if (VID_HOMOCLAVEs.Values.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.VID_HOMOCLAVE, query);

            if (NID_DECLARACIONs.Values.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.NID_DECLARACION, query);

            //if (NID_REGIMENs.Values.Count > 0) query = (NID_REGIMENs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_REGIMENs.Values.Contains(p.NID_REGIMEN)) : query.Where(p => !NID_REGIMENs.Values.Contains(p.NID_REGIMEN));
            //query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL>(NID_REGIMEN, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.NID_REGIMEN, query);

            if (NID_REGIMEN_MATRIMONIALs.Values.Count > 0) query = (NID_REGIMEN_MATRIMONIALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_REGIMEN_MATRIMONIALs.Values.Contains(p.NID_REGIMEN_MATRIMONIAL)) : query.Where(p => !NID_REGIMEN_MATRIMONIALs.Values.Contains(p.NID_REGIMEN_MATRIMONIAL));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL>(NID_REGIMEN_MATRIMONIAL, Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL.Properties.NID_REGIMEN_MATRIMONIAL, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_DECLARACION_REGIMEN_MATRIMONIALs = single_query.AsNoTracking().ToList();
            else
                base_DECLARACION_REGIMEN_MATRIMONIALs = new List<MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_DECLARACION_REGIMEN_MATRIMONIALs = query.AsNoTracking().ToList();
            else
                lista_DECLARACION_REGIMEN_MATRIMONIALs = new List<Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_REGIMEN_MATRIMONIAL> r;
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
