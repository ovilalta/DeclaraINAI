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
    public  class blld__l_PATRIMONIO_ADEUDO : bll__l_PATRIMONIO_ADEUDO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_PATRIMONIO_ADEUDO.PageSize;
            set => datos_PATRIMONIO_ADEUDO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_PATRIMONIO_ADEUDO.PageNumber;
            set => datos_PATRIMONIO_ADEUDO.PageNumber = value;
        }

        public Int32 TotalPages => datos_PATRIMONIO_ADEUDO.TotalPages;

        public Int32 TotalItems => datos_PATRIMONIO_ADEUDO.TotalItems;

        private List<blld_PATRIMONIO_ADEUDO> _PATRIMONIO_ADEUDOs { get; set; }
        public List<blld_PATRIMONIO_ADEUDO> PATRIMONIO_ADEUDOs
        {
            get
            {
                if (_PATRIMONIO_ADEUDOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _PATRIMONIO_ADEUDOs = new List<blld_PATRIMONIO_ADEUDO>();
                    foreach (MODELDeclara_V2.PATRIMONIO_ADEUDO o in base_PATRIMONIO_ADEUDOs)
                    {
                        _PATRIMONIO_ADEUDOs.Add(new blld_PATRIMONIO_ADEUDO(o));
                    }
                }
                return _PATRIMONIO_ADEUDOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_PATRIMONIO_ADEUDO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_PATRIMONIO_ADEUDO.single_select();
        }

     #endregion

    }
}
