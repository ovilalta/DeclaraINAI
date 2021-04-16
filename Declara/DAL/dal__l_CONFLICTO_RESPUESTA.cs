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
    internal class dal__l_CONFLICTO_RESPUESTA : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CONFLICTO_RESPUESTA> lista_CONFLICTO_RESPUESTAs { get; set; }
        internal List<MODELDeclara_V2.CONFLICTO_RESPUESTA> base_CONFLICTO_RESPUESTAs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_CONFLICTO { get; set; }
        internal ListFilter<Int32> NID_CONFLICTOs { get; set; }

        internal IntegerFilter NID_RUBRO { get; set; }
        internal ListFilter<Int32> NID_RUBROs { get; set; }

        internal IntegerFilter NID_ENCABEZADO { get; set; }
        internal ListFilter<Int32> NID_ENCABEZADOs { get; set; }

        internal IntegerFilter NID_PREGUNTA { get; set; }
        internal ListFilter<Int32> NID_PREGUNTAs { get; set; }

        internal StringFilter V_RESPUESTA { get; set; }
        internal ListFilter<String> V_RESPUESTAs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CONFLICTO_RESPUESTA> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CONFLICTO_RESPUESTA> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CONFLICTO_RESPUESTA()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_CONFLICTOs = new ListFilter<Int32>();
            NID_RUBROs = new ListFilter<Int32>();
            NID_ENCABEZADOs = new ListFilter<Int32>();
            NID_PREGUNTAs = new ListFilter<Int32>();
            V_RESPUESTAs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CONFLICTO_RESPUESTA
                           select p;
        }

        protected void Select()
        {

            query = from qCONFLICTO_RESPUESTA in db.CONFLICTO_RESPUESTA
                    join qCAT_CONFLICTO_PREGUNTA in db.CAT_CONFLICTO_PREGUNTA on new { qCONFLICTO_RESPUESTA.NID_RUBRO, qCONFLICTO_RESPUESTA.NID_PREGUNTA }
                                                                          equals new { qCAT_CONFLICTO_PREGUNTA.NID_RUBRO, qCAT_CONFLICTO_PREGUNTA.NID_PREGUNTA }
                    select new Declara_V2.MODELextended.CONFLICTO_RESPUESTA
                    {
                        VID_NOMBRE = qCONFLICTO_RESPUESTA.VID_NOMBRE,
                        VID_FECHA = qCONFLICTO_RESPUESTA.VID_FECHA,
                        VID_HOMOCLAVE = qCONFLICTO_RESPUESTA.VID_HOMOCLAVE,
                        NID_CONFLICTO = qCONFLICTO_RESPUESTA.NID_CONFLICTO,
                        NID_RUBRO = qCONFLICTO_RESPUESTA.NID_RUBRO,
                        NID_ENCABEZADO = qCONFLICTO_RESPUESTA.NID_ENCABEZADO,
                        NID_PREGUNTA = qCONFLICTO_RESPUESTA.NID_PREGUNTA,
                        V_RESPUESTA = qCONFLICTO_RESPUESTA.V_RESPUESTA,
                        V_RUBRO = qCAT_CONFLICTO_PREGUNTA.V_RUBRO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.CONFLICTO_RESPUESTA>(VID_NOMBRE, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.CONFLICTO_RESPUESTA>(VID_FECHA, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.CONFLICTO_RESPUESTA>(VID_HOMOCLAVE, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_CONFLICTOs.Count > 0) single_query =  (NID_CONFLICTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_CONFLICTOs.Contains(p.NID_CONFLICTO)) : single_query.Where(p => !NID_CONFLICTOs.Contains(p.NID_CONFLICTO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CONFLICTO_RESPUESTA>(NID_CONFLICTO, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.NID_CONFLICTO.ToString(), single_query);

            if (NID_RUBROs.Count > 0) single_query =  (NID_RUBROs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_RUBROs.Contains(p.NID_RUBRO)) : single_query.Where(p => !NID_RUBROs.Contains(p.NID_RUBRO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CONFLICTO_RESPUESTA>(NID_RUBRO, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.NID_RUBRO.ToString(), single_query);

            if (NID_ENCABEZADOs.Count > 0) single_query =  (NID_ENCABEZADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ENCABEZADOs.Contains(p.NID_ENCABEZADO)) : single_query.Where(p => !NID_ENCABEZADOs.Contains(p.NID_ENCABEZADO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CONFLICTO_RESPUESTA>(NID_ENCABEZADO, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.NID_ENCABEZADO.ToString(), single_query);

            if (NID_PREGUNTAs.Count > 0) single_query =  (NID_PREGUNTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PREGUNTAs.Contains(p.NID_PREGUNTA)) : single_query.Where(p => !NID_PREGUNTAs.Contains(p.NID_PREGUNTA));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CONFLICTO_RESPUESTA>(NID_PREGUNTA, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.NID_PREGUNTA.ToString(), single_query);

            if (V_RESPUESTAs.Count > 0) single_query =  (V_RESPUESTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_RESPUESTAs.Contains(p.V_RESPUESTA)) : single_query.Where(p => !V_RESPUESTAs.Contains(p.V_RESPUESTA));
            single_query = StringFilterBuilder<MODELDeclara_V2.CONFLICTO_RESPUESTA>(V_RESPUESTA, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.V_RESPUESTA.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.CONFLICTO_RESPUESTA>(VID_NOMBRE, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.CONFLICTO_RESPUESTA>(VID_FECHA, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.CONFLICTO_RESPUESTA>(VID_HOMOCLAVE, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_CONFLICTOs.Count > 0) query =  (NID_CONFLICTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_CONFLICTOs.Contains(p.NID_CONFLICTO)) : query.Where(p => !NID_CONFLICTOs.Contains(p.NID_CONFLICTO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CONFLICTO_RESPUESTA>(NID_CONFLICTO, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.NID_CONFLICTO.ToString(), query);

            if (NID_RUBROs.Count > 0) query =  (NID_RUBROs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_RUBROs.Contains(p.NID_RUBRO)) : query.Where(p => !NID_RUBROs.Contains(p.NID_RUBRO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CONFLICTO_RESPUESTA>(NID_RUBRO, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.NID_RUBRO.ToString(), query);

            if (NID_ENCABEZADOs.Count > 0) query =  (NID_ENCABEZADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ENCABEZADOs.Contains(p.NID_ENCABEZADO)) : query.Where(p => !NID_ENCABEZADOs.Contains(p.NID_ENCABEZADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CONFLICTO_RESPUESTA>(NID_ENCABEZADO, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.NID_ENCABEZADO.ToString(), query);

            if (NID_PREGUNTAs.Count > 0) query =  (NID_PREGUNTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PREGUNTAs.Contains(p.NID_PREGUNTA)) : query.Where(p => !NID_PREGUNTAs.Contains(p.NID_PREGUNTA));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CONFLICTO_RESPUESTA>(NID_PREGUNTA, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.NID_PREGUNTA.ToString(), query);

            if (V_RESPUESTAs.Count > 0) query =  (V_RESPUESTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_RESPUESTAs.Contains(p.V_RESPUESTA)) : query.Where(p => !V_RESPUESTAs.Contains(p.V_RESPUESTA));
            query = StringFilterBuilder<Declara_V2.MODELextended.CONFLICTO_RESPUESTA>(V_RESPUESTA, Declara_V2.MODELextended.CONFLICTO_RESPUESTA.Properties.V_RESPUESTA.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CONFLICTO_RESPUESTAs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CONFLICTO_RESPUESTAs = new List<MODELDeclara_V2.CONFLICTO_RESPUESTA>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CONFLICTO_RESPUESTAs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CONFLICTO_RESPUESTAs = new List<Declara_V2.MODELextended.CONFLICTO_RESPUESTA>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CONFLICTO_RESPUESTA> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CONFLICTO_RESPUESTA> r;
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
