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
    public  class blld__l_CAT_CODIGO_POSTAL : bll__l_CAT_CODIGO_POSTAL
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_CODIGO_POSTAL.PageSize;
            set => datos_CAT_CODIGO_POSTAL.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_CODIGO_POSTAL.PageNumber;
            set => datos_CAT_CODIGO_POSTAL.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_CODIGO_POSTAL.TotalPages;

        public Int32 TotalItems => datos_CAT_CODIGO_POSTAL.TotalItems;

        private List<blld_CAT_CODIGO_POSTAL> _CAT_CODIGO_POSTALs { get; set; }
        public List<blld_CAT_CODIGO_POSTAL> CAT_CODIGO_POSTALs
        {
            get
            {
                if (_CAT_CODIGO_POSTALs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_CODIGO_POSTALs = new List<blld_CAT_CODIGO_POSTAL>();
                    foreach (MODELDeclara_V2.CAT_CODIGO_POSTAL o in base_CAT_CODIGO_POSTALs)
                    {
                        _CAT_CODIGO_POSTALs.Add(new blld_CAT_CODIGO_POSTAL(o));
                    }
                }
                return _CAT_CODIGO_POSTALs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_CODIGO_POSTAL() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_CODIGO_POSTAL.single_select();
        }

     #endregion

    }
}
