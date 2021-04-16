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
    public class blld__l_CAT_FORMA_ADQUISICION : bll__l_CAT_FORMA_ADQUISICION
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_FORMA_ADQUISICION.PageSize;
            set => datos_CAT_FORMA_ADQUISICION.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_FORMA_ADQUISICION.PageNumber;
            set => datos_CAT_FORMA_ADQUISICION.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_FORMA_ADQUISICION.TotalPages;
        public Int32 TotalItems => datos_CAT_FORMA_ADQUISICION.TotalItems;
        private List<blld_CAT_FORMA_ADQUISICION> _CAT_FORMA_ADQUISICIONs { get; set; }
        public List<blld_CAT_FORMA_ADQUISICION> CAT_FORMA_ADQUISICIONs
        {
            get
            {
                if (_CAT_FORMA_ADQUISICIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_FORMA_ADQUISICIONs = new List<blld_CAT_FORMA_ADQUISICION>();
                    foreach (MODELDeclara_V2.CAT_FORMA_ADQUISICION o in base_CAT_FORMA_ADQUISICIONs)
                    {
                        _CAT_FORMA_ADQUISICIONs.Add(new blld_CAT_FORMA_ADQUISICION(o));
                    }
                }
                return _CAT_FORMA_ADQUISICIONs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_FORMA_ADQUISICION() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_FORMA_ADQUISICION.single_select();
        }

        #endregion

    }
}
