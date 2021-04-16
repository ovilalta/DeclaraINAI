using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public class blld__l_CAT_AMBITO_PUBLICO : bll__l_CAT_AMBITO_PUBLICO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_AMBITO_PUBLICO.PageSize;
            set => datos_CAT_AMBITO_PUBLICO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_AMBITO_PUBLICO.PageNumber;
            set => datos_CAT_AMBITO_PUBLICO.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_AMBITO_PUBLICO.TotalPages;
        public Int32 TotalItems => datos_CAT_AMBITO_PUBLICO.TotalItems;
        private List<blld_CAT_AMBITO_PUBLICO> _CAT_AMBITO_PUBLICOs { get; set; }
        public List<blld_CAT_AMBITO_PUBLICO> CAT_AMBITO_PUBLICOs
        {
            get
            {
                if (_CAT_AMBITO_PUBLICOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_AMBITO_PUBLICOs = new List<blld_CAT_AMBITO_PUBLICO>();
                    foreach (MODELDeclara_V2.CAT_AMBITO_PUBLICO o in base_CAT_AMBITO_PUBLICOs)
                    {
                        _CAT_AMBITO_PUBLICOs.Add(new blld_CAT_AMBITO_PUBLICO(o));
                    }
                }
                return _CAT_AMBITO_PUBLICOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_AMBITO_PUBLICO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_AMBITO_PUBLICO.single_select();
        }

        #endregion

    }
}
