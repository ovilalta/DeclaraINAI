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
    public  class blld__l_CAT_TIPS : bll__l_CAT_TIPS
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_TIPS.PageSize;
            set => datos_CAT_TIPS.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_TIPS.PageNumber;
            set => datos_CAT_TIPS.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_TIPS.TotalPages;

        public Int32 TotalItems => datos_CAT_TIPS.TotalItems;

        private List<blld_CAT_TIPS> _CAT_TIPSs { get; set; }
        public List<blld_CAT_TIPS> CAT_TIPSs
        {
            get
            {
                if (_CAT_TIPSs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_TIPSs = new List<blld_CAT_TIPS>();
                    foreach (MODELDeclara_V2.CAT_TIPS o in base_CAT_TIPSs)
                    {
                        _CAT_TIPSs.Add(new blld_CAT_TIPS(o));
                    }
                }
                return _CAT_TIPSs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_TIPS() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_TIPS.single_select();
        }

     #endregion

    }
}
