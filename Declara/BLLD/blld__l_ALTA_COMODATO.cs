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
    public class blld__l_ALTA_COMODATO : bll__l_ALTA_COMODATO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_ALTA_COMODATO.PageSize;
            set => datos_ALTA_COMODATO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_ALTA_COMODATO.PageNumber;
            set => datos_ALTA_COMODATO.PageNumber = value;
        }
        public Int32 TotalPages => datos_ALTA_COMODATO.TotalPages;
        public Int32 TotalItems => datos_ALTA_COMODATO.TotalItems;
        private List<blld_ALTA_COMODATO> _ALTA_COMODATOs { get; set; }
        public List<blld_ALTA_COMODATO> ALTA_COMODATOs
        {
            get
            {
                if (_ALTA_COMODATOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_COMODATOs = new List<blld_ALTA_COMODATO>();
                    foreach (MODELDeclara_V2.ALTA_COMODATO o in base_ALTA_COMODATOs)
                    {
                        _ALTA_COMODATOs.Add(new blld_ALTA_COMODATO(o));
                    }
                }
                return _ALTA_COMODATOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_ALTA_COMODATO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_COMODATO.single_select();
        }

        #endregion

    }
}
