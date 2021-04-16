using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public class blld__l_CAT_SECCION_INGRESO : bll__l_CAT_SECCION_INGRESO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_SECCION_INGRESO.PageSize;
            set => datos_CAT_SECCION_INGRESO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_SECCION_INGRESO.PageNumber;
            set => datos_CAT_SECCION_INGRESO.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_SECCION_INGRESO.TotalPages;
        public Int32 TotalItems => datos_CAT_SECCION_INGRESO.TotalItems;
        private List<blld_CAT_SECCION_INGRESO> _CAT_SECCION_INGRESOs { get; set; }
        public List<blld_CAT_SECCION_INGRESO> CAT_SECCION_INGRESOs
        {
            get
            {
                if (_CAT_SECCION_INGRESOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_SECCION_INGRESOs = new List<blld_CAT_SECCION_INGRESO>();
                    foreach (MODELDeclara_V2.CAT_SECCION_INGRESO o in base_CAT_SECCION_INGRESOs)
                    {
                        _CAT_SECCION_INGRESOs.Add(new blld_CAT_SECCION_INGRESO(o));
                    }
                }
                return _CAT_SECCION_INGRESOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_SECCION_INGRESO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_SECCION_INGRESO.single_select();
        }

        #endregion

    }
}
