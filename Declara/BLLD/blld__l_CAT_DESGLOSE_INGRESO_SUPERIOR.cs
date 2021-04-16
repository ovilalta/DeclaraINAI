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
    public class blld__l_CAT_DESGLOSE_INGRESO_SUPERIOR : bll__l_CAT_DESGLOSE_INGRESO_SUPERIOR
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.PageSize;
            set => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.PageNumber;
            set => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.TotalPages;
        public Int32 TotalItems => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.TotalItems;
        private List<blld_CAT_DESGLOSE_INGRESO_SUPERIOR> _CAT_DESGLOSE_INGRESO_SUPERIORs { get; set; }
        public List<blld_CAT_DESGLOSE_INGRESO_SUPERIOR> CAT_DESGLOSE_INGRESO_SUPERIORs
        {
            get
            {
                if (_CAT_DESGLOSE_INGRESO_SUPERIORs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_DESGLOSE_INGRESO_SUPERIORs = new List<blld_CAT_DESGLOSE_INGRESO_SUPERIOR>();
                    foreach (MODELDeclara_V2.CAT_DESGLOSE_INGRESO_SUPERIOR o in base_CAT_DESGLOSE_INGRESO_SUPERIORs)
                    {
                        _CAT_DESGLOSE_INGRESO_SUPERIORs.Add(new blld_CAT_DESGLOSE_INGRESO_SUPERIOR(o));
                    }
                }
                return _CAT_DESGLOSE_INGRESO_SUPERIORs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_DESGLOSE_INGRESO_SUPERIOR() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_DESGLOSE_INGRESO_SUPERIOR.single_select();
        }

        #endregion

    }
}
