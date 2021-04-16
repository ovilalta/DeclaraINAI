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
    internal class dal__l_USUARIO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.USUARIO> lista_USUARIOs { get; set; }
        internal List<MODELDeclara_V2.USUARIO> base_USUARIOs { get; set; }

        public StringFilter VID_RFC { get; set; }
        internal StringFilter V_NOMBRE_COMPLETO_ESTILO1 { get; set; }
        internal StringFilter V_NOMBRE_COMPLETO_ESTILO2 { get; set; }

        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal StringFilter V_PASSWORD { get; set; }
        internal ListFilter<String> V_PASSWORDs { get; set; }

        internal StringFilter V_NOMBRE { get; set; }
        internal ListFilter<String> V_NOMBREs { get; set; }

        internal StringFilter V_PRIMER_A { get; set; }
        internal ListFilter<String> V_PRIMER_As { get; set; }

        internal StringFilter V_SEGUNDO_A { get; set; }
        internal ListFilter<String> V_SEGUNDO_As { get; set; }

        internal DateTimeFilter F_NACIMIENTO { get; set; }
        internal ListFilter<DateTime> F_NACIMIENTOs { get; set; }

        internal StringFilter V_ACUSE { get; set; }
        internal ListFilter<String> V_ACUSEs { get; set; }

        internal System.Nullable<Boolean> L_ACTIVO { get; set; }
        internal ListFilter<Boolean> L_ACTIVOs { get; set; }

        internal DateTimeFilter F_INGRESO_INSTITUTO { get; set; }
        internal ListFilter<DateTime> F_INGRESO_INSTITUTOs { get; set; }

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


        protected IQueryable<Declara_V2.MODELextended.USUARIO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.USUARIO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_USUARIO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            V_PASSWORDs = new ListFilter<String>();
            V_NOMBREs = new ListFilter<String>();
            V_PRIMER_As = new ListFilter<String>();
            V_SEGUNDO_As = new ListFilter<String>();
            F_NACIMIENTOs = new ListFilter<DateTime>();
            V_ACUSEs = new ListFilter<String>();
            L_ACTIVOs = new ListFilter<Boolean>();
            F_INGRESO_INSTITUTOs = new ListFilter<DateTime>();
            F_REGISTROs = new ListFilter<DateTime>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.USUARIO
                           select p;
        }

        protected void Select()
        {

            query = from qUSUARIO in db.USUARIO
                    select new Declara_V2.MODELextended.USUARIO
                    {
                        VID_NOMBRE = qUSUARIO.VID_NOMBRE,
                        VID_FECHA = qUSUARIO.VID_FECHA,
                        VID_HOMOCLAVE = qUSUARIO.VID_HOMOCLAVE,
                        V_PASSWORD = qUSUARIO.V_PASSWORD,
                        V_NOMBRE = qUSUARIO.V_NOMBRE,
                        V_PRIMER_A = qUSUARIO.V_PRIMER_A,
                        V_SEGUNDO_A = qUSUARIO.V_SEGUNDO_A,
                        F_NACIMIENTO = qUSUARIO.F_NACIMIENTO,
                        V_ACUSE = qUSUARIO.V_ACUSE,
                        L_ACTIVO = qUSUARIO.L_ACTIVO,
                        F_INGRESO_INSTITUTO = qUSUARIO.F_INGRESO_INSTITUTO,
                        F_REGISTRO = qUSUARIO.F_REGISTRO,
                        VID_RFC = qUSUARIO.VID_NOMBRE + qUSUARIO.VID_FECHA + qUSUARIO.VID_HOMOCLAVE,
                        V_NOMBRE_COMPLETO_ESTILO1 = qUSUARIO.V_NOMBRE + " " + qUSUARIO.V_PRIMER_A + " " + qUSUARIO.V_SEGUNDO_A,
                        V_NOMBRE_COMPLETO_ESTILO2 = qUSUARIO.V_PRIMER_A + " " + qUSUARIO.V_SEGUNDO_A + " " + qUSUARIO.V_NOMBRE ,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO>(VID_NOMBRE, Declara_V2.MODELextended.USUARIO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO>(VID_FECHA, Declara_V2.MODELextended.USUARIO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO>(VID_HOMOCLAVE, Declara_V2.MODELextended.USUARIO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (V_PASSWORDs.Count > 0) single_query =  (V_PASSWORDs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_PASSWORDs.Contains(p.V_PASSWORD)) : single_query.Where(p => !V_PASSWORDs.Contains(p.V_PASSWORD));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO>(V_PASSWORD, Declara_V2.MODELextended.USUARIO.Properties.V_PASSWORD.ToString(), single_query);

            if (V_NOMBREs.Count > 0) single_query =  (V_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_NOMBREs.Contains(p.V_NOMBRE)) : single_query.Where(p => !V_NOMBREs.Contains(p.V_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO>(V_NOMBRE, Declara_V2.MODELextended.USUARIO.Properties.V_NOMBRE.ToString(), single_query);

            if (V_PRIMER_As.Count > 0) single_query =  (V_PRIMER_As.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_PRIMER_As.Contains(p.V_PRIMER_A)) : single_query.Where(p => !V_PRIMER_As.Contains(p.V_PRIMER_A));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO>(V_PRIMER_A, Declara_V2.MODELextended.USUARIO.Properties.V_PRIMER_A.ToString(), single_query);

            if (V_SEGUNDO_As.Count > 0) single_query =  (V_SEGUNDO_As.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_SEGUNDO_As.Contains(p.V_SEGUNDO_A)) : single_query.Where(p => !V_SEGUNDO_As.Contains(p.V_SEGUNDO_A));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO>(V_SEGUNDO_A, Declara_V2.MODELextended.USUARIO.Properties.V_SEGUNDO_A.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.USUARIO>(F_NACIMIENTO, Declara_V2.MODELextended.USUARIO.Properties.F_NACIMIENTO.ToString(), single_query);

            if (V_ACUSEs.Count > 0) single_query =  (V_ACUSEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_ACUSEs.Contains(p.V_ACUSE)) : single_query.Where(p => !V_ACUSEs.Contains(p.V_ACUSE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO>(V_ACUSE, Declara_V2.MODELextended.USUARIO.Properties.V_ACUSE.ToString(), single_query);

            if (L_ACTIVO.HasValue) single_query = single_query.Where<MODELDeclara_V2.USUARIO>(p => p.L_ACTIVO == L_ACTIVO );

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.USUARIO>(F_INGRESO_INSTITUTO, Declara_V2.MODELextended.USUARIO.Properties.F_INGRESO_INSTITUTO.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.USUARIO>(F_REGISTRO, Declara_V2.MODELextended.USUARIO.Properties.F_REGISTRO.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO>(VID_NOMBRE, Declara_V2.MODELextended.USUARIO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO>(VID_FECHA, Declara_V2.MODELextended.USUARIO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO>(VID_HOMOCLAVE, Declara_V2.MODELextended.USUARIO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (V_PASSWORDs.Count > 0) query =  (V_PASSWORDs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_PASSWORDs.Contains(p.V_PASSWORD)) : query.Where(p => !V_PASSWORDs.Contains(p.V_PASSWORD));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO>(V_PASSWORD, Declara_V2.MODELextended.USUARIO.Properties.V_PASSWORD.ToString(), query);

            if (V_NOMBREs.Count > 0) query =  (V_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_NOMBREs.Contains(p.V_NOMBRE)) : query.Where(p => !V_NOMBREs.Contains(p.V_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO>(V_NOMBRE, Declara_V2.MODELextended.USUARIO.Properties.V_NOMBRE.ToString(), query);

            if (V_PRIMER_As.Count > 0) query =  (V_PRIMER_As.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_PRIMER_As.Contains(p.V_PRIMER_A)) : query.Where(p => !V_PRIMER_As.Contains(p.V_PRIMER_A));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO>(V_PRIMER_A, Declara_V2.MODELextended.USUARIO.Properties.V_PRIMER_A.ToString(), query);

            if (V_SEGUNDO_As.Count > 0) query =  (V_SEGUNDO_As.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_SEGUNDO_As.Contains(p.V_SEGUNDO_A)) : query.Where(p => !V_SEGUNDO_As.Contains(p.V_SEGUNDO_A));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO>(V_SEGUNDO_A, Declara_V2.MODELextended.USUARIO.Properties.V_SEGUNDO_A.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.USUARIO>(F_NACIMIENTO, Declara_V2.MODELextended.USUARIO.Properties.F_NACIMIENTO.ToString(), query);

            if (V_ACUSEs.Count > 0) query =  (V_ACUSEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_ACUSEs.Contains(p.V_ACUSE)) : query.Where(p => !V_ACUSEs.Contains(p.V_ACUSE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO>(V_ACUSE, Declara_V2.MODELextended.USUARIO.Properties.V_ACUSE.ToString(), query);

            if (L_ACTIVO.HasValue) query = query.Where<Declara_V2.MODELextended.USUARIO>(p => p.L_ACTIVO == L_ACTIVO );

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.USUARIO>(F_INGRESO_INSTITUTO, Declara_V2.MODELextended.USUARIO.Properties.F_INGRESO_INSTITUTO.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.USUARIO>(F_REGISTRO, Declara_V2.MODELextended.USUARIO.Properties.F_REGISTRO.ToString(), query);

            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO>(VID_RFC, Declara_V2.MODELextended.USUARIO.Properties.VID_RFC.ToString(), query);
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO>(V_NOMBRE_COMPLETO_ESTILO1, Declara_V2.MODELextended.USUARIO.Properties.V_NOMBRE_COMPLETO_ESTILO1.ToString(), query);
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO>(V_NOMBRE_COMPLETO_ESTILO2, Declara_V2.MODELextended.USUARIO.Properties.V_NOMBRE_COMPLETO_ESTILO2.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_USUARIOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_USUARIOs = new List<MODELDeclara_V2.USUARIO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_USUARIOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_USUARIOs = new List<Declara_V2.MODELextended.USUARIO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.USUARIO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.USUARIO> r;
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
