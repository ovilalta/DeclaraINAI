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
    public  class blld__l_H_PATRIMONIO_INVERSION : bll__l_H_PATRIMONIO_INVERSION
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_H_PATRIMONIO_INVERSION.PageSize;
            set => datos_H_PATRIMONIO_INVERSION.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_H_PATRIMONIO_INVERSION.PageNumber;
            set => datos_H_PATRIMONIO_INVERSION.PageNumber = value;
        }

        public Int32 TotalPages => datos_H_PATRIMONIO_INVERSION.TotalPages;

        public Int32 TotalItems => datos_H_PATRIMONIO_INVERSION.TotalItems;

        private List<blld_H_PATRIMONIO_INVERSION> _H_PATRIMONIO_INVERSIONs { get; set; }
        public List<blld_H_PATRIMONIO_INVERSION> H_PATRIMONIO_INVERSIONs
        {
            get
            {
                if (_H_PATRIMONIO_INVERSIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _H_PATRIMONIO_INVERSIONs = new List<blld_H_PATRIMONIO_INVERSION>();
                    foreach (MODELDeclara_V2.H_PATRIMONIO_INVERSION o in base_H_PATRIMONIO_INVERSIONs)
                    {
                        _H_PATRIMONIO_INVERSIONs.Add(new blld_H_PATRIMONIO_INVERSION(o));
                    }
                }
                return _H_PATRIMONIO_INVERSIONs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_H_PATRIMONIO_INVERSION() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_H_PATRIMONIO_INVERSION.single_select();
        }

     #endregion

    }
}
