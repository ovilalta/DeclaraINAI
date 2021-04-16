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
    internal class dal__l_CAT_PAIS : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_PAIS> lista_CAT_PAISs { get; set; }
        internal List<MODELDeclara_V2.CAT_PAIS> base_CAT_PAISs { get; set; }


        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

        internal StringFilter V_PAIS { get; set; }
        internal ListFilter<String> V_PAISs { get; set; }

        internal StringFilter V_NACIONALIDAD_M { get; set; }
        internal ListFilter<String> V_NACIONALIDAD_Ms { get; set; }

        internal StringFilter V_NACIONALIDAD_F { get; set; }
        internal ListFilter<String> V_NACIONALIDAD_Fs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_PAIS> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_PAIS> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_PAIS()
        {
            NID_PAISs = new ListFilter<Int32>();
            V_PAISs = new ListFilter<String>();
            V_NACIONALIDAD_Ms = new ListFilter<String>();
            V_NACIONALIDAD_Fs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_PAIS
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_PAIS in db.CAT_PAIS
                    select new Declara_V2.MODELextended.CAT_PAIS
                    {
                        NID_PAIS = qCAT_PAIS.NID_PAIS,
                        V_PAIS = qCAT_PAIS.V_PAIS,
                        V_NACIONALIDAD_M = qCAT_PAIS.V_NACIONALIDAD_M,
                        V_NACIONALIDAD_F = qCAT_PAIS.V_NACIONALIDAD_F,
                    };
        }

        protected void Single_Where()
        {
            if (NID_PAISs.Count > 0) single_query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_PAIS>(NID_PAIS, Declara_V2.MODELextended.CAT_PAIS.Properties.NID_PAIS.ToString(), single_query);

            if (V_PAISs.Count > 0) single_query =  (V_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_PAISs.Contains(p.V_PAIS)) : single_query.Where(p => !V_PAISs.Contains(p.V_PAIS));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_PAIS>(V_PAIS, Declara_V2.MODELextended.CAT_PAIS.Properties.V_PAIS.ToString(), single_query);

            if (V_NACIONALIDAD_Ms.Count > 0) single_query =  (V_NACIONALIDAD_Ms.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_NACIONALIDAD_Ms.Contains(p.V_NACIONALIDAD_M)) : single_query.Where(p => !V_NACIONALIDAD_Ms.Contains(p.V_NACIONALIDAD_M));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_PAIS>(V_NACIONALIDAD_M, Declara_V2.MODELextended.CAT_PAIS.Properties.V_NACIONALIDAD_M.ToString(), single_query);

            if (V_NACIONALIDAD_Fs.Count > 0) single_query =  (V_NACIONALIDAD_Fs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_NACIONALIDAD_Fs.Contains(p.V_NACIONALIDAD_F)) : single_query.Where(p => !V_NACIONALIDAD_Fs.Contains(p.V_NACIONALIDAD_F));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_PAIS>(V_NACIONALIDAD_F, Declara_V2.MODELextended.CAT_PAIS.Properties.V_NACIONALIDAD_F.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_PAISs.Count > 0) query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_PAIS>(NID_PAIS, Declara_V2.MODELextended.CAT_PAIS.Properties.NID_PAIS.ToString(), query);

            if (V_PAISs.Count > 0) query =  (V_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_PAISs.Contains(p.V_PAIS)) : query.Where(p => !V_PAISs.Contains(p.V_PAIS));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_PAIS>(V_PAIS, Declara_V2.MODELextended.CAT_PAIS.Properties.V_PAIS.ToString(), query);

            if (V_NACIONALIDAD_Ms.Count > 0) query =  (V_NACIONALIDAD_Ms.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_NACIONALIDAD_Ms.Contains(p.V_NACIONALIDAD_M)) : query.Where(p => !V_NACIONALIDAD_Ms.Contains(p.V_NACIONALIDAD_M));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_PAIS>(V_NACIONALIDAD_M, Declara_V2.MODELextended.CAT_PAIS.Properties.V_NACIONALIDAD_M.ToString(), query);

            if (V_NACIONALIDAD_Fs.Count > 0) query =  (V_NACIONALIDAD_Fs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_NACIONALIDAD_Fs.Contains(p.V_NACIONALIDAD_F)) : query.Where(p => !V_NACIONALIDAD_Fs.Contains(p.V_NACIONALIDAD_F));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_PAIS>(V_NACIONALIDAD_F, Declara_V2.MODELextended.CAT_PAIS.Properties.V_NACIONALIDAD_F.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_PAISs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_PAISs = new List<MODELDeclara_V2.CAT_PAIS>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_PAISs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_PAISs = new List<Declara_V2.MODELextended.CAT_PAIS>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_PAIS> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_PAIS> r;
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
