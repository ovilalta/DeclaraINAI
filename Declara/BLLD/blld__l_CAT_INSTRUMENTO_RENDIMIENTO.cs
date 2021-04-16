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
    public class blld__l_CAT_INSTRUMENTO_RENDIMIENTO : bll__l_CAT_INSTRUMENTO_RENDIMIENTO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_INSTRUMENTO_RENDIMIENTO.PageSize;
            set => datos_CAT_INSTRUMENTO_RENDIMIENTO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_INSTRUMENTO_RENDIMIENTO.PageNumber;
            set => datos_CAT_INSTRUMENTO_RENDIMIENTO.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_INSTRUMENTO_RENDIMIENTO.TotalPages;
        public Int32 TotalItems => datos_CAT_INSTRUMENTO_RENDIMIENTO.TotalItems;
        private List<blld_CAT_INSTRUMENTO_RENDIMIENTO> _CAT_INSTRUMENTO_RENDIMIENTOs { get; set; }
        public List<blld_CAT_INSTRUMENTO_RENDIMIENTO> CAT_INSTRUMENTO_RENDIMIENTOs
        {
            get
            {
                if (_CAT_INSTRUMENTO_RENDIMIENTOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_INSTRUMENTO_RENDIMIENTOs = new List<blld_CAT_INSTRUMENTO_RENDIMIENTO>();
                    foreach (MODELDeclara_V2.CAT_INSTRUMENTO_RENDIMIENTO o in base_CAT_INSTRUMENTO_RENDIMIENTOs)
                    {
                        _CAT_INSTRUMENTO_RENDIMIENTOs.Add(new blld_CAT_INSTRUMENTO_RENDIMIENTO(o));
                    }
                }
                return _CAT_INSTRUMENTO_RENDIMIENTOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_INSTRUMENTO_RENDIMIENTO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_INSTRUMENTO_RENDIMIENTO.single_select();
        }

        #endregion

    }
}
