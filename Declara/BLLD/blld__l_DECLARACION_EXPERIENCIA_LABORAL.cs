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
    public class blld__l_DECLARACION_EXPERIENCIA_LABORAL : bll__l_DECLARACION_EXPERIENCIA_LABORAL
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.PageSize;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.PageNumber;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.PageNumber = value;
        }
        public Int32 TotalPages => datos_DECLARACION_EXPERIENCIA_LABORAL.TotalPages;
        public Int32 TotalItems => datos_DECLARACION_EXPERIENCIA_LABORAL.TotalItems;
        private List<blld_DECLARACION_EXPERIENCIA_LABORAL> _DECLARACION_EXPERIENCIA_LABORALs { get; set; }
        public List<blld_DECLARACION_EXPERIENCIA_LABORAL> DECLARACION_EXPERIENCIA_LABORALs
        {
            get
            {
                if (_DECLARACION_EXPERIENCIA_LABORALs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_EXPERIENCIA_LABORALs = new List<blld_DECLARACION_EXPERIENCIA_LABORAL>();
                    foreach (MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL o in base_DECLARACION_EXPERIENCIA_LABORALs)
                    {
                        _DECLARACION_EXPERIENCIA_LABORALs.Add(new blld_DECLARACION_EXPERIENCIA_LABORAL(o));
                    }
                }
                return _DECLARACION_EXPERIENCIA_LABORALs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_DECLARACION_EXPERIENCIA_LABORAL() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_EXPERIENCIA_LABORAL.single_select();
        }

        #endregion

    }
}
