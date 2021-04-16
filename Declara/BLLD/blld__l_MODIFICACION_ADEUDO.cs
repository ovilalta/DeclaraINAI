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
    public  class blld__l_MODIFICACION_ADEUDO : bll__l_MODIFICACION_ADEUDO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_ADEUDO.PageSize;
            set => datos_MODIFICACION_ADEUDO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_ADEUDO.PageNumber;
            set => datos_MODIFICACION_ADEUDO.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_ADEUDO.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_ADEUDO.TotalItems;

        private List<blld_MODIFICACION_ADEUDO> _MODIFICACION_ADEUDOs { get; set; }
        public List<blld_MODIFICACION_ADEUDO> MODIFICACION_ADEUDOs
        {
            get
            {
                if (_MODIFICACION_ADEUDOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_ADEUDOs = new List<blld_MODIFICACION_ADEUDO>();
                    foreach (MODELDeclara_V2.MODIFICACION_ADEUDO o in base_MODIFICACION_ADEUDOs)
                    {
                        _MODIFICACION_ADEUDOs.Add(new blld_MODIFICACION_ADEUDO(o));
                    }
                }
                return _MODIFICACION_ADEUDOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_ADEUDO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_ADEUDO.single_select();
        }

     #endregion

    }
}
