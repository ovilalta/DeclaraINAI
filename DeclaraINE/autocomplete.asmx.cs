using Declara_V2.BLLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Declara_V2.MODELextended;

namespace DeclaraINE
{
    /// <summary>
    /// Summary description for autocomplete
    /// </summary>
    [WebService(Namespace = "http://declarainai-pdn.inai.mx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class autocomplete : System.Web.Services.WebService
    {

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] GetCompletionList(string prefixText, int count)
        {
                List<String> retorno = new List<string>();
            retorno.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("uno","1"));
            retorno.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("dos", "2"));
            retorno.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("tres", "3"));
            retorno.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("cuatro", "4"));

            return retorno.ToArray<String>();
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] CAT_PUESTO(string prefixText, int count)
        {
            List<String> retorno = new List<string>();
            blld__l_CAT_PUESTO o = new blld__l_CAT_PUESTO();
            o.V_PUESTO = new Declara_V2.StringFilter(prefixText, Declara_V2.StringFilter.FilterType.like);
            o.select();
            foreach (Declara_V2.MODELextended.CAT_PUESTO ots in o.lista_CAT_PUESTO)
            {
                retorno.Add(ots.VID_PUESTO);
            }
            o = new blld__l_CAT_PUESTO();
            o.VID_PUESTO = new Declara_V2.StringFilter(prefixText, Declara_V2.StringFilter.FilterType.like);
            o.select();
            foreach (Declara_V2.MODELextended.CAT_PUESTO ots in o.lista_CAT_PUESTO)
            {
                retorno.Add(ots.VID_PUESTO);
            }
            return retorno.ToArray<String>();
        }

 
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] CAT_PRIMER_NIVEL(string prefixText, int count)
        {
            List<String> retorno = new List<String>();
            blld__l_CAT_PRIMER_NIVEL o = new blld__l_CAT_PRIMER_NIVEL();
            o.VID_PRIMER_NIVEL = new Declara_V2.StringFilter(prefixText, Declara_V2.StringFilter.FilterType.like);
            o.select();
            foreach (Declara_V2.MODELextended.CAT_PRIMER_NIVEL ots in o.lista_CAT_PRIMER_NIVEL)
            {
                retorno.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(String.Concat(ots.VID_PRIMER_NIVEL + " - " + ots.V_PRIMER_NIVEL), ots.VID_PRIMER_NIVEL));
            }
            o = new blld__l_CAT_PRIMER_NIVEL();
            o.V_PRIMER_NIVEL = new Declara_V2.StringFilter(prefixText, Declara_V2.StringFilter.FilterType.like);
            o.select();
            foreach (Declara_V2.MODELextended.CAT_PRIMER_NIVEL ots in o.lista_CAT_PRIMER_NIVEL)
            {
                retorno.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(String.Concat(ots.VID_PRIMER_NIVEL + " - " + ots.V_PRIMER_NIVEL), ots.VID_PRIMER_NIVEL));
            }
            return retorno.ToArray<String>();
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] CAT_DENOMINACION(string prefixText, int count)
        {
            List<String> retorno = new List<string>();
            blld__l_CAT_DENOMINACION o = new blld__l_CAT_DENOMINACION();
            o.V_DENOMINACION = new Declara_V2.StringFilter(prefixText, Declara_V2.StringFilter.FilterType.like);
            o.select();
            foreach (Declara_V2.MODELextended.CAT_DENOMINACION ots in o.lista_CAT_DENOMINACION)
            {
                retorno.Add(ots.V_DENOMINACION);
            }
            return retorno.ToArray<String>();
        }
    }
}
