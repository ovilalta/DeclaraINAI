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
    internal class dal__l_ALTA_INMUEBLE : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.ALTA_INMUEBLE> lista_ALTA_INMUEBLEs { get; set; }
        internal List<MODELDeclara_V2.ALTA_INMUEBLE> base_ALTA_INMUEBLEs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_INMUEBLE { get; set; }
        internal ListFilter<Int32> NID_INMUEBLEs { get; set; }

        internal IntegerFilter NID_TIPO { get; set; }
        internal ListFilter<Int32> NID_TIPOs { get; set; }

        internal DateTimeFilter F_ADQUISICION { get; set; }
        internal ListFilter<DateTime> F_ADQUISICIONs { get; set; }

        internal IntegerFilter NID_USO { get; set; }
        internal ListFilter<Int32> NID_USOs { get; set; }

        internal StringFilter E_UBICACION { get; set; }
        internal ListFilter<String> E_UBICACIONs { get; set; }

        internal DecimalFilter N_TERRENO { get; set; }
        internal ListFilter<Decimal> N_TERRENOs { get; set; }

        internal DecimalFilter N_CONSTRUCCION { get; set; }
        internal ListFilter<Decimal> N_CONSTRUCCIONs { get; set; }

        internal DecimalFilter M_VALOR_INMUEBLE { get; set; }
        internal ListFilter<Decimal> M_VALOR_INMUEBLEs { get; set; }

        internal IntegerFilter NID_PATRIMONIO { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.ALTA_INMUEBLE> query { get; set; }
        protected IQueryable<MODELDeclara_V2.ALTA_INMUEBLE> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_ALTA_INMUEBLE()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_INMUEBLEs = new ListFilter<Int32>();
            NID_TIPOs = new ListFilter<Int32>();
            F_ADQUISICIONs = new ListFilter<DateTime>();
            NID_USOs = new ListFilter<Int32>();
            E_UBICACIONs = new ListFilter<String>();
            N_TERRENOs = new ListFilter<Decimal>();
            N_CONSTRUCCIONs = new ListFilter<Decimal>();
            M_VALOR_INMUEBLEs = new ListFilter<Decimal>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.ALTA_INMUEBLE
                           select p;
        }

        protected void Select()
        {

            query = from qALTA_INMUEBLE in db.ALTA_INMUEBLE
                    join qCAT_TIPO_INMUEBLE in db.CAT_TIPO_INMUEBLE on qALTA_INMUEBLE.NID_TIPO
                                                                equals qCAT_TIPO_INMUEBLE.NID_TIPO
                    join qCAT_USO_INMUEBLE in db.CAT_USO_INMUEBLE on qALTA_INMUEBLE.NID_USO
                                                              equals qCAT_USO_INMUEBLE.NID_USO
                    select new Declara_V2.MODELextended.ALTA_INMUEBLE
                    {
                        VID_NOMBRE = qALTA_INMUEBLE.VID_NOMBRE,
                        VID_FECHA = qALTA_INMUEBLE.VID_FECHA,
                        VID_HOMOCLAVE = qALTA_INMUEBLE.VID_HOMOCLAVE,
                        NID_DECLARACION = qALTA_INMUEBLE.NID_DECLARACION,
                        NID_INMUEBLE = qALTA_INMUEBLE.NID_INMUEBLE,
                        NID_TIPO = qALTA_INMUEBLE.NID_TIPO,
                        F_ADQUISICION = qALTA_INMUEBLE.F_ADQUISICION,
                        NID_USO = qALTA_INMUEBLE.NID_USO,
                        E_UBICACION = qALTA_INMUEBLE.E_UBICACION,
                        N_TERRENO = qALTA_INMUEBLE.N_TERRENO,
                        N_CONSTRUCCION = qALTA_INMUEBLE.N_CONSTRUCCION,
                        M_VALOR_INMUEBLE = qALTA_INMUEBLE.M_VALOR_INMUEBLE,
                        NID_PATRIMONIO = qALTA_INMUEBLE.NID_PATRIMONIO,
                        V_TIPO = qCAT_TIPO_INMUEBLE.V_TIPO,
                        V_USO = qCAT_USO_INMUEBLE.V_USO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(VID_FECHA, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_INMUEBLEs.Count > 0) single_query =  (NID_INMUEBLEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INMUEBLEs.Contains(p.NID_INMUEBLE)) : single_query.Where(p => !NID_INMUEBLEs.Contains(p.NID_INMUEBLE));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(NID_INMUEBLE, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.NID_INMUEBLE.ToString(), single_query);

            if (NID_TIPOs.Count > 0) single_query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : single_query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(NID_TIPO, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.NID_TIPO.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(F_ADQUISICION, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.F_ADQUISICION.ToString(), single_query);

            if (NID_USOs.Count > 0) single_query =  (NID_USOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_USOs.Contains(p.NID_USO)) : single_query.Where(p => !NID_USOs.Contains(p.NID_USO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(NID_USO, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.NID_USO.ToString(), single_query);

            if (E_UBICACIONs.Count > 0) single_query =  (E_UBICACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_UBICACIONs.Contains(p.E_UBICACION)) : single_query.Where(p => !E_UBICACIONs.Contains(p.E_UBICACION));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(E_UBICACION, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.E_UBICACION.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(N_TERRENO, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.N_TERRENO.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(N_CONSTRUCCION, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.N_CONSTRUCCION.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(M_VALOR_INMUEBLE, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.M_VALOR_INMUEBLE.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE>(NID_PATRIMONIO, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.NID_PATRIMONIO.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(VID_FECHA, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.NID_DECLARACION.ToString(), query);

            if (NID_INMUEBLEs.Count > 0) query =  (NID_INMUEBLEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INMUEBLEs.Contains(p.NID_INMUEBLE)) : query.Where(p => !NID_INMUEBLEs.Contains(p.NID_INMUEBLE));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(NID_INMUEBLE, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.NID_INMUEBLE.ToString(), query);

            if (NID_TIPOs.Count > 0) query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(NID_TIPO, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.NID_TIPO.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(F_ADQUISICION, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.F_ADQUISICION.ToString(), query);

            if (NID_USOs.Count > 0) query =  (NID_USOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_USOs.Contains(p.NID_USO)) : query.Where(p => !NID_USOs.Contains(p.NID_USO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(NID_USO, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.NID_USO.ToString(), query);

            if (E_UBICACIONs.Count > 0) query =  (E_UBICACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_UBICACIONs.Contains(p.E_UBICACION)) : query.Where(p => !E_UBICACIONs.Contains(p.E_UBICACION));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(E_UBICACION, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.E_UBICACION.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(N_TERRENO, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.N_TERRENO.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(N_CONSTRUCCION, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.N_CONSTRUCCION.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(M_VALOR_INMUEBLE, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.M_VALOR_INMUEBLE.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE>(NID_PATRIMONIO, Declara_V2.MODELextended.ALTA_INMUEBLE.Properties.NID_PATRIMONIO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_ALTA_INMUEBLEs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_ALTA_INMUEBLEs = new List<MODELDeclara_V2.ALTA_INMUEBLE>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_ALTA_INMUEBLEs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_ALTA_INMUEBLEs = new List<Declara_V2.MODELextended.ALTA_INMUEBLE>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.ALTA_INMUEBLE> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x <OrderByCriterios.Count(); x++)
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
                IOrderedQueryable<Declara_V2.MODELextended.ALTA_INMUEBLE> r;
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
