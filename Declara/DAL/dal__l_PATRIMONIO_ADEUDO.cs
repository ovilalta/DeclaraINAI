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
    internal class dal__l_PATRIMONIO_ADEUDO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.PATRIMONIO_ADEUDO> lista_PATRIMONIO_ADEUDOs { get; set; }
        internal List<MODELDeclara_V2.PATRIMONIO_ADEUDO> base_PATRIMONIO_ADEUDOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_PATRIMONIO { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIOs { get; set; }

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


        protected IQueryable<Declara_V2.MODELextended.PATRIMONIO_ADEUDO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.PATRIMONIO_ADEUDO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_PATRIMONIO_ADEUDO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            V_LUGARs = new ListFilter<String>();
            NID_INSTITUCIONs = new ListFilter<Int32>();
            V_OTRAs = new ListFilter<String>();
            NID_TIPO_ADEUDOs = new ListFilter<Int32>();
            M_ORIGINALs = new ListFilter<Decimal>();
            M_SALDOs = new ListFilter<Decimal>();
            E_CUENTAs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.PATRIMONIO_ADEUDO
                           select p;
        }

        protected void Select()
        {

            query = from qPATRIMONIO_ADEUDO in db.PATRIMONIO_ADEUDO
                    join qCAT_ENTIDAD_FEDERATIVA in db.CAT_ENTIDAD_FEDERATIVA on new { qPATRIMONIO_ADEUDO.NID_PAIS, qPATRIMONIO_ADEUDO.CID_ENTIDAD_FEDERATIVA }
                                                                          equals new { qCAT_ENTIDAD_FEDERATIVA.NID_PAIS, qCAT_ENTIDAD_FEDERATIVA.CID_ENTIDAD_FEDERATIVA }
                    join qCAT_INST_FINANCIERA in db.CAT_INST_FINANCIERA on qPATRIMONIO_ADEUDO.NID_INSTITUCION
                                                                    equals qCAT_INST_FINANCIERA.NID_INSTITUCION
                    join qCAT_TIPO_ADEUDO in db.CAT_TIPO_ADEUDO on qPATRIMONIO_ADEUDO.NID_TIPO_ADEUDO
                                                            equals qCAT_TIPO_ADEUDO.NID_TIPO_ADEUDO
                    join qPATRIMONIO in db.PATRIMONIO on new { qPATRIMONIO_ADEUDO.VID_NOMBRE, qPATRIMONIO_ADEUDO.VID_FECHA, qPATRIMONIO_ADEUDO.VID_HOMOCLAVE, qPATRIMONIO_ADEUDO.NID_PATRIMONIO }
                                                  equals new { qPATRIMONIO.VID_NOMBRE, qPATRIMONIO.VID_FECHA, qPATRIMONIO.VID_HOMOCLAVE, qPATRIMONIO.NID_PATRIMONIO }
                    select new Declara_V2.MODELextended.PATRIMONIO_ADEUDO
                    {
                        VID_NOMBRE = qPATRIMONIO_ADEUDO.VID_NOMBRE,
                        VID_FECHA = qPATRIMONIO_ADEUDO.VID_FECHA,
                        VID_HOMOCLAVE = qPATRIMONIO_ADEUDO.VID_HOMOCLAVE,
                        NID_PATRIMONIO = qPATRIMONIO_ADEUDO.NID_PATRIMONIO,
                        NID_PAIS = qPATRIMONIO_ADEUDO.NID_PAIS,
                        CID_ENTIDAD_FEDERATIVA = qPATRIMONIO_ADEUDO.CID_ENTIDAD_FEDERATIVA,
                        V_LUGAR = qPATRIMONIO_ADEUDO.V_LUGAR,
                        NID_INSTITUCION = qPATRIMONIO_ADEUDO.NID_INSTITUCION,
                        V_OTRA = qPATRIMONIO_ADEUDO.V_OTRA,
                        NID_TIPO_ADEUDO = qPATRIMONIO_ADEUDO.NID_TIPO_ADEUDO,
                        M_ORIGINAL = qPATRIMONIO_ADEUDO.M_ORIGINAL,
                        M_SALDO = qPATRIMONIO_ADEUDO.M_SALDO,
                        E_CUENTA = qPATRIMONIO_ADEUDO.E_CUENTA,
                        V_ENTIDAD_FEDERATIVA = qCAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA,
                        V_INSTITUCION = qCAT_INST_FINANCIERA.V_INSTITUCION,
                        V_TIPO_ADEUDO = qCAT_TIPO_ADEUDO.V_TIPO_ADEUDO,
                        NID_TIPO = qPATRIMONIO.NID_TIPO,
                        M_VALOR = qPATRIMONIO.M_VALOR,
                        NID_DEC_INCOR = qPATRIMONIO.NID_DEC_INCOR,
                        F_INCORPORACION = qPATRIMONIO.F_INCORPORACION,
                        NID_DEC_ULT_MOD = qPATRIMONIO.NID_DEC_ULT_MOD,
                        F_MODIFICACION = qPATRIMONIO.F_MODIFICACION,
                        L_ACTIVO = qPATRIMONIO.L_ACTIVO,
                        F_REGISTRO = qPATRIMONIO.F_REGISTRO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(VID_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(VID_FECHA, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(VID_HOMOCLAVE, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(NID_PATRIMONIO, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.NID_PATRIMONIO.ToString(), single_query);

            if (NID_PAISs.Count > 0) single_query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(NID_PAIS, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.NID_PAIS.ToString(), single_query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) single_query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), single_query);

            if (V_LUGARs.Count > 0) single_query =  (V_LUGARs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_LUGARs.Contains(p.V_LUGAR)) : single_query.Where(p => !V_LUGARs.Contains(p.V_LUGAR));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(V_LUGAR, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.V_LUGAR.ToString(), single_query);

            if (NID_INSTITUCIONs.Count > 0) single_query =  (NID_INSTITUCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INSTITUCIONs.Contains(p.NID_INSTITUCION)) : single_query.Where(p => !NID_INSTITUCIONs.Contains(p.NID_INSTITUCION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(NID_INSTITUCION, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.NID_INSTITUCION.ToString(), single_query);

            if (V_OTRAs.Count > 0) single_query =  (V_OTRAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_OTRAs.Contains(p.V_OTRA)) : single_query.Where(p => !V_OTRAs.Contains(p.V_OTRA));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(V_OTRA, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.V_OTRA.ToString(), single_query);

            if (NID_TIPO_ADEUDOs.Count > 0) single_query =  (NID_TIPO_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO)) : single_query.Where(p => !NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(NID_TIPO_ADEUDO, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.NID_TIPO_ADEUDO.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(M_ORIGINAL, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.M_ORIGINAL.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(M_SALDO, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.M_SALDO.ToString(), single_query);

            if (E_CUENTAs.Count > 0) single_query =  (E_CUENTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_CUENTAs.Contains(p.E_CUENTA)) : single_query.Where(p => !E_CUENTAs.Contains(p.E_CUENTA));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_ADEUDO>(E_CUENTA, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.E_CUENTA.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(VID_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(VID_FECHA, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(VID_HOMOCLAVE, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(NID_PATRIMONIO, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.NID_PATRIMONIO.ToString(), query);

            if (NID_PAISs.Count > 0) query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(NID_PAIS, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.NID_PAIS.ToString(), query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), query);

            if (V_LUGARs.Count > 0) query =  (V_LUGARs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_LUGARs.Contains(p.V_LUGAR)) : query.Where(p => !V_LUGARs.Contains(p.V_LUGAR));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(V_LUGAR, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.V_LUGAR.ToString(), query);

            if (NID_INSTITUCIONs.Count > 0) query =  (NID_INSTITUCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INSTITUCIONs.Contains(p.NID_INSTITUCION)) : query.Where(p => !NID_INSTITUCIONs.Contains(p.NID_INSTITUCION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(NID_INSTITUCION, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.NID_INSTITUCION.ToString(), query);

            if (V_OTRAs.Count > 0) query =  (V_OTRAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_OTRAs.Contains(p.V_OTRA)) : query.Where(p => !V_OTRAs.Contains(p.V_OTRA));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(V_OTRA, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.V_OTRA.ToString(), query);

            if (NID_TIPO_ADEUDOs.Count > 0) query =  (NID_TIPO_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO)) : query.Where(p => !NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(NID_TIPO_ADEUDO, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.NID_TIPO_ADEUDO.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(M_ORIGINAL, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.M_ORIGINAL.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(M_SALDO, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.M_SALDO.ToString(), query);

            if (E_CUENTAs.Count > 0) query =  (E_CUENTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_CUENTAs.Contains(p.E_CUENTA)) : query.Where(p => !E_CUENTAs.Contains(p.E_CUENTA));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>(E_CUENTA, Declara_V2.MODELextended.PATRIMONIO_ADEUDO.Properties.E_CUENTA.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_PATRIMONIO_ADEUDOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_PATRIMONIO_ADEUDOs = new List<MODELDeclara_V2.PATRIMONIO_ADEUDO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_PATRIMONIO_ADEUDOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_PATRIMONIO_ADEUDOs = new List<Declara_V2.MODELextended.PATRIMONIO_ADEUDO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.PATRIMONIO_ADEUDO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.PATRIMONIO_ADEUDO> r;
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
