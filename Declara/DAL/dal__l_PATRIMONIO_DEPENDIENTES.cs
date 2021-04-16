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
    internal class dal__l_PATRIMONIO_DEPENDIENTES : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES> lista_PATRIMONIO_DEPENDIENTESs { get; set; }
        internal List<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES> base_PATRIMONIO_DEPENDIENTESs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DEPENDIENTE { get; set; }
        internal ListFilter<Int32> NID_DEPENDIENTEs { get; set; }

        internal IntegerFilter NID_TIPO_DEPENDIENTE { get; set; }
        internal ListFilter<Int32> NID_TIPO_DEPENDIENTEs { get; set; }

        internal StringFilter E_NOMBRE { get; set; }
        internal ListFilter<String> E_NOMBREs { get; set; }

        internal StringFilter E_PRIMER_A { get; set; }
        internal ListFilter<String> E_PRIMER_As { get; set; }

        internal StringFilter E_SEGUNDO_A { get; set; }
        internal ListFilter<String> E_SEGUNDO_As { get; set; }

        internal DateTimeFilter F_NACIMIENTO { get; set; }
        internal ListFilter<DateTime> F_NACIMIENTOs { get; set; }

        internal StringFilter E_RFC { get; set; }
        internal ListFilter<String> E_RFCs { get; set; }

        internal System.Nullable<Boolean> L_DEPENDE_ECO { get; set; }
        internal ListFilter<Boolean> L_DEPENDE_ECOs { get; set; }

        internal StringFilter V_DOMICILIO { get; set; }
        internal ListFilter<String> V_DOMICILIOs { get; set; }

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


        protected IQueryable<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES> query { get; set; }
        protected IQueryable<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_PATRIMONIO_DEPENDIENTES()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DEPENDIENTEs = new ListFilter<Int32>();
            NID_TIPO_DEPENDIENTEs = new ListFilter<Int32>();
            E_NOMBREs = new ListFilter<String>();
            E_PRIMER_As = new ListFilter<String>();
            E_SEGUNDO_As = new ListFilter<String>();
            F_NACIMIENTOs = new ListFilter<DateTime>();
            E_RFCs = new ListFilter<String>();
            L_DEPENDE_ECOs = new ListFilter<Boolean>();
            V_DOMICILIOs = new ListFilter<String>();
            L_ACTIVOs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.PATRIMONIO_DEPENDIENTES
                           select p;
        }

        protected void Select()
        {

            query = from qPATRIMONIO_DEPENDIENTES in db.PATRIMONIO_DEPENDIENTES
                    join qCAT_TIPO_DEPENDIENTES in db.CAT_TIPO_DEPENDIENTES on qPATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE
                                                                        equals qCAT_TIPO_DEPENDIENTES.NID_TIPO_DEPENDIENTE
                    select new Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES
                    {
                        VID_NOMBRE = qPATRIMONIO_DEPENDIENTES.VID_NOMBRE,
                        VID_FECHA = qPATRIMONIO_DEPENDIENTES.VID_FECHA,
                        VID_HOMOCLAVE = qPATRIMONIO_DEPENDIENTES.VID_HOMOCLAVE,
                        NID_DEPENDIENTE = qPATRIMONIO_DEPENDIENTES.NID_DEPENDIENTE,
                        NID_TIPO_DEPENDIENTE = qPATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE,
                        E_NOMBRE = qPATRIMONIO_DEPENDIENTES.E_NOMBRE,
                        E_PRIMER_A = qPATRIMONIO_DEPENDIENTES.E_PRIMER_A,
                        E_SEGUNDO_A = qPATRIMONIO_DEPENDIENTES.E_SEGUNDO_A,
                        F_NACIMIENTO = qPATRIMONIO_DEPENDIENTES.F_NACIMIENTO,
                        E_RFC = qPATRIMONIO_DEPENDIENTES.E_RFC,
                        L_DEPENDE_ECO = qPATRIMONIO_DEPENDIENTES.L_DEPENDE_ECO,
                        V_DOMICILIO = qPATRIMONIO_DEPENDIENTES.V_DOMICILIO,
                        L_ACTIVO = qPATRIMONIO_DEPENDIENTES.L_ACTIVO,
                        V_TIPO_DEPENDIENTE = qCAT_TIPO_DEPENDIENTES.V_TIPO_DEPENDIENTE,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(VID_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(VID_FECHA, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(VID_HOMOCLAVE, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DEPENDIENTEs.Count > 0) single_query =  (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE)) : single_query.Where(p => !NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(NID_DEPENDIENTE, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString(), single_query);

            if (NID_TIPO_DEPENDIENTEs.Count > 0) single_query =  (NID_TIPO_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_DEPENDIENTEs.Contains(p.NID_TIPO_DEPENDIENTE)) : single_query.Where(p => !NID_TIPO_DEPENDIENTEs.Contains(p.NID_TIPO_DEPENDIENTE));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(NID_TIPO_DEPENDIENTE, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.NID_TIPO_DEPENDIENTE.ToString(), single_query);

            if (E_NOMBREs.Count > 0) single_query =  (E_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_NOMBREs.Contains(p.E_NOMBRE)) : single_query.Where(p => !E_NOMBREs.Contains(p.E_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(E_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.E_NOMBRE.ToString(), single_query);

            if (E_PRIMER_As.Count > 0) single_query =  (E_PRIMER_As.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_PRIMER_As.Contains(p.E_PRIMER_A)) : single_query.Where(p => !E_PRIMER_As.Contains(p.E_PRIMER_A));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(E_PRIMER_A, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.E_PRIMER_A.ToString(), single_query);

            if (E_SEGUNDO_As.Count > 0) single_query =  (E_SEGUNDO_As.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_SEGUNDO_As.Contains(p.E_SEGUNDO_A)) : single_query.Where(p => !E_SEGUNDO_As.Contains(p.E_SEGUNDO_A));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(E_SEGUNDO_A, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.E_SEGUNDO_A.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(F_NACIMIENTO, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.F_NACIMIENTO.ToString(), single_query);

            if (E_RFCs.Count > 0) single_query =  (E_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_RFCs.Contains(p.E_RFC)) : single_query.Where(p => !E_RFCs.Contains(p.E_RFC));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(E_RFC, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.E_RFC.ToString(), single_query);

            if (L_DEPENDE_ECO.HasValue) single_query = single_query.Where<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(p => p.L_DEPENDE_ECO == L_DEPENDE_ECO );

            if (V_DOMICILIOs.Count > 0) single_query =  (V_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_DOMICILIOs.Contains(p.V_DOMICILIO)) : single_query.Where(p => !V_DOMICILIOs.Contains(p.V_DOMICILIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(V_DOMICILIO, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.V_DOMICILIO.ToString(), single_query);

            if (L_ACTIVO.HasValue) single_query = single_query.Where<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(VID_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(VID_FECHA, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(VID_HOMOCLAVE, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DEPENDIENTEs.Count > 0) query =  (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE)) : query.Where(p => !NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(NID_DEPENDIENTE, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString(), query);

            if (NID_TIPO_DEPENDIENTEs.Count > 0) query =  (NID_TIPO_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_DEPENDIENTEs.Contains(p.NID_TIPO_DEPENDIENTE)) : query.Where(p => !NID_TIPO_DEPENDIENTEs.Contains(p.NID_TIPO_DEPENDIENTE));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(NID_TIPO_DEPENDIENTE, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.NID_TIPO_DEPENDIENTE.ToString(), query);

            if (E_NOMBREs.Count > 0) query =  (E_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_NOMBREs.Contains(p.E_NOMBRE)) : query.Where(p => !E_NOMBREs.Contains(p.E_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(E_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.E_NOMBRE.ToString(), query);

            if (E_PRIMER_As.Count > 0) query =  (E_PRIMER_As.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_PRIMER_As.Contains(p.E_PRIMER_A)) : query.Where(p => !E_PRIMER_As.Contains(p.E_PRIMER_A));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(E_PRIMER_A, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.E_PRIMER_A.ToString(), query);

            if (E_SEGUNDO_As.Count > 0) query =  (E_SEGUNDO_As.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_SEGUNDO_As.Contains(p.E_SEGUNDO_A)) : query.Where(p => !E_SEGUNDO_As.Contains(p.E_SEGUNDO_A));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(E_SEGUNDO_A, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.E_SEGUNDO_A.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(F_NACIMIENTO, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.F_NACIMIENTO.ToString(), query);

            if (E_RFCs.Count > 0) query =  (E_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_RFCs.Contains(p.E_RFC)) : query.Where(p => !E_RFCs.Contains(p.E_RFC));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(E_RFC, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.E_RFC.ToString(), query);

            if (L_DEPENDE_ECO.HasValue) query = query.Where<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(p => p.L_DEPENDE_ECO == L_DEPENDE_ECO );

            if (V_DOMICILIOs.Count > 0) query =  (V_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_DOMICILIOs.Contains(p.V_DOMICILIO)) : query.Where(p => !V_DOMICILIOs.Contains(p.V_DOMICILIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(V_DOMICILIO, Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES.Properties.V_DOMICILIO.ToString(), query);

            if (L_ACTIVO.HasValue) query = query.Where<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_PATRIMONIO_DEPENDIENTESs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_PATRIMONIO_DEPENDIENTESs = new List<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_PATRIMONIO_DEPENDIENTESs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_PATRIMONIO_DEPENDIENTESs = new List<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES> r;
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
