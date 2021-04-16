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
    public  class blld__l_H_PATRIMONIO_TITULAR : bll__l_H_PATRIMONIO_TITULAR
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_H_PATRIMONIO_TITULAR.PageSize;
            set => datos_H_PATRIMONIO_TITULAR.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_H_PATRIMONIO_TITULAR.PageNumber;
            set => datos_H_PATRIMONIO_TITULAR.PageNumber = value;
        }

        public Int32 TotalPages => datos_H_PATRIMONIO_TITULAR.TotalPages;

        public Int32 TotalItems => datos_H_PATRIMONIO_TITULAR.TotalItems;

        private List<blld_H_PATRIMONIO_TITULAR> _H_PATRIMONIO_TITULARs { get; set; }
        public List<blld_H_PATRIMONIO_TITULAR> H_PATRIMONIO_TITULARs
        {
            get
            {
                if (_H_PATRIMONIO_TITULARs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _H_PATRIMONIO_TITULARs = new List<blld_H_PATRIMONIO_TITULAR>();
                    foreach (MODELDeclara_V2.H_PATRIMONIO_TITULAR o in base_H_PATRIMONIO_TITULARs)
                    {
                        _H_PATRIMONIO_TITULARs.Add(new blld_H_PATRIMONIO_TITULAR(o));
                    }
                }
                return _H_PATRIMONIO_TITULARs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_H_PATRIMONIO_TITULAR() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_H_PATRIMONIO_TITULAR.single_select();
        }

     #endregion

    }
}
