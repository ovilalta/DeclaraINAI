using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2.MODELextended
{
    public class fn_BalanzaEgresos : MODELDeclara_V2.fn_BalanzaEgresos_Result
    {
        public String V_DECLARANTE => (M_DECLARANTE == 0) ? String.Empty : String.Concat("$",M_DECLARANTE.Value.ToString("N0"));
        public String V_DEPENDIENTE => (M_DEPENDIENTE == 0) ? String.Empty : String.Concat("$",M_DEPENDIENTE.Value.ToString("N0"));
        public String V_TOTAL => (M_TOTAL == 0) ? String.Empty : String.Concat("$",M_TOTAL.Value.ToString("N0"));

        public String CssClassConcepto
        {
            get
            {
                switch (N_NIVEL)
                {
                    case 1:
                        return "balanzauno";
                    case 2:
                        return "balanzados";
                    case 3:
                        return "balanzatres";
                    default:
                        return "balanzaNumero";
                }
            }
        }

        public String CssClassCifra
        {
            get
            {
                switch (N_NIVEL)
                {
                    case 1:
                        return "balanzaunocifra";
                    case 2:
                        return "balanzadoscifra";
                    case 3:
                        return "balanzatrescifra";
                    default:
                        return "balanzaNumero";
                }
            }
        }
    }
}
