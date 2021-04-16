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
    public class blld__l_ALTA_MUEBLE_COPROPIETARIO : bll__l_ALTA_MUEBLE_COPROPIETARIO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.PageSize;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.PageNumber;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.PageNumber = value;
        }
        public Int32 TotalPages => datos_ALTA_MUEBLE_COPROPIETARIO.TotalPages;
        public Int32 TotalItems => datos_ALTA_MUEBLE_COPROPIETARIO.TotalItems;
        private List<blld_ALTA_MUEBLE_COPROPIETARIO> _ALTA_MUEBLE_COPROPIETARIOs { get; set; }
        public List<blld_ALTA_MUEBLE_COPROPIETARIO> ALTA_MUEBLE_COPROPIETARIOs
        {
            get
            {
                if (_ALTA_MUEBLE_COPROPIETARIOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_MUEBLE_COPROPIETARIOs = new List<blld_ALTA_MUEBLE_COPROPIETARIO>();
                    foreach (MODELDeclara_V2.ALTA_MUEBLE_COPROPIETARIO o in base_ALTA_MUEBLE_COPROPIETARIOs)
                    {
                        _ALTA_MUEBLE_COPROPIETARIOs.Add(new blld_ALTA_MUEBLE_COPROPIETARIO(o));
                    }
                }
                return _ALTA_MUEBLE_COPROPIETARIOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_ALTA_MUEBLE_COPROPIETARIO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_MUEBLE_COPROPIETARIO.single_select();
        }

        #endregion

    }
}
