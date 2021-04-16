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
    public  class blld__l_ALTA : bll__l_ALTA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_ALTA.PageSize;
            set => datos_ALTA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_ALTA.PageNumber;
            set => datos_ALTA.PageNumber = value;
        }

        public Int32 TotalPages => datos_ALTA.TotalPages;

        public Int32 TotalItems => datos_ALTA.TotalItems;

        private List<blld_ALTA> _ALTAs { get; set; }
        public List<blld_ALTA> ALTAs
        {
            get
            {
                if (_ALTAs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTAs = new List<blld_ALTA>();
                    foreach (MODELDeclara_V2.ALTA o in base_ALTAs)
                    {
                        _ALTAs.Add(new blld_ALTA(o));
                    }
                }
                return _ALTAs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_ALTA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA.single_select();
        }

     #endregion

    }
}
