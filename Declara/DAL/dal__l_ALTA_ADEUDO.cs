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
    internal class dal__l_ALTA_ADEUDO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.ALTA_ADEUDO> lista_ALTA_ADEUDOs { get; set; }
        internal List<MODELDeclara_V2.ALTA_ADEUDO> base_ALTA_ADEUDOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_ADEUDO { get; set; }
        internal ListFilter<Int32> NID_ADEUDOs { get; set; }

        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

        internal StringFilter CID_ENTIDAD_FEDERATIVA { get; set; }
        internal ListFilter<String> CID_ENTIDAD_FEDERATIVAs { get; set; }

        internal StringFilter V_LUGAR { get; set; }
        internal ListFilter<String> V_LUGARs { get; set; }

        internal IntegerFilter NID_INSTITUCION { get; set; }
        internal ListFilter<Int32> NID_INSTITUCIONs { get; set; }

        internal StringFilter V_OTRA { get; set; }
        internal ListFilter<String> V_OTRAs { get; set; }

        internal IntegerFilter NID_TIPO_ADEUDO { get; set; }
        internal ListFilter<Int32> NID_TIPO_ADEUDOs { get; set; }

        internal DecimalFilter M_ORIGINAL { get; set; }
        internal ListFilter<Decimal> M_ORIGINALs { get; set; }

        internal DecimalFilter M_SALDO { get; set; }
        internal ListFilter<Decimal> M_SALDOs { get; set; }

        internal StringFilter E_CUENTA { get; set; }
        internal ListFilter<String> E_CUENTAs { get; set; }

        internal System.Nullable<Boolean> L_AUTOGENERADO { get; set; }
        internal ListFilter<Boolean> L_AUTOGENERADOs { get; set; }

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


        protected IQueryable<Declara_V2.MODELextended.ALTA_ADEUDO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.ALTA_ADEUDO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_ALTA_ADEUDO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_ADEUDOs = new ListFilter<Int32>();
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            V_LUGARs = new ListFilter<String>();
            NID_INSTITUCIONs = new ListFilter<Int32>();
            V_OTRAs = new ListFilter<String>();
            NID_TIPO_ADEUDOs = new ListFilter<Int32>();
            M_ORIGINALs = new ListFilter<Decimal>();
            M_SALDOs = new ListFilter<Decimal>();
            E_CUENTAs = new ListFilter<String>();
            L_AUTOGENERADOs = new ListFilter<Boolean>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.ALTA_ADEUDO
                           select p;
        }

        protected void Select()
        {

            query = from qALTA_ADEUDO in db.ALTA_ADEUDO
                    join qCAT_ENTIDAD_FEDERATIVA in db.CAT_ENTIDAD_FEDERATIVA on new { qALTA_ADEUDO.NID_PAIS, qALTA_ADEUDO.CID_ENTIDAD_FEDERATIVA }
                                                                          equals new { qCAT_ENTIDAD_FEDERATIVA.NID_PAIS, qCAT_ENTIDAD_FEDERATIVA.CID_ENTIDAD_FEDERATIVA }
                    join qCAT_INST_FINANCIERA in db.CAT_INST_FINANCIERA on qALTA_ADEUDO.NID_INSTITUCION
                                                                    equals qCAT_INST_FINANCIERA.NID_INSTITUCION
                    join qCAT_TIPO_ADEUDO in db.CAT_TIPO_ADEUDO on qALTA_ADEUDO.NID_TIPO_ADEUDO
                                                            equals qCAT_TIPO_ADEUDO.NID_TIPO_ADEUDO
                    select new Declara_V2.MODELextended.ALTA_ADEUDO
                    {
                        VID_NOMBRE = qALTA_ADEUDO.VID_NOMBRE,
                        VID_FECHA = qALTA_ADEUDO.VID_FECHA,
                        VID_HOMOCLAVE = qALTA_ADEUDO.VID_HOMOCLAVE,
                        NID_DECLARACION = qALTA_ADEUDO.NID_DECLARACION,
                        NID_ADEUDO = qALTA_ADEUDO.NID_ADEUDO,
                        NID_PAIS = qALTA_ADEUDO.NID_PAIS,
                        CID_ENTIDAD_FEDERATIVA = qALTA_ADEUDO.CID_ENTIDAD_FEDERATIVA,
                        V_LUGAR = qALTA_ADEUDO.V_LUGAR,
                        NID_INSTITUCION = qALTA_ADEUDO.NID_INSTITUCION,
                        V_OTRA = qALTA_ADEUDO.V_OTRA,
                        NID_TIPO_ADEUDO = qALTA_ADEUDO.NID_TIPO_ADEUDO,
                        M_ORIGINAL = qALTA_ADEUDO.M_ORIGINAL,
                        M_SALDO = qALTA_ADEUDO.M_SALDO,
                        E_CUENTA = qALTA_ADEUDO.E_CUENTA,
                        L_AUTOGENERADO = qALTA_ADEUDO.L_AUTOGENERADO,
                        NID_PATRIMONIO = qALTA_ADEUDO.NID_PATRIMONIO,
                        V_ENTIDAD_FEDERATIVA = qCAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA,
                        V_INSTITUCION = qCAT_INST_FINANCIERA.V_INSTITUCION,
                        V_TIPO_ADEUDO = qCAT_TIPO_ADEUDO.V_TIPO_ADEUDO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(VID_FECHA, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_ADEUDOs.Count > 0) single_query =  (NID_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ADEUDOs.Contains(p.NID_ADEUDO)) : single_query.Where(p => !NID_ADEUDOs.Contains(p.NID_ADEUDO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(NID_ADEUDO, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_ADEUDO.ToString(), single_query);

            if (NID_PAISs.Count > 0) single_query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(NID_PAIS, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_PAIS.ToString(), single_query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) single_query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), single_query);

            if (V_LUGARs.Count > 0) single_query =  (V_LUGARs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_LUGARs.Contains(p.V_LUGAR)) : single_query.Where(p => !V_LUGARs.Contains(p.V_LUGAR));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(V_LUGAR, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.V_LUGAR.ToString(), single_query);

            if (NID_INSTITUCIONs.Count > 0) single_query =  (NID_INSTITUCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INSTITUCIONs.Contains(p.NID_INSTITUCION)) : single_query.Where(p => !NID_INSTITUCIONs.Contains(p.NID_INSTITUCION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(NID_INSTITUCION, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_INSTITUCION.ToString(), single_query);

            if (V_OTRAs.Count > 0) single_query =  (V_OTRAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_OTRAs.Contains(p.V_OTRA)) : single_query.Where(p => !V_OTRAs.Contains(p.V_OTRA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(V_OTRA, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.V_OTRA.ToString(), single_query);

            if (NID_TIPO_ADEUDOs.Count > 0) single_query =  (NID_TIPO_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO)) : single_query.Where(p => !NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(NID_TIPO_ADEUDO, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_TIPO_ADEUDO.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(M_ORIGINAL, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.M_ORIGINAL.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(M_SALDO, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.M_SALDO.ToString(), single_query);

            if (E_CUENTAs.Count > 0) single_query =  (E_CUENTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_CUENTAs.Contains(p.E_CUENTA)) : single_query.Where(p => !E_CUENTAs.Contains(p.E_CUENTA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(E_CUENTA, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.E_CUENTA.ToString(), single_query);

            if (L_AUTOGENERADO.HasValue) single_query = single_query.Where<MODELDeclara_V2.ALTA_ADEUDO>(p => p.L_AUTOGENERADO == L_AUTOGENERADO );

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_ADEUDO>(NID_PATRIMONIO, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_PATRIMONIO.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(VID_FECHA, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_DECLARACION.ToString(), query);

            if (NID_ADEUDOs.Count > 0) query =  (NID_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ADEUDOs.Contains(p.NID_ADEUDO)) : query.Where(p => !NID_ADEUDOs.Contains(p.NID_ADEUDO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(NID_ADEUDO, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_ADEUDO.ToString(), query);

            if (NID_PAISs.Count > 0) query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(NID_PAIS, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_PAIS.ToString(), query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), query);

            if (V_LUGARs.Count > 0) query =  (V_LUGARs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_LUGARs.Contains(p.V_LUGAR)) : query.Where(p => !V_LUGARs.Contains(p.V_LUGAR));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(V_LUGAR, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.V_LUGAR.ToString(), query);

            if (NID_INSTITUCIONs.Count > 0) query =  (NID_INSTITUCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INSTITUCIONs.Contains(p.NID_INSTITUCION)) : query.Where(p => !NID_INSTITUCIONs.Contains(p.NID_INSTITUCION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(NID_INSTITUCION, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_INSTITUCION.ToString(), query);

            if (V_OTRAs.Count > 0) query =  (V_OTRAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_OTRAs.Contains(p.V_OTRA)) : query.Where(p => !V_OTRAs.Contains(p.V_OTRA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(V_OTRA, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.V_OTRA.ToString(), query);

            if (NID_TIPO_ADEUDOs.Count > 0) query =  (NID_TIPO_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO)) : query.Where(p => !NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(NID_TIPO_ADEUDO, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_TIPO_ADEUDO.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(M_ORIGINAL, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.M_ORIGINAL.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(M_SALDO, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.M_SALDO.ToString(), query);

            if (E_CUENTAs.Count > 0) query =  (E_CUENTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_CUENTAs.Contains(p.E_CUENTA)) : query.Where(p => !E_CUENTAs.Contains(p.E_CUENTA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(E_CUENTA, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.E_CUENTA.ToString(), query);

            if (L_AUTOGENERADO.HasValue) query = query.Where<Declara_V2.MODELextended.ALTA_ADEUDO>(p => p.L_AUTOGENERADO == L_AUTOGENERADO );

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_ADEUDO>(NID_PATRIMONIO, Declara_V2.MODELextended.ALTA_ADEUDO.Properties.NID_PATRIMONIO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_ALTA_ADEUDOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_ALTA_ADEUDOs = new List<MODELDeclara_V2.ALTA_ADEUDO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_ALTA_ADEUDOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_ALTA_ADEUDOs = new List<Declara_V2.MODELextended.ALTA_ADEUDO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.ALTA_ADEUDO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.ALTA_ADEUDO> r;
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
