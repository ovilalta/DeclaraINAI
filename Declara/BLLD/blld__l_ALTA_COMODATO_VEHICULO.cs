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
    public class blld__l_ALTA_COMODATO_VEHICULO : bll__l_ALTA_COMODATO_VEHICULO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_ALTA_COMODATO_VEHICULO.PageSize;
            set => datos_ALTA_COMODATO_VEHICULO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_ALTA_COMODATO_VEHICULO.PageNumber;
            set => datos_ALTA_COMODATO_VEHICULO.PageNumber = value;
        }
        public Int32 TotalPages => datos_ALTA_COMODATO_VEHICULO.TotalPages;
        public Int32 TotalItems => datos_ALTA_COMODATO_VEHICULO.TotalItems;
        private List<blld_ALTA_COMODATO_VEHICULO> _ALTA_COMODATO_VEHICULOs { get; set; }
        public List<blld_ALTA_COMODATO_VEHICULO> ALTA_COMODATO_VEHICULOs
        {
            get
            {
                if (_ALTA_COMODATO_VEHICULOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_COMODATO_VEHICULOs = new List<blld_ALTA_COMODATO_VEHICULO>();
                    foreach (MODELDeclara_V2.ALTA_COMODATO_VEHICULO o in base_ALTA_COMODATO_VEHICULOs)
                    {
                        _ALTA_COMODATO_VEHICULOs.Add(new blld_ALTA_COMODATO_VEHICULO(o));
                    }
                }
                return _ALTA_COMODATO_VEHICULOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_ALTA_COMODATO_VEHICULO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_COMODATO_VEHICULO.single_select();
        }

        #endregion

    }
}
