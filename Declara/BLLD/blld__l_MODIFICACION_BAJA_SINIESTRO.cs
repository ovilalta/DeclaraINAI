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
    public  class blld__l_MODIFICACION_BAJA_SINIESTRO : bll__l_MODIFICACION_BAJA_SINIESTRO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_BAJA_SINIESTRO.PageSize;
            set => datos_MODIFICACION_BAJA_SINIESTRO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_BAJA_SINIESTRO.PageNumber;
            set => datos_MODIFICACION_BAJA_SINIESTRO.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_BAJA_SINIESTRO.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_BAJA_SINIESTRO.TotalItems;

        private List<blld_MODIFICACION_BAJA_SINIESTRO> _MODIFICACION_BAJA_SINIESTROs { get; set; }
        public List<blld_MODIFICACION_BAJA_SINIESTRO> MODIFICACION_BAJA_SINIESTROs
        {
            get
            {
                if (_MODIFICACION_BAJA_SINIESTROs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_BAJA_SINIESTROs = new List<blld_MODIFICACION_BAJA_SINIESTRO>();
                    foreach (MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO o in base_MODIFICACION_BAJA_SINIESTROs)
                    {
                        _MODIFICACION_BAJA_SINIESTROs.Add(new blld_MODIFICACION_BAJA_SINIESTRO(o));
                    }
                }
                return _MODIFICACION_BAJA_SINIESTROs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_BAJA_SINIESTRO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_BAJA_SINIESTRO.single_select();
        }

     #endregion

    }
}
