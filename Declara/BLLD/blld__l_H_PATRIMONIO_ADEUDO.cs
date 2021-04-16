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
    public  class blld__l_H_PATRIMONIO_ADEUDO : bll__l_H_PATRIMONIO_ADEUDO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_H_PATRIMONIO_ADEUDO.PageSize;
            set => datos_H_PATRIMONIO_ADEUDO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_H_PATRIMONIO_ADEUDO.PageNumber;
            set => datos_H_PATRIMONIO_ADEUDO.PageNumber = value;
        }

        public Int32 TotalPages => datos_H_PATRIMONIO_ADEUDO.TotalPages;

        public Int32 TotalItems => datos_H_PATRIMONIO_ADEUDO.TotalItems;

        private List<blld_H_PATRIMONIO_ADEUDO> _H_PATRIMONIO_ADEUDOs { get; set; }
        public List<blld_H_PATRIMONIO_ADEUDO> H_PATRIMONIO_ADEUDOs
        {
            get
            {
                if (_H_PATRIMONIO_ADEUDOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _H_PATRIMONIO_ADEUDOs = new List<blld_H_PATRIMONIO_ADEUDO>();
                    foreach (MODELDeclara_V2.H_PATRIMONIO_ADEUDO o in base_H_PATRIMONIO_ADEUDOs)
                    {
                        _H_PATRIMONIO_ADEUDOs.Add(new blld_H_PATRIMONIO_ADEUDO(o));
                    }
                }
                return _H_PATRIMONIO_ADEUDOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_H_PATRIMONIO_ADEUDO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_H_PATRIMONIO_ADEUDO.single_select();
        }

     #endregion

    }
}
