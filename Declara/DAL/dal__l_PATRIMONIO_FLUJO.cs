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
    internal class dal__l_PATRIMONIO_FLUJO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.PATRIMONIO_FLUJO> lista_PATRIMONIO_FLUJOs { get; set; }
        internal List<MODELDeclara_V2.PATRIMONIO_FLUJO> base_PATRIMONIO_FLUJOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal DecimalFilter M_INGRESOS { get; set; }
        internal ListFilter<Decimal> M_INGRESOSs { get; set; }

        internal DecimalFilter M_EGRESOS { get; set; }
        internal ListFilter<Decimal> M_EGRESOSs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.PATRIMONIO_FLUJO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.PATRIMONIO_FLUJO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_PATRIMONIO_FLUJO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            M_INGRESOSs = new ListFilter<Decimal>();
            M_EGRESOSs = new ListFilter<Decimal>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.PATRIMONIO_FLUJO
                           select p;
        }

        protected void Select()
        {

            query = from qPATRIMONIO_FLUJO in db.PATRIMONIO_FLUJO
                    select new Declara_V2.MODELextended.PATRIMONIO_FLUJO
                    {
                        VID_NOMBRE = qPATRIMONIO_FLUJO.VID_NOMBRE,
                        VID_FECHA = qPATRIMONIO_FLUJO.VID_FECHA,
                        VID_HOMOCLAVE = qPATRIMONIO_FLUJO.VID_HOMOCLAVE,
                        M_INGRESOS = qPATRIMONIO_FLUJO.M_INGRESOS,
                        M_EGRESOS = qPATRIMONIO_FLUJO.M_EGRESOS,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_FLUJO>(VID_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_FLUJO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_FLUJO>(VID_FECHA, Declara_V2.MODELextended.PATRIMONIO_FLUJO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_FLUJO>(VID_HOMOCLAVE, Declara_V2.MODELextended.PATRIMONIO_FLUJO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.PATRIMONIO_FLUJO>(M_INGRESOS, Declara_V2.MODELextended.PATRIMONIO_FLUJO.Properties.M_INGRESOS.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.PATRIMONIO_FLUJO>(M_EGRESOS, Declara_V2.MODELextended.PATRIMONIO_FLUJO.Properties.M_EGRESOS.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_FLUJO>(VID_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_FLUJO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_FLUJO>(VID_FECHA, Declara_V2.MODELextended.PATRIMONIO_FLUJO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_FLUJO>(VID_HOMOCLAVE, Declara_V2.MODELextended.PATRIMONIO_FLUJO.Properties.VID_HOMOCLAVE.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_FLUJO>(M_INGRESOS, Declara_V2.MODELextended.PATRIMONIO_FLUJO.Properties.M_INGRESOS.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_FLUJO>(M_EGRESOS, Declara_V2.MODELextended.PATRIMONIO_FLUJO.Properties.M_EGRESOS.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_PATRIMONIO_FLUJOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_PATRIMONIO_FLUJOs = new List<MODELDeclara_V2.PATRIMONIO_FLUJO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_PATRIMONIO_FLUJOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_PATRIMONIO_FLUJOs = new List<Declara_V2.MODELextended.PATRIMONIO_FLUJO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.PATRIMONIO_FLUJO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.PATRIMONIO_FLUJO> r;
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
