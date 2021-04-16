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
    internal class dal__l_CAT_INST_FINANCIERA : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_INST_FINANCIERA> lista_CAT_INST_FINANCIERAs { get; set; }
        internal List<MODELDeclara_V2.CAT_INST_FINANCIERA> base_CAT_INST_FINANCIERAs { get; set; }


        internal IntegerFilter NID_INSTITUCION { get; set; }
        internal ListFilter<Int32> NID_INSTITUCIONs { get; set; }

        internal StringFilter V_INSTITUCION { get; set; }
        internal ListFilter<String> V_INSTITUCIONs { get; set; }

        internal System.Nullable<Boolean> L_ACTIVO { get; set; }
        internal ListFilter<Boolean> L_ACTIVOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_INST_FINANCIERA> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_INST_FINANCIERA> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_INST_FINANCIERA()
        {
            NID_INSTITUCIONs = new ListFilter<Int32>();
            V_INSTITUCIONs = new ListFilter<String>();
            L_ACTIVOs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_INST_FINANCIERA
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_INST_FINANCIERA in db.CAT_INST_FINANCIERA
                    select new Declara_V2.MODELextended.CAT_INST_FINANCIERA
                    {
                        NID_INSTITUCION = qCAT_INST_FINANCIERA.NID_INSTITUCION,
                        V_INSTITUCION = qCAT_INST_FINANCIERA.V_INSTITUCION,
                        L_ACTIVO = qCAT_INST_FINANCIERA.L_ACTIVO,
                    };
        }

        protected void Single_Where()
        {
            if (NID_INSTITUCIONs.Count > 0) single_query =  (NID_INSTITUCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INSTITUCIONs.Contains(p.NID_INSTITUCION)) : single_query.Where(p => !NID_INSTITUCIONs.Contains(p.NID_INSTITUCION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_INST_FINANCIERA>(NID_INSTITUCION, Declara_V2.MODELextended.CAT_INST_FINANCIERA.Properties.NID_INSTITUCION.ToString(), single_query);

            if (V_INSTITUCIONs.Count > 0) single_query =  (V_INSTITUCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_INSTITUCIONs.Contains(p.V_INSTITUCION)) : single_query.Where(p => !V_INSTITUCIONs.Contains(p.V_INSTITUCION));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_INST_FINANCIERA>(V_INSTITUCION, Declara_V2.MODELextended.CAT_INST_FINANCIERA.Properties.V_INSTITUCION.ToString(), single_query);

            if (L_ACTIVO.HasValue) single_query = single_query.Where<MODELDeclara_V2.CAT_INST_FINANCIERA>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Where()
        {
            if (NID_INSTITUCIONs.Count > 0) query =  (NID_INSTITUCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INSTITUCIONs.Contains(p.NID_INSTITUCION)) : query.Where(p => !NID_INSTITUCIONs.Contains(p.NID_INSTITUCION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_INST_FINANCIERA>(NID_INSTITUCION, Declara_V2.MODELextended.CAT_INST_FINANCIERA.Properties.NID_INSTITUCION.ToString(), query);

            if (V_INSTITUCIONs.Count > 0) query =  (V_INSTITUCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_INSTITUCIONs.Contains(p.V_INSTITUCION)) : query.Where(p => !V_INSTITUCIONs.Contains(p.V_INSTITUCION));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_INST_FINANCIERA>(V_INSTITUCION, Declara_V2.MODELextended.CAT_INST_FINANCIERA.Properties.V_INSTITUCION.ToString(), query);

            if (L_ACTIVO.HasValue) query = query.Where<Declara_V2.MODELextended.CAT_INST_FINANCIERA>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_INST_FINANCIERAs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_INST_FINANCIERAs = new List<MODELDeclara_V2.CAT_INST_FINANCIERA>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_INST_FINANCIERAs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_INST_FINANCIERAs = new List<Declara_V2.MODELextended.CAT_INST_FINANCIERA>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_INST_FINANCIERA> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_INST_FINANCIERA> r;
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
