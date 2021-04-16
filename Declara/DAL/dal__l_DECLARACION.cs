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
    internal class dal__l_DECLARACION : _dal_base_Declara
    {

        #region *** Atributos ***

        internal List<Declara_V2.MODELextended.DECLARACION> lista_DECLARACIONs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION> base_DECLARACIONs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal StringFilter C_EJERCICIO { get; set; }
        internal ListFilter<String> C_EJERCICIOs { get; set; }

        internal IntegerFilter NID_TIPO_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_TIPO_DECLARACIONs { get; set; }

        internal IntegerFilter NID_ESTADO { get; set; }
        internal ListFilter<Int32> NID_ESTADOs { get; set; }

        internal StringFilter E_OBSERVACIONES { get; set; }
        internal ListFilter<String> E_OBSERVACIONESs { get; set; }

        internal StringFilter E_OBSERVACIONES_MARCADO { get; set; }
        internal ListFilter<String> E_OBSERVACIONES_MARCADOs { get; set; }

        internal StringFilter V_OBSERVACIONES_TESTADO { get; set; }
        internal ListFilter<String> V_OBSERVACIONES_TESTADOs { get; set; }

        internal IntegerFilter NID_ESTADO_TESTADO { get; set; }
        internal ListFilter<Int32> NID_ESTADO_TESTADOs { get; set; }

        internal System.Nullable<Boolean> L_AUTORIZA_PUBLICAR { get; set; }
        internal ListFilter<Boolean> L_AUTORIZA_PUBLICARs { get; set; }

        internal DateTimeFilter F_REGISTRO { get; set; }
        internal ListFilter<DateTime> F_REGISTROs { get; set; }

        internal DateTimeFilter F_ENVIO { get; set; }
        internal ListFilter<DateTime> F_ENVIOs { get; set; }

        internal System.Nullable<Boolean> L_CONFLICTO { get; set; }
        internal ListFilter<Boolean> L_CONFLICTOs { get; set; }

        internal StringFilter V_HASH { get; set; }
        internal ListFilter<String> V_HASHs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.DECLARACION> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION> single_query { get; set; }


        #endregion


        #region *** Constructores ***

        internal dal__l_DECLARACION()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            C_EJERCICIOs = new ListFilter<String>();
            NID_TIPO_DECLARACIONs = new ListFilter<Int32>();
            NID_ESTADOs = new ListFilter<Int32>();
            E_OBSERVACIONESs = new ListFilter<String>();
            E_OBSERVACIONES_MARCADOs = new ListFilter<String>();
            V_OBSERVACIONES_TESTADOs = new ListFilter<String>();
            NID_ESTADO_TESTADOs = new ListFilter<Int32>();
            L_AUTORIZA_PUBLICARs = new ListFilter<Boolean>();
            F_REGISTROs = new ListFilter<DateTime>();
            F_ENVIOs = new ListFilter<DateTime>();
            L_CONFLICTOs = new ListFilter<Boolean>();
            V_HASHs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


        #endregion


        #region *** Metodos ***

        protected void Single_Select()
        {
            single_query = from p in db.DECLARACION
                           select p;
        }

        protected void Select()
        {

            query = from qDECLARACION in db.DECLARACION
                    join qCAT_ESTADO_DECLARACION in db.CAT_ESTADO_DECLARACION on qDECLARACION.NID_ESTADO
                                                                          equals qCAT_ESTADO_DECLARACION.NID_ESTADO
                    join qCAT_ESTADO_TESTADO in db.CAT_ESTADO_TESTADO on qDECLARACION.NID_ESTADO_TESTADO
                                                                  equals qCAT_ESTADO_TESTADO.NID_ESTADO_TESTADO
                    join qCAT_TIPO_DECLARACION in db.CAT_TIPO_DECLARACION on qDECLARACION.NID_TIPO_DECLARACION
                                                                      equals qCAT_TIPO_DECLARACION.NID_TIPO_DECLARACION
                    select new Declara_V2.MODELextended.DECLARACION
                    {
                        VID_NOMBRE = qDECLARACION.VID_NOMBRE,
                        VID_FECHA = qDECLARACION.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION.NID_DECLARACION,
                        C_EJERCICIO = qDECLARACION.C_EJERCICIO,
                        NID_TIPO_DECLARACION = qDECLARACION.NID_TIPO_DECLARACION,
                        NID_ESTADO = qDECLARACION.NID_ESTADO,
                        E_OBSERVACIONES = qDECLARACION.E_OBSERVACIONES,
                        E_OBSERVACIONES_MARCADO = qDECLARACION.E_OBSERVACIONES_MARCADO,
                        V_OBSERVACIONES_TESTADO = qDECLARACION.V_OBSERVACIONES_TESTADO,
                        NID_ESTADO_TESTADO = qDECLARACION.NID_ESTADO_TESTADO,
                        L_AUTORIZA_PUBLICAR = qDECLARACION.L_AUTORIZA_PUBLICAR,
                        F_REGISTRO = qDECLARACION.F_REGISTRO,
                        F_ENVIO = qDECLARACION.F_ENVIO,
                        L_CONFLICTO = qDECLARACION.L_CONFLICTO,
                        V_HASH = qDECLARACION.V_HASH,
                        V_ESTADO = qCAT_ESTADO_DECLARACION.V_ESTADO,
                        V_ESTADO_TESTADO = qCAT_ESTADO_TESTADO.V_ESTADO_TESTADO,
                        V_TIPO_DECLARACION = qCAT_TIPO_DECLARACION.V_TIPO_DECLARACION,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION>(VID_FECHA, Declara_V2.MODELextended.DECLARACION.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION.Properties.NID_DECLARACION.ToString(), single_query);

            if (C_EJERCICIOs.Count > 0) single_query = (C_EJERCICIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_EJERCICIOs.Contains(p.C_EJERCICIO)) : single_query.Where(p => !C_EJERCICIOs.Contains(p.C_EJERCICIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION>(C_EJERCICIO, Declara_V2.MODELextended.DECLARACION.Properties.C_EJERCICIO.ToString(), single_query);

            if (NID_TIPO_DECLARACIONs.Count > 0) single_query = (NID_TIPO_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_DECLARACIONs.Contains(p.NID_TIPO_DECLARACION)) : single_query.Where(p => !NID_TIPO_DECLARACIONs.Contains(p.NID_TIPO_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION>(NID_TIPO_DECLARACION, Declara_V2.MODELextended.DECLARACION.Properties.NID_TIPO_DECLARACION.ToString(), single_query);

            if (NID_ESTADOs.Count > 0) single_query = (NID_ESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADOs.Contains(p.NID_ESTADO)) : single_query.Where(p => !NID_ESTADOs.Contains(p.NID_ESTADO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION>(NID_ESTADO, Declara_V2.MODELextended.DECLARACION.Properties.NID_ESTADO.ToString(), single_query);

            if (E_OBSERVACIONESs.Count > 0) single_query = (E_OBSERVACIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_OBSERVACIONESs.Contains(p.E_OBSERVACIONES)) : single_query.Where(p => !E_OBSERVACIONESs.Contains(p.E_OBSERVACIONES));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION>(E_OBSERVACIONES, Declara_V2.MODELextended.DECLARACION.Properties.E_OBSERVACIONES.ToString(), single_query);

            if (E_OBSERVACIONES_MARCADOs.Count > 0) single_query = (E_OBSERVACIONES_MARCADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_OBSERVACIONES_MARCADOs.Contains(p.E_OBSERVACIONES_MARCADO)) : single_query.Where(p => !E_OBSERVACIONES_MARCADOs.Contains(p.E_OBSERVACIONES_MARCADO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION>(E_OBSERVACIONES_MARCADO, Declara_V2.MODELextended.DECLARACION.Properties.E_OBSERVACIONES_MARCADO.ToString(), single_query);

            if (V_OBSERVACIONES_TESTADOs.Count > 0) single_query = (V_OBSERVACIONES_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_OBSERVACIONES_TESTADOs.Contains(p.V_OBSERVACIONES_TESTADO)) : single_query.Where(p => !V_OBSERVACIONES_TESTADOs.Contains(p.V_OBSERVACIONES_TESTADO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION>(V_OBSERVACIONES_TESTADO, Declara_V2.MODELextended.DECLARACION.Properties.V_OBSERVACIONES_TESTADO.ToString(), single_query);

            if (NID_ESTADO_TESTADOs.Count > 0) single_query = (NID_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADO_TESTADOs.Contains(p.NID_ESTADO_TESTADO)) : single_query.Where(p => !NID_ESTADO_TESTADOs.Contains(p.NID_ESTADO_TESTADO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION>(NID_ESTADO_TESTADO, Declara_V2.MODELextended.DECLARACION.Properties.NID_ESTADO_TESTADO.ToString(), single_query);

            if (L_AUTORIZA_PUBLICAR.HasValue) single_query = single_query.Where<MODELDeclara_V2.DECLARACION>(p => p.L_AUTORIZA_PUBLICAR == L_AUTORIZA_PUBLICAR);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.DECLARACION>(F_REGISTRO, Declara_V2.MODELextended.DECLARACION.Properties.F_REGISTRO.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.DECLARACION>(F_ENVIO, Declara_V2.MODELextended.DECLARACION.Properties.F_ENVIO.ToString(), single_query);

            if (L_CONFLICTO.HasValue) single_query = single_query.Where<MODELDeclara_V2.DECLARACION>(p => p.L_CONFLICTO == L_CONFLICTO);

            if (V_HASHs.Count > 0) single_query = (V_HASHs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_HASHs.Contains(p.V_HASH)) : single_query.Where(p => !V_HASHs.Contains(p.V_HASH));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION>(V_HASH, Declara_V2.MODELextended.DECLARACION.Properties.V_HASH.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION>(VID_FECHA, Declara_V2.MODELextended.DECLARACION.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION.Properties.NID_DECLARACION.ToString(), query);

            if (C_EJERCICIOs.Count > 0) query = (C_EJERCICIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_EJERCICIOs.Contains(p.C_EJERCICIO)) : query.Where(p => !C_EJERCICIOs.Contains(p.C_EJERCICIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION>(C_EJERCICIO, Declara_V2.MODELextended.DECLARACION.Properties.C_EJERCICIO.ToString(), query);

            if (NID_TIPO_DECLARACIONs.Count > 0) query = (NID_TIPO_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_DECLARACIONs.Contains(p.NID_TIPO_DECLARACION)) : query.Where(p => !NID_TIPO_DECLARACIONs.Contains(p.NID_TIPO_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION>(NID_TIPO_DECLARACION, Declara_V2.MODELextended.DECLARACION.Properties.NID_TIPO_DECLARACION.ToString(), query);

            if (NID_ESTADOs.Count > 0) query = (NID_ESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADOs.Contains(p.NID_ESTADO)) : query.Where(p => !NID_ESTADOs.Contains(p.NID_ESTADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION>(NID_ESTADO, Declara_V2.MODELextended.DECLARACION.Properties.NID_ESTADO.ToString(), query);

            if (E_OBSERVACIONESs.Count > 0) query = (E_OBSERVACIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_OBSERVACIONESs.Contains(p.E_OBSERVACIONES)) : query.Where(p => !E_OBSERVACIONESs.Contains(p.E_OBSERVACIONES));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION>(E_OBSERVACIONES, Declara_V2.MODELextended.DECLARACION.Properties.E_OBSERVACIONES.ToString(), query);

            if (E_OBSERVACIONES_MARCADOs.Count > 0) query = (E_OBSERVACIONES_MARCADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_OBSERVACIONES_MARCADOs.Contains(p.E_OBSERVACIONES_MARCADO)) : query.Where(p => !E_OBSERVACIONES_MARCADOs.Contains(p.E_OBSERVACIONES_MARCADO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION>(E_OBSERVACIONES_MARCADO, Declara_V2.MODELextended.DECLARACION.Properties.E_OBSERVACIONES_MARCADO.ToString(), query);

            if (V_OBSERVACIONES_TESTADOs.Count > 0) query = (V_OBSERVACIONES_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_OBSERVACIONES_TESTADOs.Contains(p.V_OBSERVACIONES_TESTADO)) : query.Where(p => !V_OBSERVACIONES_TESTADOs.Contains(p.V_OBSERVACIONES_TESTADO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION>(V_OBSERVACIONES_TESTADO, Declara_V2.MODELextended.DECLARACION.Properties.V_OBSERVACIONES_TESTADO.ToString(), query);

            if (NID_ESTADO_TESTADOs.Count > 0) query = (NID_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADO_TESTADOs.Contains(p.NID_ESTADO_TESTADO)) : query.Where(p => !NID_ESTADO_TESTADOs.Contains(p.NID_ESTADO_TESTADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION>(NID_ESTADO_TESTADO, Declara_V2.MODELextended.DECLARACION.Properties.NID_ESTADO_TESTADO.ToString(), query);

            if (L_AUTORIZA_PUBLICAR.HasValue) query = query.Where<Declara_V2.MODELextended.DECLARACION>(p => p.L_AUTORIZA_PUBLICAR == L_AUTORIZA_PUBLICAR);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.DECLARACION>(F_REGISTRO, Declara_V2.MODELextended.DECLARACION.Properties.F_REGISTRO.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.DECLARACION>(F_ENVIO, Declara_V2.MODELextended.DECLARACION.Properties.F_ENVIO.ToString(), query);

            if (L_CONFLICTO.HasValue) query = query.Where<Declara_V2.MODELextended.DECLARACION>(p => p.L_CONFLICTO == L_CONFLICTO);

            if (V_HASHs.Count > 0) query = (V_HASHs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_HASHs.Contains(p.V_HASH)) : query.Where(p => !V_HASHs.Contains(p.V_HASH));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION>(V_HASH, Declara_V2.MODELextended.DECLARACION.Properties.V_HASH.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_DECLARACIONs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_DECLARACIONs = new List<MODELDeclara_V2.DECLARACION>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_DECLARACIONs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_DECLARACIONs = new List<Declara_V2.MODELextended.DECLARACION>();
            }
        }

        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x < OrderByCriterios.Count(); x++)
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION> r;
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
