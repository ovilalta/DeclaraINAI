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
    internal class dal__l_CAT_TIPO_PATRIMONIO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO> lista_CAT_TIPO_PATRIMONIOs { get; set; }
        internal List<MODELDeclara_V2.CAT_TIPO_PATRIMONIO> base_CAT_TIPO_PATRIMONIOs { get; set; }


        internal IntegerFilter NID_TIPO { get; set; }
        internal ListFilter<Int32> NID_TIPOs { get; set; }

        internal StringFilter V_TIPO { get; set; }
        internal ListFilter<String> V_TIPOs { get; set; }

        internal IntegerFilter C_NATURALEZA { get; set; }
        internal ListFilter<Int32> C_NATURALEZAs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_TIPO_PATRIMONIO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_TIPO_PATRIMONIO()
        {
            NID_TIPOs = new ListFilter<Int32>();
            V_TIPOs = new ListFilter<String>();
            C_NATURALEZAs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_TIPO_PATRIMONIO
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_TIPO_PATRIMONIO in db.CAT_TIPO_PATRIMONIO
                    select new Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO
                    {
                        NID_TIPO = qCAT_TIPO_PATRIMONIO.NID_TIPO,
                        V_TIPO = qCAT_TIPO_PATRIMONIO.V_TIPO,
                        C_NATURALEZA = qCAT_TIPO_PATRIMONIO.C_NATURALEZA,
                    };
        }

        protected void Single_Where()
        {
            if (NID_TIPOs.Count > 0) single_query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : single_query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_TIPO_PATRIMONIO>(NID_TIPO, Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO.Properties.NID_TIPO.ToString(), single_query);

            if (V_TIPOs.Count > 0) single_query =  (V_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_TIPOs.Contains(p.V_TIPO)) : single_query.Where(p => !V_TIPOs.Contains(p.V_TIPO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_TIPO_PATRIMONIO>(V_TIPO, Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO.Properties.V_TIPO.ToString(), single_query);

            if (C_NATURALEZAs.Count > 0) single_query =  (C_NATURALEZAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_NATURALEZAs.Contains(p.C_NATURALEZA)) : single_query.Where(p => !C_NATURALEZAs.Contains(p.C_NATURALEZA));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_TIPO_PATRIMONIO>(C_NATURALEZA, Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO.Properties.C_NATURALEZA.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_TIPOs.Count > 0) query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO>(NID_TIPO, Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO.Properties.NID_TIPO.ToString(), query);

            if (V_TIPOs.Count > 0) query =  (V_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_TIPOs.Contains(p.V_TIPO)) : query.Where(p => !V_TIPOs.Contains(p.V_TIPO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO>(V_TIPO, Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO.Properties.V_TIPO.ToString(), query);

            if (C_NATURALEZAs.Count > 0) query =  (C_NATURALEZAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_NATURALEZAs.Contains(p.C_NATURALEZA)) : query.Where(p => !C_NATURALEZAs.Contains(p.C_NATURALEZA));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO>(C_NATURALEZA, Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO.Properties.C_NATURALEZA.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_TIPO_PATRIMONIOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_TIPO_PATRIMONIOs = new List<MODELDeclara_V2.CAT_TIPO_PATRIMONIO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_TIPO_PATRIMONIOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_TIPO_PATRIMONIOs = new List<Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_TIPO_PATRIMONIO> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 1; x <= OrderByCriterios.Count(); x++)
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_TIPO_PATRIMONIO> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 1; x <= OrderByCriterios.Count(); x++)
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
