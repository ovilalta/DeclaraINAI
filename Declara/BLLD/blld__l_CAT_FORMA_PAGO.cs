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
    public class blld__l_CAT_FORMA_PAGO : bll__l_CAT_FORMA_PAGO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_FORMA_PAGO.PageSize;
            set => datos_CAT_FORMA_PAGO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_FORMA_PAGO.PageNumber;
            set => datos_CAT_FORMA_PAGO.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_FORMA_PAGO.TotalPages;
        public Int32 TotalItems => datos_CAT_FORMA_PAGO.TotalItems;
        private List<blld_CAT_FORMA_PAGO> _CAT_FORMA_PAGOs { get; set; }
        public List<blld_CAT_FORMA_PAGO> CAT_FORMA_PAGOs
        {
            get
            {
                if (_CAT_FORMA_PAGOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_FORMA_PAGOs = new List<blld_CAT_FORMA_PAGO>();
                    foreach (MODELDeclara_V2.CAT_FORMA_PAGO o in base_CAT_FORMA_PAGOs)
                    {
                        _CAT_FORMA_PAGOs.Add(new blld_CAT_FORMA_PAGO(o));
                    }
                }
                return _CAT_FORMA_PAGOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_FORMA_PAGO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_FORMA_PAGO.single_select();
        }

        #endregion

    }
}
