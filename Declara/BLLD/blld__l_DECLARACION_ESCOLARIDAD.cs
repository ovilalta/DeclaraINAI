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
    public class blld__l_DECLARACION_ESCOLARIDAD : bll__l_DECLARACION_ESCOLARIDAD
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_DECLARACION_ESCOLARIDAD.PageSize;
            set => datos_DECLARACION_ESCOLARIDAD.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_DECLARACION_ESCOLARIDAD.PageNumber;
            set => datos_DECLARACION_ESCOLARIDAD.PageNumber = value;
        }
        public Int32 TotalPages => datos_DECLARACION_ESCOLARIDAD.TotalPages;
        public Int32 TotalItems => datos_DECLARACION_ESCOLARIDAD.TotalItems;
        private List<blld_DECLARACION_ESCOLARIDAD> _DECLARACION_ESCOLARIDADs { get; set; }
        public List<blld_DECLARACION_ESCOLARIDAD> DECLARACION_ESCOLARIDADs
        {
            get
            {
                if (_DECLARACION_ESCOLARIDADs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_ESCOLARIDADs = new List<blld_DECLARACION_ESCOLARIDAD>();
                    foreach (MODELDeclara_V2.DECLARACION_ESCOLARIDAD o in base_DECLARACION_ESCOLARIDADs)
                    {
                        _DECLARACION_ESCOLARIDADs.Add(new blld_DECLARACION_ESCOLARIDAD(o));
                    }
                }
                return _DECLARACION_ESCOLARIDADs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_DECLARACION_ESCOLARIDAD() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_ESCOLARIDAD.single_select();
        }

        #endregion

    }
}
