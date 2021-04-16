using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2;
using Declara_V2.DAL;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace Declara_V2.DALD
{
    // Extended
    internal partial class dald_ALTA_ADEUDO : dal_ALTA_ADEUDO
    {

        #region *** Atributos (Extended) ***

        protected ALTA_ADEUDO_PAGOS registro_pagos;

        public Decimal M_PAGOS
        {
            get
            {
                if (registro_pagos == null)
                {
                    registro_pagos = db.ALTA_ADEUDO_PAGOS.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO);
                    if (registro_pagos == null)
                        return 0;
                }
                return registro_pagos.M_PAGOS;
            }
            set
            {
                if (registro_pagos == null) SavePagos(value);
                else registro_pagos.M_PAGOS = value;
            }
        }

        internal dald_CAT_PAIS oPais;
        internal dald_CAT_ENTIDAD_FEDERATIVA oEntidad;
        internal string V_PAIS
        {
            get
            {
                if (oPais == null)
                    oPais = new dald_CAT_PAIS(NID_PAIS);
                return oPais.V_PAIS;
            }
        }
        internal string V_ENTIDAD_FEDERATIVA
        {
            get
            {
                if (oEntidad == null)
                    oEntidad = new dald_CAT_ENTIDAD_FEDERATIVA(NID_PAIS, CID_ENTIDAD_FEDERATIVA);
                return oEntidad.V_ENTIDAD_FEDERATIVA;
            }
        }

        #endregion


        #region *** Constructores (Extended) ***

        public dald_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, List<Int32> ListaTitulares, Int32 NID, Int16 NID_TIPO_BIEN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
       : base()
        {
            ObjectParameter NID_ADEUDOX = new ObjectParameter("NID_ADEUDO", typeof(int));
            if (NID_TIPO_ADEUDO == 3)
            {
                db.paALTA_INMUEBLE_ADEUDO(
                                          VID_NOMBRE
                                         , VID_FECHA
                                         , VID_HOMOCLAVE
                                         , NID_DECLARACION
                                         , NID
                                         , NID_PAIS
                                         , CID_ENTIDAD_FEDERATIVA
                                         , V_LUGAR
                                         , NID_INSTITUCION
                                         , V_OTRA
                                         , NID_TIPO_ADEUDO
                                         , F_ADEUDO
                                         , M_ORIGINAL
                                         , M_SALDO
                                         , E_CUENTA
                                         , String.Join("|", ListaTitulares)
                                         , NID_ADEUDOX
                                         
                                         );
            }
            else if (NID_TIPO_ADEUDO == 2)
            {
                db.paALTA_VEHICULO_ADEUDO(
                                         VID_NOMBRE
                                        , VID_FECHA
                                        , VID_HOMOCLAVE
                                        , NID_DECLARACION
                                        , NID
                                        , NID_PAIS
                                        , CID_ENTIDAD_FEDERATIVA
                                        , V_LUGAR
                                        , NID_INSTITUCION
                                        , V_OTRA
                                        , NID_TIPO_ADEUDO
                                        , F_ADEUDO
                                        , M_ORIGINAL
                                        , M_SALDO
                                        , E_CUENTA
                                        , String.Join("|", ListaTitulares)
                                        , NID_ADEUDOX
                                        );
            }
            else
            {
                if (NID_TIPO_BIEN == 1)
                {
                    db.paALTA_INMUEBLE_ADEUDO(
                                         VID_NOMBRE
                                        , VID_FECHA
                                        , VID_HOMOCLAVE
                                        , NID_DECLARACION
                                        , NID
                                        , NID_PAIS
                                        , CID_ENTIDAD_FEDERATIVA
                                        , V_LUGAR
                                        , NID_INSTITUCION
                                        , V_OTRA
                                        , NID_TIPO_ADEUDO
                                        , F_ADEUDO
                                        , M_ORIGINAL
                                        , M_SALDO
                                        , E_CUENTA
                                        , String.Join("|", ListaTitulares)
                                        , NID_ADEUDOX
                                        );
                }
                else if (NID_TIPO_BIEN == 2)
                {
                    db.paALTA_VEHICULO_ADEUDO(
                                           VID_NOMBRE
                                          , VID_FECHA
                                          , VID_HOMOCLAVE
                                          , NID_DECLARACION
                                          , NID
                                          , NID_PAIS
                                          , CID_ENTIDAD_FEDERATIVA
                                          , V_LUGAR
                                          , NID_INSTITUCION
                                          , V_OTRA
                                          , NID_TIPO_ADEUDO
                                          , F_ADEUDO
                                          , M_ORIGINAL
                                          , M_SALDO
                                          , E_CUENTA
                                          , String.Join("|", ListaTitulares)
                                          , NID_ADEUDOX
                                          );
                }
            }
            registro = db.ALTA_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDOX.Value); if (registro == null) throw new RowNotFoundException();
        }

        public dald_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, Decimal M_PAGOS, List<Int32> ListaTitulares, Int32 NID, Int16 NID_TIPO_BIEN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
         : this(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO, F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, ListaTitulares, NID, NID_TIPO_BIEN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
            SavePagos(M_PAGOS);
        }



        public dald_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, String V_TIPO_MONEDA, String E_RFC, String E_OBSERVACIONES, String CID_TIPO_PERSONA_OTORGANTE, Decimal M_PAGOS, Boolean L_AUTOGENERADO, Int32 NID_PATRIMONIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
: base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO, F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, V_TIPO_MONEDA, E_RFC, E_OBSERVACIONES, CID_TIPO_PERSONA_OTORGANTE, L_AUTOGENERADO, NID_PATRIMONIO, lOpcionesRegistroExistente)
        {
            SavePagos(M_PAGOS);
        }

        private void SavePagos(Decimal M_PAGOS)
        {
            registro_pagos = new ALTA_ADEUDO_PAGOS()
            {
                VID_NOMBRE = this.VID_NOMBRE,
                VID_FECHA = this.VID_FECHA,
                VID_HOMOCLAVE = this.VID_HOMOCLAVE,
                NID_DECLARACION = this.NID_DECLARACION,
                NID_ADEUDO = this.NID_ADEUDO,
                M_PAGOS = M_PAGOS,
            };
            try
            {
                db.ALTA_ADEUDO_PAGOS.Add(registro_pagos);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                registro_pagos = null;
                throw ex;
            }
        }

        #endregion


        #region *** Metodos (Extended) ***

        internal static int nNuevo_NID_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in db.ALTA_ADEUDO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p.NID_ADEUDO).Max());
                return query + 1;
            }
            catch
            {
                return 1;
            }
        }

        new public void delete()
        {
            db.paADEUDO_ELIMINA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO);
        }

        new internal void update()
        {
            if (registro_pagos != null)
            {
                if (db.Entry(registro).State == EntityState.Modified || db.Entry(registro_pagos).State == EntityState.Modified)
                {
                    db.SaveChanges();
                    _lEsNuevoRegistro = false;
                }
            }
            else
            {
                db.SaveChanges();
                _lEsNuevoRegistro = false;
            }
        }
        #endregion

    }
}
