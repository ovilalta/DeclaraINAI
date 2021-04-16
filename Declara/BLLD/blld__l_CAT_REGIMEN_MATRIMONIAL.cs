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
    public class blld__l_CAT_REGIMEN_MATRIMONIAL : bll__l_CAT_REGIMEN_MATRIMONIAL
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_REGIMEN_MATRIMONIAL.PageSize;
            set => datos_CAT_REGIMEN_MATRIMONIAL.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_REGIMEN_MATRIMONIAL.PageNumber;
            set => datos_CAT_REGIMEN_MATRIMONIAL.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_REGIMEN_MATRIMONIAL.TotalPages;
        public Int32 TotalItems => datos_CAT_REGIMEN_MATRIMONIAL.TotalItems;
        private List<blld_CAT_REGIMEN_MATRIMONIAL> _CAT_REGIMEN_MATRIMONIALs { get; set; }
        public List<blld_CAT_REGIMEN_MATRIMONIAL> CAT_REGIMEN_MATRIMONIALs
        {
            get
            {
                if (_CAT_REGIMEN_MATRIMONIALs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_REGIMEN_MATRIMONIALs = new List<blld_CAT_REGIMEN_MATRIMONIAL>();
                    foreach (MODELDeclara_V2.CAT_REGIMEN_MATRIMONIAL o in base_CAT_REGIMEN_MATRIMONIALs)
                    {
                        _CAT_REGIMEN_MATRIMONIALs.Add(new blld_CAT_REGIMEN_MATRIMONIAL(o));
                    }
                }
                return _CAT_REGIMEN_MATRIMONIALs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_REGIMEN_MATRIMONIAL() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_REGIMEN_MATRIMONIAL.single_select();
        }

        #endregion

    }
}
