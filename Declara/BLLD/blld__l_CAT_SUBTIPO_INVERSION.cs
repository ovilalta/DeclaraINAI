using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public  class blld__l_CAT_SUBTIPO_INVERSION : bll__l_CAT_SUBTIPO_INVERSION
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_SUBTIPO_INVERSION.PageSize;
            set => datos_CAT_SUBTIPO_INVERSION.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_SUBTIPO_INVERSION.PageNumber;
            set => datos_CAT_SUBTIPO_INVERSION.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_SUBTIPO_INVERSION.TotalPages;

        public Int32 TotalItems => datos_CAT_SUBTIPO_INVERSION.TotalItems;

        private List<blld_CAT_SUBTIPO_INVERSION> _CAT_SUBTIPO_INVERSIONs { get; set; }
        public List<blld_CAT_SUBTIPO_INVERSION> CAT_SUBTIPO_INVERSIONs
        {
            get
            {
                if (_CAT_SUBTIPO_INVERSIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_SUBTIPO_INVERSIONs = new List<blld_CAT_SUBTIPO_INVERSION>();
                    foreach (MODELDeclara_V2.CAT_SUBTIPO_INVERSION o in base_CAT_SUBTIPO_INVERSIONs)
                    {
                        _CAT_SUBTIPO_INVERSIONs.Add(new blld_CAT_SUBTIPO_INVERSION(o));
                    }
                }
                return _CAT_SUBTIPO_INVERSIONs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_SUBTIPO_INVERSION() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_SUBTIPO_INVERSION.single_select();
        }

     #endregion

    }
}
