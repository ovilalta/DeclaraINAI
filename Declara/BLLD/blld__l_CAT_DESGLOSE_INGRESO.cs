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
    public class blld__l_CAT_DESGLOSE_INGRESO : bll__l_CAT_DESGLOSE_INGRESO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_DESGLOSE_INGRESO.PageSize;
            set => datos_CAT_DESGLOSE_INGRESO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_DESGLOSE_INGRESO.PageNumber;
            set => datos_CAT_DESGLOSE_INGRESO.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_DESGLOSE_INGRESO.TotalPages;
        public Int32 TotalItems => datos_CAT_DESGLOSE_INGRESO.TotalItems;
        private List<blld_CAT_DESGLOSE_INGRESO> _CAT_DESGLOSE_INGRESOs { get; set; }
        public List<blld_CAT_DESGLOSE_INGRESO> CAT_DESGLOSE_INGRESOs
        {
            get
            {
                if (_CAT_DESGLOSE_INGRESOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_DESGLOSE_INGRESOs = new List<blld_CAT_DESGLOSE_INGRESO>();
                    foreach (MODELDeclara_V2.CAT_DESGLOSE_INGRESO o in base_CAT_DESGLOSE_INGRESOs)
                    {
                        _CAT_DESGLOSE_INGRESOs.Add(new blld_CAT_DESGLOSE_INGRESO(o));
                    }
                }
                return _CAT_DESGLOSE_INGRESOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_DESGLOSE_INGRESO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_DESGLOSE_INGRESO.single_select();
        }

        #endregion

    }
}
