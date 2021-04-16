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
    public class blld__l_CAT_VALOR_ADQUISICION : bll__l_CAT_VALOR_ADQUISICION
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_VALOR_ADQUISICION.PageSize;
            set => datos_CAT_VALOR_ADQUISICION.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_VALOR_ADQUISICION.PageNumber;
            set => datos_CAT_VALOR_ADQUISICION.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_VALOR_ADQUISICION.TotalPages;
        public Int32 TotalItems => datos_CAT_VALOR_ADQUISICION.TotalItems;
        private List<blld_CAT_VALOR_ADQUISICION> _CAT_VALOR_ADQUISICIONs { get; set; }
        public List<blld_CAT_VALOR_ADQUISICION> CAT_VALOR_ADQUISICIONs
        {
            get
            {
                if (_CAT_VALOR_ADQUISICIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_VALOR_ADQUISICIONs = new List<blld_CAT_VALOR_ADQUISICION>();
                    foreach (MODELDeclara_V2.CAT_VALOR_ADQUISICION o in base_CAT_VALOR_ADQUISICIONs)
                    {
                        _CAT_VALOR_ADQUISICIONs.Add(new blld_CAT_VALOR_ADQUISICION(o));
                    }
                }
                return _CAT_VALOR_ADQUISICIONs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_VALOR_ADQUISICION() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_VALOR_ADQUISICION.single_select();
        }

        #endregion

    }
}
