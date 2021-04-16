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
    public  class blld__l_CAT_TIPO_ADEUDO : bll__l_CAT_TIPO_ADEUDO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_TIPO_ADEUDO.PageSize;
            set => datos_CAT_TIPO_ADEUDO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_TIPO_ADEUDO.PageNumber;
            set => datos_CAT_TIPO_ADEUDO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_TIPO_ADEUDO.TotalPages;

        public Int32 TotalItems => datos_CAT_TIPO_ADEUDO.TotalItems;

        private List<blld_CAT_TIPO_ADEUDO> _CAT_TIPO_ADEUDOs { get; set; }
        public List<blld_CAT_TIPO_ADEUDO> CAT_TIPO_ADEUDOs
        {
            get
            {
                if (_CAT_TIPO_ADEUDOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_TIPO_ADEUDOs = new List<blld_CAT_TIPO_ADEUDO>();
                    foreach (MODELDeclara_V2.CAT_TIPO_ADEUDO o in base_CAT_TIPO_ADEUDOs)
                    {
                        _CAT_TIPO_ADEUDOs.Add(new blld_CAT_TIPO_ADEUDO(o));
                    }
                }
                return _CAT_TIPO_ADEUDOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_TIPO_ADEUDO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_TIPO_ADEUDO.single_select();
        }

     #endregion

    }
}
