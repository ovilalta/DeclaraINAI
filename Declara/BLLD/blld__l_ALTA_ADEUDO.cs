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
    public  class blld__l_ALTA_ADEUDO : bll__l_ALTA_ADEUDO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_ALTA_ADEUDO.PageSize;
            set => datos_ALTA_ADEUDO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_ALTA_ADEUDO.PageNumber;
            set => datos_ALTA_ADEUDO.PageNumber = value;
        }

        public Int32 TotalPages => datos_ALTA_ADEUDO.TotalPages;

        public Int32 TotalItems => datos_ALTA_ADEUDO.TotalItems;

        private List<blld_ALTA_ADEUDO> _ALTA_ADEUDOs { get; set; }
        public List<blld_ALTA_ADEUDO> ALTA_ADEUDOs
        {
            get
            {
                if (_ALTA_ADEUDOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_ADEUDOs = new List<blld_ALTA_ADEUDO>();
                    foreach (MODELDeclara_V2.ALTA_ADEUDO o in base_ALTA_ADEUDOs)
                    {
                        _ALTA_ADEUDOs.Add(new blld_ALTA_ADEUDO(o));
                    }
                }
                return _ALTA_ADEUDOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_ALTA_ADEUDO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_ADEUDO.single_select();
        }

     #endregion

    }
}
