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
    public class blld__l_CAT_BIEN_ENAJENADO : bll__l_CAT_BIEN_ENAJENADO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_BIEN_ENAJENADO.PageSize;
            set => datos_CAT_BIEN_ENAJENADO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_BIEN_ENAJENADO.PageNumber;
            set => datos_CAT_BIEN_ENAJENADO.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_BIEN_ENAJENADO.TotalPages;
        public Int32 TotalItems => datos_CAT_BIEN_ENAJENADO.TotalItems;
        private List<blld_CAT_BIEN_ENAJENADO> _CAT_BIEN_ENAJENADOs { get; set; }
        public List<blld_CAT_BIEN_ENAJENADO> CAT_BIEN_ENAJENADOs
        {
            get
            {
                if (_CAT_BIEN_ENAJENADOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_BIEN_ENAJENADOs = new List<blld_CAT_BIEN_ENAJENADO>();
                    foreach (MODELDeclara_V2.CAT_BIEN_ENAJENADO o in base_CAT_BIEN_ENAJENADOs)
                    {
                        _CAT_BIEN_ENAJENADOs.Add(new blld_CAT_BIEN_ENAJENADO(o));
                    }
                }
                return _CAT_BIEN_ENAJENADOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_BIEN_ENAJENADO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_BIEN_ENAJENADO.single_select();
        }

        #endregion

    }
}
