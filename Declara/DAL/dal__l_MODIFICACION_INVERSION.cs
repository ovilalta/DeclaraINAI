using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Declara_V2.DAL
{
    internal class dal__l_MODIFICACION_INVERSION : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.MODIFICACION_INVERSION> lista_MODIFICACION_INVERSIONs { get; set; }
        internal List<MODELDeclara_V2.MODIFICACION_INVERSION> base_MODIFICACION_INVERSIONs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_PATRIMONIO { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIOs { get; set; }

        internal DecimalFilter M_SALDO_ANTERIOR { get; set; }
        internal ListFilter<Decimal> M_SALDO_ANTERIORs { get; set; }

        internal DecimalFilter M_SALDO_ACTUAL { get; set; }
        internal ListFilter<Decimal> M_SALDO_ACTUALs { get; set; }

        internal System.Nullable<Boolean> L_CANCELADA { get; set; }
        internal ListFilter<Boolean> L_CANCELADAs { get; set; }

        internal System.Nullable<Boolean> L_MODIFICADA { get; set; }
        internal ListFilter<Boolean> L_MODIFICADAs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.MODIFICACION_INVERSION> query { get; set; }
        protected IQueryable<MODELDeclara_V2.MODIFICACION_INVERSION> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_MODIFICACION_INVERSION()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            M_SALDO_ANTERIORs = new ListFilter<Decimal>();
            M_SALDO_ACTUALs = new ListFilter<Decimal>();
            L_CANCELADAs = new ListFilter<Boolean>();
            L_MODIFICADAs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.MODIFICACION_INVERSION
                           select p;
        }

        protected void Select()
        {

            query = from qMODIFICACION_INVERSION in db.MODIFICACION_INVERSION
                    select new Declara_V2.MODELextended.MODIFICACION_INVERSION
                    {
                        VID_NOMBRE = qMODIFICACION_INVERSION.VID_NOMBRE,
                        VID_FECHA = qMODIFICACION_INVERSION.VID_FECHA,
                        VID_HOMOCLAVE = qMODIFICACION_INVERSION.VID_HOMOCLAVE,
                        NID_DECLARACION = qMODIFICACION_INVERSION.NID_DECLARACION,
                        NID_PATRIMONIO = qMODIFICACION_INVERSION.NID_PATRIMONIO,
                        M_SALDO_ANTERIOR = qMODIFICACION_INVERSION.M_SALDO_ANTERIOR,
                        M_SALDO_ACTUAL = qMODIFICACION_INVERSION.M_SALDO_ACTUAL,
                        L_CANCELADA = qMODIFICACION_INVERSION.L_CANCELADA,
                        L_MODIFICADA = qMODIFICACION_INVERSION.L_MODIFICADA,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_INVERSION>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_INVERSION>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_INVERSION>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_INVERSION>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_INVERSION>(NID_PATRIMONIO, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.NID_PATRIMONIO.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.MODIFICACION_INVERSION>(M_SALDO_ANTERIOR, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.M_SALDO_ANTERIOR.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.MODIFICACION_INVERSION>(M_SALDO_ACTUAL, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.M_SALDO_ACTUAL.ToString(), single_query);

            if (L_CANCELADA.HasValue) single_query = single_query.Where<MODELDeclara_V2.MODIFICACION_INVERSION>(p => p.L_CANCELADA == L_CANCELADA );

            if (L_MODIFICADA.HasValue) single_query = single_query.Where<MODELDeclara_V2.MODIFICACION_INVERSION>(p => p.L_MODIFICADA == L_MODIFICADA );

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INVERSION>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INVERSION>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INVERSION>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INVERSION>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.NID_DECLARACION.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INVERSION>(NID_PATRIMONIO, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.NID_PATRIMONIO.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INVERSION>(M_SALDO_ANTERIOR, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.M_SALDO_ANTERIOR.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INVERSION>(M_SALDO_ACTUAL, Declara_V2.MODELextended.MODIFICACION_INVERSION.Properties.M_SALDO_ACTUAL.ToString(), query);

            if (L_CANCELADA.HasValue) query = query.Where<Declara_V2.MODELextended.MODIFICACION_INVERSION>(p => p.L_CANCELADA == L_CANCELADA );

            if (L_MODIFICADA.HasValue) query = query.Where<Declara_V2.MODELextended.MODIFICACION_INVERSION>(p => p.L_MODIFICADA == L_MODIFICADA );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_MODIFICACION_INVERSIONs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_MODIFICACION_INVERSIONs = new List<MODELDeclara_V2.MODIFICACION_INVERSION>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_MODIFICACION_INVERSIONs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_MODIFICACION_INVERSIONs = new List<Declara_V2.MODELextended.MODIFICACION_INVERSION>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.MODIFICACION_INVERSION> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.MODIFICACION_INVERSION> r;
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
