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
    internal class dal__l_CONFLICTO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CONFLICTO> lista_CONFLICTOs { get; set; }
        internal List<MODELDeclara_V2.CONFLICTO> base_CONFLICTOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_CONFLICTO { get; set; }
        internal ListFilter<Int32> NID_CONFLICTOs { get; set; }

        internal IntegerFilter NID_DEC_ASOS { get; set; }
        internal ListFilter<Int32> NID_DEC_ASOSs { get; set; }

        internal IntegerFilter NID_ESTADO_CONFLICTO { get; set; }
        internal ListFilter<Int32> NID_ESTADO_CONFLICTOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CONFLICTO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CONFLICTO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CONFLICTO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_CONFLICTOs = new ListFilter<Int32>();
            NID_DEC_ASOSs = new ListFilter<Int32>();
            NID_ESTADO_CONFLICTOs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CONFLICTO
                           select p;
        }

        protected void Select()
        {

            query = from qCONFLICTO in db.CONFLICTO
                    join qCAT_ESTADO_CONFLICTO in db.CAT_ESTADO_CONFLICTO on qCONFLICTO.NID_ESTADO_CONFLICTO
                                                                      equals qCAT_ESTADO_CONFLICTO.NID_ESTADO_CONFLICTO
                    select new Declara_V2.MODELextended.CONFLICTO
                    {
                        VID_NOMBRE = qCONFLICTO.VID_NOMBRE,
                        VID_FECHA = qCONFLICTO.VID_FECHA,
                        VID_HOMOCLAVE = qCONFLICTO.VID_HOMOCLAVE,
                        NID_CONFLICTO = qCONFLICTO.NID_CONFLICTO,
                        NID_DEC_ASOS = qCONFLICTO.NID_DEC_ASOS,
                        NID_ESTADO_CONFLICTO = qCONFLICTO.NID_ESTADO_CONFLICTO,
                        V_ESTADO_CONFLICTO = qCAT_ESTADO_CONFLICTO.V_ESTADO_CONFLICTO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.CONFLICTO>(VID_NOMBRE, Declara_V2.MODELextended.CONFLICTO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.CONFLICTO>(VID_FECHA, Declara_V2.MODELextended.CONFLICTO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.CONFLICTO>(VID_HOMOCLAVE, Declara_V2.MODELextended.CONFLICTO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_CONFLICTOs.Count > 0) single_query =  (NID_CONFLICTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_CONFLICTOs.Contains(p.NID_CONFLICTO)) : single_query.Where(p => !NID_CONFLICTOs.Contains(p.NID_CONFLICTO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CONFLICTO>(NID_CONFLICTO, Declara_V2.MODELextended.CONFLICTO.Properties.NID_CONFLICTO.ToString(), single_query);

            if (NID_DEC_ASOSs.Count > 0) single_query =  (NID_DEC_ASOSs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DEC_ASOSs.Contains(p.NID_DEC_ASOS.Value)) : single_query.Where(p => !NID_DEC_ASOSs.Contains(p.NID_DEC_ASOS.Value));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CONFLICTO>(NID_DEC_ASOS, Declara_V2.MODELextended.CONFLICTO.Properties.NID_DEC_ASOS.ToString(), single_query);

            if (NID_ESTADO_CONFLICTOs.Count > 0) single_query =  (NID_ESTADO_CONFLICTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADO_CONFLICTOs.Contains(p.NID_ESTADO_CONFLICTO)) : single_query.Where(p => !NID_ESTADO_CONFLICTOs.Contains(p.NID_ESTADO_CONFLICTO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CONFLICTO>(NID_ESTADO_CONFLICTO, Declara_V2.MODELextended.CONFLICTO.Properties.NID_ESTADO_CONFLICTO.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.CONFLICTO>(VID_NOMBRE, Declara_V2.MODELextended.CONFLICTO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.CONFLICTO>(VID_FECHA, Declara_V2.MODELextended.CONFLICTO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.CONFLICTO>(VID_HOMOCLAVE, Declara_V2.MODELextended.CONFLICTO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_CONFLICTOs.Count > 0) query =  (NID_CONFLICTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_CONFLICTOs.Contains(p.NID_CONFLICTO)) : query.Where(p => !NID_CONFLICTOs.Contains(p.NID_CONFLICTO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CONFLICTO>(NID_CONFLICTO, Declara_V2.MODELextended.CONFLICTO.Properties.NID_CONFLICTO.ToString(), query);

            if (NID_DEC_ASOSs.Count > 0) query =  (NID_DEC_ASOSs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DEC_ASOSs.Contains(p.NID_DEC_ASOS.Value)) : query.Where(p => !NID_DEC_ASOSs.Contains(p.NID_DEC_ASOS.Value));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CONFLICTO>(NID_DEC_ASOS, Declara_V2.MODELextended.CONFLICTO.Properties.NID_DEC_ASOS.ToString(), query);

            if (NID_ESTADO_CONFLICTOs.Count > 0) query =  (NID_ESTADO_CONFLICTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADO_CONFLICTOs.Contains(p.NID_ESTADO_CONFLICTO)) : query.Where(p => !NID_ESTADO_CONFLICTOs.Contains(p.NID_ESTADO_CONFLICTO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CONFLICTO>(NID_ESTADO_CONFLICTO, Declara_V2.MODELextended.CONFLICTO.Properties.NID_ESTADO_CONFLICTO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CONFLICTOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CONFLICTOs = new List<MODELDeclara_V2.CONFLICTO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CONFLICTOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CONFLICTOs = new List<Declara_V2.MODELextended.CONFLICTO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CONFLICTO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CONFLICTO> r;
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
