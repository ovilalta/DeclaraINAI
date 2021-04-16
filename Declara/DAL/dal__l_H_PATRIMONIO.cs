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
    internal class dal__l_H_PATRIMONIO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.H_PATRIMONIO> lista_H_PATRIMONIOs { get; set; }
        internal List<MODELDeclara_V2.H_PATRIMONIO> base_H_PATRIMONIOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_PATRIMONIO { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIOs { get; set; }

        internal IntegerFilter NID_HISTORICO { get; set; }
        internal ListFilter<Int32> NID_HISTORICOs { get; set; }

        internal IntegerFilter NID_TIPO { get; set; }
        internal ListFilter<Int32> NID_TIPOs { get; set; }

        internal DecimalFilter M_VALOR { get; set; }
        internal ListFilter<Decimal> M_VALORs { get; set; }

        internal IntegerFilter NID_DEC_INCOR { get; set; }
        internal ListFilter<Int32> NID_DEC_INCORs { get; set; }

        internal DateTimeFilter F_INCORPORACION { get; set; }
        internal ListFilter<DateTime> F_INCORPORACIONs { get; set; }

        internal IntegerFilter NID_DEC_ULT_MOD { get; set; }
        internal ListFilter<Int32> NID_DEC_ULT_MODs { get; set; }

        internal DateTimeFilter F_MODIFICACION { get; set; }
        internal ListFilter<DateTime> F_MODIFICACIONs { get; set; }

        internal System.Nullable<Boolean> L_ACTIVO { get; set; }
        internal ListFilter<Boolean> L_ACTIVOs { get; set; }

        internal DateTimeFilter F_REGISTRO { get; set; }
        internal ListFilter<DateTime> F_REGISTROs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.H_PATRIMONIO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.H_PATRIMONIO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_H_PATRIMONIO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            NID_HISTORICOs = new ListFilter<Int32>();
            NID_TIPOs = new ListFilter<Int32>();
            M_VALORs = new ListFilter<Decimal>();
            NID_DEC_INCORs = new ListFilter<Int32>();
            F_INCORPORACIONs = new ListFilter<DateTime>();
            NID_DEC_ULT_MODs = new ListFilter<Int32>();
            F_MODIFICACIONs = new ListFilter<DateTime>();
            L_ACTIVOs = new ListFilter<Boolean>();
            F_REGISTROs = new ListFilter<DateTime>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.H_PATRIMONIO
                           select p;
        }

        protected void Select()
        {

            query = from qH_PATRIMONIO in db.H_PATRIMONIO
                    join qCAT_TIPO_PATRIMONIO in db.CAT_TIPO_PATRIMONIO on qH_PATRIMONIO.NID_TIPO
                                                                    equals qCAT_TIPO_PATRIMONIO.NID_TIPO
                    select new Declara_V2.MODELextended.H_PATRIMONIO
                    {
                        VID_NOMBRE = qH_PATRIMONIO.VID_NOMBRE,
                        VID_FECHA = qH_PATRIMONIO.VID_FECHA,
                        VID_HOMOCLAVE = qH_PATRIMONIO.VID_HOMOCLAVE,
                        NID_PATRIMONIO = qH_PATRIMONIO.NID_PATRIMONIO,
                        NID_HISTORICO = qH_PATRIMONIO.NID_HISTORICO,
                        NID_TIPO = qH_PATRIMONIO.NID_TIPO,
                        M_VALOR = qH_PATRIMONIO.M_VALOR,
                        NID_DEC_INCOR = qH_PATRIMONIO.NID_DEC_INCOR,
                        F_INCORPORACION = qH_PATRIMONIO.F_INCORPORACION,
                        NID_DEC_ULT_MOD = qH_PATRIMONIO.NID_DEC_ULT_MOD,
                        F_MODIFICACION = qH_PATRIMONIO.F_MODIFICACION,
                        L_ACTIVO = qH_PATRIMONIO.L_ACTIVO,
                        F_REGISTRO = qH_PATRIMONIO.F_REGISTRO,
                        V_TIPO = qCAT_TIPO_PATRIMONIO.V_TIPO,
                        C_NATURALEZA = qCAT_TIPO_PATRIMONIO.C_NATURALEZA,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(VID_NOMBRE, Declara_V2.MODELextended.H_PATRIMONIO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(VID_FECHA, Declara_V2.MODELextended.H_PATRIMONIO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(VID_HOMOCLAVE, Declara_V2.MODELextended.H_PATRIMONIO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(NID_PATRIMONIO, Declara_V2.MODELextended.H_PATRIMONIO.Properties.NID_PATRIMONIO.ToString(), single_query);

            if (NID_HISTORICOs.Count > 0) single_query =  (NID_HISTORICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_HISTORICOs.Contains(p.NID_HISTORICO)) : single_query.Where(p => !NID_HISTORICOs.Contains(p.NID_HISTORICO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(NID_HISTORICO, Declara_V2.MODELextended.H_PATRIMONIO.Properties.NID_HISTORICO.ToString(), single_query);

            if (NID_TIPOs.Count > 0) single_query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : single_query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(NID_TIPO, Declara_V2.MODELextended.H_PATRIMONIO.Properties.NID_TIPO.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(M_VALOR, Declara_V2.MODELextended.H_PATRIMONIO.Properties.M_VALOR.ToString(), single_query);

            if (NID_DEC_INCORs.Count > 0) single_query =  (NID_DEC_INCORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DEC_INCORs.Contains(p.NID_DEC_INCOR)) : single_query.Where(p => !NID_DEC_INCORs.Contains(p.NID_DEC_INCOR));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(NID_DEC_INCOR, Declara_V2.MODELextended.H_PATRIMONIO.Properties.NID_DEC_INCOR.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(F_INCORPORACION, Declara_V2.MODELextended.H_PATRIMONIO.Properties.F_INCORPORACION.ToString(), single_query);

            if (NID_DEC_ULT_MODs.Count > 0) single_query =  (NID_DEC_ULT_MODs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DEC_ULT_MODs.Contains(p.NID_DEC_ULT_MOD)) : single_query.Where(p => !NID_DEC_ULT_MODs.Contains(p.NID_DEC_ULT_MOD));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(NID_DEC_ULT_MOD, Declara_V2.MODELextended.H_PATRIMONIO.Properties.NID_DEC_ULT_MOD.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(F_MODIFICACION, Declara_V2.MODELextended.H_PATRIMONIO.Properties.F_MODIFICACION.ToString(), single_query);

            if (L_ACTIVO.HasValue) single_query = single_query.Where<MODELDeclara_V2.H_PATRIMONIO>(p => p.L_ACTIVO == L_ACTIVO );

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.H_PATRIMONIO>(F_REGISTRO, Declara_V2.MODELextended.H_PATRIMONIO.Properties.F_REGISTRO.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(VID_NOMBRE, Declara_V2.MODELextended.H_PATRIMONIO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(VID_FECHA, Declara_V2.MODELextended.H_PATRIMONIO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(VID_HOMOCLAVE, Declara_V2.MODELextended.H_PATRIMONIO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(NID_PATRIMONIO, Declara_V2.MODELextended.H_PATRIMONIO.Properties.NID_PATRIMONIO.ToString(), query);

            if (NID_HISTORICOs.Count > 0) query =  (NID_HISTORICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_HISTORICOs.Contains(p.NID_HISTORICO)) : query.Where(p => !NID_HISTORICOs.Contains(p.NID_HISTORICO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(NID_HISTORICO, Declara_V2.MODELextended.H_PATRIMONIO.Properties.NID_HISTORICO.ToString(), query);

            if (NID_TIPOs.Count > 0) query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(NID_TIPO, Declara_V2.MODELextended.H_PATRIMONIO.Properties.NID_TIPO.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(M_VALOR, Declara_V2.MODELextended.H_PATRIMONIO.Properties.M_VALOR.ToString(), query);

            if (NID_DEC_INCORs.Count > 0) query =  (NID_DEC_INCORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DEC_INCORs.Contains(p.NID_DEC_INCOR)) : query.Where(p => !NID_DEC_INCORs.Contains(p.NID_DEC_INCOR));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(NID_DEC_INCOR, Declara_V2.MODELextended.H_PATRIMONIO.Properties.NID_DEC_INCOR.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(F_INCORPORACION, Declara_V2.MODELextended.H_PATRIMONIO.Properties.F_INCORPORACION.ToString(), query);

            if (NID_DEC_ULT_MODs.Count > 0) query =  (NID_DEC_ULT_MODs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DEC_ULT_MODs.Contains(p.NID_DEC_ULT_MOD)) : query.Where(p => !NID_DEC_ULT_MODs.Contains(p.NID_DEC_ULT_MOD));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(NID_DEC_ULT_MOD, Declara_V2.MODELextended.H_PATRIMONIO.Properties.NID_DEC_ULT_MOD.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(F_MODIFICACION, Declara_V2.MODELextended.H_PATRIMONIO.Properties.F_MODIFICACION.ToString(), query);

            if (L_ACTIVO.HasValue) query = query.Where<Declara_V2.MODELextended.H_PATRIMONIO>(p => p.L_ACTIVO == L_ACTIVO );

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO>(F_REGISTRO, Declara_V2.MODELextended.H_PATRIMONIO.Properties.F_REGISTRO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_H_PATRIMONIOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_H_PATRIMONIOs = new List<MODELDeclara_V2.H_PATRIMONIO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_H_PATRIMONIOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_H_PATRIMONIOs = new List<Declara_V2.MODELextended.H_PATRIMONIO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.H_PATRIMONIO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.H_PATRIMONIO> r;
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
