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
    public class blld__l_ALTA_COMODATO_INMUEBLE : bll__l_ALTA_COMODATO_INMUEBLE
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_ALTA_COMODATO_INMUEBLE.PageSize;
            set => datos_ALTA_COMODATO_INMUEBLE.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_ALTA_COMODATO_INMUEBLE.PageNumber;
            set => datos_ALTA_COMODATO_INMUEBLE.PageNumber = value;
        }
        public Int32 TotalPages => datos_ALTA_COMODATO_INMUEBLE.TotalPages;
        public Int32 TotalItems => datos_ALTA_COMODATO_INMUEBLE.TotalItems;
        private List<blld_ALTA_COMODATO_INMUEBLE> _ALTA_COMODATO_INMUEBLEs { get; set; }
        public List<blld_ALTA_COMODATO_INMUEBLE> ALTA_COMODATO_INMUEBLEs
        {
            get
            {
                if (_ALTA_COMODATO_INMUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_COMODATO_INMUEBLEs = new List<blld_ALTA_COMODATO_INMUEBLE>();
                    foreach (MODELDeclara_V2.ALTA_COMODATO_INMUEBLE o in base_ALTA_COMODATO_INMUEBLEs)
                    {
                        _ALTA_COMODATO_INMUEBLEs.Add(new blld_ALTA_COMODATO_INMUEBLE(o));
                    }
                }
                return _ALTA_COMODATO_INMUEBLEs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_ALTA_COMODATO_INMUEBLE() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_COMODATO_INMUEBLE.single_select();
        }

        #endregion

    }
}
