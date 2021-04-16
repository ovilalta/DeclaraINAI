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
    public class blld__l_ALTA_INMUEBLE_COPROPIETARIO : bll__l_ALTA_INMUEBLE_COPROPIETARIO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.PageSize;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.PageNumber;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.PageNumber = value;
        }
        public Int32 TotalPages => datos_ALTA_INMUEBLE_COPROPIETARIO.TotalPages;
        public Int32 TotalItems => datos_ALTA_INMUEBLE_COPROPIETARIO.TotalItems;
        private List<blld_ALTA_INMUEBLE_COPROPIETARIO> _ALTA_INMUEBLE_COPROPIETARIOs { get; set; }
        public List<blld_ALTA_INMUEBLE_COPROPIETARIO> ALTA_INMUEBLE_COPROPIETARIOs
        {
            get
            {
                if (_ALTA_INMUEBLE_COPROPIETARIOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_INMUEBLE_COPROPIETARIOs = new List<blld_ALTA_INMUEBLE_COPROPIETARIO>();
                    foreach (MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO o in base_ALTA_INMUEBLE_COPROPIETARIOs)
                    {
                        _ALTA_INMUEBLE_COPROPIETARIOs.Add(new blld_ALTA_INMUEBLE_COPROPIETARIO(o));
                    }
                }
                return _ALTA_INMUEBLE_COPROPIETARIOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_ALTA_INMUEBLE_COPROPIETARIO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_INMUEBLE_COPROPIETARIO.single_select();
        }

        #endregion

    }
}
