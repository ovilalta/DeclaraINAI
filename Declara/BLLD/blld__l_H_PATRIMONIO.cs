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
    public  class blld__l_H_PATRIMONIO : bll__l_H_PATRIMONIO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_H_PATRIMONIO.PageSize;
            set => datos_H_PATRIMONIO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_H_PATRIMONIO.PageNumber;
            set => datos_H_PATRIMONIO.PageNumber = value;
        }

        public Int32 TotalPages => datos_H_PATRIMONIO.TotalPages;

        public Int32 TotalItems => datos_H_PATRIMONIO.TotalItems;

        private List<blld_H_PATRIMONIO> _H_PATRIMONIOs { get; set; }
        public List<blld_H_PATRIMONIO> H_PATRIMONIOs
        {
            get
            {
                if (_H_PATRIMONIOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _H_PATRIMONIOs = new List<blld_H_PATRIMONIO>();
                    foreach (MODELDeclara_V2.H_PATRIMONIO o in base_H_PATRIMONIOs)
                    {
                        _H_PATRIMONIOs.Add(new blld_H_PATRIMONIO(o));
                    }
                }
                return _H_PATRIMONIOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_H_PATRIMONIO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_H_PATRIMONIO.single_select();
        }

     #endregion

    }
}
