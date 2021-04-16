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
    public  class blld__l_DECLARACION_PERSONALES : bll__l_DECLARACION_PERSONALES
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_DECLARACION_PERSONALES.PageSize;
            set => datos_DECLARACION_PERSONALES.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_DECLARACION_PERSONALES.PageNumber;
            set => datos_DECLARACION_PERSONALES.PageNumber = value;
        }

        public Int32 TotalPages => datos_DECLARACION_PERSONALES.TotalPages;

        public Int32 TotalItems => datos_DECLARACION_PERSONALES.TotalItems;

        private List<blld_DECLARACION_PERSONALES> _DECLARACION_PERSONALESs { get; set; }
        public List<blld_DECLARACION_PERSONALES> DECLARACION_PERSONALESs
        {
            get
            {
                if (_DECLARACION_PERSONALESs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_PERSONALESs = new List<blld_DECLARACION_PERSONALES>();
                    foreach (MODELDeclara_V2.DECLARACION_PERSONALES o in base_DECLARACION_PERSONALESs)
                    {
                        _DECLARACION_PERSONALESs.Add(new blld_DECLARACION_PERSONALES(o));
                    }
                }
                return _DECLARACION_PERSONALESs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_DECLARACION_PERSONALES() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_PERSONALES.single_select();
        }

     #endregion

    }
}
